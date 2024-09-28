using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace gracosmod123.lab.decontaminator       //We need this to basically indicate the folder where it is to be read from, so you the texture will load correctly
{
    public class decontaminatorproj : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 12;  //Set the hitbox width
            projectile.height = 12; //Set the hitbox height
            projectile.friendly = true;  //Tells the game whether it is friendly to players/friendly NPCs or not
            projectile.ignoreWater = true;  //Tells the game whether or not projectile will be affected by water
            projectile.ranged = true;  //Tells the game whether it is a ranged projectile or not
            Projectile.Penetrate = -1; //Tells the game how many enemies it can hit before being destroyed, -1 infinity
            projectile.timeLeft = 125;  //The amount of time the projectile is alive for  
            projectile.extraUpdates = 3;
        }
        private int timer = 0;

        public override void AI()
        {
            Lighting.AddLight(projectile.Center, ((255 - projectile.alpha) * 0.15f) / 255f, ((255 - projectile.alpha) * 0.45f) / 255f, ((255 - projectile.alpha) * 0.05f) / 255f);   //this is the light colors
            if (projectile.timeLeft > 125)
            {
                projectile.timeLeft = 125;
            }
            if (projectile.ai[0] > 1f)  //this defines where the flames starts
            {
                if (Main.rand.Next(3) == 0)     //this defines how many dust to spawn
                {
                    int dust = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, ModContent.DustType("labdust"), projectile.velocity.X * 1.2f, projectile.velocity.Y * 1.2f, 130, default(Color), 3.75f);   //this defines the flames dust and color, change DustID to wat dust you want from Terraria, or add ModContent.DustType("CustomDustName") for your custom dust
                    Main.dust[dust].noGravity = true; //this make so the dust has no gravity
                    Main.dust[dust].velocity *= 2.5f;
                    int dust2 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, ModContent.DustType("labdust"), projectile.velocity.X * 1.2f, projectile.velocity.Y * 1.2f, 130, default(Color), 1.5f); //this defines the flames dust and color parcticles, like when they fall thru ground, change DustID to wat dust you want from Terraria
                }
            }
            else
            {
                projectile.ai[0] += 1f;
            }
            if (timer == (int)projectile.ai[0])
            {
                projectile.velocity = projectile.velocity.SafeNormalize(-Vector2.UnitY) * 8f;
                projectile.alpha = 0;
            }
            else if (timer > (int)projectile.ai[0])
            {
                if (Main.rand.Next(2) == 0)
                {
                    Dust dust2 = Main.dust[Dust.NewDust(projectile.position, projectile.width, projectile.height, ModContent.DustType("CaeliteDust"))];
                    dust2.scale = .5f;
                }
                projectile.rotation = projectile.velocity.ToRotation();
                projectile.frameCounter++;
                if (projectile.frameCounter % 10 == 0)
                {
                    projectile.frame++;
                    if (projectile.frame > 1)
                    {
                        projectile.frame = 0;
                    }
                }
            }
            timer++;
            return;
        }
        /*public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)  //how to add a buff to a projectile
        {
            target.AddBuff(ModContent.BuffType("CustomDebuff"), 600);    //this adds the buff to the NPC that got hit by this projectile , 600 is the time the buff lasts
        }*/

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            projectile.Kill();
            return false;

        }
    }
}