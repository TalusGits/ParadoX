using Terraria.ID;
using Terraria.ModLoader;

namespace gracosmod123.lab
{
    public class labbrickitem : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Lab Tile");
            Tooltip.SetDefault("");
        }
        public override void SetDefaults()
        {
            item.width = 16;
            item.height = 16;
            item.maxStack = 999;
            item.value = 0;
            item.rare = 3;
            item.createTile = mod.TileType("labbrick");
            item.useTurn = true;
            item.autoReuse = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.useStyle = 1;
            item.consumable = true;
        }
    }
}