using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace gracosmod123.items.extras.randombox.batbasher
{
    public class CustomSpinningWeapon : ModItem
    {
        public override void SetDefaults()
        {
            Item.DamageType = 11;    //The damage stat for the Weapon.
            item.melee = true;     //This defines if it does Melee damage and if its effected by Melee increasing Armor/Accessories.
            Item.width = 80;    //The size of the width of the hitbox in pixels.
            Item.height = 80;    //The size of the height of the hitbox in pixels.
            Item.useTime = 10;   //How fast the Weapon is used.
            Item.useAnimation = 10;     //How long the Weapon is used for.
            item.channel = true;
            item.useStyle = 100;    //The way your Weapon will be used, 1 is the regular sword swing for example
            Item.knockBack = 8f;    //The knockback stat of your Weapon.
            Item.value = Item.buyPrice(0, 10, 0, 0); //	How much the item is worth, in copper coins, when you sell it to a merchant. It costs 1/5th of this to buy it back from them. An easy way to remember the value is platinum, gold, silver, copper or PPGGSSCC (so this item price is 10gold)
            Item.shoot = ModContent.ProjectileType("SpinningWeaponProj");  //This defines what type of projectile this weapon will shoot	
            item.noUseGraphic = true; // this defines if it does not use graphic
            if (Main.hardMode)
            {
                Item.DamageType = 22;
            }
        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bat Basher"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
            Tooltip.SetDefault("Tired of almost mining enough iron, than getting killed by a bat? Bat Basher will help. with its comforting glow and full body protection you will be invincible\n Discalimer: only does 22 damage. you are not supposed to be reading this. is a quite rare drop. Does double damage in hardmode");
        }
        public override bool UseItemFrame(Player player)     //this defines what frame the player use when this weapon is used 
        {
            player.bodyFrame.Y = 3 * player.bodyFrame.Height;
            return true;
        }
    }
}