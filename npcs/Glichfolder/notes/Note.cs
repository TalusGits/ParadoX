using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace gracosmod123.npcs.Glichfolder.notes//location in the folders
{
    public class Note : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Note");
            Tooltip.SetDefault("'Somebody has written something on it.'\nUse to read");
        }

        public override void SetDefaults()
        {
            item.maxStack = 1;
            item.width = 32;
            item.height = 32;
            item.rare = 0;
            item.useTime = 30;
            item.useAnimation = 30;
            item.useStyle = 3;
            item.useTurn = true;
        }

        public override bool UseItem(Player player)
        {
            var aPlayer = player.GetModPlayer<exampleplayer>();
            aPlayer.OpenWindow = !aPlayer.OpenWindow;
            return true;
        }
    }
}
