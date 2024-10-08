﻿using IL.Terraria.ID;
using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ModLoader;

namespace gracosmod123.NPCs.ocean.oceanitems
{
    public class Tide : ModProjectile
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Tide");
            Main.projFrames[projectile.type] = 6;
        }

        public override void SetDefaults()
        {
            projectile.CloneDefaults(386);
            //projectile.tileCollide = true;
            //projectile.width = 162;
            //projectile.height = 42;
            projectile.aiStyle = -1;
            projectile.friendly = true;
            projectile.hostile = false;
            projectile.friendly = true;
            projectile.melee = false;
            projectile.ranged = false;
            projectile.magic = false;
            projectile.thrown = false;
            projectile.minion = false;
            Projectile.Penetrate = -1;
            //Projectile.Penetrate = -1;
            projectile.timeLeft = 100;
            projectile.damage = 20;
            projectile.light = 2.00f;
        }

        public override void AI()
        {
            int num612 = 10;
            int num613 = 15;
            float num614 = 1f;
            int num615 = 150;
            int num616 = 42;
            projectile.damage = 102;
            //if (projectile.type == 386)
            //{
            //	num612 = 16;
            //	num613 = 16;
            //	num614 = 1.5f;
            //}
            if (projectile.velocity.X != 0f)
            {
                projectile.direction = (projectile.spriteDirection = -Math.Sign(projectile.velocity.X));
            }
            projectile.frameCounter++;
            if (projectile.frameCounter > 2)
            {
                projectile.frame++;
                projectile.frameCounter = 0;
            }
            if (projectile.frame >= 6)
            {
                projectile.frame = 0;
            }
            if (projectile.localAI[0] == 0f && Main.myPlayer == projectile.owner)
            {
                projectile.localAI[0] = 1f;
                projectile.position.X = projectile.position.X + (float)(projectile.width / 2);
                projectile.position.Y = projectile.position.Y + (float)(projectile.height / 2);
                projectile.scale = ((float)(num612 + num613) - projectile.ai[1]) * num614 / (float)(num613 + num612);
                projectile.width = (int)((float)num615 * projectile.scale);
                projectile.height = (int)((float)num616 * projectile.scale);
                projectile.position.X = projectile.position.X - (float)(projectile.width / 2);
                projectile.position.Y = projectile.position.Y - (float)(projectile.height / 2);
                projectile.netUpdate = true;
            }
            if (projectile.ai[1] != -1f)
            {
                projectile.scale = ((float)(num612 + num613) - projectile.ai[1]) * num614 / (float)(num613 + num612);
                projectile.width = (int)((float)num615 * projectile.scale);
                projectile.height = (int)((float)num616 * projectile.scale);
            }
            if (!Collision.SolidCollision(projectile.position, projectile.width, projectile.height))
            {
                projectile.alpha -= 30;
                if (projectile.alpha < 60)
                {
                    projectile.alpha = 60;
                }
                //if (projectile.type == 386 && projectile.alpha < 100)
                //{
                //	projectile.alpha = 100;
                //}
            }
            else
            {
                projectile.alpha += 30;
                if (projectile.alpha > 150)
                {
                    projectile.alpha = 150;
                }
            }
            if (projectile.ai[0] > 0f)
            {
                projectile.ai[0] -= 1f;
            }
            if (projectile.ai[0] == 1f && projectile.ai[1] > 0f && projectile.owner == Main.myPlayer)
            {
                projectile.netUpdate = true;
                Vector2 center4 = projectile.Center;
                center4.Y -= (float)num616 * projectile.scale / 2f;
                float num617 = ((float)(num612 + num613) - projectile.ai[1] + 1f) * num614 / (float)(num613 + num612);
                center4.Y -= (float)num616 * num617 / 2f;
                center4.Y += 2f;
                Projectile.NewProjectileDirect(center4.X, center4.Y, projectile.velocity.X, projectile.velocity.Y, projectile.type, 20, projectile.knockBack, projectile.owner, 10f, projectile.ai[1] - 1f);
                int num618 = 4;
                //if (projectile.type == 386)
                //{
                //	num618 = 2;
                //}
                if ((int)projectile.ai[1] % num618 == 0 && projectile.ai[1] != 0f)
                {
                    int num619 = 372;
                    //if (projectile.type == 386)
                    //{
                    //	num619 = 373;
                    //}
                    //int num620 = NPC.NewNPC((int)center4.X, (int)center4.Y, num619, 0, 0f, 0f, 0f, 0f, 255);
                    //Main.NPC[num620].velocity = projectile.velocity;
                    //Main.NPC[num620].netUpdate = true;
                    //if (projectile.type == 386)
                    //{
                    //	Main.NPC[num620].ai[2] = (float)projectile.width;
                    //	Main.NPC[num620].ai[3] = -1.5f;
                    //}
                }
            }
            if (projectile.ai[0] <= 0f)
            {
                float num621 = 0.104719758f;
                float num622 = (float)projectile.width / 5f;
                //if (projectile.type == 386)
                //{
                //	num622 *= 2f;
                //}
                float num623 = (float)(Math.Cos((double)num621 * (0.0 - (double)projectile.ai[0])) - 0.5) * num622;
                projectile.position.X = projectile.position.X - num623 * (0f - (float)projectile.direction);
                projectile.ai[0] -= 1f;
                num623 = (float)(Math.Cos((double)num621 * (0.0 - (double)projectile.ai[0])) - 0.5) * num622;
                projectile.position.X = projectile.position.X + num623 * (0f - (float)projectile.direction);
            }

            //The tornado pull effect
            //Player player = Main.player[Main.myPlayer];

            //Player

            //NPCS
            for (int i = 0; i < Main.NPC.Length; i++)
            {
                if ((projectile.position.X / 16) <= ((Main.NPC[i].position.X + 700) / 16) && (projectile.position.X / 16) >= ((Main.NPC[i].position.X - 700) / 16) && !Main.NPC[i].boss && Main.NPC[i].type != 488)
                {
                    Main.NPC[i].netUpdate = true;

                    Main.NPC[i].rotation += projectile.velocity.X * 0.8f;

                    //X
                    if (Main.NPC[i].position.X <= (projectile.position.X + 37))
                    {
                        //Main.NPC[i].velocity.X = 2;
                        Main.NPC[i].velocity.X = Main.NPC[i].velocity.X + 0.3f;
                    }
                    else
                    {
                        //Main.NPC[i].velocity.X = -2;
                        Main.NPC[i].velocity.X = Main.NPC[i].velocity.X - 0.3f;
                    }

                    //Y
                    if (Main.NPC[i].position.Y <= (projectile.position.Y - 250))
                    {
                        //Main.NPC[i].velocity.Y = 2;
                        Main.NPC[i].velocity.Y = Main.NPC[i].velocity.Y + .5f;
                    }
                    else
                    {
                        //Main.NPC[i].velocity.Y = -2;
                        Main.NPC[i].velocity.Y = Main.NPC[i].velocity.Y - .5f;
                    }
                }
                else
                {
                    Main.NPC[i].rotation = 0;
                }
            }

            //Items
            for (int v = 0; v < Main.item.Length; v++)
            {
                if ((projectile.position.X / 16) <= ((Main.item[v].position.X + 700) / 16) && (projectile.position.X / 16) >= ((Main.item[v].position.X - 700) / 16))
                {
                    //X
                    if (Main.item[v].position.X <= (projectile.position.X))//+37
                    {
                        //Main.NPC[i].velocity.X = 2;
                        Main.item[v].velocity.X = Main.item[v].velocity.X + 0.3f;
                    }
                    else
                    {
                        //Main.NPC[i].velocity.X = -2;
                        Main.item[v].velocity.X = Main.item[v].velocity.X - 0.3f;
                    }

                    //Y
                    if (Main.item[v].position.Y <= (projectile.position.Y - 200))
                    {
                        //Main.NPC[i].velocity.Y = 2;
                        Main.item[v].velocity.Y = Main.item[v].velocity.Y + .5f;
                    }
                    else
                    {
                        //Main.NPC[i].velocity.Y = -2;
                        Main.item[v].velocity.Y = Main.item[v].velocity.Y - .5f;
                    }
                }
            }
            //NEW
            //NEW
            //NEW
            //NEW
            //NEW
            //NEW
            //NEW
            //NEW
            var player = Main.player[projectile.owner];
            if (Main.myPlayer != projectile.owner)
                return;
            Vector2 vector;
            vector.X = Main.MouseWorld.X - 30f;
            vector.Y = Main.MouseWorld.Y - 30f;
            projectile.netUpdate = true;
            projectile.position = vector;

        }

        public override void Kill(int timeLeft)
        {
            var player = Main.player[projectile.owner];
            Projectile.NewProjectileDirect(projectile.Center.X, projectile.Center.Y - 65f, 0.0f, 0.2f, ModContent.ProjectileType("starfish2"), (int)(73 * (double)player.meleeDamage), 6.5f, projectile.owner, 0.0f, 0.0f);
            Projectile.NewProjectileDirect(projectile.Center.X - 65f, projectile.Center.Y, 0.2f, 0.0f, ModContent.ProjectileType("starfish2"), (int)(73 * (double)player.meleeDamage), 6.5f, projectile.owner, 0.0f, 0.0f);
            Projectile.NewProjectileDirect(projectile.Center.X, projectile.Center.Y + 65f, 0.0f, -0.2f, ModContent.ProjectileType("starfish2"), (int)(73 * (double)player.meleeDamage), 6.5f, projectile.owner, 0.0f, 0.0f);
            Projectile.NewProjectileDirect(projectile.Center.X + 65f, projectile.Center.Y, -0.2f, 0.0f, ModContent.ProjectileType("starfish2"), (int)(73 * (double)player.meleeDamage), 6.5f, projectile.owner, 0.0f, 0.0f);
            Projectile.NewProjectileDirect(projectile.Center.X - 40f, projectile.Center.Y - 40f, 0.2f, 0.2f, ModContent.ProjectileType("starfish2"), (int)(73 * (double)player.meleeDamage), 6.5f, projectile.owner, 0.0f, 0.0f);
            Projectile.NewProjectileDirect(projectile.Center.X + 40f, projectile.Center.Y + 40f, -0.2f, -0.2f, ModContent.ProjectileType("starfish2"), (int)(73 * (double)player.meleeDamage), 6.5f, projectile.owner, 0.0f, 0.0f);
            Projectile.NewProjectileDirect(projectile.Center.X - 40f, projectile.Center.Y + 40f, 0.2f, -0.2f, ModContent.ProjectileType("starfish2"), (int)(73 * (double)player.meleeDamage), 6.5f, projectile.owner, 0.0f, 0.0f);
            Projectile.NewProjectileDirect(projectile.Center.X + 40f, projectile.Center.Y - 40f, -0.2f, 0.2f, ModContent.ProjectileType("starfish2"), (int)(73 * (double)player.meleeDamage), 6.5f, projectile.owner, 0.0f, 0.0f);
            for (int i = 0; i < Main.NPC.Length; i++)
            {
                Main.NPC[i].rotation = 0;
            }
        }
    }
}