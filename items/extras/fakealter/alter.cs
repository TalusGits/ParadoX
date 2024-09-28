using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace gracosmod123.items.extras.fakealter
{
    public class alter : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("LAZ-er cutter");
            Tooltip.SetDefault("Now you can do best stuff"
            + "\nCan be placed as crafting station not ready!");
        }
        public override void SetDefaults()
        {
            item.width = 24;
            item.height = 24;
            item.maxStack = 1;
            item.value = 1000000;
            item.rare = 7;
            item.useTurn = true;
            item.autoReuse = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.useStyle = 1;
            item.consumable = true;
            item.createTile = mod.TileType("ArtificialAltar");
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Bookcase);
            recipe.AddIngredient(ItemID.ImbuingStation);
            recipe.AddIngredient(ItemID.CrystalBall);
            recipe.AddIngredient(ItemID.Autohammer);
            recipe.AddIngredient(ItemID.BlendOMatic);
            recipe.AddIngredient(ItemID.MeatGrinder);
            recipe.AddIngredient(ItemID.LihzahrdFurnace);
            recipe.AddIngredient(ItemID.LunarCraftingStation);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
    }
}
