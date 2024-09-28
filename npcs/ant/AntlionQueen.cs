using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.Events;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using System.IO;
using Microsoft.Xna.Framework.Graphics;
namespace gracosmod123.NPCs.ant
{
    [AutoloadBossHead]//AntlionQueen_Head_Boss
    public class AntlionQueen : ModNPC//				spriteBatch.Draw(mod.GetTexture("NPCs/Abomination/Rune"), NPC.Center - Main.screenPosition, null, new Color(255, 10, 0), rotation, new Vector2(64, 64), 1f, SpriteEffects.None, 0f);
    {
        private int ai;
        private int aiSECOND = 0;

        private double counting;
        private bool end = false;
        private int frame;
        private int moveSpeed;
        private int mv;
        private bool rage = false;
        private bool sAI = false;
        private bool stunned;
        private int stunnedTimer;
        private int swarmerSpawnTimer;

        public override void SetDefaults()
        {
            NPC.LifeMax = 6150;
            NPC.damage = 30;
            NPC.defense = 8;
            NPC.knockBackResist = 0f;
            NPC.width = 284;
            NPC.height = 256;
            NPC.NPCSlots = 4f;
            NPC.HitSound = SoundID.NPCHit31;
            NPC.noGravity = true;
            NPC.NPCSlots = 20f;
            NPC.boss = true;
            NPC.DeathSound = SoundID.NPCDeath34;
            NPC.value = Item.buyPrice(0, 8, 0, 0);
            NPC.NoTileCollide = true;
            bossBag = ModContent.ItemType("mechqueentreasurebag");
            //music = mod.GetSoundSlot(SoundType.Music, "NPCs/ant/mechbee");
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Mechanical Queen bee");
            Main.NPCFrameCount[NPC.type] = 9;
        }
        public override void ScaleExpertStats(int playerXPlayers, float bossLifeScale)
        {
            if (playerXPlayers > 1)
            {
                NPC.LifeMax = (int)(8150 + (double)NPC.LifeMax * 0.2 * (double)playerXPlayers);
            }
            else
            {
                NPC.LifeMax = 8150;
            }
            NPC.damage = (int)(NPC.damage * 0.65f);//				Main.NewText("You are returning your free gift? Come back in a second and I'll show you the free gifts again.");

        }

        public override void NPCLoot()
        {
            //AntiarisWorld.DownedAntlionQueen = true;
            if (Main.expertMode)
            {
                NPC.DropBossBags();
            }
            if (!Main.expertMode)
            {
                Item.NewItem((int)NPC.position.X, (int)NPC.position.Y, NPC.width, NPC.height, ItemID.HealingPotion, Main.rand.Next(4, 12), false, 0, false, false);
                switch (Main.rand.Next(4))
                {
                    case 0:
                        Item.NewItem((int)NPC.position.X, (int)NPC.position.Y, NPC.width, NPC.height, ModContent.ItemType("scythe"), 1, false, 0, false, false);
                        break;
                    case 1:
                        Item.NewItem((int)NPC.position.X, (int)NPC.position.Y, NPC.width, NPC.height, ModContent.ItemType("mechsky"), 1, false, 0, false, false);
                        break;
                    case 2:
                        Item.NewItem((int)NPC.position.X, (int)NPC.position.Y, NPC.width, NPC.height, ModContent.ItemType("eliasBow"), 1, false, 0, false, false);
                        break;
                    case 3:
                        Item.NewItem((int)NPC.position.X, (int)NPC.position.Y, NPC.width, NPC.height, ModContent.ItemType("remote"), 1, false, 0, false, false);
                        break;
                }
                if (Main.rand.Next(7) == 0)
                {
                    Item.NewItem((int)NPC.position.X, (int)NPC.position.Y, NPC.width, NPC.height, ModContent.ItemType("mechbemask"), 1, false, 0, false, false);
                }
            }
            if (Main.rand.Next(10) == 0)
            {
                Item.NewItem((int)NPC.position.X, (int)NPC.position.Y, NPC.width, NPC.height, ModContent.ItemType("mechqueentrophy"), 1, false, 0, false, false);
            }
        }
        //exampleplayer
        public override void HitEffect(int hitDirection, double damage)
        {
            if (NPC.life <= 0)
            {
                for (int k = 0; k < 20; k++)
                {
                    Dust.NewDust(NPC.position, NPC.width, NPC.height, 151, 2.5f * (float)hitDirection, -2.5f, 0, default(Color), 0.7f);
                }
                Gore.NewGore(NPC.position, NPC.velocity, mod.GetGoreSlot("NPCs/ant/queengore1"), 1f);//1f//NPC.life
                Gore.NewGore(NPC.position, NPC.velocity, mod.GetGoreSlot("NPCs/ant/queengore1"), 1f);//1f//NPC.life
            }
        }
        //       if(NPC.life<NPC.LifeMax / 2)

        public override void AI()
        {
            Player player = Main.player[NPC.target];
            Vector2 target = NPC.HasPlayerTarget ? player.Center : Main.NPC[NPC.target].Center;
            NPC.netAlways = true;
            NPC.TargetClosest(true);
            NPC.rotation = NPC.velocity.X * 0.045f;
            this.moveSpeed = (int)((float)((double)NPC.LifeMax / (double)NPC.life) * 0.05f);
            if ((double)player.position.X >= (double)NPC.position.X - 8.0)
                NPC.spriteDirection = 1;
            else if ((double)player.position.X < (double)NPC.position.X - 8.0)
                NPC.spriteDirection = -1;
            if (((!Collision.CanHit(NPC.position, NPC.width, NPC.height, player.position, player.width, player.height)) && NPC.justHit) || NPC.velocity.Y == 0f)
                if ((NPC.collideY) || (NPC.collideX))
                    NPC.NoTileCollide = true;
                else if ((Collision.CanHit(NPC.position, NPC.width, NPC.height, player.position, player.width, player.height)))
                    NPC.NoTileCollide = false;
            if (NPC.target < 0 || NPC.target == 255 || player.dead || !player.active || !player.ZoneJungle)
            {
                NPC.TargetClosest(false);
                NPC.direction = 1;
                if (NPC.velocity.X > 0f)
                    NPC.velocity.X = NPC.velocity.X + 0.75f;
                else
                    NPC.velocity.X = NPC.velocity.X - 0.75f;
                NPC.velocity.Y = NPC.velocity.Y - 0.1f;
                if (NPC.timeLeft > 10)
                {
                    NPC.timeLeft = 10;
                    return;
                }
            }
            if (!player.ZoneJungle)
                AntiarisHelper.MoveTowards(NPC, player.Center, 75f, 75f);
            if (this.stunned)
            {
                NPC.velocity.Y = 0.0f;
                NPC.velocity.X = 0.0f;
                ++this.stunnedTimer;
                if (this.stunnedTimer >= 105)
                {
                    this.stunned = false;
                    this.stunnedTimer = 0;
                }
            }
            if (this.end)
            {
                this.mv = 0;
                this.ai = 0;
                NPC.ai[0] = 0f;
                NPC.ai[1] = 0f;
                NPC.ai[2] = 0f;
                NPC.ai[3] = 0f;
                this.sAI = false;
                this.stunned = false;
                this.end = false;
            }
            //Main.NewText("You are returning your free gift? Come back in a second and I'll show you the free gifts again.");
            if (NPC.life == NPC.LifeMax)
            {
                NPC.life--;
                Main.NewText("REMEMBER MEEEEEEEEEEE");
                Main.NewText("I WAS EXILED TO THE DESERT WHEN YOU KILLED ME");
                Main.NewText("Time for revenge...");

            }
            if (NPC.life <= 50)
            {
                Main.NewText("NOOOOOOOOOOOOOO");


            }//spriteBatch.Draw(mod.GetTexture("NPCs/Abomination/Rune"), NPC.Center - Main.screenPosition, null, new Color(255, 10, 0), rotation, new Vector2(64, 64), 1f, SpriteEffects.None, 0f);








            ++this.ai;
            if ((double)NPC.ai[0] < 150.0 && !this.stunned && !this.sAI)
            {
                NPC.ai[0] = (float)this.ai * 1f;
                this.frame = 0;
                AntiarisHelper.MoveTowards(NPC, target - new Vector2(0f, 250f), this.rage ? 40f : 30f, 30f);
                NPC.ai[1] += 1f;
                if (NPC.ai[1] % (float)(Main.expertMode ? 25 : 30) == 0)
                {
                    int y = (int)(NPC.Center.Y / 16f);
                    int x = (int)(NPC.Center.X / 16f);
                    int size = 100;
                    if (x < 10)
                    {
                        x = 10;
                    }
                    if (x > Main.maxTilesX - 10)
                    {
                        x = Main.maxTilesX - 10;
                    }
                    if (y < 10)
                    {
                        y = 10;
                    }
                    if (y > Main.maxTilesY - size - 10)
                    {
                        y = Main.maxTilesY - size - 10;
                    }
                    for (int finPos = y; finPos < y + size; finPos++)
                    {
                        Tile tile = Main.tile[x, finPos];
                        if (tile.active() && (Main.tileSolid[(int)tile.type] || tile.liquid != 0))
                        {
                            y = finPos;
                            break;
                        }
                    }
                    Projectile.NewProjectileDirect((float)(x * 16 + 8), (float)(y * 16 - 56), 0f, 0f, ModContent.ProjectileType("Sandnado"), NPC.damage / 2, 0f, Main.myPlayer, 16f, 15f);
                }
                NPC.netUpdate = true;
            }
            else if ((double)NPC.ai[0] >= 145.0 && !this.stunned && !this.sAI)
            {
                NPC.NoTileCollide = false;
                NPC.velocity.X = 0f;
                NPC.velocity.Y = 5f;
                this.frame = 1;
                NPC.netUpdate = true;
                ++this.swarmerSpawnTimer;
                ++NPC.ai[2];
                if ((double)NPC.ai[2] > 60.0 && this.swarmerSpawnTimer > 60)
                {
                    SoundEngine.PlaySound(15, (int)NPC.position.X, (int)NPC.position.Y, 0);
                    NPC.NewNPC((int)(player.Center.X + 1200f), (int)(player.Center.Y - 1000f), 509, 0, (float)NPC.whoAmI, 0.0f, 0.0f, 0.0f, (int)byte.MaxValue);
                    if ((double)(NPC.LifeMax - NPC.life) > (double)(40.0 * 100f))
                    {
                        NPC.NewNPC((int)(player.Center.X - 1200f), (int)(player.Center.Y - 1000f), 508, 0, (float)NPC.whoAmI, 0.0f, 0.0f, 0.0f, (int)byte.MaxValue);
                    }
                    this.swarmerSpawnTimer -= (Main.expertMode ? 30 : 60);
                }
                if ((double)NPC.ai[2] > 120.0)
                {
                    this.swarmerSpawnTimer = 0;
                    this.sAI = true;
                    NPC.ai[3] = 10f;
                }
                NPC.netUpdate = true;
            }
            if ((double)NPC.ai[3] >= 10.0 && (double)NPC.ai[3] < 20.0)
            {
                this.mv += 1 + (int)((NPC.life > NPC.LifeMax / 2 ? 0 : 1) + (NPC.life > NPC.LifeMax / 3 ? 0 : 1));
                this.frame = 0;
                NPC.NoTileCollide = true;
                if (this.mv >= 150 && this.mv < 500)
                {
                    Vector2 vector2_1 = player.Center + new Vector2(0.0f, -600.0f);
                    float speed = 7f;
                    Vector2 vector2_2 = vector2_1 - NPC.Center;
                    float distance = (float)Math.Sqrt((double)vector2_2.X * (double)vector2_2.X + (double)vector2_2.Y * (double)vector2_2.Y);
                    vector2_2 *= speed / distance;
                    NPC.velocity = vector2_2;
                    if (this.mv > 350)
                    {
                        SoundEngine.PlaySound(15, (int)NPC.position.X, (int)NPC.position.Y, 0);
                        NPC.velocity.X = 0.0f;
                        NPC.velocity.Y = 20f;
                        if ((double)NPC.position.Y < (double)player.position.Y + 500.0)
                        {
                            this.mv = 425;
                        }
                    }
                    if (this.mv >= 425)
                    {
                        AntiarisHelper.MoveTowards(NPC, target - new Vector2(0f, 25f), (NPC.life <= NPC.LifeMax * 0.35f) ? 435f : 275f, 30f);
                    }
                }
                else if (this.mv >= 650 && this.mv < 1000)
                {
                    Vector2 vector2_1 = player.Center + new Vector2(-600.0f, 0.0f);
                    float speed = 7f;
                    Vector2 vector2_2 = vector2_1 - NPC.Center;
                    float distance = (float)Math.Sqrt((double)vector2_2.X * (double)vector2_2.X + (double)vector2_2.Y * (double)vector2_2.Y);
                    vector2_2 *= speed / distance;
                    NPC.velocity = vector2_2;
                    if (this.mv > 850)
                    {
                        SoundEngine.PlaySound(15, (int)NPC.position.X, (int)NPC.position.Y, 0);
                        NPC.velocity.X = 20f;
                        NPC.velocity.Y = 0.0f;
                        if ((double)NPC.position.X < (double)player.position.X + 500.0)
                        {
                            this.mv = 925;
                        }
                    }
                    if (this.mv >= 925)
                    {
                        AntiarisHelper.MoveTowards(NPC, target - new Vector2(0f, 25f), (NPC.life <= NPC.LifeMax * 0.35f) ? 435f : 275f, 30f);
                    }
                }
                else if (this.mv >= 1150 && this.mv < 1500)
                {
                    Vector2 vector2_1 = player.Center + new Vector2(600.0f, 0.0f);
                    float speed = 7f;
                    Vector2 vector2_2 = vector2_1 - NPC.Center;
                    float distance = (float)Math.Sqrt((double)vector2_2.X * (double)vector2_2.X + (double)vector2_2.Y * (double)vector2_2.Y);
                    vector2_2 *= speed / distance;
                    NPC.velocity = vector2_2;
                    if (this.mv > 1350)
                    {
                        SoundEngine.PlaySound(15, (int)NPC.position.X, (int)NPC.position.Y, 0);
                        NPC.velocity.X = -20f;
                        NPC.velocity.Y = 0.0f;
                        if ((double)NPC.position.X > (double)player.position.X - 500.0)
                        {
                            this.mv = 1425;
                        }
                    }
                    if (this.mv >= 1425)
                    {
                        AntiarisHelper.MoveTowards(NPC, target - new Vector2(0f, 25f), (NPC.life <= NPC.LifeMax * 0.35f) ? 435f : 275f, 30f);
                    }
                }
                else
                {
                    AntiarisHelper.MoveTowards(NPC, target, Vector2.Distance(target, NPC.Center) > 500 ? (Main.expertMode ? 32f : 30f) : (Main.expertMode ? 13f : 11f), 30f);
                }
                if (this.mv >= 1600)
                {
                    this.mv = 0;
                    NPC.ai[3] = 20f;
                }
                NPC.netUpdate = true;
            }
            else if ((double)NPC.ai[3] >= 20.0 && (double)NPC.ai[3] < 30.0)
            {
                AntiarisHelper.MoveTowards(NPC, target, Vector2.Distance(target, NPC.Center) > 500 ? (Main.expertMode ? 32f : 30f) : (Main.expertMode ? 13f : 11f), 30f);
                this.mv += (int)0.2 + (int)((NPC.life > NPC.LifeMax / 2 ? 0 : 1) + (NPC.life > NPC.LifeMax / 3 ? 0 : 1));
                this.frame = 0;
                if (this.mv >= 100 && this.mv < 175)
                {
                    if (this.mv % 10 == 0)
                    {
                        Vector2 shootPos = (NPC.Top + new Vector2((NPC.direction == -1 ? -150f : 150f), 155f)).RotatedBy(NPC.rotation, NPC.Center);
                        float inaccuracy = 3f * (NPC.life / NPC.LifeMax);
                        Vector2 shootVel = target - shootPos + new Vector2(Main.rand.NextFloat(-inaccuracy, inaccuracy), Main.rand.NextFloat(-inaccuracy, inaccuracy));
                        shootVel.Normalize();
                        shootVel *= 28f;
                        int k = Projectile.NewProjectileDirect(shootPos, shootVel, 31, NPC.damage / 2, 5f, Main.myPlayer);
                        Main.projectile[k].friendly = false;
                        Main.projectile[k].hostile = true;
                        Main.projectile[k].scale = 1.4f;
                    }
                }
                else if (this.mv >= 175)
                {
                    this.mv = 0;
                    NPC.ai[3] = 30f;
                }
                NPC.netUpdate = true;
            }
            else if ((double)NPC.ai[3] >= 30.0)
            {
                this.mv += 2 + (int)((NPC.life > NPC.LifeMax / 2 ? 0 : 1) + (NPC.life > NPC.LifeMax / 3 ? 0 : 1));
                this.frame = 0;
                if (this.mv % 500 == 0)
                {
                    SoundEngine.PlaySound(15, (int)NPC.position.X, (int)NPC.position.Y, 0);
                    NPC.NewNPC((int)(player.Center.X - 1200f), (int)(player.Center.Y - 1000f), 508, 0, (float)NPC.whoAmI, 0.0f, 0.0f, 0.0f, (int)byte.MaxValue);
                    NPC.NewNPC((int)(player.Center.X + 1200f), (int)(player.Center.Y - 1000f), 508, 0, (float)NPC.whoAmI, 0.0f, 0.0f, 0.0f, (int)byte.MaxValue);
                }
                if (this.mv >= 650 && this.mv < 800)
                {
                    if (this.mv >= 650 && this.mv < 725)
                    {
                        if (player.position.Y < NPC.position.Y + 650)
                        {
                            NPC.velocity.Y -= 0.44f;
                        }
                    }
                    if (player.position.Y >= NPC.position.Y + 650)
                    {
                        Vector2 targetPos = player.Center;
                        float speed = 15f;
                        float speedFactor = 0.7f;
                        Vector2 center = new Vector2(NPC.position.X + (float)NPC.width * 0.5f, NPC.position.Y + (float)NPC.height * 0.5f);
                        float posX = targetPos.X - center.X;
                        float posY = targetPos.Y - center.Y;
                        float distance = (float)Math.Sqrt((double)(posX * posX + posY * posY));
                        distance = speed / distance;
                        posX *= distance;
                        posY *= distance;
                        if (NPC.velocity.X < posX)
                        {
                            NPC.velocity.X = NPC.velocity.X + speedFactor;
                            if (NPC.velocity.X < 0f && posX > 0f)
                                NPC.velocity.X = NPC.velocity.X + speedFactor;
                        }
                        else if (NPC.velocity.X > posX)
                        {
                            NPC.velocity.X = NPC.velocity.X - speedFactor;
                            if (NPC.velocity.X > 0f && posX < 0f)
                                NPC.velocity.X = NPC.velocity.X - speedFactor;
                        }
                        if (NPC.velocity.Y < posY)
                        {
                            NPC.velocity.Y = NPC.velocity.Y + speedFactor;
                            if (NPC.velocity.Y < 0f && posY > 0f)
                                NPC.velocity.Y = NPC.velocity.Y + speedFactor;
                        }
                        else if (NPC.velocity.Y > posY)
                        {
                            NPC.velocity.Y = NPC.velocity.Y - speedFactor;
                            if (NPC.velocity.Y > 0f && posY < 0f)
                                NPC.velocity.Y = NPC.velocity.Y - speedFactor;
                        }
                        this.mv = 720;
                    }
                }
                else if (this.mv >= 1000 && this.mv < 1150)
                {
                    if (this.mv >= 1000 && this.mv < 1075)
                    {
                        if (player.position.Y < NPC.position.Y + 650)
                        {
                            NPC.velocity.Y -= 0.44f;
                        }
                    }
                    if (player.position.Y >= NPC.position.Y + 650)
                    {
                        Vector2 targetPos = player.Center;
                        float speed = 15f;
                        float speedFactor = 0.7f;
                        Vector2 center = new Vector2(NPC.position.X + (float)NPC.width * 0.5f, NPC.position.Y + (float)NPC.height * 0.5f);
                        float posX = targetPos.X - center.X;
                        float posY = targetPos.Y - center.Y;
                        float distance = (float)Math.Sqrt((double)(posX * posX + posY * posY));
                        distance = speed / distance;
                        posX *= distance;
                        posY *= distance;
                        if (NPC.velocity.X < posX)
                        {
                            NPC.velocity.X = NPC.velocity.X + speedFactor;
                            if (NPC.velocity.X < 0f && posX > 0f)
                                NPC.velocity.X = NPC.velocity.X + speedFactor;
                        }
                        else if (NPC.velocity.X > posX)
                        {
                            NPC.velocity.X = NPC.velocity.X - speedFactor;
                            if (NPC.velocity.X > 0f && posX < 0f)
                                NPC.velocity.X = NPC.velocity.X - speedFactor;
                        }
                        if (NPC.velocity.Y < posY)
                        {
                            NPC.velocity.Y = NPC.velocity.Y + speedFactor;
                            if (NPC.velocity.Y < 0f && posY > 0f)
                                NPC.velocity.Y = NPC.velocity.Y + speedFactor;
                        }
                        else if (NPC.velocity.Y > posY)
                        {
                            NPC.velocity.Y = NPC.velocity.Y - speedFactor;
                            if (NPC.velocity.Y > 0f && posY < 0f)
                                NPC.velocity.Y = NPC.velocity.Y - speedFactor;
                        }
                        this.mv = 1070;
                    }
                }
                else
                {
                    AntiarisHelper.MoveTowards(NPC, target, Vector2.Distance(target, NPC.Center) > 500 ? (Main.expertMode ? 32f : 30f) : (Main.expertMode ? 13f : 11f), 30f);
                }
                if (this.mv >= 1150)
                {
                    this.end = true;
                }
                NPC.netUpdate = true;
            }
            if (NPC.life <= NPC.LifeMax * 0.35f)
                this.rage = true;
            if (NPC.life <= NPC.LifeMax * 0.15f)
            {
                this.end = true;
                this.frame = 0;
                this.stunned = true;
                NPC.NoTileCollide = false;
                SoundEngine.PlaySound(15, (int)NPC.position.X, (int)NPC.position.Y, 0);
                ++this.aiSECOND;
                if (this.aiSECOND % 2 == 0 && this.aiSECOND <= 120)
                {
                    var ShootPos = player.position + new Vector2(Main.rand.Next(-1000, 1000), -1000);
                    var ShootVel = new Vector2(Main.rand.NextFloat(-3f, 3f), Main.rand.NextFloat(15f, 20f));
                    var k = Projectile.NewProjectileDirect(ShootPos, ShootVel, 31, NPC.damage / 4, 1f);
                    Main.projectile[k].friendly = false;
                    Main.projectile[k].hostile = true;
                    Main.projectile[k].scale = 1.4f;
                    Main.projectile[k].tileCollide = false;
                }
                if (this.aiSECOND >= 250 && this.aiSECOND < 320 && this.aiSECOND % 15 == 0)
                {
                    var shootPos = (NPC.Top + new Vector2((NPC.direction == -1 ? -150f : 150f), 155f)).RotatedBy(NPC.rotation, NPC.Center);
                    var inaccuracy = 3f * (NPC.life / NPC.LifeMax);
                    var shootVel = target - shootPos + new Vector2(Main.rand.NextFloat(-inaccuracy, inaccuracy), Main.rand.NextFloat(-inaccuracy, inaccuracy));
                    shootVel.Normalize();
                    shootVel *= 28f;
                    var k = Projectile.NewProjectileDirect(shootPos, shootVel, 31, NPC.damage / 2, 5f, Main.myPlayer);
                    Main.projectile[k].friendly = false;
                    Main.projectile[k].hostile = true;
                    Main.projectile[k].scale = 1.4f;
                }
                if (this.aiSECOND >= 450)
                {
                    this.aiSECOND = 0;
                }
                if (Main.expertMode)
                {
                    if (this.aiSECOND % 250 == 0)
                    {
                        NPC.NewNPC((int)(player.Center.X - 1200f), (int)(player.Center.Y - 1000f), 508, 0, (float)NPC.whoAmI, 0.0f, 0.0f, 0.0f, (int)byte.MaxValue);
                        NPC.NewNPC((int)(player.Center.X - 1200f), (int)(player.Center.Y - 1000f), 509, 0, (float)NPC.whoAmI, 0.0f, 0.0f, 0.0f, (int)byte.MaxValue);
                    }
                }
            }
        }

        public override void FindFrame(int frameHeight)
        {
            if (this.frame == 0)
            {
                counting += 2.0;
                if (counting < 8.0)
                {
                    NPC.frame.Y = 0;
                }
                else if (counting < 16.0)
                {
                    NPC.frame.Y = frameHeight;
                }
                else if (counting < 24.0)
                {
                    NPC.frame.Y = frameHeight * 2;
                }
                else if (counting < 32.0)
                {
                    NPC.frame.Y = frameHeight * 3;
                }
                else if (counting < 40.0)
                {
                    NPC.frame.Y = frameHeight * 4;
                }
                else if (counting < 48.0)
                {
                    NPC.frame.Y = frameHeight * 5;
                }
                else if (counting < 56.0)
                {
                    NPC.frame.Y = frameHeight * 6;
                }
                else if (counting < 64.0)
                {
                    NPC.frame.Y = frameHeight * 7;
                }
                else
                {
                    counting = 0.0;
                }
            }
            else
                NPC.frame.Y = frameHeight * 8;
        }

        public override void BossHeadRotation(ref float rotation)
        {
            rotation = NPC.rotation;
        }

        private void StartSandstorm()
        {
            Sandstorm.Happening = true;
            Sandstorm.TimeLeft = (int)(3600.0 * (8.0 + (double)Main.rand.NextFloat() * 16.0));
            this.ChangeSeverityIntentions();
        }

        private void StopSandstorm()
        {
            Sandstorm.Happening = false;
            Sandstorm.TimeLeft = 0;
            this.ChangeSeverityIntentions();
        }

        private void ChangeSeverityIntentions()
        {
            Sandstorm.IntendedSeverity = !Sandstorm.Happening ? (Main.rand.Next(3) != 0 ? Main.rand.NextFloat() * 0.3f : 0.0f) : 0.4f + Main.rand.NextFloat();
        }

        public override bool CheckDead()
        {
            var player = Main.player[NPC.target];
            /*if (player.ZoneDesert && !player.ZoneBeach)
            {
                StopSandstorm();
            }*/
            SoundEngine.PlaySound(15, (int)NPC.position.X, (int)NPC.position.Y, 0);
            return base.CheckDead();
        }
        //Boss second stage texture
        private const int Sphere = 50;
        /*public override bool PreDraw(SpriteBatch spriteBatch, Color drawColor)
        {
            if (NPC.life <= 5000)
            {
                spriteBatch.Draw(mod.GetTexture("NPCs/ant/AntlionQueen2"), NPC.Center - Main.screenPosition, null, Color.White * (70f / 255f), 0f, new Vector2(Sphere, Sphere), 3f, SpriteEffects.None, 0f);
                Main.NewText("You thought I would die, didn't you");
            }
            return true;
        }*/
    }
}