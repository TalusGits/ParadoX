using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using gracosmod123.items;
namespace gracosmod123.npcs.wormboss.items
{
    public class JadeSpear : ModItem//MysticItem
    {
        public override void SetDefaults()
        {
            item.damage = 15;
            item.useStyle = 5;
            item.useAnimation = 28;
            item.useTime = 32;
            item.shootSpeed = 2f;
            item.knockBack = 10f;
            item.width = 32;
            item.height = 32;
            item.scale = 1f;
            item.melee = true;
            item.rare = ItemRarityID.Green;
            item.rare = 0;
            item.UseSound = SoundID.Item1;
            item.shoot = mod.ProjectileType("JadeSpearProjectile");
            item.value = Item.sellPrice(0, 0, 0, 21);
            item.noUseGraphic = true;
            item.autoReuse = true;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Malfunctioning jade distance poker");
            Tooltip.SetDefault("Not as much damage as most weapons, but is super long range:)");
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod, "GlowingCrystalItem", 20);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
    }
}
