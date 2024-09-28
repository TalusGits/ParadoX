using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using gracosmod123.items;
namespace gracosmod123.items.forumsman
{
    public class Crimspear : ModItem//MysticItem
    {
        public override void SetDefaults()
        {
            item.damage = 20;
            item.useStyle = 5;
            item.useAnimation = 28;
            item.useTime = 32;
            item.shootSpeed = 2f;
            item.knockBack = 10f;
            item.width = 32;
            item.height = 32;
            item.scale = 1f;
            item.melee = true;
            item.rare = 0;
            item.UseSound = SoundID.Item1;
            item.shoot = mod.ProjectileType("Crimstabby");
            item.value = Item.sellPrice(0, 0, 0, 21);
            item.noUseGraphic = true;
            item.autoReuse = false;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Blood Stabber");
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(1257, 20);
            recipe.AddIngredient(1329, 10);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
