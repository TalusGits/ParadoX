using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace gracosmod123.NPCs.ocean.oceanitems
{
    public class oceanshotspin : ModProjectile
    {
        int shootDelay = 0;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("ZING");
        }
        public override void SetDefaults()
        {
            shootDelay = 0;
            projectile.width = 40;
            projectile.height = 40;
            projectile.friendly = true;
            Projectile.Penetrate = -1;                       //this is the projectile penetration
            Main.projFrames[projectile.type] = 1;           //this is projectile frames
            projectile.hostile = false;
            projectile.magic = true;                        //this make the projectile do magic damage
            projectile.tileCollide = false;                 //this make that the projectile does not go thru walls
            projectile.ignoreWater = true;
            projectile.light = 2.00f;

        }
        public override void AI()
        {
            shootDelay++;
            if (shootDelay >= 40 /** 60*/)
            {
                for (int i = 0; i < 20; i++)
                {
                    if (Main.netMode != 1)
                        Projectile.NewProjectileDirect(projectile.Center.X, projectile.Center.Y, (float)Math.Cos(Math.PI / 4 * i) * 12, (float)Math.Sin(Math.PI / 4 * i) * 12, ModContent.ProjectileType<starfish2>(), (int)(80), 3, Main.myPlayer);
                }
                shootDelay = 0;
            }

        }
    }
}