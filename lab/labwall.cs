using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace gracosmod123.lab
{
    public class labwall : ModWall
    {

        public override void SetDefaults()
        {
            Main.wallHouse[Type] = true;
            dustType = ModContent.DustType("labdust");
            drop = ModContent.ItemType("labwallitem");
            AddMapEntry(new Color(76, 80, 92));
        }

        public override void NumDust(int i, int j, bool fail, ref int num)
        {
            num = fail ? 1 : 3;
        }
    }
}