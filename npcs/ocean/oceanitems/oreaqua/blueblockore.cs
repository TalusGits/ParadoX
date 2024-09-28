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

namespace gracosmod123.NPCs.ocean.oceanitems.oreaqua
{
    public class blueblockore : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Aquatic Ore");
            Tooltip.SetDefault("When smelted, it seems to turn darker... Like fish!");
        }
        public override void SetDefaults()
        {
            item.Size = new Vector2(12);
            Item.rare = ItemRarityID.Blue;
            Item.value = Item.sellPrice(copper: 2);
            Item.autoReuse = true;
            item.useTurn = true;
            Item.useTime = 10;
            Item.useAnimation = 12;
            item.useStyle = ItemUseStyleID.SwingThrow;

            Item.consumable = true;
            Item.maxStack = 999;

            Item.createTile = TileType<NPCs.ocean.oceanitems.oreaqua.blueblockore2>();
        }
    }
}
