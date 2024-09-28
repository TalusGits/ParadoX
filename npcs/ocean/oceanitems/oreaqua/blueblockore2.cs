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

namespace gracosmod123.npcs.ocean.oceanitems.oreaqua
{
    public class blueblockore2 : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileSolid[Type] = true;
            Main.tileMergeDirt[Type] = true;
            Main.tileBlockLight[Type] = true;
            Main.tileSpelunker[Type] = true;
            drop = ItemType<npcs.ocean.oceanitems.oreaqua.blueblockore>();
            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Aquatic Ore");
            AddMapEntry(new Color(162, 184, 185), name);
            minPick = 224;
        }
    }
}
