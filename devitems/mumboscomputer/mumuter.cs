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
            item.width = 16;
            item.height = 16;
            item.maxStack = 999;
            item.useTurn = true;
            item.autoReuse = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.useStyle = 1;
            item.consumable = true;
            item.value = 0;
            item.createTile = mod.TileType("mumutertile");
        }
    }
}