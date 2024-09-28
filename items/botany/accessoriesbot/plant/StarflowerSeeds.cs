using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace gracosmod123.items.botany.accessoriesbot.plant
{
    public class StarflowerSeeds : ModItem 
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Razor Flower seeds");
        }
        public override void SetDefaults() 
        {
            Item.autoReuse = true;
            item.useTurn = true;
            item.useStyle = 1;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.maxStack = 99;
            Item.consumable = true;
            Item.width = 12;
            Item.height = 14;
            Item.value = 80;
            Item.createTile = TileType<items.botany.accessoriesbot.plant.Starflowertile>();
        }
    }
}
