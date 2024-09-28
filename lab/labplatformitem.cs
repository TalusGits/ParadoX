using Terraria.ID;
using Terraria.ModLoader;

namespace gracosmod123.lab
{
    public class labplatformitem : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Lab platform");
        }

        public override void SetDefaults()
        {
            item.width = 26;
            item.height = 22;
            item.maxStack = 999;
            item.useTurn = true;
            item.autoReuse = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.useStyle = 1;
            item.consumable = true;
            item.value = 0;
            item.createTile = mod.TileType("labplatform");
        }
    }
}
