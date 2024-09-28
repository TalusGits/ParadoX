using Terraria.ID;
using Terraria.ModLoader;

namespace gracosmod123.lab
{
    public class labwallitem : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Lab wall");
            Tooltip.SetDefault("");
        }
        public override void SetDefaults()
        {
            item.rare = 3;
            item.width = 12;
            item.height = 12;
            item.maxStack = 999;
            item.useTurn = true;
            item.autoReuse = true;
            item.useAnimation = 15;
            item.useTime = 7;
            item.useStyle = 1;
            item.consumable = true;
            item.createWall = mod.WallType("labwall");
        }
    }
}