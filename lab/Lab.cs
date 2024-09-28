using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.IO;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.Generation;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.World.Generation;
using System;
using System.Linq;
using static Terraria.ModLoader.ModContent;
namespace gracosmod123.lab
{
    public class Lab : ModWorld
    {
        public override void ModifyWorldGenTasks(List<GenPass> tasks, ref float totalWeight)
        {
            int genIndex = tasks.FindIndex(genpass => genpass.Name.Equals("Micro Biomes"));
            tasks.Insert(genIndex + 1, new PassLegacy("Dirt Blob", delegate (GenerationProgress progress)
            {
                //WorldGen.KillTile(x, y);
                //WorldGen.KillWall(x, y);
                //WorldGen.PlaceTile(x, y, TileID.);
                //WorldGen.PlaceWall(x, y, WallID.);
                //WorldGen.PlaceChest(x, y, 21, false);
                ////////house1
                ////////house1
                ////////house1
                ////////house1
                ////////house1
                ////////house1
                ////////house1
                ////////house1
                ////////house1
                ////////house1
                ////////house1
                ////////house1
                ////////house1
                ////////house1
                ////////house1
                ////////house1
                ////////house1
                ////////house1
                for (int i = 0; i < 10; i++)//loop for 10
                {
                    for (int j = 0; j < 10; j++)
                    {
                        WorldGen.KillTile(Main.spawnTileX + i, Main.spawnTileY + j + 50);//kills the area in a 10 block wide cube
                        WorldGen.KillTile(Main.spawnTileX - i, Main.spawnTileY + j + 50);//kills the area in a 10 block wide cube
                        WorldGen.KillTile(Main.spawnTileX + i, Main.spawnTileY - j + 50);//kills the area in a 10 block wide cube
                        WorldGen.KillTile(Main.spawnTileX - i, Main.spawnTileY - j + 50);//kills the area in a 10 block wide cube
                        WorldGen.KillWall(Main.spawnTileX + i, Main.spawnTileY + j + 50);//kills the area in a 10 block wide cube
                        WorldGen.KillWall(Main.spawnTileX - i, Main.spawnTileY + j + 50);//kills the area in a 10 block wide cube
                        WorldGen.KillWall(Main.spawnTileX + i, Main.spawnTileY - j + 50);//kills the area in a 10 block wide cube
                        WorldGen.KillWall(Main.spawnTileX - i, Main.spawnTileY - j + 50);//kills the area in a 10 block wide cube
                    }
                }
                for (int m = 0; m < 10; m++)
                {
                    for (int t = 0; t < 10; t++)
                    {
                        WorldGen.PlaceTile(Main.spawnTileX + m, Main.spawnTileY + 59, mod.TileType("labbrick"));//kills the area in a 10 block wide cube
                        WorldGen.PlaceTile(Main.spawnTileX - m, Main.spawnTileY + 59, mod.TileType("labbrick"));//kills the area in a 10 block wide cube
                        WorldGen.PlaceTile(Main.spawnTileX + m, Main.spawnTileY + 41, mod.TileType("labbrick"));//kills the area in a 10 block wide cube
                        WorldGen.PlaceTile(Main.spawnTileX - m, Main.spawnTileY + 41, mod.TileType("labbrick"));//kills the area in a 10 block wide cube
                        WorldGen.PlaceTile(Main.spawnTileX - 9, Main.spawnTileY + 41 + m, mod.TileType("labbrick"));//kills the area in a 10 block wide cube
                        WorldGen.PlaceTile(Main.spawnTileX + 9, Main.spawnTileY + 41 + m, mod.TileType("labbrick"));//kills the area in a 10 block wide cube
                        WorldGen.PlaceTile(Main.spawnTileX - 9, Main.spawnTileY + 59 - m, mod.TileType("labbrick"));//kills the area in a 10 block wide cube
                        WorldGen.PlaceTile(Main.spawnTileX + 9, Main.spawnTileY + 59 - m, mod.TileType("labbrick"));//kills the area in a 10 block wide cube

                        WorldGen.PlaceWall(Main.spawnTileX + m, Main.spawnTileY + t + 50, mod.WallType("labwall"));//kills the area in a 10 block wide cube
                        WorldGen.PlaceWall(Main.spawnTileX - m, Main.spawnTileY + t + 50, mod.WallType("labwall"));//kills the area in a 10 block wide cube
                        WorldGen.PlaceWall(Main.spawnTileX + m, Main.spawnTileY - t + 50, mod.WallType("labwall"));//kills the area in a 10 block wide cube
                        WorldGen.PlaceWall(Main.spawnTileX - m, Main.spawnTileY - t + 50, mod.WallType("labwall"));//kills the area in a 10 block wide cube
                    }

                }
                for (int pltfrm = 0; pltfrm < 18; pltfrm++)
                {
                    WorldGen.PlaceTile(Main.spawnTileX - 9 + pltfrm, Main.spawnTileY + 51, mod.TileType("labplatform"));//places a 18 piece long platform across the middle
                }
                WorldGen.KillTile(Main.spawnTileX - 7, Main.spawnTileY + 51);//kills the blocks on the platforms
                WorldGen.KillTile(Main.spawnTileX + 7, Main.spawnTileY + 51);//kills the blocks on the platforms

                WorldGen.KillTile(Main.spawnTileX + 9, Main.spawnTileY + 56);//kills the blocks on the platforms//8
                WorldGen.KillTile(Main.spawnTileX + 9, Main.spawnTileY + 57);//kills the blocks on the platforms//9
                WorldGen.KillTile(Main.spawnTileX + 9, Main.spawnTileY + 58);//kills the blocks on the platforms//10
                WorldGen.KillTile(Main.spawnTileX - 9, Main.spawnTileY + 56);//kills the blocks on the platforms//8
                WorldGen.KillTile(Main.spawnTileX - 9, Main.spawnTileY + 57);//kills the blocks on the platforms//9
                WorldGen.KillTile(Main.spawnTileX - 9, Main.spawnTileY + 58);//kills the blocks on the platforms//10
                WorldGen.PlaceTile(Main.spawnTileX + 9, Main.spawnTileY + 56, mod.TileType("labdoorclosed"));//places the door 56
                WorldGen.PlaceTile(Main.spawnTileX - 9, Main.spawnTileY + 56, mod.TileType("labdoorclosed"));//places the door 56
                WorldGen.PlaceTile(Main.spawnTileX - 7, Main.spawnTileY + 51, mod.TileType("labbrick"));//places bricks
                WorldGen.PlaceTile(Main.spawnTileX + 7, Main.spawnTileY + 51, mod.TileType("labbrick"));//places bricks
                WorldGen.PlaceTile(Main.spawnTileX - 7, Main.spawnTileY + 42, mod.TileType("lablantern"));//places top lanterns
                WorldGen.PlaceTile(Main.spawnTileX + 7, Main.spawnTileY + 42, mod.TileType("lablantern"));//places top lanterns
                WorldGen.PlaceTile(Main.spawnTileX - 7, Main.spawnTileY + 52, mod.TileType("lablantern"));//places lanterns
                WorldGen.PlaceTile(Main.spawnTileX + 7, Main.spawnTileY + 52, mod.TileType("lablantern"));//places lanterns
                ////////house1
                ////////house1
                ////////house1
                ////////house1
                ////////house1
                ////////house1
                ////////house1
                ////////house1
                ////////house1
                ////////house1
                ////////house1
                ////////house1
                ////////house1
                ////////house1
                ////////house1
                ////////house1
                ////////house1
                ////////house1
                int num = 26;
                for (int i = 0; i < 10; i++)//loop for 10
                {
                    for (int j = 0; j < 10; j++)
                    {
                        WorldGen.KillTile(Main.spawnTileX + i+ num, Main.spawnTileY + j + 50);//kills the area in a 10 block wide cube
                        WorldGen.KillTile(Main.spawnTileX - i+ num, Main.spawnTileY + j + 50);//kills the area in a 10 block wide cube
                        WorldGen.KillTile(Main.spawnTileX + i+ num, Main.spawnTileY - j + 50);//kills the area in a 10 block wide cube
                        WorldGen.KillTile(Main.spawnTileX - i+ num, Main.spawnTileY - j + 50);//kills the area in a 10 block wide cube
                        WorldGen.KillWall(Main.spawnTileX + i+ num, Main.spawnTileY + j + 50);//kills the area in a 10 block wide cube
                        WorldGen.KillWall(Main.spawnTileX - i+ num, Main.spawnTileY + j + 50);//kills the area in a 10 block wide cube
                        WorldGen.KillWall(Main.spawnTileX + i+ num, Main.spawnTileY - j + 50);//kills the area in a 10 block wide cube
                        WorldGen.KillWall(Main.spawnTileX - i+ num, Main.spawnTileY - j + 50);//kills the area in a 10 block wide cube
                    }
                }
                for (int m = 0; m < 10; m++)
                {
                    for (int t = 0; t < 10; t++)
                    {
                        WorldGen.PlaceTile(Main.spawnTileX + m+ num, Main.spawnTileY + 59, mod.TileType("labbrick"));//kills the area in a 10 block wide cube
                        WorldGen.PlaceTile(Main.spawnTileX - m+ num, Main.spawnTileY + 59, mod.TileType("labbrick"));//kills the area in a 10 block wide cube
                        WorldGen.PlaceTile(Main.spawnTileX + m+ num, Main.spawnTileY + 41, mod.TileType("labbrick"));//kills the area in a 10 block wide cube
                        WorldGen.PlaceTile(Main.spawnTileX - m+ num, Main.spawnTileY + 41, mod.TileType("labbrick"));//kills the area in a 10 block wide cube
                        WorldGen.PlaceTile(Main.spawnTileX - 9+ num, Main.spawnTileY + 41 + m, mod.TileType("labbrick"));//kills the area in a 10 block wide cube
                        WorldGen.PlaceTile(Main.spawnTileX + 9+ num, Main.spawnTileY + 41 + m, mod.TileType("labbrick"));//kills the area in a 10 block wide cube
                        WorldGen.PlaceTile(Main.spawnTileX - 9+ num, Main.spawnTileY + 59 - m, mod.TileType("labbrick"));//kills the area in a 10 block wide cube
                        WorldGen.PlaceTile(Main.spawnTileX + 9+ num, Main.spawnTileY + 59 - m, mod.TileType("labbrick"));//kills the area in a 10 block wide cube

                        WorldGen.PlaceWall(Main.spawnTileX + m+ num, Main.spawnTileY + t + 50, mod.WallType("labwall"));//kills the area in a 10 block wide cube
                        WorldGen.PlaceWall(Main.spawnTileX - m+ num, Main.spawnTileY + t + 50, mod.WallType("labwall"));//kills the area in a 10 block wide cube
                        WorldGen.PlaceWall(Main.spawnTileX + m+ num, Main.spawnTileY - t + 50, mod.WallType("labwall"));//kills the area in a 10 block wide cube
                        WorldGen.PlaceWall(Main.spawnTileX - m+ num, Main.spawnTileY - t + 50, mod.WallType("labwall"));//kills the area in a 10 block wide cube
                    }

                }
                for (int pltfrm = 0; pltfrm < 18; pltfrm++)
                {
                    WorldGen.PlaceTile(Main.spawnTileX - 9 + pltfrm+ num, Main.spawnTileY + 51, mod.TileType("labplatform"));//places a 18 piece long platform across the middle
                }
                WorldGen.KillTile(Main.spawnTileX - 7+ num, Main.spawnTileY + 51);//kills the blocks on the platforms
                WorldGen.KillTile(Main.spawnTileX + 7+ num, Main.spawnTileY + 51);//kills the blocks on the platforms

                WorldGen.KillTile(Main.spawnTileX + 9+ num, Main.spawnTileY + 56);//kills the blocks on the platforms//8
                WorldGen.KillTile(Main.spawnTileX + 9+ num, Main.spawnTileY + 57);//kills the blocks on the platforms//9
                WorldGen.KillTile(Main.spawnTileX + 9+ num, Main.spawnTileY + 58);//kills the blocks on the platforms//10
                WorldGen.KillTile(Main.spawnTileX - 9+ num, Main.spawnTileY + 56);//kills the blocks on the platforms//8
                WorldGen.KillTile(Main.spawnTileX - 9+ num, Main.spawnTileY + 57);//kills the blocks on the platforms//9
                WorldGen.KillTile(Main.spawnTileX - 9+ num, Main.spawnTileY + 58);//kills the blocks on the platforms//10
                WorldGen.PlaceTile(Main.spawnTileX + 9+ num, Main.spawnTileY + 56, mod.TileType("labdoorclosed"));//places the door
                WorldGen.PlaceTile(Main.spawnTileX - 9+ num, Main.spawnTileY + 56, mod.TileType("labdoorclosed"));//places the door
                WorldGen.PlaceTile(Main.spawnTileX - 7+ num, Main.spawnTileY + 51, mod.TileType("labbrick"));//places bricks
                WorldGen.PlaceTile(Main.spawnTileX + 7+ num, Main.spawnTileY + 51, mod.TileType("labbrick"));//places bricks
                WorldGen.PlaceTile(Main.spawnTileX - 7+ num, Main.spawnTileY + 42, mod.TileType("lablantern"));//places top lanterns
                WorldGen.PlaceTile(Main.spawnTileX + 7+ num, Main.spawnTileY + 42, mod.TileType("lablantern"));//places top lanterns
                WorldGen.PlaceTile(Main.spawnTileX - 7+ num, Main.spawnTileY + 52, mod.TileType("lablantern"));//places lanterns
                WorldGen.PlaceTile(Main.spawnTileX + 7+ num, Main.spawnTileY + 52, mod.TileType("lablantern"));//places lanterns

            }));
        }
    }
}
