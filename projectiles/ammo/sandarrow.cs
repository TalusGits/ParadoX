using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace gracosmod123.projectiles.ammo
{
    public class sandarrow : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.TrailCacheLength[projectile.type] = 5;
            ProjectileID.Sets.TrailingMode[projectile.type] = 0;
        }
        public override void SetDefaults()
        {
            projectile.Size = new Vector2(8);
            projectile.aiStyle = 1;

            projectile.friendly = true;
            projectile.ranged = true;

            Projectile.Penetrate = 40;
            projectile.timeLeft = 600;

            projectile.ignoreWater = true;
            projectile.tileCollide = true;

            projectile.extraUpdates = 1;/////19
            projectile.light = 1.00f; // projectile light still a lot
            //            aiType = ProjectileID.Arrow;
        }
        public override void Kill(int timeLeft)
        {
            SoundEngine.PlaySound(0, (int)projectile.position.X, (int)projectile.position.Y, 0);
			for (int i = 0; i < 25; i++)
			{
				Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 19, projectile.oldVelocity.X * 0.2f, projectile.oldVelocity.Y * 0.2f);
			}
        }
        /*public override void Kill(int timeLeft)
        {
            SoundEngine.PlaySound(SoundID.Item10, projectile.position);
            Projectile.NewProjectileDirect(projectile.position, new Vector2(projectile.velocity.X, -projectile.velocity.Y), ProjectileID.SandBlock, projectile.damage / 2, projectile.knockBack / 2f);
        }*/
    }
}//
