using Terraria.ID;
using Terraria.ModLoader;

namespace gracosmod123.lab
{
    public class labtableitem : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Lab table");
            Tooltip.SetDefault("");
        }

        public override void SetDefaults()
        {
            item.width = 38;
            item.height = 26;
            item.maxStack = 99;
            item.useTurn = true;
            item.autoReuse = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.useStyle = 1;
            item.consumable = true;
            item.value = 250;
            item.createTile = mod.TileType("labtable");
        }
    }
}