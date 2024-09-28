using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ModLoader;

namespace gracosmod123.NPCs.ocean
{
    public class TrueEtherialPulse : ModProjectile
    {
        public bool bitherial = true;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("shell");
        }

        public override void SetDefaults()
        {
            bitherial = true;
            projectile.width = 22;
            projectile.height = 22;
            //projectile.alpha = 255;
            projectile.timeLeft = 160;
            projectile.friendly = false;
            projectile.hostile = true;
            projectile.ignoreWater = true;
            projectile.tileCollide = false;
        }

        public override void AI()
        {
            bitherial = true;
            projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f / 2;
        }
        public override Color? GetAlpha(Color drawColor)
        {
            int b = 225;
            int b2 = 125;
            int b3 = 155;
            if (drawColor.R != (byte)b)
            {
                drawColor.R = (byte)b;
            }
            if (drawColor.G < (byte)b2)
            {
                drawColor.G = (byte)b2;
            }
            if (drawColor.B < (byte)b3)
            {
                drawColor.B = (byte)b3;
            }
            return drawColor;
        }
    }
}