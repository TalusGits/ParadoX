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
            Item.DamageType = 20;
            item.useStyle = 5;
            Item.useAnimation = 28;
            Item.useTime = 32;
            Item.shootSpeed = 2f;
            Item.knockBack = 10f;
            Item.width = 32;
            Item.height = 32;
            Item.scale = 1f;
            item.melee = true;
            Item.rare = 0;
            Item.UseSound = SoundID.Item1;
            Item.shoot = ModContent.ProjectileType("Crimstabby");
            Item.value = Item.sellPrice(0, 0, 0, 21);
            item.noUseGraphic = true;
            Item.autoReuse = false;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Blood Stabber");
        }
        public override void AddRecipes()
        {
            Recipe recipe = new Recipe(mod);
            recipe.AddIngredient(1257, 20);
            recipe.AddIngredient(1329, 10);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.Register();
        }
    }
}
