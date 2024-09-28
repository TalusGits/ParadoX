using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ID;

namespace gracosmod123.items.botany.copper
{
    public class copperwave1 : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("copper wave first"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
        }

        public override void SetDefaults()
        {
            projectile.width = 22;
            projectile.height = 22;
            //projectile.aiStyle = 684;
            projectile.ranged = true;
            //aiType = ProjectileID.SwordBeam;
            projectile.CloneDefaults(ProjectileID.FrostWave);//ProjectileID.FrostWave
            projectile.friendly = true;
            projectile.hostile = false;
            projectile.tileCollide = true;

        }
        public override void AI()
        {
            for (int k = 0; k < 2; k++)
            {
                int dust = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, mod.DustType("Copperdust"), projectile.velocity.X * 0.2f, projectile.velocity.Y * 0.2f, 100);
                Main.dust[dust].noGravity = true;
                Main.dust[dust].velocity.X += 0.6f * projectile.spriteDirection;
            }
        }

        public override void Kill(int timeLeft)
        {
            for (int k = 0; k < 15; k++)
            {
                int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, mod.DustType("Copperdust"), (float)Main.rand.Next(-4, 4), (float)Main.rand.Next(-4, 4), 0);
                Main.dust[dust].noGravity = true;
            }
        }
    }
}
