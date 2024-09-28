using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using gracosmod123.items;
namespace gracosmod123
{
    class EtherialGlobalNPC : GlobalNPC
    {

        public override bool InstancePerEntity
        {
            get
            {
                return true;
            }
        }

        public override void SetDefaults(NPC NPC)
        {
            if (NPC.type == NPCID.DD2EterniaCrystal)
            {
                NPC.dontTakeDamageFromHostiles = false;
            }
            else if (NPC.friendly)
            {
                NPC.dontTakeDamageFromHostiles = true;
            }
            if (NPC.type == NPCID.Guide)
            {

            }
        }
        public override void NPCLoot(NPC NPC)
        {
            if (NPC.type == NPCID.Derpling)
            {
                Item.NewItem((int)NPC.position.X, (int)NPC.position.Y, NPC.width, NPC.height, ModContent.ItemType("BorealWoodSpear"), 1);
            }
            if (NPC.type == NPCID.Zombie)
            {
                if (Main.rand.Next(2) == 0)   //item rarity
                {
                    Item.NewItem((int)NPC.position.X, (int)NPC.position.Y, NPC.width, NPC.height, ModContent.ItemType("ItemName")); //Item spawn
                }
            }//MarbleBow
            if (Main.player[Main.myPlayer].ZoneCorrupt)
            {
                Item.NewItem((int)NPC.position.X, (int)NPC.position.Y, NPC.width, NPC.height, ModContent.ItemType("nuthing"));
            }
            if (NPC.type == NPCID.FireImp && NPC.downedBoss3)
            {
                if (Main.rand.Next(80) == 0)   //item rarity
                {
                    Item.NewItem((int)NPC.position.X, (int)NPC.position.Y, NPC.width, NPC.height, ModContent.ItemType("impsword")); //Item spawn
                }
            }
            if (NPC.type == (49))//  51 60 150 
            {
                if (Main.rand.Next(50) == 0)   //item rarity
                {
                    Item.NewItem((int)NPC.position.X, (int)NPC.position.Y, NPC.width, NPC.height, ModContent.ItemType("CustomSpinningWeapon")); //Item spawn battus battus
                }
            }
            if (NPC.type == (634))//  51 60 150 
            {
                if (Main.rand.Next(50) == 0)   //item rarity
                {
                    Item.NewItem((int)NPC.position.X, (int)NPC.position.Y, NPC.width, NPC.height, ModContent.ItemType("CustomSpinningWeapon")); //Item spawn battus battus
                }
            }
            if (NPC.type == (51))//   60 150 
            {
                if (Main.rand.Next(50) == 0)   //item rarity
                {
                    Item.NewItem((int)NPC.position.X, (int)NPC.position.Y, NPC.width, NPC.height, ModContent.ItemType("CustomSpinningWeapon")); //Item spawn battus battus
                }
            }
            if (NPC.type == (60))//   60 150 
            {
                if (Main.rand.Next(50) == 0)   //item rarity
                {
                    Item.NewItem((int)NPC.position.X, (int)NPC.position.Y, NPC.width, NPC.height, ModContent.ItemType("CustomSpinningWeapon")); //Item spawn battus battus
                }
            }
            if (NPC.type == (150))//   60 150 
            {
                if (Main.rand.Next(50) == 0)   //item rarity
                {
                    Item.NewItem((int)NPC.position.X, (int)NPC.position.Y, NPC.width, NPC.height, ModContent.ItemType("CustomSpinningWeapon")); //Item spawn battus battus
                }
            }
            if (NPC.type == (NPCID.Medusa))
            {
                if (Main.rand.Next(30) == 0)   //item rarity
                {
                    Item.NewItem((int)NPC.position.X, (int)NPC.position.Y, NPC.width, NPC.height, ModContent.ItemType("MarbleBow")); //Item spawn
                }
            }//CustomSpinningWeapon
            if (NPC.type == (481))
            {
                if (Main.rand.Next(30) == 0)   //item rarity
                {
                    Item.NewItem((int)NPC.position.X, (int)NPC.position.Y, NPC.width, NPC.height, ModContent.ItemType("MarbleBow")); //Item spawn
                }
            }//
            if (NPC.type == 35)
            {
                if (Main.rand.Next(1) == 0)   //item rarity
                {
                    Item.NewItem((int)NPC.position.X, (int)NPC.position.Y, NPC.width, NPC.height, 1169); //Item spawn
                }
            }
            if (Main.rand.Next(30) == 0)   //item rarity
            {
                Item.NewItem((int)NPC.position.X, (int)NPC.position.Y, NPC.width, NPC.height, ModContent.ItemType("meBurger")); //Item spawn
            }
            if (NPC.type == 491)
            {
                switch (Main.rand.Next(4))
                {
                    case 0:
                        Item.NewItem((int)NPC.position.X, (int)NPC.position.Y, NPC.width, NPC.height, ItemID.CoinGun); //Item spawn
                        break;
                    case 1:
                        Item.NewItem((int)NPC.position.X, (int)NPC.position.Y, NPC.width, NPC.height, ItemID.Cutlass); //Item spawn
                        break;
                    case 2:
                        Item.NewItem((int)NPC.position.X, (int)NPC.position.Y, NPC.width, NPC.height, ItemID.GoldRing); //Item
                        break;
                    case 3:
                        Item.NewItem((int)NPC.position.X, (int)NPC.position.Y, NPC.width, NPC.height, ItemID.LuckyCoin); //Item spawn
                        break;
                    default:
                        Item.NewItem((int)NPC.position.X, (int)NPC.position.Y, NPC.width, NPC.height, ItemID.DiscountCard); //Item spawn
                        break;
                }
            }
            if (NPC.type == 395)
            {
                if (Main.rand.Next(7) == 0)   //item rarity
                {
                    Item.NewItem((int)NPC.position.X, (int)NPC.position.Y, NPC.width, NPC.height, ModContent.ItemType("Alien_blaster")); //Item spawn
                }

            }
        }

    }
}
