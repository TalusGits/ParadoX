using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace gracosmod123.NPCs.paperevent.lightpet
{
    public class PaperAirplanebuff : ModBuff
    {
        public override void SetDefaults()
        {
            // DisplayName and Description are automatically set from the .lang files, but below is how it is done normally.
            DisplayName.SetDefault("Paper Airplane");
            Description.SetDefault("\"Let this pet be an amazing toy to you!\"");
            Main.buffNoTimeDisplay[Type] = true;
            Main.vanityPet[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.buffTime[buffIndex] = 18000;
            bool petProjectileNotSpawned = player.ownedProjectileCounts[ModContent.ProjectileType("PaperAirplane")] <= 0;
            if (petProjectileNotSpawned && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectileDirect(player.position.X + (float)(player.width / 2), player.position.Y + (float)(player.height / 2), 0f, 0f, ModContent.ProjectileType("PaperAirplane"), 0, 0f, player.whoAmI, 0f, 0f);
            }
        }
    }
}
