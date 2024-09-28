using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria;
using static Terraria.ModLoader.ModContent;

namespace gracosmod123.items.forumsman
{
    public class Amythestflamestaff : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Amythest Staff");
            Tooltip.SetDefault("PURPLEEEEEEEE");
            Item.staff[item.type] = true; //this makes the useStyle animate as a staff instead of as a gun
        }

        public override void SetDefaults()
        {
            item.damage = 45;
            item.magic = true;
            item.mana = 4;
            item.width = 48;
            item.height = 64;
            item.useTime = 10;
            item.useAnimation = 10;
            item.useStyle = 5;
            item.noMelee = true;
            item.knockBack = 2.3f;
            item.value = Item.sellPrice(0, 5, 0, 0);
            item.rare = 3;
            item.UseSound = SoundID.Item75;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("FlamethrowerProj");
            item.shootSpeed = 10.0f;
            Item.staff[item.type] = true;
        }

        /*public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
            Vector2 vector = Main.MouseWorld;
            position += Vector2.Normalize(new Vector2(speedX, speedY)) * 70.5f;
            float speed = (float)(3.0 + (double)Main.rand.NextFloat() * 6.0);
            Vector2 start = Vector2.UnitY.RotatedByRandom(6.32);
            Projectile.NewProjectile(position.X, position.Y, start.X * speed, start.Y * speed, type, damage, knockBack, player.whoAmI, vector.X, vector.Y);
            return false;
		}*/
        public override bool UseItem(Player player)
        {
            Dust.NewDust(player.position, player.width, player.height, mod.DustType("Dustdarkpurp"), 0, 0);
            return true;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(621, 20);//pearlwood
            recipe.AddIngredient(181, 20);//amythest
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}