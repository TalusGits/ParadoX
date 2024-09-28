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
            Item.rare = 3;
            Item.width = 12;
            Item.height = 12;
            Item.maxStack = 999;
            item.useTurn = true;
            Item.autoReuse = true;
            Item.useAnimation = 15;
            Item.useTime = 7;
            item.useStyle = 1;
            Item.consumable = true;
            item.createWall = mod.WallType("labwall");
        }
    }
}