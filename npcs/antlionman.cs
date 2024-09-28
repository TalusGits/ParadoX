using gracosmod123.items;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace gracosmod123.NPCs
{
    // [AutoloadHead] and NPC.townNPC are extremely important and absolutely both necessary for any Town NPC to work at all.
    [AutoloadHead]
    public class antlionman : ModNPC
    {
        public override string Texture => "gracosmod123/NPCs/antlionman";

        //public override string[] AltTextures => new[] { "elias/townNPCs/ExamplePerson_Alt_1" };

        public override bool Autoload(ref string name)
        {
            name = "antilon charger";
            return mod.Properties.Autoload;
        }

        public override void SetStaticDefaults()
        {
            // DisplayName automatically assigned from .lang files, but the commented line below is the normal approach.
            // DisplayName.SetDefault("Example Person");
            Main.NPCFrameCount[NPC.type] = 25;
            NPCID.Sets.ExtraFramesCount[NPC.type] = 9;
            NPCID.Sets.AttackFrameCount[NPC.type] = 4;
            NPCID.Sets.DangerDetectRange[NPC.type] = 700;
            NPCID.Sets.AttackType[NPC.type] = 0;
            NPCID.Sets.AttackTime[NPC.type] = 90;
            NPCID.Sets.AttackAverageChance[NPC.type] = 30;
            NPCID.Sets.HatOffsetY[NPC.type] = 4;
        }

        public override void SetDefaults()
        {
            NPC.townNPC = true;
            NPC.friendly = true;
            NPC.width = 18;
            NPC.height = 40;
            NPC.aiStyle = 7;
            NPC.damage = 10;
            NPC.defense = 15;
            NPC.LifeMax = 250;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;
            NPC.knockBackResist = 0.5f;
            animationType = NPCID.Guide;
        }

        /*public override void HitEffect(int hitDirection, double damage)
        {
            int num = NPC.life > 0 ? 1 : 5;
            for (int k = 0; k < num; k++)
            {
                Dust.NewDust(NPC.position, NPC.width, NPC.height, ModContent.DustType("pandadust"));
            }
        }*/

        public override bool CanTownNPCSpawn(int numTownNPCs, int money)
        {
            for (int k = 0; k < 255; k++)
            {
                Player player = Main.player[k];
                if (!player.active)
                {
                    continue;
                }

                foreach (Item item in player.inventory)
                {
                    if (item.type == ModContent.ItemType("ExampleItem") || item.type == ModContent.ItemType("ExampleBlock"))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        // Example Person needs a house built out of ExampleMod tiles. You can delete this whole method in your townNPC for the regular house conditions.
        /*public override bool CheckConditions(int left, int right, int top, int bottom)
        {
            int score = 0;
            for (int x = left; x <= right; x++)
            {
                for (int y = top; y <= bottom; y++)
                {
                    int type = Main.tile[x, y].type;
                    if (type == ModContent.TileType("ExampleBlock") || type == ModContent.TileType("ExampleChair") || type == ModContent.TileType("ExampleWorkbench") || type == ModContent.TileType("ExampleBed") || type == ModContent.TileType("ExampleDoorOpen") || type == ModContent.TileType("ExampleDoorClosed"))
                    {
                        score++;
                    }
                    if (Main.tile[x, y].wall == mod.WallType("ExampleWall"))
                    {
                        score++;
                    }
                }
            }
            return score >= (right - left) * (bottom - top) / 2;
        }*/

        public override string TownNPCName()
        {
            switch (WorldGen.genRand.Next(10))
            {
                case 0:
                    return "bull";
                case 1:
                    return "smasher";
                case 2:
                    return "sandy";
                case 3:
                    return "antilon";
                default:
                    return "sandinmyeye";//Bao Bao
            }
        }

        public override void FindFrame(int frameHeight)
        {
            /*NPC.frame.Width = 40;
			if (((int)Main.time / 10) % 2 == 0)
			{
				NPC.frame.X = 40;
			}
			else
			{
				NPC.frame.X = 0;
			}*/
        }

        public override string GetChat()
        {
            switch (Main.rand.Next(3))
            {
                case 0:
                    return "don't get too close.";
                case 1:
                    return "I miss the sand.";
                case 2:
                    return "I wish there were more scorpion snacks.";
                default:
                    return "If you get kicked out of the sand, does that mean that you still cant suffocate";//I ain't selling nothing till you kill that eye

            }
        }

        /* 
		// Consider using this alternate approach to choosing a random thing. Very useful for a variety of use cases.
		// The WeightedRandom class needs "using Terraria.Utilities;" to use
		public override string GetChat()
		{
			WeightedRandom<string> chat = new WeightedRandom<string>();
			int partyGirl = NPC.FindFirstNPC(NPCID.PartyGirl);
			if (partyGirl >= 0 && Main.rand.NextBool(4))
			{
				chat.Add("Can you please tell " + Main.NPC[partyGirl].GivenName + " to stop decorating my house with colors?");
			}
			chat.Add("Sometimes I feel like I'm different from everyone else here.");
			chat.Add("What's your favorite color? My favorite colors are white and black.");
			chat.Add("What? I don't have any arms or legs? Oh, don't be ridiculous!");
			chat.Add("This message has a weight of 5, meaning it appears 5 times more often.", 5.0);
			chat.Add("This message has a weight of 0.1, meaning it appears 10 times as rare.", 0.1);
			return chat; // chat is implicitly cast to a string. You can also do "return chat.Get();" if that makes you feel better
		}
		*/

        public override void SetChatButtons(ref string button, ref string button2)
        {
            button = Language.GetTextValue("LegacyInterface.28");
            //button2 = "Awesomeify";
        }

        public override void OnChatButtonClicked(bool firstButton, ref bool shop)
        {
            if (firstButton)
            {
                shop = true;
            }
            else
            {
                // If the 2nd button is pressed, open the inventory...
                Main.playerInventory = true;
                // remove the chat window...
                Main.NPCChatText = "";
                // and start an instance of our UIState.
                //elias.Instance.ExamplePersonUserInterface.SetState(new UI.ExamplePersonUI());//started with examplemod
                // Note that even though we remove the chat window, Main.LocalPlayer.talkNPC will still be set correctly and we are still technically chatting with the NPC.
            }
        }

        public override void SetupShop(Chest shop, ref int nextSlot)
        {

            /*if (Main.LocalPlayer.HasBuff(ModContent.BuffType.Lifeforce))
            {
                shop.item[nextSlot].SetDefaults(ModContent.ItemType("ExampleHealingPotion"));
                nextSlot++;
            }*/
            /*if (Main.LocalPlayer.GetModPlayer<exampleplayer>().ZoneExample && !ExampleMod.exampleServerConfig.DisableExampleWings)
            {
                shop.item[nextSlot].SetDefaults(ModContent.ItemType("ExampleWings"));
                nextSlot++;
            }*/
            /*shop.item[nextSlot].SetDefaults(ItemID.);
            nextSlot++;*/
            shop.item[nextSlot].SetDefaults(ModContent.ItemType("housebomb"));
            nextSlot++;//housebomb
            shop.item[nextSlot].SetDefaults(169);
            nextSlot++;
            if (NPC.downedBoss1)//eoc
            {
                shop.item[nextSlot].SetDefaults(ModContent.ItemType("boomerangant"));
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ModContent.ItemType("CrimtaneLeechRing"));
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ModContent.ItemType("arrowsand"));
                nextSlot++;//housebomb
                shop.item[nextSlot].SetDefaults(266);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(323);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(3772);//169
                nextSlot++;
            }
            // Here is an example of how your NPC can sell items from other mods.

            /*if (!Main.LocalPlayer.GetModPlayer<exampleplayer>().examplePersonGiftReceived && ExampleMod.exampleServerConfig.ExamplePersonFreeGiftList != null)
            {
                foreach (var item in ExampleMod.exampleServerConfig.ExamplePersonFreeGiftList)
                {
                    if (item.IsUnloaded)
                        continue;
                    shop.item[nextSlot].SetDefaults(item.GetID());
                    shop.item[nextSlot].shopCustomPrice = 0;
                    shop.item[nextSlot].GetGlobalItem<ExampleInstancedGlobalItem>().examplePersonFreeGift = true;
                    nextSlot++;
                    // TODO: Have tModLoader handle index issues.
                }
            }*/
        }

        public override void NPCLoot()
        {
            //Item.NewItem(NPC.getRect(), ModContent.ItemType<Items.Armor.ExampleCostume>());
        }

        public override void TownNPCAttackStrength(ref int damage, ref float knockback)
        {
            damage = 20;
            knockback = 12f;
        }

        public override void TownNPCAttackCooldown(ref int cooldown, ref int randExtraCooldown)
        {
            cooldown = 1;
            randExtraCooldown = 1;
        }

        public override void TownNPCAttackProj(ref int projType, ref int attackDelay)
        {
            projType = ModContent.ProjectileType("meepshot");
            attackDelay = 1;
        }

        public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset)
        {
            multiplier = 12f;
            randomOffset = 2f;
        }
    }
}