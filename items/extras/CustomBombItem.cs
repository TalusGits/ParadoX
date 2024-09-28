using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace gracosmod123.items.extras                 //We need this to basically indicate the folder where it is to be read from, so you the texture will load correctly
{
    public class CustomBombItem : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Atomic bomb"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
            Tooltip.SetDefault("Error 404");
        }
        public override void SetDefaults()
        {
            item.damage = 100000;     //The damage stat for the Weapon.
            item.width = 10;    //sprite width
            item.height = 32;   //sprite height
            item.maxStack = 99;   //This defines the items max stack
            item.consumable = true;  //Tells the game that this should be used up once fired
            item.useStyle = 1;   //The way your item will be used, 1 is the regular sword swing for example
            item.rare = 2;     //The color the title of your item when hovering over it ingame
            item.UseSound = SoundID.Item1; //The sound played when using this item
            item.useAnimation = 20;  //How long the item is used for.
            item.useTime = 20;     //How fast the item is used.
            item.value = Item.buyPrice(0, 0, 3, 0);   //How much the item is worth, in copper coins, when you sell it to a merchant. It costs 1/5th of this to buy it back from them. An easy way to remember the value is platinum, gold, silver, copper or PPGGSSCC (so this item price is 3 silver)
            item.noUseGraphic = true;
            item.noMelee = true;      //Setting to True allows the weapon sprite to stop doing damage, so only the projectile does the damge
            item.shoot = mod.ProjectileType("CustomBombProj"); //This defines what type of projectile this item will shoot	
            item.shootSpeed = 5f; //This defines the projectile speed when shot
        }
    }
}
