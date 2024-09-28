using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace gracosmod123.NPCs
{
    // [AutoloadHead] and NPC.townNPC are extremely important and absolutely both necessary for any Town NPC to work at all.
    [AutoloadHead]
    public class ExamplePerson : ModNPC
    {
        public override string Texture => "gracosmod123/NPCs/ExamplePerson";

        //public override string[] AltTextures => new[] { "gracosmod123/townNPCs/ExamplePerson_Alt_1" };

        public override bool Autoload(ref string name)
        {
            name = "Pandonian";
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
            NPC.LifeMax = 9999999;
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
                    if (item.type == ModContent.ItemType("") || item.type == ModContent.ItemType(""))
                    {
                        return true;
                    }
                }
            }
            return false;/*
            if (NPC.downedBoss1)  //so after the EoC is killed
            {
                return true;
            }
            return false;*/
        }/*
                public override bool CanTownNPCSpawn(int numTownNPCs, int money) //Whether or not the conditions have been met for this town NPC to be able to move into town.
        {
            if (NPC.downedBoss1)  //so after the EoC is killed
            {
                return true;
            }
            return false;
        }*/

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
                    return "Pandian";
                case 1:
                    return "Pandonia";
                case 2:
                    return "Mrs. Bamboo";
                case 3:
                    return "Bao Bao";
                case 4:
                    return "Pochoo";
                case 5:
                    return "Sunshine";//Sunshine
                case 6:
                    return "Bamboo";//Sunshine
                case 7:
                    return "Sunshine";//Sunshine
                case 8:
                    return "Clingy Panda";//Sunshine
                case 9:
                    return "Cookie";//Sunshine
                default:
                    return "Noodles";//Bao Bao
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
            /*int partyGirl = NPC.FindFirstNPC(NPCID.PartyGirl);
            if (partyGirl >= 0 && Main.rand.NextBool(4))
            {
                return "Can you please tell " + Main.NPC[partyGirl].GivenName + " to keep decorating my house with colors?";
            }*/
            switch (Main.rand.Next(4))
            {
                case 0:
                    return "Fighting a giant eyeball just doesn't appeal to me. I don't know why, but I tried and it doesn't taste good.";
                case 1:
                    return "What's your favorite color? My favorite colors are white and black.";
                case 2:
                    return "I stored up a bunch of bamboo and left it for a week in the sun. It turned into zombies, which also taste pretty good.";
                case 3:
                    return "Pandas love explosives everyone knows that,.";
                default:
                    return "Moon lord flesh tastes a little cheesy, is that because the moon is made of cheese?";
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
                //gracosmod123.Instance.ExamplePersonUserInterface.SetState(new UI.ExamplePersonUI());//started with examplemod
                // Note that even though we remove the chat window, Main.LocalPlayer.talkNPC will still be set correctly and we are still technically chatting with the NPC.
            }
        }

        public override void SetupShop(Chest shop, ref int nextSlot)
        {
            shop.item[nextSlot].SetDefaults(ModContent.ItemType(""));
            nextSlot++;
            shop.item[nextSlot].SetDefaults(ModContent.ItemType("pandablock"));
            nextSlot++;
            shop.item[nextSlot].SetDefaults(ModContent.ItemType("CustomBombItem"));
            nextSlot++;
            shop.item[nextSlot].SetDefaults(ModContent.ItemType(""));
            nextSlot++;
            shop.item[nextSlot].SetDefaults(ModContent.ItemType(""));
            nextSlot++;
            shop.item[nextSlot].SetDefaults(ModContent.ItemType(""));
            nextSlot++;
            shop.item[nextSlot].SetDefaults(ModContent.ItemType(""));
            nextSlot++;
            shop.item[nextSlot].SetDefaults(ModContent.ItemType(""));
            nextSlot++;
            shop.item[nextSlot].SetDefaults(ModContent.ItemType(""));
            nextSlot++;
            shop.item[nextSlot].SetDefaults(ModContent.ItemType(""));
            nextSlot++;
            if (NPC.downedBoss1)   //this make so when the king slime is killed the town NPC will sell this
            {
                shop.item[nextSlot].SetDefaults(ModContent.ItemType("golemswordsword"));  //an example of how to add a vanilla terraria item
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ModContent.ItemType("encimpstaff"));
                nextSlot++;
            }
            if (NPC.downedSlimeKing)   //this make so when the king slime is killed the town NPC will sell this
            {
                shop.item[nextSlot].SetDefaults(ModContent.ItemType(""));  //an example of how to add a vanilla terraria item
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ModContent.ItemType(""));
                nextSlot++;
            }
            if (NPC.downedBoss3)   //this make so when Skeletron is killed the town NPC will sell this
            {
                shop.item[nextSlot].SetDefaults(ModContent.ItemType(""));
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ModContent.ItemType(""));
                nextSlot++;
            }
            if (Main.hardMode)   //this make so when hardmode is open the town NPC will sell this
            {
                shop.item[nextSlot].SetDefaults(ModContent.ItemType("ANTEGGSUMMON"));
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ModContent.ItemType(""));
                nextSlot++;
            }
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
            if (Main.moonPhase < 2)
            {
                shop.item[nextSlot].SetDefaults(ModContent.ItemType(""));
                nextSlot++;
            }
            else if (Main.moonPhase < 4)
            {
                shop.item[nextSlot].SetDefaults(ModContent.ItemType(""));
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ModContent.ItemType(""));
                nextSlot++;
            }
            else if (Main.moonPhase < 6)
            {
                shop.item[nextSlot].SetDefaults(ModContent.ItemType(""));
                nextSlot++;
            }
            else
            {
            }
            // Here is an example of how your NPC can sell items from other mods.
            var modSummonersAssociation = ModLoader.GetMod("");
            if (modSummonersAssociation != null)
            {
                shop.item[nextSlot].SetDefaults(modSummonersAssociation.ItemType(""));
                nextSlot++;
            }

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
            knockback = 12000f;
            if (Main.hardMode)
            {
                damage = 35;
            }
            if (NPC.downedPlantBoss)
            {
                damage = 55;
            }
            if (NPC.downedGolemBoss)
            {
                damage = 65;
            }
            if (NPC.downedMoonlord)
            {
                damage = 123;
            }
        }

        public override void TownNPCAttackCooldown(ref int cooldown, ref int randExtraCooldown)
        {
            cooldown = 1;
            randExtraCooldown = 1;
        }

        public override void TownNPCAttackProj(ref int projType, ref int attackDelay)
        {
            projType = ModContent.ProjectileType("bamboodiscus");
            attackDelay = 1;
        }

        public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset)
        {
            multiplier = 12f;
            randomOffset = 2f;
        }
    }
}/*
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ID;
using Terraria;
using Terraria.ModLoader;

namespace TutorialMOD.NPCs            //We need this to basically indicate the folder where it is to be read from, so you the texture will load correctly
{
    public class CustomTownNPC : ModNPC
    {
        public override bool Autoload(ref string name, ref string texture, ref string[] altTextures)
        {
            name = "Custom Town NPC";
            return mod.Properties.Autoload;
        }
        public override void SetDefaults()
        {
            NPC.name = "Custom Town NPC";   //the name displayed when hovering over the NPC ingame.
            NPC.townNPC = true; //This defines if the NPC is a town NPC or not
            NPC.friendly = true;  //this defines if the NPC can hur you or not()
            NPC.width = 18; //the NPC sprite width
            NPC.height = 46;  //the NPC sprite height
            NPC.aiStyle = 7; //this is the NPC ai style, 7 is Pasive Ai
            NPC.defense = 25;  //the NPC defense
            NPC.LifeMax = 250;// the NPC life
            NPC.HitSound = SoundID.NPCHit1;  //the NPC sound when is hit
            NPC.DeathSound = SoundID.NPCDeath1;  //the NPC sound when he dies
            NPC.knockBackResist = 0.5f;  //the NPC knockback resistance
            Main.NPCFrameCount[NPC.type] = 25; //this defines how many frames the NPC sprite sheet has
            NPCID.Sets.ExtraFramesCount[NPC.type] = 9;
            NPCID.Sets.AttackFrameCount[NPC.type] = 4;
            NPCID.Sets.DangerDetectRange[NPC.type] = 150; //this defines the NPC danger detect range
            NPCID.Sets.AttackType[NPC.type] = 3; //this is the attack type,  0 (throwing), 1 (shooting), or 2 (magic). 3 (melee) 
            NPCID.Sets.AttackTime[NPC.type] = 30; //this defines the NPC attack speed
            NPCID.Sets.AttackAverageChance[NPC.type] = 10;//this defines the NPC atack chance
            NPCID.Sets.HatOffsetY[NPC.type] = 4; //this defines the party hat position
            animationType = NPCID.Guide;  //this copy the guide animation
        }
        public override bool CanTownNPCSpawn(int numTownNPCs, int money) //Whether or not the conditions have been met for this town NPC to be able to move into town.
        {
            if (NPC.downedBoss1)  //so after the EoC is killed
            {
                return true;
            }
            return false;
        }
        public override bool CheckConditions(int left, int right, int top, int bottom)    //Allows you to define special conditions required for this town NPC's house
        {
            return true;  //so when a house is available the NPC will  spawn
        }
        public override string TownNPCName()     //Allows you to give this town NPC any name when it spawns
        {
            switch (WorldGen.genRand.Next(6))
            {
                case 0:
                    return "Rick";
                case 1:
                    return "Denis";
                case 2:
                    return "Heisenberg";
                case 3:
                    return "Jack";
                case 4:
                    return "Blue Magic";
                case 5:
                    return "Blue";
                default:
                    return "Walter";
            }
        }

        public override void SetChatButtons(ref string button, ref string button2)  //Allows you to set the text for the buttons that appear on this town NPC's chat window. 
        {
            button = "Buy Potions";   //this defines the buy button name
        }
        public override void OnChatButtonClicked(bool firstButton, ref bool openShop) //Allows you to make something happen whenever a button is clicked on this town NPC's chat window. The firstButton parameter tells whether the first button or second button (button and button2 from SetChatButtons) was clicked. Set the shop parameter to true to open this NPC's shop.
        {

            if (firstButton)
            {
                openShop = true;   //so when you click on buy button opens the shop
            }
        }

        public override void SetupShop(Chest shop, ref int nextSlot)       //Allows you to add items to this town NPC's shop. Add an item by setting the defaults of shop.item[nextSlot] then incrementing nextSlot.
        {
            if (NPC.downedSlimeKing)   //this make so when the king slime is killed the town NPC will sell this
            {
                shop.item[nextSlot].SetDefaults(ItemID.RecallPotion);  //an example of how to add a vanilla terraria item
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ItemID.WormholePotion);
                nextSlot++;
            }
            if (NPC.downedBoss3)   //this make so when Skeletron is killed the town NPC will sell this
            {
                shop.item[nextSlot].SetDefaults(ItemID.BookofSkulls);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ItemID.ClothierVoodooDoll);
                nextSlot++;
            }
            shop.item[nextSlot].SetDefaults(ItemID.IronskinPotion);
            nextSlot++;
            shop.item[nextSlot].SetDefaults(ModContent.ItemType("CustomSword"));  //this is an example of how to add a modded item
            nextSlot++;

        }

        public override string GetChat()       //Allows you to give this town NPC a chat message when a player talks to it.
        {
            int wizardNPC = NPC.FindFirstNPC(NPCID.Wizard);   //this make so when this NPC is close to Wizard
            if (wizardNPC >= 0 && Main.rand.Next(4) == 0)    //has 1 in 3 chance to show this message
            {
                return "Yes " + Main.NPC[wizardNPC].displayName + " is a wizard.";
            }
            int guideNPC = NPC.FindFirstNPC(NPCID.Guide); //this make so when this NPC is close to the Guide
            if (guideNPC >= 0 && Main.rand.Next(4) == 0) //has 1 in 3 chance to show this message
            {
                return "Sure you can ask " + Main.NPC[guideNPC].displayName + " how to make Ironskin potion or you can buy it from me..hehehe.";
            }
            switch (Main.rand.Next(4))    //this are the messages when you talk to the NPC
            {
                case 0:
                    return "You wanna buy something?";
                case 1:
                    return "What you want?";
                case 2:
                    return "I like this house.";
                case 3:
                    return "<I'm blue dabu di dabu dai>....OH HELLO THERE..";
                default:
                    return "Go kill Skeletron.";

            }
        }
        public override void TownNPCAttackStrength(ref int damage, ref float knockback)//  Allows you to determine the damage and knockback of this town NPC attack
        {
            damage = 40;  //NPC damage
            knockback = 2f;   //NPC knockback
        }

        public override void TownNPCAttackCooldown(ref int cooldown, ref int randExtraCooldown)  //Allows you to determine the cooldown between each of this town NPC's attack. The cooldown will be a number greater than or equal to the first parameter, and less then the sum of the two parameters.
        {
            cooldown = 5;
            randExtraCooldown = 10;
        }
        //------------------------------------This is an example of how to make the NPC use a sward attack-------------------------------
        public override void DrawTownAttackSwing(ref Texture2D item, ref int itemSize, ref float scale, ref Vector2 offset)//Allows you to customize how this town NPC's weapon is drawn when this NPC is swinging it (this NPC must have an attack type of 3). Item is the Texture2D instance of the item to be drawn (use ModContent.Request[id of item]), itemSize is the width and height of the item's hitbox
        {
            scale = 1f;
            item = ModContent.Request[ModContent.ItemType("CustomSword")]; //this defines the item that this NPC will use
            itemSize = 56;
        }

        public override void TownNPCAttackSwing(ref int itemWidth, ref int itemHeight) //  Allows you to determine the width and height of the item this town NPC swings when it attacks, which controls the range of this NPC's swung weapon.
        {
            itemWidth = 56;
            itemHeight = 56;
        }

        //----------------------------------This is an example of how to make the NPC use a gun and a projectile ----------------------------------
        /*public override void DrawTownAttackGun(ref float scale, ref int item, ref int closeness) //Allows you to customize how this town NPC's weapon is drawn when this NPC is shooting (this NPC must have an attack type of 1). Scale is a multiplier for the item's drawing size, item is the ID of the item to be drawn, and closeness is how close the item should be drawn to the NPC.
          {
              scale = 1f;
              item = ModContent.ItemType("GunName");  
              closeness = 20;
          }
          public override void TownNPCAttackProj(ref int projType, ref int attackDelay)//Allows you to determine the projectile type of this town NPC's attack, and how long it takes for the projectile to actually appear
          {
              projType = ProjectileID.CrystalBullet;
              attackDelay = 1;
          }

          public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset)//Allows you to determine the speed at which this town NPC throws a projectile when it attacks. Multiplier is the speed of the projectile, gravityCorrection is how much extra the projectile gets thrown upwards, and randomOffset allows you to randomize the projectile's velocity in a square centered around the original velocity
          {
              multiplier = 7f;
             // randomOffset = 4f;

          }   *//*

    }
}*/