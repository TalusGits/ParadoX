using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace gracosmod123.NPCs.ant
{
    public class mechsky : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Sky Knives");
            Tooltip.SetDefault("the elder bees shall throw these!");
        }

        public override void SetDefaults()
        {
            Item.DamageType = 13;
            item.melee = true;
            Item.knockBack = 1;
            Item.value = 50000;
            Item.rare = 3;
            Item.width = 14;
            Item.height = 34;
            item.useStyle = 1;
            Item.shootSpeed = 12f;
            Item.useTime = 4;
            Item.useAnimation = 12;
            Item.shoot = ModContent.ProjectileType("CaeliteRainKnifeP");
            //item.noUseGraphic = true;
            Item.noMelee = true;
            Item.autoReuse = true;
        }



        public int shotCounter = 2;

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            position = new Vector2(Main.MouseWorld.X + Main.rand.Next(-100, 100), position.Y - 600);
            float trueSpeed = new Vector2(speedX, speedY).Length();
            int shift = Main.rand.Next(-100, 100);
            speedX = (float)Math.Cos((new Vector2(Main.MouseWorld.X + shift, Main.MouseWorld.Y) - position).ToRotation()) * trueSpeed;
            speedY = (float)Math.Sin((new Vector2(Main.MouseWorld.X + shift, Main.MouseWorld.Y) - position).ToRotation()) * trueSpeed;
            shotCounter++;
            return true;
        }

        public class CaeliteRainKnifeP : ModProjectile
        {
            public override void SetStaticDefaults()
            {
                DisplayName.SetDefault("Caelite Rain Knife");
            }

            public override void SetDefaults()
            {
                projectile.aiStyle = 1;
                //aiType = ProjectileID.Bullet;
                projectile.width = 18;
                projectile.height = 18;
                projectile.friendly = true;
                Projectile.Penetrate = -1;
                projectile.melee = true;
                projectile.light = 30.00f; // projectile light still a lot
                projectile.tileCollide = false;

                projectile.usesLocalNPCImmunity = true;
            }

            private bool runOnce = true;
            private float outOfPhaseHeight;

            public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
            {
                if (Main.rand.Next(10) == 0)
                {
                    target.AddBuff(ModContent.BuffType("PowerDown"), 120);//poisnedprime
                }
                projectile.localNPCImmunity[target.whoAmI] = -1;
                target.immune[projectile.owner] = 0;
            }

            public override void AI()
            {
                if (Main.rand.Next(10) == 0)
                {
                    //Dust dust = Dust.NewDustPerfect(projectile.Center, ModContent.DustType("CaeliteDust"), Vector2.Zero);
                    //dust.frame.Y = 0;
                }
                if (runOnce)
                {
                    outOfPhaseHeight = Main.MouseWorld.Y;
                    runOnce = false;
                }

                if (projectile.Center.Y > outOfPhaseHeight)
                {
                    projectile.tileCollide = true;
                }
                //Main.NewText(outOfPhaseHeight);
            }

            public override void Kill(int timeLeft)
            {
            }

        }
    }
}