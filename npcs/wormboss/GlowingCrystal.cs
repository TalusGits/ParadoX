using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;
using TileObjectData = Terraria.ObjectData.TileObjectData;

namespace gracosmod123.NPCs.wormboss
{
    public class GlowingCrystal : ModTile        // Tile counterpart to GlowingCompound
    {

        public override void SetDefaults()
        {
            Main.tileSolid[Type] = false;
            Main.tileNoAttach[Type] = true;
            Main.tileFrameImportant[Type] = true;
            Main.tileNoFail[Type] = true;
            drop = ModContent.ItemType("GlowingCrystalItem");
            AddMapEntry(new Color(148, 134, 48));

            TileObjectData.newTile.CopyFrom(TileObjectData.Style1x1);
            TileObjectData.newTile.StyleHorizontal = true;
            /*TileObjectData.newTile.Height = 1;
            TileObjectData.newTile.CoordinateHeights = new int[] {16};
            TileObjectData.newTile.Width = 1;
            TileObjectData.newTile.CoordinateWidth = 16;
            TileObjectData.newTile.CoordinatePadding = 2;*/
            TileObjectData.newTile.AnchorTop = AnchorData.Empty;
            TileObjectData.newTile.AnchorRight = AnchorData.Empty;
            TileObjectData.newTile.AnchorLeft = AnchorData.Empty;
            TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidWithTop | AnchorType.SolidTile | AnchorType.Table, TileObjectData.newTile.Width, 0);
            TileObjectData.newTile.StyleWrapLimit = 18;
            TileObjectData.newTile.RandomStyleRange = 17;
            TileObjectData.newAlternate.CopyFrom(TileObjectData.Style1x1);
            TileObjectData.newAlternate.StyleHorizontal = true;
            TileObjectData.newAlternate.AnchorTop = AnchorData.Empty;
            TileObjectData.newAlternate.AnchorRight = new AnchorData(AnchorType.SolidSide | AnchorType.SolidTile, TileObjectData.newTile.Width, 0);
            TileObjectData.newAlternate.AnchorLeft = AnchorData.Empty;
            TileObjectData.newAlternate.AnchorBottom = AnchorData.Empty;
            TileObjectData.newAlternate.StyleWrapLimit = 18;
            TileObjectData.newAlternate.RandomStyleRange = 17;
            TileObjectData.addAlternate(36);
            TileObjectData.newAlternate.CopyFrom(TileObjectData.Style1x1);
            TileObjectData.newAlternate.StyleHorizontal = true;
            TileObjectData.newAlternate.AnchorTop = AnchorData.Empty;
            TileObjectData.newAlternate.AnchorRight = AnchorData.Empty;
            TileObjectData.newAlternate.AnchorLeft = new AnchorData(AnchorType.SolidSide | AnchorType.SolidTile, TileObjectData.newTile.Width, 0);
            TileObjectData.newAlternate.AnchorBottom = AnchorData.Empty;
            TileObjectData.newAlternate.StyleWrapLimit = 18;
            TileObjectData.newAlternate.RandomStyleRange = 17;
            TileObjectData.addAlternate(54);
            TileObjectData.newAlternate.CopyFrom(TileObjectData.Style1x1);
            TileObjectData.newAlternate.StyleHorizontal = true;
            TileObjectData.newAlternate.AnchorTop = new AnchorData(AnchorType.SolidBottom | AnchorType.SolidTile, TileObjectData.newTile.Width, 0);
            TileObjectData.newAlternate.AnchorRight = AnchorData.Empty;
            TileObjectData.newAlternate.AnchorLeft = AnchorData.Empty;
            TileObjectData.newAlternate.AnchorBottom = AnchorData.Empty;
            TileObjectData.newAlternate.StyleWrapLimit = 18;
            TileObjectData.newAlternate.RandomStyleRange = 17;
            TileObjectData.addAlternate(18);
            TileObjectData.addTile(Type);

            //TileObjectData.newTile.FullCopyFrom(TileID.Crystals);
        }

        /*public override void AnimateIndividualTile(int type, int i, int j, ref int frameXOffset, ref int frameYOffset) {
            // Tweak the frame drawn by x position so tiles next to each other are off-sync and look much more interesting.
            int uniqueAnimationFrame = Main.tileFrame[Type] + i;
            if (i % 2 == 0) {
                uniqueAnimationFrame += 3;
            }
            if (i % 3 == 0) {
                uniqueAnimationFrame += 3;
            }
            if (i % 4 == 0) {
                uniqueAnimationFrame += 3;
            }
            uniqueAnimationFrame = uniqueAnimationFrame % 6;

            frameXOffset = uniqueAnimationFrame * animationFrameWidth;
        }*/
    }
}