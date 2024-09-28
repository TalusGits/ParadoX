using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using gracosmod123;
namespace gracosmod123.items.botany.accessoriesbot.plant
{
    public class StarflowerPlanterBox : ModItem
    {
        public static bool isCraftable;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Razor Flower planter box");
            Tooltip.SetDefault("Only Razor Flowers can grow in this sharp soil");
        }

        public override void SetDefaults()
        {
            Item.maxStack = 999;
            Item.width = 24;
            Item.height = 20;
            Item.value = 100;
            Item.autoReuse = true;
            item.useTurn = true;
            item.useStyle = 1;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.consumable = true;
            Item.createTile = ModContent.TileType("StarflowerPlanterBoxtile");
        }

        public override void AddRecipes()
        {
            if (GetInstance<ServerConfig>().isPlanterBoxCraftingEnabled)
            {
                Recipe recipe = new Recipe(mod);
                recipe.AddIngredient(ItemID.DirtBlock, 2);
                recipe.RegisterGroup("Wood", 2);
                recipe.AddIngredient(mod, "StarflowerSeeds");
                recipe.AddTile(TileID.WorkBenches);
                recipe.SetResult(this);
                recipe.Register();
            }
        }
    }
}
