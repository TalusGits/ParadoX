﻿using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;
using static Terraria.ModLoader.ModContent;

namespace gracosmod123.npcs.ocean.oceanitems.oreaqua
{
    public class Aquabar2 : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileShine[Type] = 1100;
            Main.tileSolid[Type] = true;
            Main.tileSolidTop[Type] = true;
            Main.tileFrameImportant[Type] = true;

            TileObjectData.newTile.CopyFrom(TileObjectData.Style1x1);
            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.newTile.LavaDeath = false;
            TileObjectData.addTile(Type);
            drop = ItemType<npcs.ocean.oceanitems.oreaqua.Aquabar>();
            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Aquatic Bar");
            AddMapEntry(new Color(162, 184, 185), name);
            minPick = 224;
        }
    }
}
