using System;//uses the systems
using Microsoft.Xna.Framework;//uses math and other properties
using Terraria;// uses terraria stuff
using Terraria.ID;// uses projectile and item IDs
using Terraria.ModLoader;//uses tmodloader stuff
using Terraria.GameContent.Events;//uses moments like raining or in the jungle
using Terraria.Localization;//uses the localization folders
using System.IO;//what?
using Microsoft.Xna.Framework.Graphics;//framework
using Terraria.Utilities;
namespace gracosmod123.NPCs//location in the folders

{
    [AutoloadHead]
    public class Harpy : ModNPC
    {
        public override void SetDefaults()
        {
            NPC.LifeMax = 165;
            NPC.damage = 12;
            NPC.defense = 8;
            NPC.knockBackResist = 0f;
            NPC.width = 78;
            NPC.height = 54;
            NPC.aiStyle = 44;
            aiType = NPCID.FlyingFish;
            animationType = 48;
            NPC.NPCSlots = 0.5f;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.noGravity = true;
            NPC.NPCSlots = 2f;
            NPC.DeathSound = SoundID.NPCDeath1;
            NPC.value = Item.buyPrice(0, 0, 34, 5);
            //bannerItem = ModContent.ItemType("BirdTravellerBanner");
            //banner = NPC.type;
            NPC.rarity = 1;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Mysteryskeeto");
            Main.NPCFrameCount[NPC.type] = 4;
        }

        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            NPC.LifeMax = (int)(NPC.LifeMax * 1);
            NPC.damage = (int)(NPC.damage * 1);
        }

        private float timer;
        public override void AI()
        {
            NPC.TargetClosest(true);
            Player player = Main.player[NPC.target];
            ++timer;
            if (timer >= 180f && timer % 20f == 0f)
            {
                Vector2 player2 = player.Center;
                Vector2 vector2_1 = player2;
                float speed = 10f;
                Vector2 vector2_2 = vector2_1 - NPC.Center;
                float distance = (float)Math.Sqrt((double)vector2_2.X * (double)vector2_2.X + (double)vector2_2.Y * (double)vector2_2.Y);
                vector2_2 *= speed / distance;
                Projectile.NewProjectileDirect(NPC.Center.X, NPC.Center.Y, vector2_2.X, vector2_2.Y, ModContent.ProjectileType("shotharp"), NPC.damage / 3 + 15, 5.0f, 0, 0.0f, 0.0f);
            }
            if (timer >= 180f && timer % 20f == 0f)
            {
                Vector2 player2 = player.Center;
                Vector2 vector2_1 = player2;
                float speed = 25f;
                Vector2 vector2_2 = vector2_1 - NPC.Center;
                float distance = (float)Math.Sqrt((double)vector2_2.X * (double)vector2_2.X + (double)vector2_2.Y * (double)vector2_2.Y);
                vector2_2 *= speed / distance;
                Projectile.NewProjectileDirect(NPC.Center.X, NPC.Center.Y, vector2_2.X, vector2_2.Y, ModContent.ProjectileType("shotharpHoming"), NPC.damage / 3 + 15, 5.0f, 0, 0.0f, 0.0f);
            }
            if (timer >= 260.0f)
                timer = 0.0f;
        }

        public override void HitEffect(int hitDirection, double damage)
        {
            if (NPC.life <= 0)
            {
                for (int k = 0; k < 20; k++)
                {
                    Dust.NewDust(NPC.position, NPC.width, NPC.height, 151, 2.5f * (float)hitDirection, -2.5f, 0, default(Color), 0.7f);
                }
            }
        }

        public override void NPCLoot()
        {
            if (Main.netMode != 1)
            {
                int centerX = (int)(NPC.position.X + (float)(NPC.width / 2)) / 16;
                int centerY = (int)(NPC.position.Y + (float)(NPC.height / 2)) / 16;
                int halfLength = NPC.width / 2 / 16 + 1;
                if (Main.rand.Next(2) == 0)
                {
                    Item.NewItem((int)NPC.position.X, (int)NPC.position.Y, NPC.width, NPC.height, ModContent.ItemType("randombox"), Main.rand.Next(100, 500), false, 0, false, false);
                }
                if (Main.rand.Next(2) == 0)
                {
                    Item.NewItem((int)NPC.position.X, (int)NPC.position.Y, NPC.width, NPC.height, ModContent.ItemType("Gun"), 1, false, 0, false, false);
                }
            }
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            return spawnInfo.sky ? 0.11f : 0f;
        }
    }
}
