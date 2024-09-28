using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace gracosmod123.NPCs.Glichfolder.notes//location in the folders
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
            Item.maxStack = 1;
            Item.width = 32;
            Item.height = 32;
            Item.rare = 0;
            Item.useTime = 30;
            Item.useAnimation = 30;
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
