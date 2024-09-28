using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ID;
namespace gracosmod123.items.forumsman
{
    public class Darkstabby : ModProjectile
    {
        public float movementFactor
        {
            get { return projectile.ai[0]; }
            set { projectile.ai[0] = value; }
        }
        private bool spawned;
        private float spawning;
        int shootDelay = 0;

        public override void SetDefaults()
        {
            projectile.width = 44;
            projectile.height = 44;
            projectile.aiStyle = 19;
            projectile.friendly = true;
            projectile.penetrate = -1;
            projectile.tileCollide = false;
            projectile.scale = 1.3f;
            projectile.hide = true;
            projectile.ownerHitCheck = true;
            projectile.melee = true;
            projectile.alpha = 0;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("corrupt Stabber");
        }

        public override void AI()
        {
            Vector2 position = projectile.Center;

            Player owner = null;
            if (projectile.owner != -1)
            {
                owner = Main.player[projectile.owner];
            }
            else if (projectile.owner == 255)
            {
                owner = Main.LocalPlayer;
            }
            var player = owner;
            Player projOwner = player;
            Vector2 ownerMountedCenter = projOwner.RotatedRelativePoint(projOwner.MountedCenter, true);
            projectile.direction = projOwner.direction;
            projOwner.heldProj = projectile.whoAmI;
            projOwner.itemTime = projOwner.itemAnimation;
            projectile.position.X = ownerMountedCenter.X - (float)(projectile.width / 2);
            projectile.position.Y = ownerMountedCenter.Y - (float)(projectile.height / 2);
            if (!projOwner.frozen)
            {
                if (movementFactor == 0f)
                {
                    movementFactor = 7f;//3
                    projectile.netUpdate = true;
                }
                if (projOwner.itemAnimation < projOwner.itemAnimationMax / 3)
                {
                    movementFactor -= 2.4f;
                }
                else
                {
                    movementFactor += 2.1f;
                }
            }
            projectile.position += projectile.velocity * movementFactor;
            if (projOwner.itemAnimation == 0)
            {
                projectile.Kill();
            }
            projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + MathHelper.ToRadians(135f);
            if (projectile.spriteDirection == -1)
            {
                projectile.rotation -= MathHelper.ToRadians(90f);
            }

            ++this.spawning;
            if ((double)this.spawning >= 280.0) { this.spawned = true; }
            if (!this.spawned)
            {

            }

        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            //target.AddBuff(BuffID.OnFire, 180);
            /*for (int i = 0; i < 50; i++)
            {
            }*/
            float distance = 160f;
            float k = 1.26f;
            for (int count = 0; count < 10; count++)
            {
                Vector2 spawn = projectile.Center + distance * ((float)count * k).ToRotationVector2();
                Projectile.NewProjectile((int)spawn.X, (int)spawn.Y, 0.0f, 0.0f, ProjectileID.TinyEater, projectile.damage, projectile.knockBack, 0, (float)projectile.whoAmI, (float)count);
            }
        }
    }
}



