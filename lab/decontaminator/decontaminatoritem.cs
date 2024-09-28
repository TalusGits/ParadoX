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
            item.width = 16;
            item.height = 16;
            item.maxStack = 999;
            item.value = 0;
            item.rare = 3;
            item.createTile = mod.TileType("decontaminator");
            item.useTurn = true;
            item.autoReuse = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.useStyle = 1;
            item.consumable = true;
        }
    }
}