using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using gracosmod123.NPCs.ocean;
namespace gracosmod123.NPCs.ocean
{
    public class MechanicalDungeonGuardian : ModNPC
    {
        int counter = 0;
        public float tVel = 0f;
        public float vel = 0f;
        public float vMax = 8f;
        public float vAccel = .2f;
        public float vMag = 0f;
        Vector2 targetPos;
        int shootDelay = 0;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Trident");
        }
        public override void SetDefaults()
        {
            shootDelay = 0;//Main.player[Main.myPlayer].name
            counter = 0;
            vMag = 0f;
            vMax = 8f;
            tVel = 0f;
            NPC.width = 130;
            NPC.height = 130;
            NPC.damage = 10;
            NPC.defense = 21;
            NPC.LifeMax = 50000;
            NPC.HitSound = SoundID.NPCHit4;
            NPC.DeathSound = SoundID.NPCDeath14;
            NPC.value = 60f;
            NPC.knockBackResist = 0f;
            NPC.aiStyle = 0;
            NPC.lavaImmune = true;
            NPC.noGravity = true;
            NPC.NoTileCollide = true;
        }

        public override void AI()
        {
            Shoot();
            NPC.rotation += .4f;
            targetPos = Main.player[NPC.target].Center;
            MoveToTarget(NPC);
        }

        private void Shoot()
        {
            shootDelay++;
            if (shootDelay >= 8 * 60)
            {
                for (int i = 0; i < 8; i++)
                {
                    if (Main.netMode != 1)
                        Projectile.NewProjectileDirect(NPC.Center.X, NPC.Center.Y, (float)Math.Cos(Math.PI / 4 * i) * 12, (float)Math.Sin(Math.PI / 4 * i) * 12, ModContent.ProjectileType<starfish>(), (int)(80), 3, Main.myPlayer);
                }
                shootDelay = 0;
            }
        }

        private void MoveToTarget(NPC NPC)
        {
            float dist = Vector2.Distance(targetPos, NPC.Center);
            tVel = dist / 15;
            if (vMag < vMax && vMag < tVel)
            {
                vMag += vAccel;
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
    }
}
