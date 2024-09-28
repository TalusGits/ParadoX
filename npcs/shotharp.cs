using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace gracosmod123.NPCs
{
    public class shotharp : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 14;
            projectile.height = 24;
            projectile.aiStyle = 1;
            projectile.hostile = true;
            projectile.tileCollide = true;
            projectile.light = 1.00f;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("HUH");
        }

        public override void Kill(int timeLeft)
        {
            if (Main.netMode != 2)
            {
                Collision.HitTiles(projectile.position, projectile.velocity, projectile.width, projectile.height);
                SoundEngine.PlaySound(0, (int)projectile.position.X, (int)projectile.position.Y, 1);
                for (int i = 0; i < 25; i++)
                {
                    Dust.NewDust(projectile.position, projectile.width, projectile.height, 15, projectile.velocity.X, projectile.velocity.Y);
                }
            }
        }
        public override void OnHitPlayer(Player player, int dmgDealt, bool crit)
        {
            player.AddBuff(31, 300, true);// adds confused
        }
        public override void AI()
        {
            Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 15, 0f, 0f);
        }

    }
}
