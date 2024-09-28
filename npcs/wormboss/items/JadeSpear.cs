using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using gracosmod123.items;
namespace gracosmod123.NPCs.wormboss.items
{
    public class JadeSpear : ModItem//MysticItem
    {
        public override void SetDefaults()
        {
            Item.DamageType = 15;
            item.useStyle = 5;
            Item.useAnimation = 28;
            Item.useTime = 32;
            Item.shootSpeed = 2f;
            Item.knockBack = 10f;
            Item.width = 32;
            Item.height = 32;
            Item.scale = 1f;
            item.melee = true;
            Item.rare = ItemRarityID.Green;
            Item.rare = 0;
            Item.UseSound = SoundID.Item1;
            Item.shoot = ModContent.ProjectileType("JadeSpearProjectile");
            Item.value = Item.sellPrice(0, 0, 0, 21);
            item.noUseGraphic = true;
            Item.autoReuse = true;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Malfunctioning jade distance poker");
            Tooltip.SetDefault("Not as much damage as most weapons, but is super long range:)");
        }
        public override void AddRecipes()
        {
            Recipe recipe = new Recipe(mod);
            recipe.AddIngredient(mod, "GlowingCrystalItem", 20);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this, 1);
            recipe.Register();
        }
    }
}
