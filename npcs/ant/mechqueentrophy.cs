using Terraria.ModLoader;
using Terraria.ID;

namespace gracosmod123.NPCs.ant
{
    public class mechqueentrophy : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 30;
            Item.height = 30;
            Item.maxStack = 99;
            item.useTurn = true;
            Item.autoReuse = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
            item.useStyle = ItemUseStyleID.SwingThrow;
            Item.consumable = true;
            Item.value = 50000;
            Item.rare = ItemRarityID.Blue;
            Item.createTile = ModContent.TileType<mechqueentrophy2>();
            item.placeStyle = 0;
        }
    }
}/*
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;
using TerrariaOverhaul;

namespace Antiaris.Tiles.Decorations.Trophies
{
	public class AntlionQueenTrophy : ModTile
	{
	    public override void SetDefaults()
		{
			Main.tileFrameImportant[Type] = true;
			Main.tileLavaDeath[Type] = true;
			TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3Wall);
			TileObjectData.newTile.StyleHorizontal = true;
			TileObjectData.newTile.StyleWrapLimit = 36;
			TileObjectData.addTile(Type);
			dustType = 7;
			ModTranslation name = CreateMapEntryName();
			name.SetDefault("Trophy");
            name.AddTranslation(GameCulture.Russian, "Трофей");
			name.AddTranslation(GameCulture.Chinese, "荣誉之证");
            AddMapEntry(new Color(120, 85, 60), name);
		}

	    public void OverhaulInit()
        {
            this.SetTag("flammable");
        }

	    public override void KillMultiTile(int i, int j, int frameX, int frameY)
		{
			if(frameX == 0)
			{
				Item.NewItem(i * 16, j * 16, 48, 48, ModContent.ItemType("AntlionQueenTrophy"), 1, false, 0, false, false);
			}
		}
	}
}*/