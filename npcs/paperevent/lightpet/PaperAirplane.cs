using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace gracosmod123.NPCs.paperevent.lightpet
{
    public class PaperAirplane : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Paper Airplane"); // Automatic from .lang files
            Main.projFrames[projectile.type] = 4;
            Main.projPet[projectile.type] = true;
        }

        public override void SetDefaults()
        {
            projectile.CloneDefaults(ProjectileID.ZephyrFish);
            aiType = ProjectileID.ZephyrFish;
            projectile.light = 2.0f;
        }

        public override bool PreAI()
        {
            Player player = Main.player[projectile.owner];
            player.zephyrfish = false; // Relic from aiType
            return true;
        }

        public override void AI()
        {
            Player player = Main.player[projectile.owner];

        }
    }
}
