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
using gracosmod123.npcs.wormboss;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.Localization;
using Terraria.World.Generation;
namespace gracosmod123.npcs.wormboss
{
    public class CactusworldChest : ModWorld
    {
        public override void PostWorldGen()
        {
            int[] itemsToPlaceInIceChests = { ModContent.ItemType<goldenRelic>(), ModContent.ItemType<goldenRelic>(), ModContent.ItemType<goldenRelic>() };//mod.ItemType("goldenRelic")
            int itemsToPlaceInIceChestsChoice = 0;
            for (int chestIndex = 0; chestIndex < 1000; chestIndex++)
            {
                Chest chest = Main.chest[chestIndex];
                // If you look at the sprite for Chests by extracting Tiles_21.xnb, you'll see that the 12th chest is the Ice Chest. Since we are counting from 0, this is where 11 comes from. 36 comes from the width of each tile including padding. 
                if (chest != null && Main.tile[chest.x, chest.y].type == TileID.Containers && Main.tile[chest.x, chest.y].frameX == 1 * 36)
                {
                    for (int inventoryIndex = 0; inventoryIndex < 40; inventoryIndex++)
                    {
                        if (chest.item[inventoryIndex].type == ItemID.None)
                        {
                            chest.item[inventoryIndex].SetDefaults(itemsToPlaceInIceChests[itemsToPlaceInIceChestsChoice]);
                            itemsToPlaceInIceChestsChoice = (itemsToPlaceInIceChestsChoice + 1) % itemsToPlaceInIceChests.Length;
                            // Alternate approach: Random instead of cyclical: chest.item[inventoryIndex].SetDefaults(Main.rand.Next(itemsToPlaceInIceChests));
                            break;
                        }
                    }
                }
            }
        }

    }
}