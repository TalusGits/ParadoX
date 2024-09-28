using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System;
using System.IO;
using Microsoft.Xna.Framework.Graphics;

namespace gracosmod123.projectiles
{
    public class bamboodiscus : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("bright bamboo");
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
            projectile.light = 20.00f; // projectile light still a lot
            projectile.rotation = projectile.velocity.X * 1.05f;//0.05f

        }
        public override void AI()
        {
            //this is projectile dust
            int DustID2 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y + 2f), projectile.width + 2, projectile.height + 2, ModContent.DustType("ret2"), projectile.velocity.X * 0.2f, projectile.velocity.Y * 0.2f, 20, default(Color), 2.9f);
            Main.dust[DustID2].noGravity = true;
            //this make that the projectile faces the right way 
            projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;
            projectile.localAI[0] += 1f;
            projectile.alpha = (int)projectile.localAI[0] * 2;

            if (projectile.localAI[0] > 190f) //projectile time left before disappears 
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