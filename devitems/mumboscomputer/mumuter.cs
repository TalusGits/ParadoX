using Terraria.ID;
using Terraria.ModLoader;

namespace gracosmod123.devitems.mumboscomputer
{
    public class mumuter : ModItem
    {


        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Talus's Computer");
            Tooltip.SetDefault("Infinite power rests inside the moniter, if only there was a way to acess it\n Levitates off the ground \n There is a small electrical slot in the side of the moniter.");
        }
        public override void SetDefaults()
        {
            Item.width = 16;
            Item.height = 16;
            Item.maxStack = 999;
            item.useTurn = true;
            Item.autoReuse = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
            item.useStyle = 1;
            Item.consumable = true;
            Item.value = 0;
            Item.createTile = ModContent.TileType("mumutertile");
        }
    }
}