using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using gracosmod123.npcs.ocean;
namespace gracosmod123.npcs.ocean
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
            npc.width = 130;
            npc.height = 130;
            npc.damage = 10;
            npc.defense = 21;
            npc.lifeMax = 50000;
            npc.HitSound = SoundID.NPCHit4;
            npc.DeathSound = SoundID.NPCDeath14;
            npc.value = 60f;
            npc.knockBackResist = 0f;
            npc.aiStyle = 0;
            npc.lavaImmune = true;
            npc.noGravity = true;
            npc.noTileCollide = true;
        }

        public override void AI()
        {
            Shoot();
            npc.rotation += .4f;
            targetPos = Main.player[npc.target].Center;
            MoveToTarget(npc);
        }

        private void Shoot()
        {
            shootDelay++;
            if (shootDelay >= 8 * 60)
            {
                for (int i = 0; i < 8; i++)
                {
                    if (Main.netMode != 1)
                        Projectile.NewProjectile(npc.Center.X, npc.Center.Y, (float)Math.Cos(Math.PI / 4 * i) * 12, (float)Math.Sin(Math.PI / 4 * i) * 12, ModContent.ProjectileType<starfish>(), (int)(80), 3, Main.myPlayer);
                }
                shootDelay = 0;
            }
        }

        private void MoveToTarget(NPC npc)
        {
            float dist = Vector2.Distance(targetPos, npc.Center);
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
                npc.velocity = npc.DirectionTo(targetPos) * vMag;
            }
        }
    }
}
