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
            item.maxStack = 999;
            item.width = 24;
            item.height = 20;
            item.value = 100;
            item.autoReuse = true;
            item.useTurn = true;
            item.useStyle = 1;
            item.useAnimation = 15;
            item.useTime = 10;
            item.consumable = true;
            item.createTile = mod.TileType("StarflowerPlanterBoxtile");
        }

        public override void AddRecipes()
        {
            if (GetInstance<ServerConfig>().isPlanterBoxCraftingEnabled)
            {
                ModRecipe recipe = new ModRecipe(mod);
                recipe.AddIngredient(ItemID.DirtBlock, 2);
                recipe.AddRecipeGroup("Wood", 2);
                recipe.AddIngredient(mod, "StarflowerSeeds");
                recipe.AddTile(TileID.WorkBenches);
                recipe.SetResult(this);
                recipe.AddRecipe();
            }
        }
    }
}
