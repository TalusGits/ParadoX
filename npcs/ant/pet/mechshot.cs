
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace gracosmod123.NPCs.ant.pet
{
    public class mechshot : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 46;
            projectile.height = 54;
            projectile.friendly = true;
            projectile.melee = true;
            projectile.tileCollide = false;
            projectile.timeLeft = 240;
            Projectile.Penetrate = 4;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Scythe");

        }

        public override void AI()
        {
            Lighting.AddLight(projectile.Center, 1.0f, 0.7f, 0.1f);
            if (projectile.ai[1] == 0f && projectile.type == 44)
            {
                projectile.ai[1] = 1f;
                SoundEngine.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 8);
            }
            projectile.ai[0] += 1f;
            if (projectile.ai[0] >= 30f)
            {
                if (projectile.ai[0] < 100f)
                {
                    projectile.velocity *= 1.06f;
                }
                else
                {
                    projectile.ai[0] = 200f;
                }
            }
            for (var k = 0; k < 2; k++)
            {
                //var dust = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, ModContent.DustType(""));
                //Main.dust[dust].noGravity = true;
            }//            int DustID2 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y + 2f), projectile.width + 2, projectile.height + 2, ModContent.DustType("ret"), projectile.velocity.X * 0.2f, projectile.velocity.Y * 0.2f, 20, default(Color), 2.9f);

            projectile.rotation += (float)projectile.direction * 0.3f;
            projectile.velocity *= 0.95f;
        }

        public override Color? GetAlpha(Color lightColor)
        {
            return Color.White;
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            /*target.AddBuff(24, 300, false);
            target.AddBuff(30, 600, false);*/ //poisnedprime

        }
    }
}
