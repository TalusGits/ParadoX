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

namespace gracosmod123.items.enchantedstuff
{
    public class MineFlail : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Enchanted Flail");
        }

        public override void SetDefaults()
        {
            Item.width = 22;
            Item.height = 20;
            Item.value = Item.sellPrice(silver: 5);
            Item.rare = ItemRarityID.White;
            Item.noMelee = true;
            item.useStyle = ItemUseStyleID.HoldingOut;
            Item.useAnimation = 40;
            Item.useTime = 20;
            Item.knockBack = 200f;
            Item.DamageType = 30;
            item.noUseGraphic = true;
            Item.shoot = ModContent.ProjectileType<MineFlailProjectile>();
            Item.shootSpeed = 15.1f;
            Item.UseSound = SoundID.Item1;
            item.melee = true;
            item.crit = 9;
            item.channel = true;
        }
        public override void AddRecipes()
        {
            Recipe recipe = new Recipe(mod);
            recipe.AddIngredient(ItemType<ore.eliasBar>(), 3);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.Register();
        }
    }
}