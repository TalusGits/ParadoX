using Terraria.ID;
using Terraria.ModLoader;

namespace gracosmod123.NPCs.ant
{
    public class scythe : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("scythe"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
            Tooltip.SetDefault("");
        }

        public override void SetDefaults()
        {
            Item.DamageType = 102;
            item.melee = true;
            Item.width = 40000;
            Item.height = 600000;
            Item.useTime = 10;
            Item.useAnimation = 12;
            item.useStyle = 1;
            Item.knockBack = 50;
            Item.value = 100;
            Item.rare = 10;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
            Item.shoot = ModContent.ProjectileType("scythe2");
            Item.shootSpeed = 16f;
            item.useTurn = true;
            Item.noMelee = false;

        }

        /*public override void AddRecipes()
        {
            Recipe recipe = new Recipe(mod);
            recipe.AddIngredient(ItemID.BeetleHusk, 20);
            recipe.AddIngredient(ItemID.Boulder, 20);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.Register();
        }*/
    }
}