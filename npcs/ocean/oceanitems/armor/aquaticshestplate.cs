﻿using Terraria;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;
using Terraria.ID;
using static Terraria.ModLoader.ModContent;

namespace gracosmod123.NPCs.ocean.oceanitems.armor
{
    [AutoloadEquip(EquipType.Body)]
    public class aquaticshestplate : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Aquatic Chainmail");
        }
        public override void SetDefaults()
        {

            item.Size = new Vector2(18);
            Item.value = Item.sellPrice(silver: 24);
            Item.rare = ItemRarityID.Blue;
            item.defense = 35;
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
