using Terraria.ID;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.IO;
using System.Linq;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameInput;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using static Terraria.ModLoader.ModContent;
using gracosmod123.npcs.ocean.oceanitems.oreaqua;
namespace gracosmod123
{
    public class oregentry
    {
        public static bool bysmal = false;
        private static readonly int[,] _bysmalBig = new int[,]
        {
            { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            { 0,0,0,0,0,0,0,0,0,0,0,0,1,1,0,0,1,1,1,1,1,0,0,1,1,0,0,0,0,0,0,0,0,0,0,0,0},
            { 0,0,0,0,0,0,0,0,0,0,1,0,1,1,0,1,1,1,1,1,1,1,0,1,1,0,1,0,0,0,0,0,0,0,0,0,0},
            { 0,0,0,0,0,0,0,0,0,0,1,1,1,0,0,0,1,1,1,1,1,0,0,0,1,1,1,0,0,0,0,0,0,0,0,0,0},
            { 0,0,0,0,0,0,0,0,0,0,0,1,1,0,0,0,0,0,1,0,0,0,0,0,1,1,0,0,0,0,0,0,0,0,0,0,0},
            { 0,0,1,0,0,0,0,0,0,0,0,1,1,0,0,0,0,0,1,0,0,0,0,0,1,1,0,0,0,0,0,0,0,0,1,0,0},
            { 0,0,1,1,1,0,0,0,0,0,0,0,1,1,0,0,0,0,1,0,0,0,0,1,1,0,0,0,0,0,0,0,1,1,1,0,0},
            { 0,0,0,0,1,1,1,0,0,0,0,0,1,1,0,0,0,1,1,1,0,0,0,1,1,0,0,0,0,0,1,1,1,0,0,0,0},
            { 0,0,0,0,0,1,1,0,0,0,0,0,1,1,0,0,0,0,1,0,0,0,0,1,1,0,0,0,0,0,1,1,0,0,0,0,0},
            { 0,0,0,0,0,0,1,1,0,0,0,0,0,1,0,0,0,0,1,0,0,0,0,1,0,0,0,0,0,1,1,0,0,0,0,0,0},
            { 0,0,0,0,0,0,0,1,0,0,0,0,0,1,0,0,0,0,1,0,0,0,0,1,0,0,0,0,0,1,0,0,0,0,0,0,0},
            { 0,0,0,0,0,0,0,1,1,0,0,0,0,1,1,0,0,0,1,0,0,0,1,1,0,0,0,0,1,1,0,0,0,0,0,0,0},
            { 0,0,0,0,0,0,0,1,1,0,0,0,0,1,1,0,0,0,1,0,0,0,1,1,0,0,0,0,1,1,0,0,0,0,0,0,0},
            { 0,0,0,0,0,0,0,0,1,1,0,0,0,1,1,0,0,0,1,0,0,0,1,1,0,0,0,1,1,0,0,0,0,0,0,0,0},
            { 0,0,0,0,0,1,1,1,1,1,1,1,1,1,1,1,1,0,1,0,1,1,1,1,1,1,1,1,1,1,1,1,0,0,0,0,0},
            { 0,0,0,0,0,0,0,0,1,1,0,0,0,0,1,0,0,0,1,0,0,0,1,0,0,0,0,1,1,0,0,0,0,0,0,0,0},
            { 0,0,0,0,0,0,0,0,1,1,0,0,0,0,1,0,0,0,1,0,0,0,1,0,0,0,0,1,1,0,0,0,0,0,0,0,0},
            { 0,0,0,0,0,0,0,0,1,1,0,0,0,0,1,0,0,0,1,0,0,0,1,0,0,0,0,1,1,0,0,0,0,0,0,0,0},
            { 0,0,0,0,0,0,0,0,1,1,0,0,0,1,1,0,0,0,1,0,0,0,1,1,0,0,0,1,1,0,0,0,0,0,0,0,0},
            { 0,0,0,0,0,1,1,1,1,1,1,1,1,1,1,1,1,0,1,0,1,1,1,1,1,1,1,1,1,1,1,1,0,0,0,0,0},
            { 0,0,0,0,0,0,0,1,1,0,0,0,0,1,0,0,0,0,1,0,0,0,0,1,0,0,0,0,1,1,0,0,0,0,0,0,0},
            { 0,0,0,0,0,0,1,1,0,0,0,0,1,1,0,0,0,0,1,0,0,0,0,1,1,0,0,0,0,1,1,0,0,0,0,0,0},
            { 0,0,0,0,0,0,1,1,0,0,0,0,1,1,0,0,0,0,1,0,0,0,0,1,1,0,0,0,0,1,1,0,0,0,0,0,0},
            { 0,0,0,0,1,1,1,0,0,0,0,0,1,0,0,0,0,0,1,0,0,0,0,0,1,0,0,0,0,0,1,1,1,0,0,0,0},
            { 0,0,0,1,1,1,0,0,0,0,0,1,1,0,0,0,0,0,1,0,0,0,0,0,1,1,0,0,0,0,0,1,1,1,0,0,0},
            { 1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,0,1,1,1,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
            { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,0,0,1,0,0,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,0,0,1,0,0,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,0,0,0,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},

        };

        private static readonly int[,] _bysmalMed = new int[,]
        {
            { 0,0,0,0,0,0,0,1,0,0,0,0,0,0,0},
            { 0,0,0,0,0,0,0,1,0,0,0,0,0,0,0},
            { 0,0,0,0,0,0,1,1,1,0,0,0,0,0,0},
            { 0,0,0,0,0,1,1,1,1,1,0,0,0,0,0},
            { 0,0,0,1,0,0,0,1,0,0,0,1,0,0,0},
            { 0,0,0,1,0,0,1,1,1,0,0,1,0,0,0},
            { 0,0,0,1,1,0,0,1,0,0,1,1,0,0,0},
            { 0,0,0,1,1,0,0,1,0,0,1,1,0,0,0},
            { 0,0,1,1,1,0,0,1,0,0,1,1,1,0,0},
            { 0,0,1,1,0,0,0,1,0,0,0,1,1,0,0},
            { 0,1,1,0,0,0,1,1,1,0,0,0,1,1,0},
            { 0,1,1,0,1,1,1,1,1,1,1,0,1,1,0},
            { 1,1,1,1,1,0,1,1,1,0,1,1,1,1,1},
            { 0,1,0,0,0,0,1,1,1,0,0,0,0,1,0},
            { 0,0,0,0,0,1,1,1,1,1,0,0,0,0,0},
            { 0,0,0,0,1,1,1,1,1,1,1,0,0,0,0},
            { 0,0,0,0,0,0,0,1,0,0,0,0,0,0,0},
            { 0,0,0,0,0,0,1,1,1,0,0,0,0,0,0},
            { 0,0,0,0,0,0,0,1,0,0,0,0,0,0,0},

        };

        private static readonly int[,] _bysmalSmall = new int[,]
        {
            { 0,0,0,0,1,0,0,0,0},
            { 0,0,0,1,1,1,0,0,0},
            { 1,0,0,0,1,0,0,0,1},
            { 1,1,0,0,1,0,0,1,1},
            { 0,1,0,0,1,0,0,1,0},
            { 0,1,0,1,1,1,0,1,0},
            { 1,1,1,1,1,1,1,1,1},
            { 0,1,0,0,1,0,0,1,0},
            { 0,0,0,0,1,0,0,0,0},
            { 0,0,0,1,1,1,0,0,0},
            { 0,0,0,0,1,0,0,0,0},


        };
        /**
         * 0 = Do Nothing
         * 1 = Bysmal
         * */
        public static void StructureGenBig(int xPosO, int yPosO)
        {
            for (int i = 0; i < _bysmalBig.GetLength(1); i++)
            {
                for (int j = 0; j < _bysmalBig.GetLength(0); j++)
                {
                    if (TileCheckSafe((int)(xPosO + i), (int)(yPosO + j)))
                    {
                        if (_bysmalBig[j, i] == 1)
                        {
                            WorldGen.KillTile(xPosO + i, yPosO + j);
                            WorldGen.PlaceTile(xPosO + i, yPosO + j, ModContent.TileType<npcs.ocean.oceanitems.oreaqua.blueblockore2>(), true, true);
                        }
                    }
                }
            }
        }

        public static void StructureGenMed(int xPosO, int yPosO)
        {
            for (int i = 0; i < _bysmalMed.GetLength(1); i++)
            {
                for (int j = 0; j < _bysmalMed.GetLength(0); j++)
                {
                    if (TileCheckSafe((int)(xPosO + i), (int)(yPosO + j)))
                    {
                        if (_bysmalMed[j, i] == 1)
                        {
                            WorldGen.KillTile(xPosO + i, yPosO + j);
                            WorldGen.PlaceTile(xPosO + i, yPosO + j, ModContent.TileType<npcs.ocean.oceanitems.oreaqua.blueblockore2>(), true, true);
                        }
                    }
                }
            }
        }

        public static void StructureGenSmall(int xPosO, int yPosO)
        {
            for (int i = 0; i < _bysmalSmall.GetLength(1); i++)
            {
                for (int j = 0; j < _bysmalSmall.GetLength(0); j++)
                {
                    if (TileCheckSafe((int)(xPosO + i), (int)(yPosO + j)))
                    {
                        if (_bysmalSmall[j, i] == 1)
                        {
                            WorldGen.KillTile(xPosO + i, yPosO + j);
                            WorldGen.PlaceTile(xPosO + i, yPosO + j, ModContent.TileType<npcs.ocean.oceanitems.oreaqua.blueblockore2>(), true, true);
                        }
                    }
                }
            }
        }

        private static bool TileCheckSafe(int i, int j)
        {
            int type = Main.tile[i, j].type;
            if (i > 0 && i < Main.maxTilesX - 1 && j > 0 && j < Main.maxTilesY - 1 && (type == TileID.Dirt || type == TileID.Stone || type == TileID.IceBlock || type == TileID.SnowBlock || type == TileID.Mud || type == TileID.Iron || type == TileID.Copper || type == TileID.Lead || type == TileID.Silver || type == TileID.WoodBlock || type == TileID.Sand || type == TileID.Ebonstone || type == TileID.Crimstone))
                return true;
            return false;
        }
    }
}