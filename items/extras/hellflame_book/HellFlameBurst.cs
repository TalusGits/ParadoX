using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using System.Diagnostics;

namespace gracosmod123.items.extras.hellflame_book
{
    public class HellFlameBurst : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            Main.projFrames[projectile.type] = 16;
        }
        public override void SetDefaults()
        {
            projectile.width = 75;
            projectile.height = 156;
            projectile.alpha = 0;
            projectile.friendly = true;
            projectile.tileCollide = false;
            projectile.ignoreWater = true;
            projectile.magic = true;
            projectile.aiStyle = 1;
            Projectile.Penetrate = 3;
            projectile.scale = 1.5f;
            projectile.timeLeft = 32;
            projectile.light = 2.00f;
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            switch ((int)projectile.ai[0])
            {
                case 1:
                    target.AddBuff(ModContent.BuffType.OnFire, 300); // 5 second debuff
                    break;
                case 2:
                    target.AddBuff(ModContent.BuffType.OnFire, 100); // 5 second debuff
                    break;
                case 3:
                    target.AddBuff(ModContent.BuffType.OnFire, 200); // 5 second debuff
                    break;
            }
            base.OnHitNPC(target, damage, knockback, crit);
        }
        public override void AI()
        {
            if (++projectile.frameCounter >= 2)
            {
                projectile.frameCounter = 0;
                if (++projectile.frame >= 16)
                {
                    projectile.frame = 0;
                    projectile.velocity.Y = projectile.velocity.Y + -0.1f; // 0.1f for arrow gravity, 0.4f for knife gravity
                    if (projectile.velocity.Y > 16f) // This check implements "terminal velocity". We don't want the projectile to keep getting faster and faster. Past 16f this projectile will travel through blocks, so this check is useful.
                    {
                        projectile.velocity.Y = 16f;
                    }
                }
            }
        }
    }
}