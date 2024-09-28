using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace gracosmod123.NPCs.ocean.oceanitems.bosssummonbag
{
    public class aquabag : ModItem
    {
        public override void SetDefaults()
        {
            Item.maxStack = 999;
            Item.consumable = true;
            Item.width = 36;
            Item.height = 32;
            Item.rare = 9;
            item.expert = true;
            //bossBagNPC = ModContent.NPCType("AntlionQueen");
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Treasure Bag");
            Tooltip.SetDefault("right click to open");
        }
        public override bool CanRightClick()
        {
            return true;
        }

        /*public override void OpenBossBag(Player player)
        {
            player.QuickSpawnItem(ModContent.ItemType("accesore"));

            if (Main.rand.Next(7) == 0)
            {
                player.QuickSpawnItem(ModContent.ItemType("mechbemask"));
            }
            switch (Main.rand.Next(4))
            {
                case 0:
                    player.QuickSpawnItem(ModContent.ItemType("scythe"));
                    break;
                case 1:
                    player.QuickSpawnItem(ModContent.ItemType("mechsky"));
                    break;
                case 2:
                    player.QuickSpawnItem(ModContent.ItemType("eliasBow"));
                    break;
                case 3:
                    player.QuickSpawnItem(ModContent.ItemType("remote"));
                    break;
            }
            if (Main.rand.Next(20) == 0)
            {
                player.QuickSpawnItem(ModContent.ItemType("mechqueentrophy"));
            }*/
        public override void OpenBossBag(Player player)
        {                                         //below it's a choice from 3 items that will drop randomly
            //and this is the items that will 100% drop from the treasure bag
            player.QuickSpawnItem(ModContent.ItemType("aquaexpertitem"), Main.rand.Next(1, 1));
            player.QuickSpawnItem(ModContent.ItemType("blueblockore"), Main.rand.Next(25, 35));
        }
        public override int BossBagNPC => ModContent.NPCType<NPCs.ocean.POSIDEN>();

    }
}
/*
using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
 
namespace YourModName.Items
{
    public class TreasureBag : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Cool Treasure Bag";
            Item.maxStack = 999;
            Item.consumable = true;
            Item.width = 24;
            Item.height = 24;
            item.toolTip = "Right click to open";
            Item.rare = 11;
            bossBagNPC = ModContent.NPCType("NPCName");  //add this if the tresure bag is droped from a boss
            item.expert = true;      //add this if it's expert mode only
        }
        public override bool CanRightClick()
        {
            return true;
        }
 
        public override void OpenBossBag(Player player)
        {                                         //below it's a choice from 3 items that will drop randomly
            int choice = Main.rand.Next(3);
            if (choice == 0)
            {
                player.QuickSpawnItem(ModContent.ItemType("PetCall"));      
            }
            if (choice == 1)
            {
                player.QuickSpawnItem(ModContent.ItemType("ShotGun"));
            }
            if (choice == 2)
            {
                player.QuickSpawnItem(ModContent.ItemType("YourSword"));
            }
            //and this is the items that will 100% drop from the treasure bag
            player.QuickSpawnItem(ModContent.ItemType("CoolSoul"), Main.rand.Next(25, 35));
            player.QuickSpawnItem(ModContent.ItemType("Flail"));
        }
    }
}*/