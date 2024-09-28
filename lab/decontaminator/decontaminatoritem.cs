using Terraria.ID;
using Terraria.ModLoader;

namespace gracosmod123.lab.decontaminator
{
    public class decontaminatoritem : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Decontaminator");
            Tooltip.SetDefault("Shoots a spray of harmless decontamination fluid");
        }
        public override void SetDefaults()
        {
            Item.width = 16;
            Item.height = 16;
            Item.maxStack = 999;
            Item.value = 0;
            Item.rare = 3;
            Item.createTile = ModContent.TileType("decontaminator");
            item.useTurn = true;
            Item.autoReuse = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
            item.useStyle = 1;
            Item.consumable = true;
        }
    }
}