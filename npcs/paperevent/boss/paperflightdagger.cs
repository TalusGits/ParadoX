using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace gracosmod123.NPCs.paperevent.boss
{
    public class paperflightdagger : ModNPC
    {
        public float rot;
        public Vector2 rotVec = new Vector2(0.0f, 170.0f);

        public override void ScaleExpertStats(int playerXPlayers, float bossLifeScale)
        {
            NPC.LifeMax = (int)(NPC.LifeMax * 1);
            NPC.damage = (int)(NPC.damage * 1);
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Paper Dagger");
        }

        public override void SetDefaults()
        {
            NPC.width = 30;
            NPC.height = 42;
            NPC.noGravity = true;
            NPC.NoTileCollide = true;
            NPC.damage = 0;
            NPC.LifeMax = 180;
            NPC.knockBackResist = 0f;
            NPC.HitSound = SoundID.NPCHit42;
            NPC.DeathSound = SoundID.NPCDeath44;
        }

        public override bool PreAI()
        {
            NPC.TargetClosest(true);
            int boss = (int)NPC.ai[0];
            if (boss < 0 || boss >= 200 || !Main.NPC[boss].active || Main.NPC[boss].type != ModContent.NPCType("paperCut"))
            {
                NPC.active = false;
                return false;
            }
            this.rot += 0.02f;
            NPC.netUpdate = true;
            Vector2 v = Main.NPC[boss].Center - NPC.Center;
            v.Normalize();
            v *= 9f;
            NPC.rotation = Utils.ToRotation(v);
            NPC NPC2 = Main.NPC[(int)NPC.ai[0]];
            NPC.Center = NPC2.Center + AntiarisHelper.RotateVector(new Vector2(), this.rotVec, this.rot + NPC.ai[2] * 0.628f);
            return false;
        }
        public override void AI()
        {
            NPC.rotation += .4f;
        }

        public override void ModifyHitByProjectile(Projectile projectile, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
        {
            projectile.velocity /= 2.0f;
            projectile.damage /= 2;
        }

        public override Color? GetAlpha(Color lightColor)
        {
            return Color.White;
        }

        public override bool CheckActive()
        {
            return false;
        }
    }
}
