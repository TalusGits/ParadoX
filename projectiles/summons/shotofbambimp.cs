/*using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;
using System;
using System.IO;
using Microsoft.Xna.Framework.Graphics;

namespace gracosmod123.projectiles.summons
{
    public class shotofbambimp : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.Homing[projectile.type] = true;
            ProjectileID.Sets.MinionShot[projectile.type] = true;
        }

        public override void SetDefaults()
        {
            projectile.width = 16;
            projectile.height = 16;
            projectile.alpha = 255;
            projectile.penetrate = 1;
            projectile.friendly = true;
            projectile.ignoreWater = true;
        }

        public override void AI()
        {
            if (projectile.localAI[0] == 0f)
            {
                Main.PlaySound(SoundID.Item20, projectile.position);
                projectile.localAI[0] = 1f;
            }
            int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 66, 0f, 0f, 100, new Color(44, 164, 255), 1.5f);
            Main.dust[dust].velocity *= 0.1f;
            if (projectile.velocity == Vector2.Zero)
            {
                Main.dust[dust].velocity.Y -= 1f;
                Main.dust[dust].scale = 1.2f;
            }
            else
            {
                Main.dust[dust].velocity += projectile.velocity * 0.2f;
            }
            Main.dust[dust].position.X = projectile.Center.X + 4f + (float)Main.rand.Next(-2, 3);
            Main.dust[dust].position.Y = projectile.Center.Y + (float)Main.rand.Next(-2, 3);
            Main.dust[dust].noGravity = true;
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            projectile.penetrate = -1;
            projectile.maxPenetrate = -1;
            projectile.tileCollide = false;
            projectile.position += projectile.velocity;
            projectile.velocity = Vector2.Zero;
            projectile.timeLeft = 180;
            return false;
        }
    }
}*/
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System;
using System.IO;
using Microsoft.Xna.Framework.Graphics;

namespace gracosmod123.projectiles.summons
{
    public class shotofbambimp : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("bamboo ball");
        }

        public override void SetDefaults()
        {
            projectile.arrow = true;
            projectile.width = 34;
            projectile.height = 32;
            projectile.aiStyle = 14;
            projectile.ranged = true;
            projectile.CloneDefaults(ProjectileID.BoulderStaffOfEarth);
            projectile.friendly = true;
            projectile.light = 1.00f; // projectile light still a lot
            projectile.rotation = projectile.velocity.X * 1.05f;//0.05f

        }
        public override void AI()
        {
            //this is projectile dust
            int DustID2 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y + 2f), projectile.width + 2, projectile.height + 2, mod.DustType("ret2"), projectile.velocity.X * 0.2f, projectile.velocity.Y * 0.2f, 20, default(Color), 2.9f);
            Main.dust[DustID2].noGravity = true;
            //this make that the projectile faces the right way 
            projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;
            projectile.localAI[0] += 1f;
            projectile.alpha = (int)projectile.localAI[0] * 2;

            if (projectile.localAI[0] > 250f) //projectile time left before disappears 190
            {
                projectile.Kill();
            }

        }
        /*public override void Behavior()
        {

        }*/
        // Additional hooks/methods here.
    }
}