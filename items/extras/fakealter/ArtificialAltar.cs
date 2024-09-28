using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ObjectData;

namespace gracosmod123.items.extras.fakealter
{
    public class ArtificialAltar : ModTile
    {
        public override void SetDefaults()
        {
			Main.tileLighted[Type] = true;
			Main.tileFrameImportant[Type] = true;
			Main.tileNoAttach[Type] = true;
			Main.tileLavaDeath[Type] = true;
			TileObjectData.newTile.CopyFrom(TileObjectData.Style3x4);
			TileObjectData.newTile.CoordinateHeights = new int[]{ 16, 16, 16, 18 };
			TileObjectData.newTile.StyleHorizontal = true;
			TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
			TileObjectData.addTile(Type);
			ModTranslation name = CreateMapEntryName();
			name.SetDefault("THE ALTER");
            AddMapEntry(new Color(200, 200, 200), name);
			disableSmartCursor = true;
			adjTiles = new int[]
			{
			TileID.WorkBenches, 
			TileID.Anvils, 
			TileID.Furnaces, 
			TileID.Hellforge, 
			TileID.Bookcases,
			TileID.Sinks,
			TileID.Solidifier,
			TileID.Blendomatic,
			TileID.MeatGrinder,
			TileID.Loom,
			TileID.LivingLoom,
			TileID.FleshCloningVat,
			TileID.GlassKiln,
			TileID.BoneWelder,
			TileID.SteampunkBoiler,
			TileID.Bottles,
			TileID.LihzahrdFurnace,
			TileID.ImbuingStation,
			TileID.DyeVat,
			TileID.Kegs,
			TileID.HeavyWorkBench,
			TileID.Tables, 
			TileID.Chairs,
			TileID.CookingPots,
			TileID.DemonAltar, 
			TileID.Sawmill,
			TileID.CrystalBall, 
			TileID.AdamantiteForge, 
			TileID.MythrilAnvil,
			TileID.TinkerersWorkbench,
			TileID.Autohammer,
			TileID.IceMachine,
			TileID.SkyMill,
			TileID.HoneyDispenser,
			TileID.AlchemyTable,
			TileID.LunarCraftingStation
			};
			dustType = ModContent.DustType("JustitiaPale");
			animationFrameHeight = 74;
        }

        public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
        {
            Tile tile = Main.tile[i, j];
            if (tile.frameX < 66)
            {
                r = 0.9f;
                g = 0.3f;
                b = 0.3f;
            }
        }
        public override void NumDust(int i, int j, bool fail, ref int num)
        {
            num = fail ? 1 : 3;
        }

        public override void AnimateTile(ref int frame, ref int frameCounter)
        {
            frame = Main.tileFrame[TileID.FireflyinaBottle];
            frameCounter = Main.tileFrameCounter[TileID.FireflyinaBottle];
        }
		public override void NearbyEffects(int i, int j, bool closer)
        {
            Player player = Main.player[Main.myPlayer];
            player.alchemyTable = true;
		}
        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            Item.NewItem(i * 16, j * 16, 32, 16, ModContent.ItemType("alter"));
        }
    }
}