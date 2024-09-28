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
namespace gracosmod123.items.enchantedstuff.ore
{
    public class oregen : ModWorld
    {
        private static bool GenerateSnowHouse = false;

		public override void ModifyWorldGenTasks(List<GenPass> tasks, ref float totalWeight) {
			// Because world generation is like layering several images ontop of each other, we need to do some steps between the original world generation steps.

			// The first step is an Ore. Most vanilla ores are generated in a step called "Shinies", so for maximum compatibility, we will also do this.
			// First, we find out which step "Shinies" is.
			int ShiniesIndex = tasks.FindIndex(genpass => genpass.Name.Equals("Shinies"));
			if (ShiniesIndex != -1) {
				// Next, we insert our step directly after the original "Shinies" step. 
				// ExampleModOres is a method seen below.
				tasks.Insert(ShiniesIndex + 1, new PassLegacy("Example Mod Ores", ExampleModOres));
			} 
			
            if (GetInstance<ServerConfig>().Houser)
            {
			int genIndex = tasks.FindIndex(genpass => genpass.Name.Equals("Micro Biomes"));
    		tasks.Insert(genIndex + 1, new PassLegacy("Dirt Blob", delegate (GenerationProgress progress)
    		{

				//makes the house and walls and clears the area
				//makes the house and walls and clears the area
				//makes the house and walls and clears the area
				//makes the house and walls and clears the area
				//makes the house and walls and clears the area
				//makes the house and walls and clears the area
				//makes the house and walls and clears the area
				for (int i = 0; i < 12; i++)
				{
				WorldGen.KillTile(Main.spawnTileX + i, Main.spawnTileY-6);
				WorldGen.KillTile(Main.spawnTileX - i, Main.spawnTileY-6);
				WorldGen.KillTile(Main.spawnTileX + i, Main.spawnTileY-5);
				WorldGen.KillTile(Main.spawnTileX - i, Main.spawnTileY-5);
				WorldGen.KillTile(Main.spawnTileX + i, Main.spawnTileY-4);
				WorldGen.KillTile(Main.spawnTileX - i, Main.spawnTileY-4);
				WorldGen.KillTile(Main.spawnTileX + i, Main.spawnTileY-3);
				WorldGen.KillTile(Main.spawnTileX - i, Main.spawnTileY-3);
				WorldGen.KillTile(Main.spawnTileX + i, Main.spawnTileY-2);
				WorldGen.KillTile(Main.spawnTileX - i, Main.spawnTileY-2);
				WorldGen.KillTile(Main.spawnTileX + i, Main.spawnTileY-1);
				WorldGen.KillTile(Main.spawnTileX - i, Main.spawnTileY-1);
   				WorldGen.KillTile(Main.spawnTileX + i, Main.spawnTileY);
				WorldGen.KillTile(Main.spawnTileX - i, Main.spawnTileY);
				WorldGen.KillTile(Main.spawnTileX + 12, Main.spawnTileY - i);
				WorldGen.KillTile(Main.spawnTileX - 12, Main.spawnTileY - i);
				WorldGen.KillTile(Main.spawnTileX + 13, Main.spawnTileY - i);
				WorldGen.KillTile(Main.spawnTileX - 13, Main.spawnTileY - i);
				WorldGen.KillWall(Main.spawnTileX + i, Main.spawnTileY - 6);
				WorldGen.KillWall(Main.spawnTileX - i, Main.spawnTileY - 6);
				WorldGen.KillWall(Main.spawnTileX + i, Main.spawnTileY - 5);
				WorldGen.KillWall(Main.spawnTileX - i, Main.spawnTileY - 5);
				WorldGen.KillWall(Main.spawnTileX + i, Main.spawnTileY - 4);
				WorldGen.KillWall(Main.spawnTileX - i, Main.spawnTileY - 4);
				WorldGen.KillWall(Main.spawnTileX + i, Main.spawnTileY - 3);
				WorldGen.KillWall(Main.spawnTileX - i, Main.spawnTileY - 3);
				WorldGen.KillWall(Main.spawnTileX + i, Main.spawnTileY - 2);
				WorldGen.KillWall(Main.spawnTileX - i, Main.spawnTileY - 2);
				WorldGen.KillWall(Main.spawnTileX + i, Main.spawnTileY - 1);
				WorldGen.KillWall(Main.spawnTileX - i, Main.spawnTileY - 1);
				WorldGen.KillWall(Main.spawnTileX + i, Main.spawnTileY);
				WorldGen.KillWall(Main.spawnTileX - i, Main.spawnTileY);
				WorldGen.KillWall(Main.spawnTileX + 12, Main.spawnTileY - i);
				WorldGen.KillWall(Main.spawnTileX - 12, Main.spawnTileY - i);
				WorldGen.KillWall(Main.spawnTileX + 13, Main.spawnTileY - i);
				WorldGen.KillWall(Main.spawnTileX - 13, Main.spawnTileY - i);	
				}
				for (int i = 0; i < 12; i++)
				{
					//kills
					WorldGen.KillTile(Main.spawnTileX + 12, Main.spawnTileY - i);
					WorldGen.KillTile(Main.spawnTileX - 12, Main.spawnTileY - i);
					WorldGen.KillTile(Main.spawnTileX + 13, Main.spawnTileY - i);
					WorldGen.KillTile(Main.spawnTileX - 13, Main.spawnTileY - i);
					WorldGen.KillWall(Main.spawnTileX + 12, Main.spawnTileY - i);
					WorldGen.KillWall(Main.spawnTileX - 12, Main.spawnTileY - i);
					WorldGen.KillWall(Main.spawnTileX + 13, Main.spawnTileY - i);
					WorldGen.KillWall(Main.spawnTileX - 13, Main.spawnTileY - i);	
					WorldGen.KillTile(Main.spawnTileX + i, Main.spawnTileY-i);
					WorldGen.KillTile(Main.spawnTileX - i, Main.spawnTileY-i);
					WorldGen.KillWall(Main.spawnTileX + i, Main.spawnTileY - i);
					WorldGen.KillWall(Main.spawnTileX - i, Main.spawnTileY - i);
					//kills
				    WorldGen.PlaceTile(Main.spawnTileX + i, Main.spawnTileY, TileID.WoodBlock);
					WorldGen.PlaceTile(Main.spawnTileX - i, Main.spawnTileY, TileID.WoodBlock);
					WorldGen.PlaceTile(Main.spawnTileX + i, Main.spawnTileY+1, TileID.WoodBlock);
					WorldGen.PlaceTile(Main.spawnTileX - i, Main.spawnTileY+1, TileID.WoodBlock);
					WorldGen.PlaceTile(Main.spawnTileX + i, Main.spawnTileY-12, TileID.WoodBlock);
					WorldGen.PlaceTile(Main.spawnTileX - i, Main.spawnTileY-12, TileID.WoodBlock);
					WorldGen.PlaceTile(Main.spawnTileX - 12, Main.spawnTileY - i, TileID.WoodBlock);
					WorldGen.PlaceTile(Main.spawnTileX + 12, Main.spawnTileY - i, TileID.WoodBlock);
				}
				WorldGen.PlaceTile(Main.spawnTileX + 11, Main.spawnTileY - 10, TileID.Torches);//torches
				WorldGen.PlaceTile(Main.spawnTileX - 11, Main.spawnTileY - 10, TileID.Torches);//torches
				WorldGen.PlaceTile(Main.spawnTileX + 11, Main.spawnTileY - 5, TileID.Torches);//torches
				WorldGen.PlaceTile(Main.spawnTileX - 11, Main.spawnTileY - 5, TileID.Torches);//torches
				WorldGen.KillTile(Main.spawnTileX - 12, Main.spawnTileY - 3);//doorspace
				WorldGen.KillTile(Main.spawnTileX - 12, Main.spawnTileY - 2);//doorspace
				WorldGen.KillTile(Main.spawnTileX - 12, Main.spawnTileY - 1);//doorspace
				WorldGen.KillTile(Main.spawnTileX + 12, Main.spawnTileY - 3);//doorspace
				WorldGen.KillTile(Main.spawnTileX + 12, Main.spawnTileY - 2);//doorspace
				WorldGen.KillTile(Main.spawnTileX + 12, Main.spawnTileY - 1);//doorspace
				WorldGen.PlaceTile(Main.spawnTileX - 12, Main.spawnTileY - 1, TileID.ClosedDoor);//door
				WorldGen.PlaceTile(Main.spawnTileX + 12, Main.spawnTileY - 1, TileID.ClosedDoor);//door
				for (int m = 0; m < 10; m++)
				{
					WorldGen.PlaceTile(Main.spawnTileX + m, Main.spawnTileY - 6, TileID.Platforms);//plat
					WorldGen.PlaceTile(Main.spawnTileX - m, Main.spawnTileY - 6, TileID.Platforms);//plat
				}
				WorldGen.PlaceTile(Main.spawnTileX - 9, Main.spawnTileY - 7, TileID.Torches);//torches
				for (int p = 0; p < 10; p=p+2)
				{
				WorldGen.PlaceChest(Main.spawnTileX-p, Main.spawnTileY-7, 21, false);
				WorldGen.PlaceChest(Main.spawnTileX+p, Main.spawnTileY-7, 21, false);	
				}
				for (int f = 0; f < 12; f++)
				{
					for (int j = 0; j < 12; j++)
					{
					WorldGen.PlaceWall(Main.spawnTileX + f, Main.spawnTileY+j, WallID.Wood);
					WorldGen.PlaceWall(Main.spawnTileX - f, Main.spawnTileY-j, WallID.Wood);	
					WorldGen.PlaceWall(Main.spawnTileX + f, Main.spawnTileY-j, WallID.Wood);
					WorldGen.PlaceWall(Main.spawnTileX - f, Main.spawnTileY+j, WallID.Wood);		
					}	
				}
				//WorldGen.PlaceTile(Main.spawnTileX - 6, Main.spawnTileY -1, TileID.Chairs);//plat
				WorldGen.PlaceTile(Main.spawnTileX - 2, Main.spawnTileY -1, TileID.Chairs);//plat
				WorldGen.PlaceTile(Main.spawnTileX - 4, Main.spawnTileY -1, TileID.Tables);//plat
				////////////attic
				WorldGen.PlaceTile(Main.spawnTileX - 3, Main.spawnTileY -13, TileID.Tables);//plat
				WorldGen.PlaceTile(Main.spawnTileX - 3, Main.spawnTileY -15, TileID.Candles);//plat
				WorldGen.PlaceTile(Main.spawnTileX + 5, Main.spawnTileY - 13, TileID.Torches);//torches

				WorldGen.KillTile(Main.spawnTileX +4, Main.spawnTileY - 12);//doorspace
				WorldGen.KillTile(Main.spawnTileX +3, Main.spawnTileY - 12);//doorspace
				WorldGen.KillTile(Main.spawnTileX +2, Main.spawnTileY - 12);//doorspace
				WorldGen.PlaceTile(Main.spawnTileX +4, Main.spawnTileY - 12, TileID.Platforms);//plat
				WorldGen.PlaceTile(Main.spawnTileX +3, Main.spawnTileY - 12, TileID.Platforms);//plat
				WorldGen.PlaceTile(Main.spawnTileX +2, Main.spawnTileY - 12, TileID.Platforms);//plat 1474

				WorldGen.PlaceChest(Main.spawnTileX + 7, Main.spawnTileY -13, 21, false);	
				///////////attic

				if (GetInstance<ServerConfig>().Crafters)//Crafters
            	{
				WorldGen.PlaceTile(Main.spawnTileX + 3, Main.spawnTileY -1, TileID.WorkBenches);//plat
				WorldGen.PlaceTile(Main.spawnTileX + 5, Main.spawnTileY -1, TileID.Anvils);//plat
				WorldGen.PlaceTile(Main.spawnTileX + 8, Main.spawnTileY -1, TileID.Furnaces);//plat
				WorldGen.PlaceTile(Main.spawnTileX + 4, Main.spawnTileY -2, TileID.Candles);//plat
				WorldGen.PlaceTile(Main.spawnTileX - 3, Main.spawnTileY -3, TileID.Bottles);//plat
				}
				if (GetInstance<ServerConfig>().Bags)//Crafters
            	{
				WorldGen.PlaceTile(Main.spawnTileX - 4, Main.spawnTileY -3, ModContent.TileType<RobberSack1>());//plat
				}
				/*Main.tile[Main.spawnTileX + 12, Main.spawnTileY - 12].slope(2);
				WorldGen.PlaceTile(Main.spawnTileX + 12, Main.spawnTileY - 12, TileID.WoodBlock);//edges to house1
				Main.tile[Main.spawnTileX - 12, Main.spawnTileY - 12].slope(2);
				WorldGen.PlaceTile(Main.spawnTileX - 12, Main.spawnTileY - 12, TileID.WoodBlock);//edges to house1*/
				for (int y = 0; y < 13; y++)
				{
					WorldGen.PlaceTile(Main.spawnTileX + 12-y, Main.spawnTileY - 12-y, TileID.WoodBlock);//edges to house1	
					WorldGen.PlaceTile(Main.spawnTileX - 12+y, Main.spawnTileY - 12-y, TileID.WoodBlock);//edges to house1
					WorldGen.PlaceTile(Main.spawnTileX + 11-y, Main.spawnTileY - 12-y, TileID.WoodBlock);//edges to house1	
					WorldGen.PlaceTile(Main.spawnTileX - 11+y, Main.spawnTileY - 12-y, TileID.WoodBlock);//edges to house1
					for (int wall = 0; wall < 12; wall++)
					{
						WorldGen.PlaceWall(Main.spawnTileX + wall-y, Main.spawnTileY - wall-y, WallID.Wood);
						WorldGen.PlaceWall(Main.spawnTileX - wall+y, Main.spawnTileY - wall-y, WallID.Wood);
						WorldGen.PlaceWall(Main.spawnTileX + wall-y-1, Main.spawnTileY - wall-y, WallID.Wood);
						WorldGen.PlaceWall(Main.spawnTileX - wall+y-1, Main.spawnTileY - wall-y, WallID.Wood);
						WorldGen.PlaceWall(Main.spawnTileX + wall-y+1, Main.spawnTileY - wall-y, WallID.Wood);
						WorldGen.PlaceWall(Main.spawnTileX - wall+y+1, Main.spawnTileY - wall-y, WallID.Wood);

					}
		
				}
				for (int mac = 0; mac < 12; mac++)
				{
					WorldGen.KillWall(Main.spawnTileX + 12-mac, Main.spawnTileY - 12-mac);
					WorldGen.KillWall(Main.spawnTileX - 12+mac, Main.spawnTileY - 12-mac);
					WorldGen.KillWall(Main.spawnTileX + 13-mac, Main.spawnTileY - 13-mac);
					WorldGen.KillWall(Main.spawnTileX - 13+mac, Main.spawnTileY - 13-mac);
					WorldGen.KillWall(Main.spawnTileX + 14-mac, Main.spawnTileY - 14-mac);
					WorldGen.KillWall(Main.spawnTileX - 14+mac, Main.spawnTileY - 14-mac);
					WorldGen.KillWall(Main.spawnTileX + 12-mac-1, Main.spawnTileY - 12-mac);
					WorldGen.KillWall(Main.spawnTileX - 12+mac-1, Main.spawnTileY - 12-mac);
					WorldGen.KillWall(Main.spawnTileX + 13-mac-1, Main.spawnTileY - 13-mac);
					WorldGen.KillWall(Main.spawnTileX - 13+mac-1, Main.spawnTileY - 13-mac);
					WorldGen.KillWall(Main.spawnTileX + 14-mac-1, Main.spawnTileY - 14-mac);
					WorldGen.KillWall(Main.spawnTileX - 14+mac-1, Main.spawnTileY - 14-mac);

					WorldGen.KillWall(Main.spawnTileX + 12-mac+1, Main.spawnTileY - 12-mac);
					WorldGen.KillWall(Main.spawnTileX - 12+mac+1, Main.spawnTileY - 12-mac);
					WorldGen.KillWall(Main.spawnTileX + 13-mac+1, Main.spawnTileY - 13-mac);
					WorldGen.KillWall(Main.spawnTileX - 13+mac+1, Main.spawnTileY - 13-mac);
					WorldGen.KillWall(Main.spawnTileX + 14-mac+1, Main.spawnTileY - 14-mac);
					WorldGen.KillWall(Main.spawnTileX - 14+mac+1, Main.spawnTileY - 14-mac);

				}
				WorldGen.KillWall(Main.spawnTileX + 12, Main.spawnTileY - 11);
				WorldGen.KillWall(Main.spawnTileX - 12, Main.spawnTileY - 11);
				WorldGen.PlaceTile(Main.spawnTileX + 3, Main.spawnTileY - 19, TileID.Torches);//torches
				WorldGen.PlaceTile(Main.spawnTileX - 3, Main.spawnTileY - 19, TileID.Torches);//torches
				WorldGen.PlaceTile(Main.spawnTileX - 13, Main.spawnTileY - 4, TileID.WoodBlock);//torches
				WorldGen.PlaceTile(Main.spawnTileX + 13, Main.spawnTileY - 4, TileID.WoodBlock);//torches
				WorldGen.PlaceTile(Main.spawnTileX - 13, Main.spawnTileY - 3, 42);//Lanterns
				WorldGen.PlaceTile(Main.spawnTileX + 13, Main.spawnTileY - 3, 42);//lanterns
				for (int burger = 0; burger < 12; burger++)
				{
					for (int pigz = 1; pigz < 6; pigz++)
					{
						WorldGen.KillTile(Main.spawnTileX + burger, Main.spawnTileY+pigz);
						WorldGen.KillTile(Main.spawnTileX - burger, Main.spawnTileY+pigz);
					}
				}
				for (int bacon = 0; bacon < 12; bacon++)
				{
					for (int cheese = 1; cheese < 6; cheese++)
					{
						WorldGen.PlaceTile(Main.spawnTileX + bacon, Main.spawnTileY+cheese, TileID.WoodBlock);
						WorldGen.PlaceTile(Main.spawnTileX - bacon, Main.spawnTileY+cheese, TileID.WoodBlock);
					}
				}
				WorldGen.KillTile(Main.spawnTileX + 1, Main.spawnTileY-24);
				WorldGen.KillTile(Main.spawnTileX - 1, Main.spawnTileY-24);
				//makes the house and walls and clears the area
				//makes the house and walls and clears the area
				//makes the house and walls and clears the area
				//makes the house and walls and clears the area
				//makes the house and walls and clears the area
				//makes the house and walls and clears the area
				//makes the house and walls and clears the area
				/*TileID.Tables);
						if (x == 2) //Chair
							WorldGen.PlaceTile(xPosition, yPosition, TileID.Chairs*/
			}));
			}
		}
			
	

		private void ExampleModOres(GenerationProgress progress) {
			// progress.Message is the message shown to the user while the following code is running. Try to make your message clear. You can be a little bit clever, but make sure it is descriptive enough for troubleshooting purposes. 
			progress.Message = "Enchanted Ore";

			// Ores are quite simple, we simply use a for loop and the WorldGen.TileRunner to place splotches of the specified Tile in the world.
			// "6E-05" is "scientific notation". It simply means 0.00006 but in some ways is easier to read.
			for (int k = 0; k < (int)((Main.maxTilesX * Main.maxTilesY) * 6E-05); k++) {
				// The inside of this for loop corresponds to one single splotch of our Ore.
				// First, we randomly choose any coordinate in the world by choosing a random x and y value.
				int x = WorldGen.genRand.Next(0, Main.maxTilesX);
				int y = WorldGen.genRand.Next((int)WorldGen.worldSurfaceLow, Main.maxTilesY); // WorldGen.worldSurfaceLow is actually the highest surface tile. In practice you might want to use WorldGen.rockLayer or other WorldGen values.

				// Then, we call WorldGen.TileRunner with random "strength" and random "steps", as well as the Tile we wish to place. Feel free to experiment with strength and step to see the shape they generate.
				WorldGen.TileRunner(x, y, WorldGen.genRand.Next(3, 6), WorldGen.genRand.Next(2, 6), ModContent.TileType<encore2>());

				// Alternately, we could check the tile already present in the coordinate we are interested. Wrapping WorldGen.TileRunner in the following condition would make the ore only generate in Snow.
				// Tile tile = Framing.GetTileSafely(x, y);
				// if (tile.active() && tile.type == TileID.SnowBlock)
				// {
				// 	WorldGen.TileRunner(.....);
				// }
			}
		}

    }
}