using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.IO;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Events;
using Terraria.Localization;
using Terraria.ModLoader;
using gracosmod123.NPCs.wormboss;
using Microsoft.Xna.Framework.Graphics;
namespace gracosmod123.NPCs.wormboss
{
    [AutoloadBossHead]
    public class GrandCactusWormHead : ModNPC
    {
        int _despawn = 0;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("The Jade wyrm");
            Main.NPCFrameCount[NPC.type] = 2;
        }

        public override void SetDefaults()
        {
            NPC.active = true;
            NPC.LifeMax = 13000;
            NPC.damage = 27;
            NPC.defense = 8;
            NPC.knockBackResist = 0f;
            NPC.width = 86;
            NPC.height = 106;
            NPC.noGravity = true;
            NPC.NoTileCollide = true;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;
            NPC.behindTiles = true;
            NPC.value = Item.buyPrice(0, 6, 0, 0);
            NPC.netAlways = true;
            NPC.boss = true;
            NPC.lavaImmune = true;
            NPC.dontTakeDamage = false;
            //bossBag = ModContent.ItemType("GrandCactusWormBag");
            //music = mod.GetSoundSlot(SoundType.Music, "Sounds/Music/DeoremMua");
            musicPriority = MusicPriority.BossHigh;
        }

        public override void FindFrame(int frameHeight)
        {
            if (NPC.ai[1] % 25 <= 12)
            {
                NPC.frame.Y = 0;
            }
            else
            {
                NPC.frame.Y = 108;
            }
        }
        public override bool CanHitPlayer(Player target, ref int cooldownSlot)
        {
            if (Vector2.Distance(target.Center, NPC.Center) > 50)
            {
                return false;
            }
            return base.CanHitPlayer(target, ref cooldownSlot);
        }
        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            NPC.LifeMax = (int)(NPC.LifeMax * 0.7f * bossLifeScale) + 1;
            NPC.damage = (int)(NPC.damage * 0.7f);
        }
        public override void BossHeadRotation(ref float rotation)
        {
            rotation = NPC.rotation;
        }
        public override void BossLoot(ref string name, ref int potionType)
        {
            potionType = ItemID.RestorationPotion;
        }
        private void GenerateCrystals()
        {

            Cactusworld.GenCrystals();

        }
        public override void HitEffect(int hitDirection, double damage)
        {
            if (NPC.life <= 0)
            {
                Gore.NewGore(NPC.position, NPC.velocity, mod.GetGoreSlot("NPCs/ wormboss/GrandCactusWormHead_Gore"), NPC.scale);
                GenerateCrystals();
            }

        }
        public override void NPCLoot()
        {
            // if (!JoostWorld.downedCactusWorm)
            // {
            //     NPC.DropItemInstanced(NPC.position, NPC.Size, ModContent.ItemType("GrandCactusWorm"), 1, false);
            // }
            if (Main.expertMode)
            {
                NPC.DropBossBags();
            }
            else
            {
                /*Item.NewItem((int)NPC.position.X, (int)NPC.position.Y, NPC.width, NPC.height, ModContent.ItemType("LusciousCactus"), 8 + Main.rand.Next(8));
                if (Main.rand.Next(4) == 0)
                {
                    Item.NewItem((int)NPC.position.X, (int)NPC.position.Y, NPC.width, NPC.height, ModContent.ItemType("DeoremMuaMusicBox"));
                }
                if (Main.rand.Next(7) == 0)
                {
                    Item.NewItem((int)NPC.position.X, (int)NPC.position.Y, NPC.width, NPC.height, ModContent.ItemType("GrandCactusWormMask"));
                }
                if (Main.rand.Next(10) == 0)
                {
                    Item.NewItem((int)NPC.position.X, (int)NPC.position.Y, NPC.width, NPC.height, ModContent.ItemType("GrandCactusWormTrophy"));
                }*/
            }
            // JoostWorld.downedCactusWorm = true;
        }
        Vector2 targetPos = Vector2.Zero;
        double speed = 10f;
        public override void SendExtraAI(BinaryWriter writer)
        {
            writer.WriteVector2(targetPos);
            writer.Write(speed);
        }
        public override void ReceiveExtraAI(BinaryReader reader)
        {
            targetPos = reader.ReadVector2();
            speed = reader.ReadDouble();
        }
        public override bool PreAI()
        {
            Player P = Main.player[NPC.target];
            if (!Main.player[NPC.target].active || Main.player[NPC.target].dead)
            {
                NPC.TargetClosest(true);
                if (!Main.player[NPC.target].active || Main.player[NPC.target].dead)
                {
                    if (_despawn == 0)
                        _despawn++;
                }
            }
            else if (!Main.dayTime)
                _despawn = 0;
            if (P.ZoneUndergroundDesert || Vector2.Distance(NPC.Center, P.MountedCenter) > 4000 || NPC.target < 0 || NPC.target == 255 || P.dead || !P.active)
            {
                NPC.active = true;
                NPC.dontTakeDamage = false;
            }
            else
            {
                NPC.dontTakeDamage = true;
            }
            if (_despawn >= 1)
            {
                _despawn++;
                NPC.NoTileCollide = true;
                if (_despawn >= 300)
                    NPC.active = false;
                _despawn = 0;
            }
            //Everything else
            if (Main.netMode != 1)
            {
                if (NPC.ai[0] == 0)
                {
                    NPC.realLife = NPC.whoAmI;
                    int latestNPC = NPC.whoAmI;
                    int cactusWormLength = 18;
                    for (int i = 0; i < cactusWormLength; ++i)
                    {
                        latestNPC = NPC.NewNPC((int)NPC.Center.X, (int)NPC.Center.Y, ModContent.NPCType("GrandCactusWormBody"), NPC.whoAmI, 0, latestNPC);
                        Main.NPC[(int)latestNPC].realLife = NPC.whoAmI;
                        Main.NPC[(int)latestNPC].ai[3] = NPC.whoAmI;
                    }
                    latestNPC = NPC.NewNPC((int)NPC.Center.X, (int)NPC.Center.Y, ModContent.NPCType("GrandCactusWormTail"), NPC.whoAmI, 0, latestNPC);
                    Main.NPC[(int)latestNPC].realLife = NPC.whoAmI;
                    Main.NPC[(int)latestNPC].ai[3] = NPC.whoAmI;
                    NPC.ai[0] = 1;
                    NPC.netUpdate = true;
                }
            }
            NPC.ai[2] = 0;
            if (NPC.life < NPC.LifeMax / 7 && NPC.ai[0] != 0 && Main.expertMode)
            {
                NPC.ai[0] = 2;
            }
            else
            {
                NPC.ai[0] = 1;
            }
            NPC.rotation = (float)Math.Atan2(NPC.velocity.Y, NPC.velocity.X) + 1.57f;
            if (NPC.ai[3] == 0)
            {
                music = MusicID.Desert;
                NPC.ai[1] = 0;
                speed = 5;
                NPC.life = NPC.life < NPC.LifeMax ? NPC.life + 1 + (int)((float)NPC.LifeMax * 0.001f) : NPC.LifeMax;
                targetPos = NPC.Center + new Vector2((float)Math.Cos(NPC.rotation - 1.585f) * 160, (float)Math.Sin(NPC.rotation - 1.585f) * 160);
                NPC.velocity = NPC.DirectionTo(targetPos) * (float)speed;
                NPC.ai[2] = 0;
                if (Vector2.Distance(NPC.Center, P.MountedCenter) < 9999999999999999 && P.active && !P.dead)
                {
                    targetPos = new Vector2(P.MountedCenter.X - 300, P.MountedCenter.Y - 300);
                    speed = 20;
                    if (Vector2.Distance(targetPos, NPC.Center) < 40)
                    {
                        NPC.ai[3] = 1;
                    }
                }
            }
            else
            {
                NPC.direction = NPC.velocity.X < 0 ? -1 : 1;
                //music = mod.GetSoundSlot(SoundType.Music, "Sounds/Music/DeoremMua");
                if (NPC.ai[1] == 0)
                {
                    targetPos = new Vector2(NPC.Center.X, NPC.Center.Y + 500);
                    speed = 20;
                }
                if (NPC.ai[1] == 24)
                {
                    targetPos = new Vector2(NPC.Center.X + 850, NPC.Center.Y);
                    speed = 20;
                }
                if (NPC.ai[1] == 66)
                {
                    targetPos = new Vector2(NPC.Center.X, NPC.Center.Y - 850);
                    speed = 20;
                }
                if (NPC.ai[1] == 110)
                {
                    targetPos = new Vector2(NPC.Center.X - 350, NPC.Center.Y);
                    speed = 16;
                }
                if (NPC.ai[1] == 130)
                {
                    targetPos = new Vector2(NPC.Center.X, NPC.Center.Y + 400);
                    speed = 4;
                }
                if (NPC.ai[1] >= 225 && NPC.ai[1] < 425)
                {
                    targetPos = new Vector2(P.MountedCenter.X + (NPC.ai[1] % 100 < 50 ? 150 : -150), P.MountedCenter.Y - 200 + (NPC.ai[1] % 60 < 30 ? 16 : -16));
                    speed = 4;
                    Vector2 dir = NPC.DirectionTo(P.MountedCenter);
                    NPC.rotation = (float)Math.Atan2(dir.Y, dir.X) + 1.57f;
                }
                if (NPC.ai[1] >= 425 && NPC.ai[1] < 550)
                {
                    targetPos = new Vector2(P.MountedCenter.X, P.MountedCenter.Y - 300 + (NPC.ai[1] % 20 < 10 ? 16 : -16));
                    speed = Math.Abs(NPC.Center.X - targetPos.X) < 16 ? 1 : 6;
                    Vector2 dir = NPC.DirectionTo(P.MountedCenter);
                    if (Main.expertMode && NPC.ai[1] > 500)
                    {
                        float sped = 15f;
                        Vector2 vel = new Vector2(P.velocity.X, 0);
                        Vector2 predictedPos = P.MountedCenter + P.velocity + (vel * (Vector2.Distance(P.MountedCenter, NPC.Center) / sped));
                        dir = NPC.DirectionTo(predictedPos);
                    }
                    NPC.rotation = (float)Math.Atan2(dir.Y, dir.X) + 1.57f;
                    if (NPC.ai[1] % 25 == 0 && Main.netMode != 1)
                    {
                        Projectile.NewProjectileDirect(NPC.Center + dir * 40, dir * 15, ModContent.ProjectileType("CactusWormBall"), 15, 5, Main.myPlayer);
                    }
                }
                if (NPC.ai[1] >= 550 && NPC.ai[1] < 575)
                {
                    targetPos = new Vector2(NPC.Center.X, NPC.Center.Y + 400);
                    speed = -2;
                    NPC.rotation = (float)Math.PI;
                }
                if (NPC.ai[1] == 575)
                {
                    targetPos = new Vector2(NPC.Center.X, NPC.Center.Y + 400);
                    NPC.rotation = (float)Math.PI;
                    speed = 16;
                    NPC.ai[2] = -1;
                    NPC.velocity = NPC.DirectionTo(targetPos) * (float)speed;
                }
                if (NPC.ai[1] >= 600 && NPC.ai[1] < 624)
                {
                    targetPos = new Vector2(P.MountedCenter.X, P.MountedCenter.Y + 300);
                    speed = 11;
                }
                if (NPC.ai[1] >= 624 && NPC.ai[1] < 820)
                {
                    targetPos = new Vector2(P.MountedCenter.X + (NPC.ai[1] % 100 < 50 ? 150 : -150), P.MountedCenter.Y + 250 + (NPC.ai[1] % 60 < 30 ? 16 : -16));
                    speed = 4;
                    Vector2 dir = NPC.DirectionTo(P.MountedCenter);
                    NPC.rotation = (float)Math.Atan2(dir.Y, dir.X) + 1.57f;
                }
                if (NPC.ai[1] >= 820 && NPC.ai[1] < 945)
                {
                    targetPos = new Vector2(P.MountedCenter.X, P.MountedCenter.Y + 250 + (NPC.ai[1] % 20 < 10 ? 16 : -16));
                    speed = Math.Abs(NPC.Center.X - targetPos.X) < 16 ? 1 : 6;
                    Vector2 dir = NPC.DirectionTo(P.MountedCenter);
                    if (Main.expertMode && NPC.ai[1] > 900)
                    {
                        float sped = 15f;
                        Vector2 vel = new Vector2(P.velocity.X, 0);
                        Vector2 predictedPos = P.MountedCenter + P.velocity + (vel * (Vector2.Distance(P.MountedCenter, NPC.Center) / sped));
                        dir = NPC.DirectionTo(predictedPos);
                    }
                    NPC.rotation = (float)Math.Atan2(dir.Y, dir.X) + 1.57f;
                    if (NPC.ai[1] % 25 == 0 && Main.netMode != 1)
                    {
                        Projectile.NewProjectileDirect(NPC.Center + dir * 40, dir * 15, ModContent.ProjectileType("CactusWormBall"), 15, 5, Main.myPlayer);
                    }
                }
                if (NPC.ai[1] >= 945 && NPC.ai[1] < 970)
                {
                    targetPos = new Vector2(NPC.Center.X, NPC.Center.Y - 400);
                    speed = -2;
                    NPC.rotation = 0;
                }
                if (NPC.ai[1] == 970)
                {
                    targetPos = new Vector2(NPC.Center.X, NPC.Center.Y - 400);
                    speed = 16;
                    NPC.rotation = 0;
                    NPC.ai[2] = -1;
                    NPC.velocity = NPC.DirectionTo(targetPos) * (float)speed;
                }
                if (NPC.ai[1] >= 995 && NPC.ai[1] < 1020)
                {
                    targetPos = new Vector2(P.MountedCenter.X - 400, P.MountedCenter.Y - 300);
                    NPC.ai[2] = 1;
                    speed = 10;
                }
                if (NPC.ai[1] == 1020)
                {
                    targetPos = new Vector2(P.MountedCenter.X + 200 * NPC.direction, P.MountedCenter.Y + 300);
                    speed = 14;
                    NPC.ai[2] = -1;
                    NPC.velocity = NPC.DirectionTo(targetPos) * (float)speed;
                }
                if (NPC.ai[1] >= 1050 && NPC.ai[1] < 1080)
                {
                    targetPos = new Vector2(P.MountedCenter.X + 200 * NPC.direction, P.MountedCenter.Y - 300);
                    NPC.ai[2] = 1;
                    speed = 2;
                }
                if (NPC.ai[1] == 1080)
                {
                    targetPos = new Vector2(P.MountedCenter.X + 200 * NPC.direction, P.MountedCenter.Y - 300);
                    speed = 14;
                    NPC.ai[2] = -1;
                    NPC.velocity = NPC.DirectionTo(targetPos) * (float)speed;
                }
                if (NPC.ai[1] >= 1111 && NPC.ai[1] < 1140)
                {
                    targetPos = new Vector2(P.MountedCenter.X + 100 * NPC.direction, P.MountedCenter.Y);
                    NPC.ai[2] = 1;
                    speed = 5;
                }
                if (NPC.ai[1] == 1140)
                {
                    targetPos = new Vector2(P.MountedCenter.X + 200, P.MountedCenter.Y - 100);
                    NPC.ai[2] = 1;
                    speed = 14;
                }
                if (NPC.ai[1] == 1160)
                {
                    targetPos = new Vector2(P.MountedCenter.X - 200, P.MountedCenter.Y - 100);
                    NPC.ai[2] = 1;
                    speed = 14;
                }
                if (NPC.ai[1] == 1180)
                {
                    targetPos = P.MountedCenter;
                    speed = 12;
                }
                /*if (NPC.ai[1] == 1215 || NPC.ai[1] == 1265 || NPC.ai[1] == 1315 || NPC.ai[1] == 1365)
                {
                    targetPos = P.MountedCenter;
                    speed = -2;
                    Vector2 dir = NPC.DirectionTo(P.MountedCenter);
                    NPC.rotation = (float)Math.Atan2(dir.Y, dir.X) + 1.57f;
                }*/
                if ((NPC.ai[1] >= 1215 && NPC.ai[1] < 1240) || (NPC.ai[1] >= 1265 && NPC.ai[1] < 1290) || (NPC.ai[1] >= 1315 && NPC.ai[1] < 1340) || (NPC.ai[1] >= 1365 && NPC.ai[1] < 1390) || (NPC.ai[1] >= 1410 && NPC.ai[1] < 1440))
                {
                    targetPos = P.MountedCenter;
                    speed = -2;
                    Vector2 dir = NPC.DirectionTo(P.MountedCenter);
                    NPC.rotation = (float)Math.Atan2(dir.Y, dir.X) + 1.57f;
                    NPC.ai[2] = -1;
                    NPC.velocity = NPC.DirectionTo(targetPos) * (float)speed;
                }
                if (NPC.ai[1] == 1240 || NPC.ai[1] == 1290 || NPC.ai[1] == 1340 || NPC.ai[1] == 1390)
                {
                    targetPos = P.MountedCenter;
                    speed = 12;
                    NPC.velocity = NPC.DirectionTo(targetPos) * (float)speed;
                }
                if (NPC.ai[1] >= 1240 && NPC.ai[1] <= 1390)
                {
                    NPC.ai[2] = -1;
                }
                if (NPC.ai[1] == 1440)
                {
                    targetPos = P.MountedCenter;
                    speed = 14;
                    NPC.velocity = NPC.DirectionTo(targetPos) * (float)speed;
                }
                if (NPC.ai[1] >= 1440 && NPC.ai[1] < 1460)
                {
                    NPC.ai[2] = -1;
                }
                if (NPC.ai[1] >= 1460 && NPC.ai[1] <= 1620)
                {
                    targetPos = P.MountedCenter;
                    speed = 5;
                    Vector2 dir = NPC.DirectionTo(P.MountedCenter);
                    if (Main.expertMode)
                    {
                        float sped = 15f;
                        Vector2 vel = new Vector2(P.velocity.X, 0);
                        Vector2 predictedPos = P.MountedCenter + P.velocity + (vel * (Vector2.Distance(P.MountedCenter, NPC.Center) / sped));
                        dir = NPC.DirectionTo(predictedPos);
                        targetPos = predictedPos;
                    }
                    NPC.rotation = (float)Math.Atan2(dir.Y, dir.X) + 1.57f;
                    if (Main.netMode != 1 && (NPC.ai[1] == 1494 || NPC.ai[1] == 1524 || NPC.ai[1] == 1620))
                    {
                        Projectile.NewProjectileDirect(NPC.Center + NPC.DirectionTo(targetPos) * 40, dir * 15, ModContent.ProjectileType("CactusWormBall"), 15, 5, Main.myPlayer);
                    }
                }

                if (NPC.ai[1] > 1620 && NPC.ai[1] < 1820)
                {
                    //targetPos = new Vector2(NPC.Center.X + 120 * NPC.direction, NPC.Center.Y + (NPC.ai[1] % 60 < 5 ? 90 : NPC.ai[1] % 60 < 10 ? 60 : NPC.ai[1] % 60 < 15 ? 30 : NPC.ai[1] % 60 < 20 ? 0 : NPC.ai[1] % 60 < 25 ? -30 : NPC.ai[1] % 60 < 30 ? -60 : NPC.ai[1] % 60 < 35 ? -90 : NPC.ai[1] % 60 < 40 ? -60 : NPC.ai[1] % 60 < 45 ? -30 : NPC.ai[1] % 60 < 50 ? 0 : NPC.ai[1] % 60 < 55 ? 30 : 60));
                    float rotation = NPC.ai[1] * 0.0174f * 9;
                    targetPos = P.MountedCenter + (new Vector2((float)(Math.Cos(rotation) * 100), (float)(Math.Sin(rotation) * 100)));
                    speed = 4;
                    NPC.ai[2] = 1;
                }
                if (NPC.ai[1] >= 1820 && NPC.ai[1] < 1945)
                {
                    targetPos = P.MountedCenter;
                    speed = 6;
                    Vector2 dir = NPC.DirectionTo(P.MountedCenter);
                    if (Main.expertMode && NPC.ai[1] % 50 > 20)
                    {
                        float sped = 15f;
                        Vector2 vel = new Vector2(P.velocity.X, 0);
                        Vector2 predictedPos = P.MountedCenter + P.velocity + (vel * (Vector2.Distance(P.MountedCenter, NPC.Center) / sped));
                        dir = NPC.DirectionTo(predictedPos);
                    }
                    NPC.rotation = (float)Math.Atan2(dir.Y, dir.X) + 1.57f;
                    if (NPC.ai[1] % 25 == 20 && Main.netMode != 1)
                    {
                        Projectile.NewProjectileDirect(NPC.Center + NPC.DirectionTo(targetPos) * 40, dir * 15, ModContent.ProjectileType("CactusWormBall"), 15, 5, Main.myPlayer);
                    }
                }
                if (NPC.ai[1] >= 1945 && NPC.ai[1] < 1970)
                {
                    targetPos = P.MountedCenter;
                    speed = Vector2.Distance(targetPos, NPC.Center) < 16 ? 0 : 1;
                }
                if (NPC.ai[1] == 1970)
                {
                    targetPos = P.MountedCenter;
                    speed = 12;
                }
                if (NPC.ai[1] >= 2019 && NPC.ai[1] < 2215)
                {
                    //targetPos = new Vector2(NPC.Center.X + 120 * NPC.direction, NPC.Center.Y + (NPC.ai[1] % 60 < 5 ? 90 : NPC.ai[1] % 60 < 10 ? 60 : NPC.ai[1] % 60 < 15 ? 30 : NPC.ai[1] % 60 < 20 ? 0 : NPC.ai[1] % 60 < 25 ? -30 : NPC.ai[1] % 60 < 30 ? -60 : NPC.ai[1] % 60 < 35 ? -90 : NPC.ai[1] % 60 < 40 ? -60 : NPC.ai[1] % 60 < 45 ? -30 : NPC.ai[1] % 60 < 50 ? 0 : NPC.ai[1] % 60 < 55 ? 30 : 60));
                    float rotation = NPC.ai[1] * 0.0174f * 9;
                    targetPos = P.MountedCenter + (new Vector2((float)(Math.Cos(rotation) * 100), (float)(Math.Sin(rotation) * 100)));
                    speed = 4;
                    NPC.ai[2] = 1;
                }
                if (NPC.ai[1] >= 2215 && NPC.ai[1] < 2340)
                {
                    targetPos = P.MountedCenter;
                    speed = 6;
                    Vector2 dir = NPC.DirectionTo(P.MountedCenter);
                    if (Main.expertMode && NPC.ai[1] % 50 > 15)
                    {
                        float sped = 15f;
                        Vector2 vel = new Vector2(P.velocity.X, 0);
                        Vector2 predictedPos = P.MountedCenter + P.velocity + (vel * (Vector2.Distance(P.MountedCenter, NPC.Center) / sped));
                        dir = NPC.DirectionTo(predictedPos);
                    }
                    NPC.rotation = (float)Math.Atan2(dir.Y, dir.X) + 1.57f;
                    if (NPC.ai[1] % 25 == 15 && Main.netMode != 1)
                    {
                        Projectile.NewProjectileDirect(NPC.Center + NPC.DirectionTo(targetPos) * 40, dir * 15, ModContent.ProjectileType("CactusWormBall"), 15, 5, Main.myPlayer);
                    }
                }
                if (NPC.ai[1] >= 2340 && NPC.ai[1] < 2365)
                {
                    targetPos = new Vector2(P.MountedCenter.X - 300, P.MountedCenter.Y - 300);
                    speed = 10;
                }
                if (NPC.ai[1] >= 2365)
                {
                    targetPos = new Vector2(P.MountedCenter.X - 300, P.MountedCenter.Y - 300);
                    speed = 25;
                }
                //music = mod.GetSoundSlot(SoundType.Music, "Sounds/Music/DeoremMua");
                NPC.ai[1]++;
                if (NPC.ai[1] > 2410)
                {
                    NPC.ai[1] = 0;
                }
            }
            if (NPC.ai[2] == 0 && (targetPos == P.MountedCenter || NPC.Distance(targetPos) < 100))
            {
                NPC.ai[2] = 1;
            }
            if (NPC.ai[2] > 0)
            {
                float home = 20f;
                Vector2 move = targetPos - NPC.Center;
                if (move.Length() > speed && speed > 0)
                {
                    move *= (float)(speed / move.Length());
                }
                NPC.velocity = ((home - 1f) * NPC.velocity + move) / home;
                if (NPC.velocity.Length() < speed && speed > 0)
                {
                    NPC.velocity *= (float)(speed / NPC.velocity.Length());
                }
            }
            else if (NPC.ai[2] == 0)
            {
                NPC.velocity = NPC.DirectionTo(targetPos) * (float)speed;
            }
            NPC.netUpdate = true;
            return false;
        }

        public override bool PreDraw(SpriteBatch spriteBatch, Color drawColor)
        {
            Texture2D texture = Main.NPCTexture[NPC.type];
            Vector2 origin = new Vector2(texture.Width * 0.5f, texture.Height * 0.5f);
            Rectangle? rect = new Rectangle?(new Rectangle(0, (texture.Height / Main.NPCFrameCount[NPC.type]) * (NPC.frame.Y / 108), texture.Width, texture.Height / Main.NPCFrameCount[NPC.type]));
            Main.spriteBatch.Draw(texture, NPC.Center - Main.screenPosition, rect, drawColor, NPC.rotation, origin, NPC.scale, SpriteEffects.None, 0);
            return false;
        }
        public override void PostDraw(SpriteBatch spriteBatch, Color drawColor)
        {
            Texture2D texture = mod.GetTexture("NPCs/wormboss/GrandCactusWormEyes");
            Vector2 origin = new Vector2(texture.Width * 0.5f, texture.Height * 0.5f);
            int eyeFrame = 0;
            Color color = Color.YellowGreen;
            if ((NPC.ai[1] >= 550 && NPC.ai[1] <= 575) || (NPC.ai[1] >= 945 && NPC.ai[1] < 970) || (NPC.ai[1] >= 995 && NPC.ai[1] < 1020) || (NPC.ai[1] >= 1110 && NPC.ai[1] < 1115) || (NPC.ai[1] >= 1120 && NPC.ai[1] < 1125) || (NPC.ai[1] >= 1130 && NPC.ai[1] < 1135) || (NPC.ai[1] >= 1215 && NPC.ai[1] < 1240) || (NPC.ai[1] >= 1265 && NPC.ai[1] < 1290) || (NPC.ai[1] >= 1315 && NPC.ai[1] < 1340) || (NPC.ai[1] >= 1365 && NPC.ai[1] < 1390) || (NPC.ai[1] >= 1410 && NPC.ai[1] < 1440) || (NPC.ai[1] >= 1945 && NPC.ai[1] < 1970) || (NPC.ai[1] >= 2340 && NPC.ai[1] < 2365))
            {
                eyeFrame = 1;
                color = Color.Red;
            }
            Rectangle? rect = new Rectangle?(new Rectangle(0, (texture.Height / 2) * eyeFrame, texture.Width, texture.Height / 2));
            Main.spriteBatch.Draw(texture, NPC.Center - Main.screenPosition, rect, color, NPC.rotation, origin, NPC.scale, SpriteEffects.None, 0);
        }
        public override bool? DrawHealthBar(byte hbPosition, ref float scale, ref Vector2 position)
        {
            scale = 1f;
            return null;
        }
        public override bool CheckActive()
        {
            return false;
        }
    }
}