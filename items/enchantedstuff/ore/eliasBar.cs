using Terraria;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace gracosmod123.items.enchantedstuff.ore
{
    public class eliasBar : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Enchanted Bar");
        }
        public override void SetDefaults()
        {
            item.Size = new Vector2(16);
            Item.rare = ItemRarityID.Blue;
            Item.value = Item.sellPrice(copper: 90);

            Item.autoReuse = true;
            item.useTurn = true;
            Item.useTime = 15;
            Item.useAnimation = 15;
            item.useStyle = ItemUseStyleID.SwingThrow;

            Item.consumable = true;
            Item.maxStack = 99;

            Item.createTile = TileType<items.enchantedstuff.ore.eliasBars>();
            item.placeStyle = 0;
        }

        public override void AddRecipes()
        {
            Recipe recipe = new Recipe(mod);
            recipe.AddIngredient(ItemType<encore>(), 5);
            recipe.AddTile(TileID.Furnaces);
            recipe.SetResult(this);
            recipe.Register();
        }
    }
}
