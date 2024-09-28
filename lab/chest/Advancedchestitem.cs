using Terraria.Localization;
using Terraria.ModLoader;

namespace gracosmod123.lab.chest
{
    public class Advancedchestitem : ModItem
    {
        public override void SetDefaults()
        {
            item.width = 32;
            item.height = 28;
            item.maxStack = 99;
            item.useTurn = true;
            item.autoReuse = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.useStyle = 1;
            item.consumable = true;
            item.value = 500;
            item.createTile = mod.TileType("Advancedchest");
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Lab Containment Unit");
        }
    }
}
