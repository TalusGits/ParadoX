using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace gracosmod123.items.forumsman
{
    public class MarbleArrow : ModProjectile
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

            projectile.penetrate = 40;
            projectile.timeLeft = 600;

            projectile.ignoreWater = true;
            projectile.tileCollide = true;

            projectile.extraUpdates = 1;
            projectile.light = 0.05f; // projectile light still a lot
            //            aiType = ProjectileID.Arrow;
        }

        /*public override void Kill(int timeLeft)
        {
            Main.PlaySound(SoundID.Item10, projectile.position);
            Projectile.NewProjectile(projectile.position, new Vector2(projectile.velocity.X, -projectile.velocity.Y), ProjectileID.SandBlock, projectile.damage / 2, projectile.knockBack / 2f);
        }*/
    }
}//
