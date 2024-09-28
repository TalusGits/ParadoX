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
namespace gracosmod123.npcs.wormboss
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
            item.width = 16;
            item.height = 16;
            item.useTurn = true;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.useAnimation = 15;
            item.useTime = 15;
            item.autoReuse = true;
            item.maxStack = 99;
            item.consumable = true;
            item.value = 1000;
            item.createTile = mod.TileType("GlowingCrystal");
            item.UseSound = null;
            item.rare = ItemRarityID.Green;

        }
    }
}