using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
/*namespace gracosmod123.npcs
{
    public class shotharpHoming : ModProjectile
    {

        public float Distance;
        public int Target;

        float Rotation
        {
            get { return projectile.ai[0]; }
            set { projectile.ai[0] = value; }
        }

        int Owner
        {
            get { return (int)projectile.ai[1]; }
            set { projectile.ai[1] = value; }
        }
        public override void SetDefaults()
        {
            projectile.width = 30;
            projectile.height = 30;
            projectile.friendly = false;
            projectile.hostile = true;
            projectile.penetrate = 1;
            projectile.tileCollide = false;
            projectile.timeLeft = 60;
            ProjectileID.Sets.Homing[projectile.type] = true;
            projectile.light = 1.00f;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Huh");
        }

        public override void AI()
        {
            projectile.timeLeft = 60;
            if (!Main.npc[Owner].active)
            {
                projectile.Kill();
            }
            projectile.tileCollide = false;
            if (Distance <= 64f)
            {
                Distance += 1.5f;
            }
            Rotation = MathHelper.WrapAngle(Rotation + MathHelper.TwoPi / 200f);
            NPC npc = Main.npc[Owner];
            projectile.Center = npc.Center + new Vector2(0, Distance);
            projectile.Center = projectile.Center.RotatedBy(Rotation, npc.Center);
        }

        public override void Kill(int timeLeft)
        {
            for (int i = 0; i < 5; i++)
            {
                Dust.NewDust(projectile.position, projectile.width, projectile.height, 15, projectile.velocity.X, projectile.velocity.Y);
            }
        }
    }
}*/
using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace gracosmod123.npcs
{
    public class shotharpHoming : ModProjectile
    {

        public bool bitherial = true;
        public bool stopped = false;
        public int power = 0;
        public bool spawned = false;

        public override void SetDefaults()
        {
            power = 0;
            stopped = false;
            spawned = false;
            //mystDmg = (float)projectile.damage;
            //mystDur = 1f + projectile.knockBack;
            projectile.width = 22;
            projectile.height = 22;
            projectile.penetrate = -1;
            projectile.hostile = true;
            projectile.timeLeft = 220;
            projectile.ignoreWater = true;
            projectile.tileCollide = false;
            projectile.scale = 1.25f;
        }


        public override void AI()
        {
            bitherial = true;
            Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 15, 0f, 0f);
            //projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X);
            if (projectile.localAI[0] == 0f)
            {
                AdjustMagnitude(ref projectile.velocity);
                projectile.localAI[0] = 1f;
            }
            Vector2 move = Vector2.Zero;
            float distance = 1400f;
            bool target = false;
            for (int k = 0; k < 8; k++)
            {
                if (Main.player[k].active)
                {
                    Vector2 newMove = Main.player[k].Center - projectile.Center;
                    float distanceTo = (float)Math.Sqrt(newMove.X * newMove.X + newMove.Y * newMove.Y);
                    if (distanceTo < distance)
                    {
                        move = newMove;
                        distance = distanceTo;
                        target = true;
                    }
                }
            }
            if (target)
            {
                AdjustMagnitude(ref move);
                projectile.velocity = (16 * projectile.velocity + move) / 5f;
                AdjustMagnitude(ref projectile.velocity);
            }

        }

        private void AdjustMagnitude(ref Vector2 vector)
        {
            float magnitude = (float)Math.Sqrt(vector.X * vector.X + vector.Y * vector.Y);
            if (magnitude > 6f)
            {
                vector *= 6f / magnitude;
            }
        }


        public override void OnHitPlayer(Player player, int dmgDealt, bool crit)
        {
            player.AddBuff(31, 300, true);// adds confused
        }
        public override void Kill(int timeLeft)
        {
            for (int i = 0; i < 25; i++)
            {
                Dust.NewDust(projectile.position, projectile.width, projectile.height, 15, projectile.velocity.X, projectile.velocity.Y);
            }
        }
    }
}