using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace gracosmod123.NPCs.ocean.oceanitems.summonocean
{
    public class SwordMinionStaff : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("The Long-Trident Staff");
            Tooltip.SetDefault("Who needs a horde of minions when you have a giant Trident?");
        }

        public override void SetDefaults()
        {
            item.summon = true;
            Item.mana = 4;
            Item.DamageType = 300;
            Item.rare = 7;
            Item.value = Item.sellPrice(0, 10, 0, 0);
            Item.knockBack = 2f;
            item.useStyle = 5;
            Item.useAnimation = Item.useTime = 8;
            Item.shootSpeed = 24f;
            Item.width = Item.height = 44;
            item.useStyle = ItemUseStyleID.SwingThrow;
            Item.shoot = ModContent.ProjectileType("SwordMinion");
            Item.UseSound = SoundID.Item44;
            Item.noMelee = true;
            Item.autoReuse = true;
            Item.buffType = ModContent.BuffType("SwordMinionBuff");
            Item.buffTime = 3600;
        }
        public delegate bool SpecialCondition(NPC possibleTarget);
        public static Vector2 PolarVector(float radius, float theta)
        {
            return new Vector2((float)Math.Cos(theta), (float)Math.Sin(theta)) * radius;
        }
                
        public static bool ClosestNPC(ref NPC target, float maxDistance, Vector2 position, bool ignoreTiles = false, int overrideTarget = -1, SpecialCondition specialCondition = null)
        {
            //very advance users can use a delegate to insert special condition into the function like only targetting enemies not currently having local iFrames, but if a special condition isn't added then just return it true
            if (specialCondition == null)
            {
                specialCondition = delegate (NPC possibleTarget) { return true; };
            }
            bool foundTarget = false;
            //If you want to prioritse a certain target this is where it's processed, mostly used by minions that haave a target priority
            if (overrideTarget != -1)
            {
                if ((Main.NPC[overrideTarget].Center - position).Length() < maxDistance)
                {
                    target = Main.NPC[overrideTarget];
                    return true;
                }
            }
            //this is the meat of the targetting logic, it loops through every NPC to check if it is valid the miniomum distance and target selected are updated so that the closest valid NPC is selected
            for (int k = 0; k < Main.NPC.Length; k++)
            {
                NPC possibleTarget = Main.NPC[k];
                float distance = (possibleTarget.Center - position).Length();
                if (distance < maxDistance && possibleTarget.active && possibleTarget.chaseable && !possibleTarget.dontTakeDamage && !possibleTarget.friendly && possibleTarget.lifeMax > 5 && !possibleTarget.immortal && (Collision.CanHit(position, 0, 0, possibleTarget.Center, 0, 0) || ignoreTiles) && specialCondition(possibleTarget))
                {
                    target = Main.NPC[k];
                    foundTarget = true;

                    maxDistance = (target.Center - position).Length();
                }
            }
            return foundTarget;
        }
        public static float SlowRotation(float currentRotation, float targetAngle, float speed)
        {
            int f = 1; //this is used to switch rotation direction
            float actDirection = new Vector2((float)Math.Cos(currentRotation), (float)Math.Sin(currentRotation)).ToRotation();
            targetAngle = new Vector2((float)Math.Cos(targetAngle), (float)Math.Sin(targetAngle)).ToRotation();

            //this makes f 1 or -1 to rotate the shorter distance
            if (Math.Abs(actDirection - targetAngle) > Math.PI)
            {
                f = -1;
            }
            else
            {
                f = 1;
            }

            if (actDirection <= targetAngle + MathHelper.ToRadians(speed * 2) && actDirection >= targetAngle - MathHelper.ToRadians(speed * 2))
            {
                actDirection = targetAngle;
            }
            else if (actDirection <= targetAngle)
            {
                actDirection += MathHelper.ToRadians(speed) * f;
            }
            else if (actDirection >= targetAngle)
            {
                actDirection -= MathHelper.ToRadians(speed) * f;
            }
            actDirection = new Vector2((float)Math.Cos(actDirection), (float)Math.Sin(actDirection)).ToRotation();

            return actDirection;
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            float minionCount = 0;
            foreach (Projectile projectile in Main.projectile)
            {
                if (projectile.active && projectile.owner == item.owner)
                {
                    minionCount += projectile.minionSlots;
                }
            }
            foreach (Projectile projectile in Main.projectile)
            {
                if (projectile.active && projectile.type == type && projectile.owner == item.owner)
                {
                    if (player.maxMinions - minionCount >= 1)
                    {
                        projectile.minionSlots++;
                    }
                    return false;
                }
            }
            player.AddBuff(ModContent.BuffType("SwordMinionBuff"), 3600); //Idk why but the Item.buffType didn't work for this
            position = Main.MouseWorld;
            return true;
        }

        public override bool AltFunctionUse(Player player)
        {
            return true;
        }

        public override bool UseItem(Player player)
        {
            if (player.altFunctionUse == 2)
            {
                player.MinionNPCTargetAim();
            }
            return base.UseItem(player);
        }
    }

    public class SwordMinion : ModProjectile
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Trident");
            ProjectileID.Sets.MinionTargettingFeature[projectile.type] = true; //This is necessary for right-click targeting
        }

        public override void SetDefaults()
        {
            projectile.minion = true;
            projectile.minionSlots = 1;
            projectile.width = projectile.height = 10;
            Projectile.Penetrate = -1;
            projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = 15;
            projectile.tileCollide = false;
            projectile.aiStyle = -1;
            projectile.hostile = false;
            projectile.friendly = true;
            projectile.ignoreWater = true;
            projectile.timeLeft = 2;
        }

        private float yetAnotherTrigCounter;
        private NPC target;
        private bool returningToPlayer = false;
        private float turnOffset = (float)Math.PI / 4;
        private int counter = 0;
        private float bladeLength = 10;

        public override void AI()
        {
            bool spinAttack = false;
            bladeLength = 24 + 16 + 14 * projectile.minionSlots;
            counter++;
            if (counter % projectile.localNPCHitCooldown == 0)
            {
                turnOffset *= -1;
            }
            yetAnotherTrigCounter += (float)Math.PI / 120;
            Player player = Main.player[projectile.owner];
            if (player.GetModPlayer<MinionManager>().SwordMinion)
            {
                projectile.timeLeft = 2;
            }
            if ((player.Center - projectile.Center).Length() > 1000)
            {
                returningToPlayer = true;
            }
            if ((player.Center - projectile.Center).Length() < 300)
            {
                returningToPlayer = false;
            }
            Vector2 flyTo = player.Center + new Vector2(-50 * player.direction, -50 - 14 * projectile.minionSlots) + Vector2.UnitY * (float)Math.Sin(yetAnotherTrigCounter) * 20;
            float turnTo = (float)Math.PI / 2;
            float speed = 10f;
            if (returningToPlayer)
            {
                speed = (player.Center - projectile.Center).Length() / 30f;
            }
            if (SwordMinionStaff.ClosestNPC(ref target, 800, projectile.Center, false, player.MinionAttackTargetNPC) && !returningToPlayer)
            {
                Vector2 difference2 = projectile.Center - target.Center;
                flyTo = target.Center + SwordMinionStaff.PolarVector(bladeLength / 2, difference2.ToRotation());
                turnTo = (target.Center - projectile.Center).ToRotation();
                int nerabyEnemies = 0;
                foreach (NPC NPC in Main.NPC)
                {
                    if (NPC.active && NPC.chaseable && !NPC.dontTakeDamage && !NPC.friendly && NPC.LifeMax > 5 && !NPC.immortal && (NPC.Center - projectile.Center).Length() < bladeLength)
                    {
                        nerabyEnemies++;
                    }
                }
                if (nerabyEnemies > 2)
                {
                    spinAttack = true;
                }
                if (difference2.Length() < bladeLength)
                {
                    turnTo += turnOffset;
                }
            }
            Vector2 difference = flyTo - projectile.Center;
            if (difference.Length() < speed)
            {
                projectile.Center = flyTo;
                projectile.velocity = Vector2.Zero;
            }
            else
            {
                projectile.velocity = difference.SafeNormalize(Vector2.UnitY) * speed;
            }
            if (spinAttack)
            {
                projectile.rotation += (float)Math.PI / 15;
            }
            else
            {
                projectile.rotation = SwordMinionStaff.SlowRotation(projectile.rotation, turnTo, 6);
            }
        }

        public override bool? Colliding(Rectangle projHitbox, Rectangle targetHitbox)
        {
            float point = 0f;
            return Collision.CheckAABBvLineCollision(targetHitbox.TopLeft(), targetHitbox.Size(), projectile.Center, projectile.Center + SwordMinionStaff.PolarVector(bladeLength, projectile.rotation), 14f, ref point) || Collision.CheckAABBvAABBCollision(targetHitbox.TopLeft(), targetHitbox.Size(), projHitbox.TopLeft(), projHitbox.Size());
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            projectile.localNPCImmunity[target.whoAmI] = projectile.localNPCHitCooldown;
            target.immune[projectile.owner] = 0;
        }

        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            Texture2D texture = Main.projectileTexture[projectile.type];
            spriteBatch.Draw(texture, projectile.Center - Main.screenPosition,
                       new Rectangle(0, 0, 31, 21), lightColor, projectile.rotation,
                       new Vector2(9f, 11f), projectile.scale, SpriteEffects.None, 0f);
            for (int b = 0; b < projectile.minionSlots; b++)
            {
                spriteBatch.Draw(texture, projectile.Center - Main.screenPosition + SwordMinionStaff.PolarVector(22 + b * 14, projectile.rotation),
                       new Rectangle(34, 0, 14, 21), lightColor, projectile.rotation,
                       new Vector2(0, 11f), projectile.scale, SpriteEffects.None, 0f);
            }
            spriteBatch.Draw(texture, projectile.Center - Main.screenPosition + SwordMinionStaff.PolarVector(22 + projectile.minionSlots * 14, projectile.rotation),
                       new Rectangle(50, 0, 16, 21), lightColor, projectile.rotation,
                       new Vector2(0, 11f), projectile.scale, SpriteEffects.None, 0f);
            return false;
        }

        public override void ModifyHitNPC(NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
        {
            damage = (int)projectile.minionSlots * damage;
        }
    }
}