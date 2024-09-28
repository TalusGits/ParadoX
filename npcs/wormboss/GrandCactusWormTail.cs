using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace gracosmod123.NPCs.wormboss
{
    [AutoloadBossHead]
    public class GrandCactusWormTail : ModNPC
    {
        int _despawn = 0;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("The Jade wyrm");
        }
        public override void SetDefaults()
        {
            NPC.dontTakeDamage = false;

            NPC.active = true;
            NPC.CloneDefaults(NPCID.DiggerTail);
            NPC.aiStyle = -1;
            NPC.damage = 25;
            NPC.defense = 15;
            NPC.knockBackResist = 0f;
            NPC.width = 82;
            NPC.height = 112;
            NPC.behindTiles = true;
            NPC.NoTileCollide = true;
            NPC.netAlways = true;
            NPC.noGravity = true;
            NPC.dontCountMe = true;
            NPC.lavaImmune = true;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;
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
            NPC.damage = (int)(NPC.damage * 0.7f);
        }
        public override void BossHeadRotation(ref float rotation)
        {
            rotation = NPC.rotation;
        }
        public override void HitEffect(int hitDirection, double damage)
        {
            if (NPC.life <= 0)
            {
                Gore.NewGore(NPC.position, NPC.velocity, mod.GetGoreSlot("NPCs/wormboss/GrandCactusWormTail_Gore"), NPC.scale);
            }
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
            if (NPC.ai[3] > 0)
            {
                NPC.realLife = (int)NPC.ai[3];
            }
            if (NPC.target < 0 || NPC.target == byte.MaxValue || Main.player[NPC.target].dead)
            {
                NPC.TargetClosest(true);
            }
            if (Main.netMode != 1)
            {
                if (!Main.NPC[(int)NPC.ai[1]].active)
                {
                    NPC.life = 0;
                    NPC.HitEffect(0, 10.0);
                    NPC.active = false;
                    if (Main.netMode == 2)
                    {
                        NetMessage.SendData(28, -1, -1, null, NPC.whoAmI, -1f, 0.0f, 0.0f, 0, 0, 0);
                    }
                }
            }

            if (NPC.ai[1] < (double)Main.NPC.Length)
            {
                float dirX = Main.NPC[(int)NPC.ai[1]].Center.X - NPC.Center.X;
                float dirY = Main.NPC[(int)NPC.ai[1]].Center.Y - NPC.Center.Y;
                NPC.rotation = (float)Math.Atan2(dirY, dirX) + 1.57f;
                float length = (float)Math.Sqrt(dirX * dirX + dirY * dirY);
                float dist = (length - (float)NPC.width) / length;
                float posX = dirX * dist;
                float posY = dirY * dist;
                NPC.velocity = Vector2.Zero;
                NPC.position.X = NPC.position.X + posX;
                NPC.position.Y = NPC.position.Y + posY;
                NPC.netUpdate = true;
            }
            return false;
        }

        public override bool PreDraw(SpriteBatch spriteBatch, Color drawColor)
        {
            Texture2D texture = Main.NPCTexture[NPC.type];
            Vector2 origin = new Vector2(texture.Width * 0.5f, texture.Height * 0.5f);
            Main.spriteBatch.Draw(texture, NPC.Center - Main.screenPosition, new Rectangle?(), drawColor, NPC.rotation, origin, NPC.scale, SpriteEffects.None, 0);
            return false;
        }
        public override bool? DrawHealthBar(byte hbPosition, ref float scale, ref Vector2 position)
        {
            return false;
        }
        public override bool CheckActive()
        {
            return false;
        }
    }
}