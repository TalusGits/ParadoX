using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace gracosmod123.items.botany.accessoriesbot.plant
{
    public class Starflower : ModItem 
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Razor Flower");
        }
        public override void SetDefaults() 
        {
            Item.maxStack = 99;
            Item.width = 14;
            Item.height = 18;
            Item.value = 80;
        }
    }
}
