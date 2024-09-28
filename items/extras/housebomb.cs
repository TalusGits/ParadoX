using Terraria.ID;
using Terraria.ModLoader;

namespace gracosmod123.items.extras
{
    public class housebomb : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("sandybit maker"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
            Tooltip.SetDefault("sandy house to make unfortunatly you die so stand where you want the house to be");
        }

        public override void SetDefaults()
        {
            Item.DamageType = 0;     //The damage stat for the Weapon.
            Item.width = 20;    //sprite width
            Item.height = 20;   //sprite height
            Item.maxStack = 999;
            Item.consumable = true;  //Tells the game that this should be used up once fired
            item.useStyle = 1;   //The way your item will be used, 1 is the regular sword swing for example
            Item.rare = 2;   //The color the title of your item when hovering over it ingame
            Item.useAnimation = 20;  //How long the item is used for.
                                     //Item.useTime = 20;	 //How fast the item is used.
            item.noUseGraphic = true;
            Item.noMelee = true;      //Setting to True allows the weapon sprite to stop doing damage, so only the projectile does the damge
            Item.shoot = ModContent.ProjectileType("anthousegen"); //This defines what type of projectile this item will shoot
            Item.shootSpeed = 5f;
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