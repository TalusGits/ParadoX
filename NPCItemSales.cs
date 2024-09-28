using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace gracosmod123
{
    public class NPCItemSales : GlobalNPC
    {
        public override void SetupShop(int type, Chest shop, ref int nextSlot)
        {
            if (type == NPCID.SkeletonMerchant)
            {
                /*shop.item[nextSlot].SetDefaults(ModContent.ItemType("ConjureBone"));
                nextSlot++;
                if (NPC.downedBoss1)
                {
                    shop.item[nextSlot].SetDefaults(ModContent.ItemType("DuelistHeadband"));
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(ModContent.ItemType("DuelistShirt"));
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(ModContent.ItemType("DuelistPants"));
                    nextSlot++;
                }
                if (Main.moonPhase < 4)
                {
                    shop.item[nextSlot].SetDefaults(ModContent.ItemType("ArcaneArmorBreaker"));
                    nextSlot++;
                }
                else
                {
                    shop.item[nextSlot].SetDefaults(ModContent.ItemType("AerodynamicFins"));
                    nextSlot++;
                }*/
            }
            if (type == NPCID.Demolitionist)
            {
                /*shop.item[nextSlot].SetDefaults(ModContent.ItemType("PrimedGrenadeCore"));
                nextSlot++;*/
            }
            if (type == NPCID.Cyborg)
            {
                /*shop.item[nextSlot].SetDefaults(ModContent.ItemType("TeleportationArrow"));
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ModContent.ItemType("TeleportationArrowGrab"));
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ModContent.ItemType("TeleportationArrowSwap"));
                nextSlot++;*/
            }
            if (type == NPCID.WitchDoctor)
            {
                /*shop.item[nextSlot].SetDefaults(ModContent.ItemType("MinionFang"));
                nextSlot++;*/
            }
            /*if (type == NPCID.Dryad && NPC.downedMechBossAny)
            {
                /*shop.item[nextSlot].SetDefaults(ModContent.ItemType("BloomingBow"));
                nextSlot++;
            }*/
            if (type == NPCID.Dryad)
            {
                shop.item[nextSlot].SetDefaults(ModContent.ItemType(""));  //an example of how to add a vanilla terraria item
                nextSlot++;
                if (NPC.downedBoss1)   //this make so when the EOC is killed the town NPC will sell this
                {
                    shop.item[nextSlot].SetDefaults(ModContent.ItemType("StarflowerSeeds"));  //an example of how to add a vanilla terraria item
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(ModContent.ItemType("StarflowerPlanterBox"));  //an example of how to add a vanilla terraria item
                    nextSlot++;
                }
                if (Main.hardMode)
                {
                    shop.item[nextSlot].SetDefaults(ModContent.ItemType("potionmed"));  //an example of how to add a vanilla terraria item
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(ModContent.ItemType("Starflower"));  //an example of how to add a vanilla terraria item
                    nextSlot++;
                }
                if (NPC.downedGolemBoss)
                {
                    shop.item[nextSlot].SetDefaults(ModContent.ItemType("potionbig"));  //an example of how to add a vanilla terraria item
                    nextSlot++;
                }

            }
            if (type == NPCID.Mechanic)
            {
                /*shop.item[nextSlot].SetDefaults(ModContent.ItemType("Fan"));
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ModContent.ItemType("VFan"));
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ModContent.ItemType("Illuminator"));
                nextSlot++;*/
            }
            if (type == NPCID.ArmsDealer)
            {
                /*if (QwertyWorld.downedAncient)
                {
                    shop.item[nextSlot].SetDefaults(ModContent.ItemType("TankShift"));
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(ModContent.ItemType("MiniTankStaff"));
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(ModContent.ItemType("TankCommanderHelmet"));
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(ModContent.ItemType("TankCommanderJacket"));
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(ModContent.ItemType("TankCommanderPants"));
                    nextSlot++;
                }*/
            }
            if (type == NPCID.Merchant)
            {
                /*shop.item[nextSlot].SetDefaults(ModContent.ItemType("Flechettes"));
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ModContent.ItemType("Flashlight"));
                nextSlot++;*/
                shop.item[nextSlot].SetDefaults(ItemID.MagicMirror);
                nextSlot++;
            }
            if (type == NPCID.Wizard)
            {
                /*shop.item[nextSlot].SetDefaults(ItemID.MagicMirror);
                nextSlot++;*/
            }
            if (type == NPCID.Steampunker)
            {
                /*shop.item[nextSlot].SetDefaults(ModContent.ItemType("Steambath"));
                nextSlot++;*/
            }
            if (type == NPCID.DyeTrader)
            {
                /* shop.item[nextSlot].SetDefaults(ModContent.ItemType("CustomDye"));
                 nextSlot++;
                 shop.item[nextSlot].SetDefaults(ModContent.ItemType("CustomDye2"));
                 nextSlot++;
                 shop.item[nextSlot].SetDefaults(ModContent.ItemType("CustomDye3"));
                 nextSlot++;
                 shop.item[nextSlot].SetDefaults(ModContent.ItemType("CustomDye4"));
                 nextSlot++;*/
            }
            if (type == NPCID.Clothier)
            {
                /*shop.item[nextSlot].SetDefaults(ModContent.ItemType("SRobe"));
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ModContent.ItemType("DressB"));
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ModContent.ItemType("DressC"));
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ModContent.ItemType("Miniskirt"));
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ModContent.ItemType("Shorts"));
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ModContent.ItemType("SwimsuitTop"));
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ModContent.ItemType("SwimsuitBottom"));
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ModContent.ItemType("LeatherBelt"));
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ModContent.ItemType("LeatherShoesMale"));
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ModContent.ItemType("LeatherShoesFemale"));
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ModContent.ItemType("LeatherBootsMale"));
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ModContent.ItemType("LeatherBootsFemale"));
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ModContent.ItemType("HighHeels"));
                nextSlot++;*/
            }
        }

        /*public override void SetupTravelShop(int[] shop, ref int nextSlot)
        {
            if (Main.rand.Next(0, 5) == 0)
            {
                shop[nextSlot] = ModContent.ItemType("Metronome");
                nextSlot++;
            }
            int selectAccesory = Main.rand.Next(4);
            switch (selectAccesory)
            {
                case 0:
                    shop[nextSlot] = ModContent.ItemType("SwordEmbiggenner");
                    nextSlot++;
                    break;

                case 1:
                    shop[nextSlot] = ModContent.ItemType("Gemini");
                    nextSlot++;
                    break;

                case 2:
                    shop[nextSlot] = ModContent.ItemType("QuestionableSubstance");
                    nextSlot++;
                    break;

                case 4:
                    shop[nextSlot] = ModContent.ItemType("BookOfMinionTactics");
                    nextSlot++;
                    break;
            }
        }*/
    }
}