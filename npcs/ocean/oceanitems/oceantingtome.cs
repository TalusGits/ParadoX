using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace gracosmod123.NPCs.ocean.oceanitems
{
    public class oceantingtome : ModItem
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Starfish Storm"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
        }
        public override void SetDefaults()
        {
            Item.DamageType = 300;
            item.magic = true;                     //this make the item do magic damage
            Item.width = 24;
            Item.height = 28;
            Item.useTime = 30;
            Item.useAnimation = 30;
            item.useStyle = 5;        //this is how the item is holded
            Item.noMelee = true;
            Item.knockBack = 2;
            Item.value = 1000;
            Item.rare = 6;
            Item.mana = 20;             //mana use
            Item.UseSound = SoundID.Item21;            //this is the sound when you use the item
            Item.autoReuse = true;
            Item.shoot = ModContent.ProjectileType("oceanshotspin");  //this make the Item.shoot your projectile
            Item.shootSpeed = 8f;    //projectile speed when shoot
        }
        public override void AddRecipes()
        {
            Recipe recipe = new Recipe(mod);
            recipe.AddIngredient(ItemType<oreaqua.Aquabar>(), 5);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this, 1);
            recipe.Register();
        }
    }
}