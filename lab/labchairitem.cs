using Terraria.ID;
using Terraria.ModLoader;

namespace gracosmod123.lab
{
    public class labchairitem : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Lab chair");
            Tooltip.SetDefault("");
        }

        public override void SetDefaults()
        {
            item.width = 16;
            item.height = 32;
            item.maxStack = 99;
            item.useTurn = true;
            item.autoReuse = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.useStyle = 1;
            item.consumable = true;
            item.value = 250;
            item.createTile = mod.TileType("labchair");
        }
    }
}