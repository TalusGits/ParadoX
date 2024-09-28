using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace gracosmod123.items.forumsman
{
    public class Copperduel : ModItem
    {
        public override void SetDefaults()
        {
            Item.DamageType = 26;
            item.melee = true;
            Item.width = 36;
            Item.height = 38;
            Item.useTime = 25;
            Item.useAnimation = 25;
            item.useStyle = 1;
            Item.knockBack = 10;
            Item.value = Item.sellPrice(0, 4, 0, 0);
            Item.rare = 4;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
            item.useTurn = true;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Copper Duel Sword");
            Tooltip.SetDefault("Yoove been doobled");
        }
        public override void AddRecipes()
        {
            Recipe recipe = new Recipe(mod);
            recipe.AddIngredient(3508, 2);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.Register();
        }
    }
}
