using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using Terraria.Graphics.Shaders;
using static Terraria.ModLoader.ModContent;
namespace gracosmod123.projectiles
{
	
    public class anthousegen : ModProjectile
    {
		private const int pickPower = 100;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("sandhouse");
        }

        public override void SetDefaults()
        {
            projectile.tileCollide = true;
			projectile.width = 10;
			projectile.height = 10;
			projectile.aiStyle = 16;
			projectile.friendly = true;
			Projectile.Penetrate = -1;
			projectile.timeLeft = 1000;

			drawOffsetX = -15;
			drawOriginOffsetY = -15;
        }

        /*public override bool OnTileCollide(Vector2 old)
        {
            projectile.position.X = projectile.position.X + (float)(projectile.width / 2);
            projectile.position.Y = projectile.position.Y + (float)(projectile.height / 2);
            projectile.width = 5;
            projectile.height = 5;
            projectile.position.X = projectile.position.X - (float)(projectile.width / 2);
            projectile.position.Y = projectile.position.Y - (float)(projectile.height / 2);

            projectile.velocity.X = 0;
            projectile.velocity.Y = 0;
            projectile.aiStyle = 0;
            return true;
        }

        public override void Kill(int timeLeft)
        {
            //Create Bomb Sound
            //Create Bomb Damage
            //ExplosionDamage(5f, projectile.Center, 70, 20, projectile.owner);

            //Create Bomb Explosion

            //Create Bomb Dust
            CreateDust(projectile.Center, 250);

            //Create Bomb Gore
            Vector2 gVel1 = new Vector2(2f, 2f);
            Vector2 gVel2 = new Vector2(-2f, -2f);
        }

        public override void AI()
        {
            Vector2 position = projectile.Center;

            int x = 0;
            int y = 0;

            int height = 7;

            for (x = -5; x < 6; x++)
            {
                for (y = height - 1; y >= 0; y--)
                {
                    int xPosition = (int)(x + position.X / 16.0f);
                    int yPosition = (int)(-y + position.Y / 16.0f);

                    if (WorldGen.InWorld(xPosition, yPosition))
                    {
                        Dust.NewDust(position, 22, 22, DustID.Smoke, 0.0f, 0.0f, 120, new Color(), 1f);


                        //Destroy water
                        Main.tile[xPosition, yPosition].type = TileID.Dirt;
                        Main.tile[xPosition, yPosition].type = TileID.Stone;
                        Main.tile[xPosition, yPosition].type = TileID.IceBlock;
                        Main.tile[xPosition, yPosition].type = TileID.SnowBlock;
                        Main.tile[xPosition, yPosition].type = TileID.Iron;//TileID.Iron || type == TileID.Copper || type == TileID.Lead || type == TileID.Silver || type == TileID.WoodBlock || type == TileID.Sand || type == TileID.Ebonstone || type == TileID.Crimstone))
                        Main.tile[xPosition, yPosition].type = TileID.Copper;
                        Main.tile[xPosition, yPosition].type = TileID.Lead;
                        Main.tile[xPosition, yPosition].type = TileID.Mud;
                        Main.tile[xPosition, yPosition].type = TileID.Silver;
                        Main.tile[xPosition, yPosition].type = TileID.WoodBlock;
                        Main.tile[xPosition, yPosition].type = TileID.Sand;
                        Main.tile[xPosition, yPosition].type = TileID.Ebonstone;
                        Main.tile[xPosition, yPosition].type = TileID.Crimstone;
                        Main.tile[xPosition, yPosition].type = TileID.SandstoneBrick;
                        Main.tile[xPosition, yPosition].liquid = Tile.Liquid_Water;//TileID.Dirt || type == TileID.Stone || type == TileID.IceBlock || type == TileID.SnowBlock || type == TileID.Mud || type == TileID.Iron || type == TileID.Copper || type == TileID.Lead || type == TileID.Silver || type == TileID.WoodBlock || type == TileID.Sand || type == TileID.Ebonstone || type == TileID.Crimstone))
                        WorldGen.SquareTileFrame(xPosition, yPosition, true);

                        //Particle Effects
                        Dust.NewDust(position, 22, 22, DustID.Smoke, 0.0f, 0.0f, 120, new Color(), 1f);  //this is the dust that will spawn after the explosion

                        //Place House Outline
                        if (y == 0 || y == 6)
                            WorldGen.PlaceTile(xPosition, yPosition, TileID.SandstoneBrick);
                        if ((x == -5 || x == 5) && (y == 4 || y == 5))
                            WorldGen.PlaceTile(xPosition, yPosition, TileID.SandstoneBrick);

                        //Place House Walls
                        if ((y == 5 || y == 2 || y == 1) && x != -5 && x != 5)
                            WorldGen.PlaceWall(xPosition, yPosition, WallID.SandstoneBrick);
                        if (y == 3 || y == 4)
                        {
                            if (x == -4 || x == -3 || x == -2 || x == 2 || x == 3 || x == 4)
                                WorldGen.PlaceWall(xPosition, yPosition, WallID.SandstoneBrick);
                            if (x == -1 || x == 0 || x == 1)
                                WorldGen.PlaceWall(xPosition, yPosition, WallID.SandFall);
                        }

                        //Places House Lights
                        if (y == 5)
                            if (x == -4 || x == 4)
                                WorldGen.PlaceTile(xPosition, yPosition, TileID.Torches);
                    }
                }
            }

            for (x = -5; x < 6; x++)
            {
                for (y = 0; y < height; y++)
                {
                    int xPosition = (int)(x + position.X / 16.0f);
                    int yPosition = (int)(-y + position.Y / 16.0f);

                    //Places House Furniture
                    if (y == 1)
                    {
                        if (x == -5 || x == 5) //Door
                            WorldGen.PlaceTile(xPosition, yPosition, TileID.ClosedDoor);
                        if (x == 0) //Table
                            WorldGen.PlaceTile(xPosition, yPosition, TileID.Tables);
                        if (x == 2) //Chair
                            WorldGen.PlaceTile(xPosition, yPosition, TileID.Chairs);
                    }
                }
            }
            for (int n = 0; n < 1000; n++)
            {
                NPC.NewNPC((int)position.X + Main.rand.Next(1000) - 500, (int)position.Y, NPCID.Bunny, 0, 0f, 0f, 0f, 0f, 255); //Spawn da bunnies
                Main.NewText("BUNNNNNNNNNNNNNNNIES", 0, 200, 255);
            }
        }

        private void CreateDust(Vector2 position, int amount)
        {

            for (int i = 0; i <= amount; i++)
            {
            }
        }*/
        public override bool OnTileCollide(Vector2 old)
		{
			projectile.position.X = projectile.position.X + (float)(projectile.width / 2);
			projectile.position.Y = projectile.position.Y + (float)(projectile.height / 2);
			projectile.width = 5;
			projectile.height = 5;
			projectile.position.X = projectile.position.X - (float)(projectile.width / 2);
			projectile.position.Y = projectile.position.Y - (float)(projectile.height / 2);

			projectile.velocity.X = 0;
			projectile.velocity.Y = 0;
			projectile.aiStyle = 0;
			return true;
		}

		public override void Kill(int timeLeft)
		{
			//Create Bomb Sound

			//Create Bomb Damage
			//ExplosionDamage(5f, projectile.Center, 70, 20, projectile.owner);

			//Create Bomb Explosion
			Explosion();

			//Create Bomb Dust

			//Create Bomb Gore
			Vector2 gVel1 = new Vector2(2f, 2f);
			Vector2 gVel2 = new Vector2(-2f, -2f);
		}
            
            
        public static bool CanBreakTile(int tileId, int pickPower)
		{
			// Dynamic mod tile functionality at the bottom
			if (pickPower == -1)
				return true; // Override so an item can be set to ignore pickaxe power and destory everything
			if (pickPower <= -2)
				return false; // Override so an item can be set to not damage anything ever also catches invalid garbage
			if (tileId < 470)
			{
				// this is for all blocks which can be destroyed by any pickaxe
				if (Main.tileNoFail[tileId])
				{
					return true;
				}

				if (tileId == (TileID.DefendersForge | TileID.Containers | TileID.Containers2 | TileID.DemonAltar | TileID.FakeContainers | TileID.TrashCan | TileID.Dressers))
				{
					return false;
				}

				if (tileId == TileID.DesertFossil && pickPower < 65)
				{
					return false;
				}

				// Meteorite (Power 50)
				if (tileId == 37 && pickPower < 50)
				{
					return false;
				}

				// Demonite & Crimtane Ores (Power 55)
				if ((tileId == TileID.Demonite || tileId == TileID.Crimtane) && pickPower < 55)
				{
					return false;
				}

				// Obsidian & Ebonstone Hellstone Pearlstone and Crimstone Blocks (Power 65)
				if ((tileId == TileID.Obsidian || tileId == TileID.Ebonstone || tileId == TileID.Hellstone || tileId == TileID.Pearlstone || tileId == TileID.Crimstone) &&
					pickPower < 65)
				{
					return false;
				}

				// Dungeon Bricks (Power 65)
				// Separate from Obsidian block to allow for future functionality to better reflect base game mechanics
				if ((tileId == TileID.BlueDungeonBrick || tileId == TileID.GreenDungeonBrick || tileId == TileID.PinkDungeonBrick)
				    && pickPower < 65)
				{
					return false;
				}

				// Cobalt & Palladium (Power 100)
				if ((tileId == TileID.Cobalt || tileId == TileID.Palladium)
				    && pickPower < 100)
				{
					return false;
				}

				// Mythril & Orichalcum (Power 110)
				if ((tileId == TileID.Mythril || tileId == TileID.Orichalcum)
				    && pickPower < 110)
				{
					return false;
				}

				// Adamantite & Titanium (Power 150)
				if ((tileId == TileID.Adamantite || tileId == TileID.Titanium)
				    && pickPower < 150)
				{
					return false;
				}

				// Chlorophyte Ore (Power 200)
				if (tileId == TileID.Chlorophyte
				    && pickPower < 200)
				{
					return false;
				}

				// Lihzahrd Brick (Power 210) todo add additional checks for Lihzahrd traps and the locked temple door
				if ((tileId == TileID.LihzahrdBrick || tileId == TileID.LihzahrdAltar || tileId == TileID.Traps)
				    && pickPower < 210)
				{
					return false;
				}
			}
			// If the tile is modded, will need updating when tml is updated
			if (tileId > 469)
			{
				int tileResistance = GetModTile(tileId).minPick;
				if (tileResistance <= pickPower) return true;
				return false;
			}
			return true;	// Catch for anything which slipped through, defaults to true
		}
		public void Explosion()
		{
			Vector2 position = projectile.Center;
			
			int x = 0;
			int y = 0;

			int width = 11;
			int height = 7;

			for (x = -5; x < 6; x++)
			{
				for (y = height - 1; y >= 0; y--)
				{
					int xPosition = (int)(x + position.X / 16.0f);
					int yPosition = (int)(-y + position.Y / 16.0f);

					if (WorldGen.InWorld(xPosition, yPosition))
					{
						ushort tile = Main.tile[xPosition, yPosition].type;
						if (!CanBreakTile(tile, pickPower)) //Unbreakable CheckForUnbreakableTiles(tile) ||
						{
						}
						else //Breakable
						{
							WorldGen.KillTile(xPosition, yPosition, false, false, false); //This destroys Tiles
							WorldGen.KillWall(xPosition, yPosition, false); //This destroys Walls

							Dust.NewDust(position, 22, 22, DustID.Smoke, 0.0f, 0.0f, 120, new Color(), 1f);
						}

						//Destroy water
						Main.tile[xPosition, yPosition].liquid = Tile.Liquid_Water;
						WorldGen.SquareTileFrame(xPosition, yPosition, true);

						//Particle Effects
						Dust.NewDust(position, 22, 22, DustID.Smoke, 0.0f, 0.0f, 120, new Color(), 1f);  //this is the dust that will spawn after the explosion

						//Place House Outline
						if (y == 0 || y == 6)
							WorldGen.PlaceTile(xPosition, yPosition, TileID.SandstoneBrick);
						if ((x == -5 || x == 5) && (y == 4 || y == 5))
							WorldGen.PlaceTile(xPosition, yPosition, TileID.SandstoneBrick);

						//Place House Walls
						if ((y == 5 || y == 2 || y == 1) && x != -5 && x != 5)
							WorldGen.PlaceWall(xPosition, yPosition, WallID.SandstoneBrick);
						if (y == 3 || y == 4)
						{
							if (x == -4 || x == -3 || x == -2 || x == 2 || x == 3 || x == 4)
								WorldGen.PlaceWall(xPosition, yPosition, WallID.SandstoneBrick);
							if (x == -1 || x == 0 || x == 1)
								WorldGen.PlaceWall(xPosition, yPosition, WallID.SandFall);
						}

						//Places House Lights
						if (y == 5)
							if (x == -4 || x == 4)
								WorldGen.PlaceTile(xPosition, yPosition, TileID.Torches);
					}
				}
			}

			for (x = -5; x < 6; x++)
			{
				for (y = 0; y < height; y++)
				{
					int xPosition = (int)(x + position.X / 16.0f);
					int yPosition = (int)(-y + position.Y / 16.0f);

					//Places House Furniture
					if (y == 1)
					{
						if (x == -5 || x == 5) //Door
							WorldGen.PlaceTile(xPosition, yPosition, TileID.ClosedDoor);
						if (x == 0) //Table
							WorldGen.PlaceTile(xPosition, yPosition, TileID.Tables);
						if (x == 2) //Chair
							WorldGen.PlaceTile(xPosition, yPosition, TileID.Chairs);
					}
				}
			}
		}
    }
}