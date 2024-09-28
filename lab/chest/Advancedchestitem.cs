using Terraria.Localization;
using Terraria.ModLoader;

namespace gracosmod123.lab.chest
{
    public class Advancedchestitem : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 32;
            Item.height = 28;
            Item.maxStack = 99;
            item.useTurn = true;
            Item.autoReuse = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
            item.useStyle = 1;
            Item.consumable = true;
            Item.value = 500;
            Item.createTile = ModContent.TileType("Advancedchest");
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Lab Containment Unit");
        }
    }
}
