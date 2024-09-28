using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace gracosmod123.NPCs.wormboss
{
    public class CactusThorn : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Jade spike");
        }
        public override void SetDefaults()
        {
            NPC.width = 10;
            NPC.height = 10;
            NPC.defense = 0;
            NPC.LifeMax = 1;
            if (Main.expertMode)
            {
                NPC.damage = 60;
            }
            else
            {
                NPC.damage = 30;
            }
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath9;
            NPC.value = Item.buyPrice(0, 0, 0, 0);
            NPC.knockBackResist = 0;
            NPC.behindTiles = true;
            NPC.aiStyle = -1;
            NPC.noGravity = false;
            NPC.NoTileCollide = false;
        }
        public override void PostDraw(SpriteBatch sb, Color lightColor)
        {
            Texture2D tex = Main.NPCTexture[NPC.type];
            sb.Draw(tex, NPC.Center - Main.screenPosition + new Vector2(0f, NPC.gfxOffY), new Rectangle?(new Rectangle(0, 0, tex.Width, tex.Height)), Color.White, NPC.rotation, new Vector2(tex.Width / 2, tex.Height / 2), NPC.scale, SpriteEffects.None, 0f);
        }
        public override bool PreNPCLoot()
        {
            return false;
        }
        public override void AI()
        {
            NPC.rotation = (float)System.Math.Atan2(NPC.velocity.Y, NPC.velocity.X) + 1.57f;
            if (NPC.ai[0] <= 1)
            {
                NPC.velocity = new Vector2(Main.rand.Next(-3, 4), Main.rand.Next(2) - 2);
                NPC.netUpdate = true;
            }
            else
            {
                if (NPC.velocity.X != NPC.oldVelocity.X)
                {
                    NPC.velocity.X = -NPC.oldVelocity.X;
                }
                if (NPC.velocity.Y != NPC.oldVelocity.Y)
                {
                    NPC.velocity.Y = -NPC.oldVelocity.Y * 0.9f;
                    NPC.ai[0] += 20;
                }
            }
            NPC.ai[0]++;
            if (NPC.ai[0] > 180)
            {
                NPC.active = false;
            }
        }
    }
}

