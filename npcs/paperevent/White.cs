using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace gracosmod123.NPCs.paperevent
{
    public class White : ModContent.DustType
    {
        public override void OnSpawn(Dust dust)
        {
            dust.color = new Color(255, 255, 255);
            dust.alpha = 1;
            dust.scale = 1.1f;
            dust.velocity *= 0.6f;
            dust.noGravity = true;
            dust.noLight = false;
        }

        public override bool Update(Dust dust)
        {
            dust.rotation += dust.velocity.X / 3f;
            dust.position += dust.velocity;
            int oldAlpha = dust.alpha;
            dust.alpha = (int)(dust.alpha * 1.2);
            if (dust.alpha == oldAlpha)
            {
                dust.alpha++;
            }
            if (dust.alpha >= 255)
            {
                dust.alpha = 255;
                dust.active = false;
            }
            return false;
        }
    }
}