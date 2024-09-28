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

        public override void SetDefaults(NPC npc)
        {
            if (npc.type == NPCID.DD2EterniaCrystal)
            {
                npc.dontTakeDamageFromHostiles = false;
            }
            else if (npc.friendly)
            {
                npc.dontTakeDamageFromHostiles = true;
            }
            if (npc.type == NPCID.Guide)
            {

            }
        }
        public override void NPCLoot(NPC npc)
        {
            if (npc.type == NPCID.Derpling)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("BorealWoodSpear"), 1);
            }
            if (npc.type == NPCID.Zombie)
            {
                if (Main.rand.Next(2) == 0)   //item rarity
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ItemName")); //Item spawn
                }
            }//MarbleBow
            if (Main.player[Main.myPlayer].ZoneCorrupt)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("nuthing"));
            }
            if (npc.type == NPCID.FireImp && NPC.downedBoss3)
            {
                if (Main.rand.Next(80) == 0)   //item rarity
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("impsword")); //Item spawn
                }
            }
            if (npc.type == (49))//  51 60 150 
            {
                if (Main.rand.Next(50) == 0)   //item rarity
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("CustomSpinningWeapon")); //Item spawn battus battus
                }
            }
            if (npc.type == (634))//  51 60 150 
            {
                if (Main.rand.Next(50) == 0)   //item rarity
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("CustomSpinningWeapon")); //Item spawn battus battus
                }
            }
            if (npc.type == (51))//   60 150 
            {
                if (Main.rand.Next(50) == 0)   //item rarity
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("CustomSpinningWeapon")); //Item spawn battus battus
                }
            }
            if (npc.type == (60))//   60 150 
            {
                if (Main.rand.Next(50) == 0)   //item rarity
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("CustomSpinningWeapon")); //Item spawn battus battus
                }
            }
            if (npc.type == (150))//   60 150 
            {
                if (Main.rand.Next(50) == 0)   //item rarity
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("CustomSpinningWeapon")); //Item spawn battus battus
                }
            }
            if (npc.type == (NPCID.Medusa))
            {
                if (Main.rand.Next(30) == 0)   //item rarity
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("MarbleBow")); //Item spawn
                }
            }//CustomSpinningWeapon
            if (npc.type == (481))
            {
                if (Main.rand.Next(30) == 0)   //item rarity
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("MarbleBow")); //Item spawn
                }
            }//
            if (npc.type == 35)
            {
                if (Main.rand.Next(1) == 0)   //item rarity
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 1169); //Item spawn
                }
            }
            if (Main.rand.Next(30) == 0)   //item rarity
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("meBurger")); //Item spawn
            }
            if (npc.type == 491)
            {
                switch (Main.rand.Next(4))
                {
                    case 0:
                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.CoinGun); //Item spawn
                        break;
                    case 1:
                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Cutlass); //Item spawn
                        break;
                    case 2:
                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.GoldRing); //Item
                        break;
                    case 3:
                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.LuckyCoin); //Item spawn
                        break;
                    default:
                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.DiscountCard); //Item spawn
                        break;
                }
            }
            if (npc.type == 395)
            {
                if (Main.rand.Next(7) == 0)   //item rarity
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Alien_blaster")); //Item spawn
                }

            }
        }

    }
}
