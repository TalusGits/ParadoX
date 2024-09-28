using Terraria.ID;
using Terraria.ModLoader;

namespace gracosmod123.lab
{
    public class labdoor : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Lab door");
            Tooltip.SetDefault("");
        }

        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 34;
            Item.maxStack = 99;
            item.useTurn = true;
            Item.autoReuse = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
            item.useStyle = 1;
            Item.consumable = true;
            Item.value = 250;
            Item.createTile = ModContent.TileType("labdoorclosed");
        }
    }
}