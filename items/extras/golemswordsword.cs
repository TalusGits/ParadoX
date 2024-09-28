using Terraria.ID;
using Terraria.ModLoader;

namespace gracosmod123.items.extras
{
    public class golemswordsword : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("bright bamboo disc"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
            Tooltip.SetDefault("");
        }

        public override void SetDefaults()
        {
            item.damage = 20;
            item.melee = true;
            item.width = 40000;
            item.height = 600000;
            item.useTime = 10;
            item.useAnimation = 12;
            item.useStyle = 1;
            item.knockBack = 50;
            item.value = 100;
            item.rare = 10;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("bamboodiscus");
            item.shootSpeed = 16f;
            item.noMelee = true;
            item.useTurn = true;

        }

        /*public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.BeetleHusk, 20);
            recipe.AddIngredient(ItemID.Boulder, 20);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }*/
    }
}