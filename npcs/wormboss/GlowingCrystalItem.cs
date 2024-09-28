using Terraria.ID;
using Terraria.ObjectData;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
namespace gracosmod123.NPCs.wormboss
{
    public class GlowingCrystalItem : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Jade");
            Tooltip.SetDefault("Oh, Edmund, can it be true, that I hold here in my mortal hand a nugget of purest green?");
        }
        public override void SetDefaults()
        {
            Item.width = 16;
            Item.height = 16;
            item.useTurn = true;
            item.useStyle = ItemUseStyleID.SwingThrow;
            Item.useAnimation = 15;
            Item.useTime = 15;
            Item.autoReuse = true;
            Item.maxStack = 99;
            Item.consumable = true;
            Item.value = 1000;
            Item.createTile = ModContent.TileType("GlowingCrystal");
            Item.UseSound = null;
            Item.rare = ItemRarityID.Green;

        }
    }
}