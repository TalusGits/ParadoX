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

namespace gracosmod123.items.enchantedstuff.ore
{
    public class encore2 : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileMergeDirt[Type] = true;
            Main.tileBlockLight[Type] = true;
            Main.tileSpelunker[Type] = true;
            drop = ItemType<items.enchantedstuff.ore.encore>();
            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Enchanted Ore");
            AddMapEntry(new Color(162, 184, 185), name);
            minPick = 65;
        }
    }
}
