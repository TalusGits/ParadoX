using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using static Terraria.ModLoader.ModContent;
using Microsoft.Xna.Framework;

namespace gracosmod123.items.forumsman
{

    public class TheXyoyoProj : ModProjectile
    {
        private bool spawned;
        private float spawning;
        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.YoyosLifeTimeMultiplier[projectile.type] = 7.5f;
            ProjectileID.Sets.YoyosMaximumRange[projectile.type] = 235f;
            ProjectileID.Sets.YoyosTopSpeed[projectile.type] = 11.5f;
            ProjectileID.Sets.YoyosMaximumRange[projectile.type] = 2000f;//325
        }

        public override void SetDefaults()
        {
            projectile.extraUpdates = 0;
            projectile.Size = new Vector2(16);
            projectile.aiStyle = 99;
            projectile.friendly = true;
            Projectile.Penetrate = -1;
            projectile.melee = true;
            projectile.scale = 1f;
            projectile.tileCollide = false;
            projectile.light = 2.00f;
            projectile.width = 60;
            projectile.height = 60;
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            //target.AddBuff(ModContent.BuffType.OnFire, 180);
            /*for (int i = 0; i < 50; i++)
            {
            }*/
            //float distance = 160f;
            //float k = 1.26f;
        }
        public override void AI()
        {
            /*++this.spawning;
            if ((double)this.spawning >= 280.0) { this.spawned = true; }
            if (!this.spawned)
            {
                this.spawning = 0.0f;
                this.spawned = true;
                float distance = 160f;
                float k = 1.26f;
                for (int count = 0; count < 10; count++)
                {
                    Vector2 spawn = projectile.Center + distance * ((float)count * k).ToRotationVector2();
                    Projectile.NewProjectileDirect((int)spawn.X, (int)spawn.Y, 0.0f, 0.0f, ModContent.ProjectileType("starfish2"), projectile.damage, projectile.knockBack, 0, (float)projectile.whoAmI, (float)count);
                }
            }*/

        }
    }
}
