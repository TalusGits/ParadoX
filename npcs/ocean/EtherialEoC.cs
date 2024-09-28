using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace gracosmod123.NPCs.ocean
{
    public class EtherialEoC : ModNPC
    {
        int movementType = 0;
        int movementCounter = 0;
        bool justSpawned = false;
        private Vector2 targetPos;
        float vMag = 0;
        int counter = 0;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ocean Eye");
        }

        public override void SetDefaults()
        {
            movementCounter = 0;
            NPC.width = 124;
            NPC.height = 124;
            NPC.damage = 180;
            NPC.defense = 50;
            NPC.LifeMax = 40000;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath19;
            NPC.value = 60f;
            NPC.knockBackResist = 0f;
            NPC.aiStyle = 4;
            NPC.lavaImmune = true;
            NPC.noGravity = true;
            NPC.NoTileCollide = true;
            Main.NPCFrameCount[NPC.type] = 6;
        }

        public override void AI()
        {
            if (!justSpawned)
            {
                justSpawned = true;
                movementCounter = 45 * (int)NPC.ai[1];
                targetPos = Main.player[NPC.target].Center;
            }
            if (NPC.life > NPC.LifeMax * 2 / 3)
                Shoot();
            else
            {
                Movement();
                NPC.rotation = (float)Math.Atan2(targetPos.Y - NPC.Center.Y, targetPos.X - NPC.Center.X) - 1.57f;
            }
            if (POSIDEN.death == true)
            {
                NPC.life -= 999999999;
            }
            POSIDEN.death = false;

        }

        private void Movement()
        {
            NPC.aiStyle = 0;
            MovementTypeCheck();
            Move();
            MoveToTarget();
        }

        private void MovementTypeCheck()
        {
            movementCounter++;
            if (movementCounter > 2 * 60 && movementType == 0)
            {
                movementType = 1;
                targetPos.Y += 800;
                movementCounter = 0;
            }
            if (movementCounter > 60 && movementType == 1)
            {
                movementType = 2;
                movementCounter = 0;
            }
            if (movementCounter > 2 * 60 && movementType == 2)
            {
                movementType = 3;
                targetPos.X -= NPC.ai[1] * 800;
                movementCounter = 0;
            }
            if (movementCounter > 60 && movementType == 3)
            {
                movementType = 4;
                movementCounter = 0;
            }
            if (movementCounter > 5 * 60 && movementType == 4)
            {
                movementType = 0;
                movementCounter = 0;
            }
        }

        private void Move()
        {
            if (movementType == 0)
            {
                targetPos = Main.player[NPC.target].Center;
                targetPos.Y -= 300 + 100 * (int)NPC.ai[1];
            }
            if (movementType == 2)
            {
                targetPos = Main.player[NPC.target].Center;
                targetPos.X += NPC.ai[1] * 300;
            }
            if (movementType == 4)
            {
                if (movementCounter % 60 == 0)
                    targetPos = Main.player[NPC.target].Center + (Main.player[NPC.target].Center - NPC.Center) / 2;
            }
        }

        private void MoveToTarget()
        {
            float dist = Vector2.Distance(targetPos, NPC.Center);
            float tVel = dist / 15;
            float vMax = 24;
            if (vMag < vMax && vMag < tVel)
            {
                vMag += .2f;
                vMag = tVel;
            }
            if (vMag > tVel)
            {
                vMag = tVel;
            }
            if (vMag > vMax)
            {
                vMag = vMax;
            }
            if (dist != 0)
            {
                NPC.velocity = NPC.DirectionTo(targetPos) * vMag;
            }
        }

        private void Shoot()
        {
            counter++;
            if (counter >= 4 * 60)
            {
                counter = 0;
                Projectile.NewProjectileDirect(NPC.Center.X, NPC.Center.Y, 0, 0, ModContent.ProjectileType<starfish>(), (int)(NPC.damage / 4), 3, Main.myPlayer);
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

    }
}
