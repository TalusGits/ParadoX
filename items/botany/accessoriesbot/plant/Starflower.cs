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
            item.maxStack = 99;
            item.width = 14;
            item.height = 18;
            item.value = 80;
        }
    }
}
