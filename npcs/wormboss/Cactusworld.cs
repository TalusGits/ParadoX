using System;
using System.Collections.Generic;
using System.IO;
using IL.Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.Generation;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.ObjectData;
using Terraria.World.Generation;
using Item = IL.Terraria.Item;
using ItemID = Terraria.ID.ItemID;
using Tile = IL.Terraria.Tile;
using TileID = Terraria.ID.TileID;
using Terraria.ID;
using Microsoft.Xna.Framework.Graphics;
using Terraria.DataStructures;
using Terraria.GameInput;
using static Terraria.ModLoader.ModContent;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.Localization;
using Terraria.World.Generation;
using gracosmod123.NPCs.wormboss;

namespace gracosmod123.NPCs.wormboss
{
    public class Cactusworld
    {

        private static bool TileCheckSafe(int i, int j)
        {
            if (i > 0 && i < Main.maxTilesX - 1 && j > 0 && j < Main.maxTilesY - 1)
            {
                if (TileID.Sets.BasicChest[Main.tile[i, j].type])
                    return false;
                return true;
            }
            return false;
        }

        public static void GenCrystals()
        {
            // if (Main.rand.Next(1) == 0) // 1 in 400 chance, TODO balance   
            // {
            //     Main.NewText("GenCrystals2");
            //     // Tries the location and if its air and touches pearlstone (type == 117) then it will spawn
            //     int x = WorldGen.genRand.Next(10, Main.maxTilesX - 10);
            //     int y = WorldGen.genRand.Next((int)WorldGen.worldSurfaceLow, Main.maxTilesY - 10);
            //     Main.NewText("GenCrystals3");
            //     if (Main.tile[x, y].type == TileID.DemonAltar) return;    // Avoid breaking demon alters since this blesses the world with hm ores
            //     Main.NewText("GenCrystals4");
            //     if ((WorldGen.SolidTile(x - 1, y) && Main.tile[x - 1, y].type == 117) ||
            //         (WorldGen.SolidTile(x + 1, y) && Main.tile[x + 1, y].type == 117) ||
            //         (WorldGen.SolidTile(x, y - 1) && Main.tile[x, y - 1].type == 117) ||
            //         (WorldGen.SolidTile(x, y + 1) && Main.tile[x, y + 1].type == 117))
            //     {
            //         Main.NewText("GenCrystals5");
            //         WorldGen.PlaceTile(x, y, ModContent.TileType<NPCs.wormboss.GlowingCrystal>(), false, false, -1,
            //             Main.rand.Next(18));    // Random style between 0-17, rotation is done automatically 8 is tile id
            //         Main.NewText("GenCrystals6");
            //     }
            // }
            for (int i = 0; i < Main.maxTilesX - 2; i += 15)
            {
                for (int j = 0; j < Main.maxTilesY - 2; j += 15)
                {
                    if (TileCheckSafe(i, j) && TileCheckSafe(i, j + 1))
                    {
                        if (Main.tile[i, j].wall == (ushort)187 && Main.tile[i, j + 1].type == (ushort)396 && Main.tile[i, j].type == 0 && Main.tile[i, j].active() == false)
                        {
                            if (Main.rand.Next(8) == 0)
                            {
                                WorldGen.PlaceTile(i, j, ModContent.TileType<NPCs.wormboss.GlowingCrystal>(), true, false, -1, Main.rand.Next(18));
                            }
                        }
                        else if (Main.tile[i, j].wall == (ushort)187 && Main.tile[i, j].type == (ushort)396)
                        {
                            if (Main.rand.Next(3) == 0)
                            {
                                if (TileCheckSafe(i, j - 1) && TileCheckSafe(i, j + 1) && TileCheckSafe(i, j - 2) && TileCheckSafe(i, j + 2)) ;
                            }
                        }
                    }
                }
            }
        }
    }
}