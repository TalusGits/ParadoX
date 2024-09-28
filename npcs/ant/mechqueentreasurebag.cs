using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace gracosmod123.npcs.ant
{
    public class mechqueentreasurebag : ModItem
    {
        public override void SetDefaults()
        {
            item.maxStack = 999;
            item.consumable = true;
            item.width = 36;
            item.height = 32;
            item.rare = 9;
            item.expert = true;
            //bossBagNPC = mod.NPCType("AntlionQueen");
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
            player.QuickSpawnItem(mod.ItemType("accesore"));

            if (Main.rand.Next(7) == 0)
            {
                player.QuickSpawnItem(mod.ItemType("mechbemask"));
            }
            switch (Main.rand.Next(4))
            {
                case 0:
                    player.QuickSpawnItem(mod.ItemType("scythe"));
                    break;
                case 1:
                    player.QuickSpawnItem(mod.ItemType("mechsky"));
                    break;
                case 2:
                    player.QuickSpawnItem(mod.ItemType("eliasBow"));
                    break;
                case 3:
                    player.QuickSpawnItem(mod.ItemType("remote"));
                    break;
            }
            if (Main.rand.Next(20) == 0)
            {
                player.QuickSpawnItem(mod.ItemType("mechqueentrophy"));
            }*/
        public override void OpenBossBag(Player player)
        {                                         //below it's a choice from 3 items that will drop randomly
            if (Main.rand.Next(7) == 0)
            {
                player.QuickSpawnItem(mod.ItemType("mechbemask"));
            }
            int choice = Main.rand.Next(4);
            if (choice == 0)
            {
                player.QuickSpawnItem(mod.ItemType("mechsky"));
            }
            if (choice == 1)
            {
                player.QuickSpawnItem(mod.ItemType("eliasBow"));
            }
            if (choice == 2)
            {
                player.QuickSpawnItem(mod.ItemType("scythe"));
            }
            if (choice == 3)
            {
                player.QuickSpawnItem(mod.ItemType("remote"));
            }
            //and this is the items that will 100% drop from the treasure bag
            player.QuickSpawnItem(mod.ItemType("accesore"), Main.rand.Next(1, 1));
        }
        public override int BossBagNPC => ModContent.NPCType<AntlionQueen>();

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
            item.maxStack = 999;
            item.consumable = true;
            item.width = 24;
            item.height = 24;
            item.toolTip = "Right click to open";
            item.rare = 11;
            bossBagNPC = mod.NPCType("NpcName");  //add this if the tresure bag is droped from a boss
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
                player.QuickSpawnItem(mod.ItemType("PetCall"));      
            }
            if (choice == 1)
            {
                player.QuickSpawnItem(mod.ItemType("ShotGun"));
            }
            if (choice == 2)
            {
                player.QuickSpawnItem(mod.ItemType("YourSword"));
            }
            //and this is the items that will 100% drop from the treasure bag
            player.QuickSpawnItem(mod.ItemType("CoolSoul"), Main.rand.Next(25, 35));
            player.QuickSpawnItem(mod.ItemType("Flail"));
        }
    }
}*/