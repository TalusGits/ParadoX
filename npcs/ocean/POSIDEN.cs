using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using gracosmod123.NPCs.ocean;
using Terraria.GameContent.Events;
using Terraria.Localization;
using System.IO;
using Microsoft.Xna.Framework.Graphics;
namespace gracosmod123.NPCs.ocean
{
    [AutoloadBossHead]//AntlionQueen_Head_Boss
    public class POSIDEN : ModNPC
    {
        int movementType = 0;
        int movementCounter = 0;
        bool justSpawned = false;
        private Vector2 targetPos;
        float vMag = 0;
        int counter = 0;
        public static bool oceanNPC = false;
        public static bool death = false;
        public static int phase = 0;
        public int delay = 0;
        public bool bitherial = true;
        public int plays = 0;
        public int attack = 0;
        public int attackRel = -1;
        public int attackRelMax = 0;
        public int attackDel = 0;
        public int attackDelMax = 0;
        public int moveType = 1;
        public int hovDir = 1;
        public int moveDelay = 600;
        public int vDir = 2;
        public int dir = 0;
        public int vdir = 0;
        public float accel = 0f;
        public float maxAccel = 20f;
        public float vaccel = 0f;
        public float maxVaccel = 20f;
        public int damage = 0;
        public int eattack = 0;
        public int eattackDel = 0;
        public int eattackDelMax = 0;
        int _despawn = 0;
        bool _attacking = false;
        float _theta = 0f;
        public static float thetaSlow = 0f;
        int _attackDur = 0;
        public static int tearIndex = 0;
        public static Vector2 center;
        public static float scale = 1;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("posiden");
        }

        public override void SetDefaults()
        {
            movementCounter = 0;
            NPC.width = 124;
            NPC.height = 124;
            NPC.damage = 180;
            NPC.defense = 50;
            NPC.LifeMax = 150000;
            NPC.DeathSound = SoundID.NPCDeath19;
            NPC.value = 60f;
            NPC.knockBackResist = 0f;
            NPC.lavaImmune = true;
            NPC.noGravity = true;
            NPC.NoTileCollide = true;
            Main.NPCFrameCount[NPC.type] = 10;
            NPC.boss = true;
            NPC.NPCSlots = 0.001f;
            tearIndex = 0;
            thetaSlow = 0f;
            _attackDur = 0;
            _theta = 0f;
            _attacking = false;
            _despawn = 0;
            plays = 1;
            phase = 0;
            eattack = 0;
            eattackDelMax = 280;
            eattackDel = eattackDelMax;
            damage = 30;
            moveDelay = 600;
            maxAccel = 22f;
            maxVaccel = 20f;
            accel = 0f;
            vaccel = 0f;
            hovDir = 1;
            vDir = 1;
            moveType = 1;
            attackDelMax = 300;
            attackDel = attackDelMax;
            attackRel = -1;
            attackRelMax = 0;
            attack = 0;
            bitherial = true;
            NPC.aiStyle = 0;
            NPC.HitSound = SoundID.NPCHit21;
            NPC.NPCSlots = 15f;
            bossBag = ModContent.ItemType("mechqueentreasurebag");
        }

        private void GenerateBysmal()
        {
            int sizeMult = (int)(Math.Floor(Main.maxTilesX / 4200f));
            for (int i = 0; i < 30 * sizeMult; i++)
            {
                oregentry.StructureGenBig(Main.rand.Next(200, Main.maxTilesX - 200), Main.rand.Next(350 * sizeMult, Main.maxTilesY - 400));
            }
            for (int i = 0; i < 100 * sizeMult; i++)
            {
                oregentry.StructureGenMed(Main.rand.Next(200, Main.maxTilesX - 200), Main.rand.Next(350 * sizeMult, Main.maxTilesY - 400));
            }
            for (int i = 0; i < 120 * sizeMult; i++)
            {
                oregentry.StructureGenSmall(Main.rand.Next(200, Main.maxTilesX - 200), Main.rand.Next(350 * sizeMult, Main.maxTilesY - 400));
            }
        }

        public override bool? DrawHealthBar(byte hbPosition, ref float scale, ref Vector2 position)
        {
            return false;

        }
        public override void NPCLoot()
        {
            //AntiarisWorld.DownedAntlionQueen = true;
            if (Main.expertMode)
            {
                NPC.DropBossBags();
            }
        }
        public override void FindFrame(int frameHeight)
        {
            NPC.frameCounter += 1.0;
            if (NPC.frameCounter > 24.0)
            {
                NPC.frame.Y = NPC.frame.Y + frameHeight;
                NPC.frameCounter = 0.0;
            }
            if (NPC.frame.Y > frameHeight * 2 && NPC.life > NPC.LifeMax * 2 / 3)
            {
                NPC.frame.Y = 0;
            }
            else if (NPC.frame.Y > frameHeight * 5 && NPC.life <= NPC.LifeMax * 2 / 3)
            {
                NPC.frame.Y = 3 * frameHeight;
            }
        }
        public override bool CheckActive()
        {
            return false;
        }

        public override void AI()
        {
            /*if (NPC.life <= NPC.LifeMax / 2 && oceanNPC == false)
            {
                oceanNPC = true;
                NPC.NewNPC((int)NPC.position.X, (int)NPC.position.Y, ModContent.NPCType("EtherialEoC"));
            }
            */
            /*if (NPC.life <= 0)
            {
                if (oregentry.bysmal == false)
                {
                    oregentry.bysmal = true;
                    Main.NewText("tridents of ore are thrust into the world", 125, 200, 255);
                    GenerateBysmal();
                }
            }*/

            //YEET
            //YEET
            //YEET
            //YEET
            //YEET
            //YEET
            //YEET
            //YEET
            //YEET
            //YEET
            //YEET
            //YEET
            //YEET
            //YEET
            //YEET
            //YEET
            //Retarget (borrowed from Dan <3)
            Player player = Main.player[NPC.target];
            //YEET
            //YEET
            //YEET
            //YEET
            //YEET
            //YEET
            //YEET
            //YEET
            //YEET
            //YEET
            //YEET
            //YEET
            //YEET
            //YEET
            //YEET
            //YEET
            if (NPC.target < 0 || NPC.target == 255 || Main.player[NPC.target].dead || !Main.player[NPC.target].active)
            {
                NPC.TargetClosest(true);
            }
            NPC.netUpdate = true;

            //DESPAWN
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
            if (Main.dayTime && _despawn == 0)
                _despawn++;
            if (_despawn >= 1)
            {
                _despawn++;
                NPC.NoTileCollide = true;
                if (_despawn >= 300)
                    NPC.active = false;
            }

            NPC.spriteDirection = 0;
            bitherial = true;
            NPC.rotation = 0;
            if (phase > 2)
                NPC.scale = 1f + (float)(phase) / 10f;
            else
                NPC.scale = 1f;
            NPC.height = (int)(NPC.scale * 190);
            NPC.width = (int)(NPC.scale * 240);
            //Setting Phases
            if (NPC.life < NPC.LifeMax * .75 && phase == 0)
            {
                phase += 1;
                if (Main.expertMode)
                    attackDelMax -= 30;
                NPC.netUpdate = true;
            }
            if (NPC.life < NPC.LifeMax * .5 && phase == 1)
            {
                phase += 1;
                if (Main.expertMode)
                    attackDelMax -= 30;
                if (Main.netMode != 1)
                {
                    NPC.NewNPC((int)NPC.position.X + Main.rand.Next(0, NPC.width), (int)NPC.position.Y + Main.rand.Next(0, NPC.height), ModContent.NPCType<MechanicalDungeonGuardian>());
                }
                NPC.netUpdate = true;
            }

            if (NPC.life < NPC.LifeMax * .25 && phase == 2 && Main.expertMode)
            {
                NPC.life = (int)(NPC.LifeMax * .5);
                phase += 1;
                if (Main.expertMode)
                    attackDelMax -= 30;
                NPC.netUpdate = true;
            }
            if (NPC.life < NPC.LifeMax * .25 && phase == 3 && Main.expertMode)
            {
                phase += 1;
                if (Main.expertMode)
                    attackDelMax -= 30;
                if (Main.netMode != 1)
                    NPC.NewNPC((int)NPC.position.X + Main.rand.Next(0, NPC.width), (int)NPC.position.Y + Main.rand.Next(0, NPC.height), ModContent.NPCType<MechanicalDungeonGuardian>());
                NPC.netUpdate = true;
            }

            //Movement
            Vector2 delta = Main.player[NPC.target].Center - NPC.Center;
            float magnitude = (float)Math.Sqrt(delta.X * delta.X + delta.Y * delta.Y);

            //Hovering
            if (moveType == 1)
            {
                moveDelay -= 1;
                if (moveDelay <= 0)
                {
                    moveDelay = 900;
                    moveType = 1;
                }
                //Horizontal Movement
                NPC.velocity.X = accel;
                if (delta.X > 0) { hovDir = 1; }
                if (delta.X < 0) { hovDir = -1; }
                if (Math.Abs(accel) < maxAccel / 2) { accel += (float)hovDir / 5f; }
                else { accel *= .98f; }

                //Vertical Movement
                NPC.velocity.Y = vaccel;
                if (NPC.position.Y - Main.player[NPC.target].position.Y + 70 > 0) { vDir = -1; }
                if (NPC.position.Y - Main.player[NPC.target].position.Y + 70 < 0) { vDir = 1; }
                if (Math.Abs(vaccel) < maxVaccel / 4) { vaccel += (float)vDir / 3f; }
                else { vaccel *= .98f; }
            }

            //Floating
            if (moveType == 2)
            {
                moveDelay -= 1;
                if (moveDelay <= 0)
                {
                    moveDelay = 750;
                    moveType = 1;
                }
                //Horizontal Movement
                NPC.velocity.X = accel;
                if (NPC.position.X < Main.player[NPC.target].position.X - 200 && hovDir == -1) { hovDir = 1; }
                if (NPC.position.X > Main.player[NPC.target].position.X + 200 && hovDir == 1) { hovDir = -1; }
                if (Math.Abs(accel) < maxAccel) { accel += (float)hovDir / 3f; }
                else { accel *= .98f; }

                //Vertical Movement
                NPC.velocity.Y = vaccel;
                if (NPC.position.Y - Main.player[NPC.target].position.Y + 70 > 0) { vDir = -1; }
                if (NPC.position.Y - Main.player[NPC.target].position.Y + 70 < 0) { vDir = 1; }
                if (Math.Abs(vaccel) < maxVaccel / 6) { vaccel += (float)vDir / 6f; }
                else { vaccel *= .98f; }
            }

            //Attack Vars
            _theta += 3.14f / 40f;
            if (_theta > 6.28f)
                _theta -= 6.28f;
            thetaSlow += 3.14f / 60f;
            if (thetaSlow > 6.28f)
                thetaSlow -= 6.28f;
            float projMod = 2f;
            center = NPC.Center;
            scale = NPC.scale;

            //Attack Delay
            if (!_attacking)
                attackDel--;
            if (attackDel <= 0)
            {
                attackDel = attackDelMax;
                attack++;
                _attacking = true;
                if (attack > 5)
                    attack = 1;
                if (phase > 4)
                {
                    eattack = attack;
                    attack = 0;
                    projMod = 2.5f;
                }
            }

            //Attacks
            if (attack == 1 && Main.netMode != 1 && _attacking)
            {
                attackRel++;
                if (attackRel > 2)
                {
                    attackRel = 0;
                    Projectile.NewProjectileDirect(NPC.Center.X + 48 * (float)Math.Cos(_theta), NPC.Center.Y + 48 * (float)Math.Sin(_theta), 8 * (float)Math.Cos(_theta), 8 * (float)Math.Sin(_theta), ModContent.ProjectileType<starfish>(), (int)(NPC.damage / projMod), 3, Main.myPlayer);
                }
                _attackDur++;
                if (_attackDur > 150)
                {
                    _attackDur = 0;
                    _attacking = false;
                }
            }
            if (attack == 2 && Main.netMode != 1 && _attacking)
            {
                attackRel++;
                if (attackRel > 30)
                {
                    _attackDur++;
                    attackRel = 0;
                    Projectile.NewProjectileDirect(NPC.Center.X, NPC.Center.Y, 0, 0, ModContent.ProjectileType<starfish>(), (int)(NPC.damage / projMod), 3, Main.myPlayer);
                }
                if (_attackDur >= 4)
                {
                    _attackDur = 0;
                    _attacking = false;
                }
            }
            if (attack == 3 && Main.netMode != 1 && _attacking)
            {
                SoundEngine.PlaySound(SoundLoader.customSoundType, -1, -1, mod.GetSoundSlot(SoundType.Custom, "Sounds/EtherialChange"));
                for (int i = 0; i < 8; i++)
                {
                    int n = NPC.NewNPC((int)NPC.Center.X, (int)NPC.Center.Y, ModContent.NPCType<EtherialSpiralShot>());
                    Main.NPC[n].ai[0] = NPC.whoAmI;
                    Main.NPC[n].ai[1] = i;
                }
                NPC.position.X = Main.player[NPC.target].position.X - (NPC.position.X - Main.player[NPC.target].position.X) / 2;
                NPC.position.Y = Main.player[NPC.target].position.Y - (NPC.position.Y - Main.player[NPC.target].position.Y) / 2;
                NPC.velocity.X = -NPC.velocity.X;
                NPC.velocity.Y = -NPC.velocity.Y;
                _attacking = false;
            }
            if (attack == 4 && Main.netMode != 1 && _attacking)
            {
                float dir = (float)Math.Atan2(NPC.DirectionTo(Main.player[NPC.target].Center).Y, NPC.DirectionTo(Main.player[NPC.target].Center).X);
                //Projectile.NewProjectileDirect(NPC.Center.X, NPC.Center.Y, 8 * (float)Math.Cos(dir), 8 * (float)Math.Sin(dir), ModContent.ProjectileType<QuadroBurst>(), (int)(NPC.damage / projMod), 3, Main.myPlayer);
                _attacking = false;
            }
            if (attack == 5 && Main.netMode != 1 && _attacking)
            {
                if (NPC.CountNPCS(ModContent.NPCType<EtherialEoC>()) < 4)
                {
                    NPC.NewNPC((int)NPC.position.X + Main.rand.Next(0, NPC.width), (int)NPC.position.Y + Main.rand.Next(0, NPC.height), ModContent.NPCType<EtherialEoC>());
                    tearIndex++;
                    _attacking = false;
                }
                else
                    attack = 1;
            }

            //Etherial Attacks
            if (eattack == 1 && Main.netMode != 1 && _attacking)
            {
                attackRel++;
                if (attackRel > 2)
                {
                    attackRel = 0;
                    Projectile.NewProjectileDirect(NPC.Center.X + 48 * (float)Math.Cos(_theta), NPC.Center.Y + 48 * (float)Math.Cos(_theta), 8 * (float)Math.Cos(_theta), 8 * (float)Math.Sin(_theta), ModContent.ProjectileType<TrueEtherialPulse>(), (int)(NPC.damage / projMod), 3, Main.myPlayer);
                    Projectile.NewProjectileDirect(NPC.Center.X + 48 * (float)Math.Cos(_theta + 3.14), NPC.Center.Y + 48 * (float)Math.Sin(_theta + 3.14), 8 * (float)Math.Cos(_theta + 3.14), 8 * (float)Math.Sin(_theta + 3.14), ModContent.ProjectileType<TrueEtherialPulse>(), (int)(NPC.damage / projMod), 3, Main.myPlayer);
                }
                _attackDur++;
                if (_attackDur > 240)
                {
                    _attackDur = 0;
                    _attacking = false;
                }
            }
            if (eattack == 2 && Main.netMode != 1 && _attacking)
            {
                attackRel++;
                if (attackRel > 30)
                {
                    _attackDur++;
                    attackRel = 0;
                    Projectile.NewProjectileDirect(NPC.Center.X, NPC.Center.Y, 0, 0, ModContent.ProjectileType<junionia>(), (int)(NPC.damage / projMod), 3, Main.myPlayer);
                }
                if (_attackDur >= 4)
                {
                    _attackDur = 0;
                    _attacking = false;
                }
            }
            if (eattack == 3 && Main.netMode != 1 && _attacking)
            {
                for (int i = 0; i < 12; i++)
                {
                    int n = NPC.NewNPC((int)NPC.Center.X, (int)NPC.Center.Y, ModContent.NPCType<EtherialSpiralShot>());
                    Main.NPC[n].ai[0] = NPC.whoAmI;
                    Main.NPC[n].ai[1] = i;
                }
                NPC.position.X = Main.player[NPC.target].position.X - (NPC.position.X - Main.player[NPC.target].position.X) / 2;
                NPC.position.Y = Main.player[NPC.target].position.Y - (NPC.position.Y - Main.player[NPC.target].position.Y) / 2;
                NPC.velocity.X = -NPC.velocity.X;
                NPC.velocity.Y = -NPC.velocity.Y;
                _attacking = false;
            }
            if (eattack == 4 && Main.netMode != 1 && _attacking)
            {
                float dir = (float)Math.Atan2(NPC.DirectionTo(Main.player[NPC.target].Center).Y, NPC.DirectionTo(Main.player[NPC.target].Center).X);
                //Projectile.NewProjectileDirect(NPC.Center.X, NPC.Center.Y, 8 * (float)Math.Cos(dir), 8 * (float)Math.Sin(dir), ModContent.ProjectileType<TrueQuadroBurst>(), (int)(NPC.damage / projMod), 3, Main.myPlayer);
                //Projectile.NewProjectileDirect(NPC.Center.X, NPC.Center.Y, 8 * (float)Math.Cos(dir + 3.14), 8 * (float)Math.Sin(dir + 3.14), ModContent.ProjectileType<TrueQuadroBurst>(), (int)(NPC.damage / projMod), 3, Main.myPlayer);
                _attacking = false;
            }
            if (eattack == 5 && Main.netMode != 1 && _attacking)
            {
                if (NPC.CountNPCS(ModContent.NPCType<EtherialSpiralShot>()) < 4)
                {
                    NPC.NewNPC((int)NPC.position.X + Main.rand.Next(0, NPC.width), (int)NPC.position.Y + Main.rand.Next(0, NPC.height), ModContent.NPCType<EtherialSpiralShot>());
                    tearIndex++;
                    _attacking = false;
                }
                else
                    attack = 1;
            }
            //Main.NewText(phase.ToString(), 0, 200, 250);

            if (Main.dayTime)
            {
                NPC.position.Y += 18;
            }
        }
        public override bool CheckDead()
        {
            death = true;
            if (oregentry.bysmal == false)
            {
                oregentry.bysmal = true;
                Main.NewText("tridents of ore are thrust into the world", 125, 200, 255);
                GenerateBysmal();
            }
            return base.CheckDead();

        }

    }

}

