using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace gracosmod123.devitems.mumboscomputer
{
    public class mumutertile : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileSolidTop[Type] = false;
            Main.tileFrameImportant[Type] = true;
            Main.tileNoAttach[Type] = true;
            Main.tileTable[Type] = true;
            Main.tileContainer[Type] = true;
            Main.tileLavaDeath[Type] = false;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style5x4);
            TileObjectData.newTile.Origin = new Point16(1, 1);
            TileObjectData.newTile.CoordinateHeights = new[] { 16, 16, 16, 16 };
            TileObjectData.newTile.AnchorInvalidTiles = new[] { 127 };
            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.newTile.DrawYOffset = 2;
            TileObjectData.addTile(Type);
            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Talus's Computer");
            AddMapEntry(new Color(75, 75, 50), name);
            disableSmartCursor = true;
            Main.tileLighted[Type] = true;
            dustType = mod.DustType("labdust");
        }

        public override void NumDust(int i, int j, bool fail, ref int num)
        {
            num = fail ? 1 : 3;
        }

        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            Item.NewItem(i * 16, j * 16, 48, 32, mod.ItemType("mumuter"));
        }
        public override void RightClick(int i, int j)
        {
            Player player = Main.LocalPlayer;
            //QwertyMethods.ServerClientCheck();
            if (!NPC.AnyNPCs(mod.NPCType("FortressBoss")))
            {
                for (int b = 0; b < 58; b++) // this searches every invintory slot
                {
                    if (player.inventory[b].type == mod.ItemType("FortressBossSummon") && player.inventory[b].stack > 0) //this checks if the slot has the valid item
                    {
                        if (Main.netMode == 0)
                        {
                            int npcID = NPC.NewNPC(i * 16 + 400, j * 16, mod.NPCType("FortressBoss"));
                        }
                        else
                        {
                            ModPacket packet = mod.GetPacket();
                            packet.WriteVector2(new Vector2(i * 16 + 400, j * 16));
                            packet.Send();
                        }

                        player.inventory[b].stack--;
                        break;
                    }
                }
            }
        }

        public override void MouseOver(int i, int j)
        {
            Player player = Main.LocalPlayer;
            player.noThrow = 2;
            player.showItemIcon = true;
            player.showItemIcon2 = mod.ItemType("FortressBossSummon");
        }
    }
}