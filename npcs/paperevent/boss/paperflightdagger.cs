using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace gracosmod123.npcs.paperevent.boss
{
    public class paperflightdagger : ModNPC
    {
        public float rot;
        public Vector2 rotVec = new Vector2(0.0f, 170.0f);

        public override void ScaleExpertStats(int playerXPlayers, float bossLifeScale)
        {
            npc.lifeMax = (int)(npc.lifeMax * 1);
            npc.damage = (int)(npc.damage * 1);
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Paper Dagger");
        }

        public override void SetDefaults()
        {
            npc.width = 30;
            npc.height = 42;
            npc.noGravity = true;
            npc.noTileCollide = true;
            npc.damage = 0;
            npc.lifeMax = 180;
            npc.knockBackResist = 0f;
            npc.HitSound = SoundID.NPCHit42;
            npc.DeathSound = SoundID.NPCDeath44;
        }

        public override bool PreAI()
        {
            npc.TargetClosest(true);
            int boss = (int)npc.ai[0];
            if (boss < 0 || boss >= 200 || !Main.npc[boss].active || Main.npc[boss].type != mod.NPCType("paperCut"))
            {
                npc.active = false;
                return false;
            }
            this.rot += 0.02f;
            npc.netUpdate = true;
            Vector2 v = Main.npc[boss].Center - npc.Center;
            v.Normalize();
            v *= 9f;
            npc.rotation = Utils.ToRotation(v);
            NPC npc2 = Main.npc[(int)npc.ai[0]];
            npc.Center = npc2.Center + AntiarisHelper.RotateVector(new Vector2(), this.rotVec, this.rot + npc.ai[2] * 0.628f);
            return false;
        }
        public override void AI()
        {
            npc.rotation += .4f;
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
