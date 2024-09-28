﻿using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace gracosmod123.npcs.paperevent
{
    public class paperFlailProj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Paper Flail");
        }
        int shootDelay = 0;
        public override void SetDefaults()
        {
            projectile.width = 34;
            projectile.height = 34;
            projectile.aiStyle = 15;
            projectile.friendly = true;
            projectile.melee = true;
            projectile.tileCollide = false;
            projectile.timeLeft = 3600;
            projectile.penetrate = -1;
            projectile.usesIDStaticNPCImmunity = true;
            projectile.idStaticNPCHitCooldown = 10;
            projectile.light = 0.50f; // projectile light still a lot
        }
        public override bool TileCollideStyle(ref int width, ref int height, ref bool fallThrough)
        {
            width = (int)(26 * projectile.scale);
            height = (int)(26 * projectile.scale);
            return true;
        }
        public override bool PreDrawExtras(SpriteBatch spriteBatch)
        {
            return false;
        }
        public override bool PreAI()
        {
            Player player = Main.player[projectile.owner];
            shootDelay++;
            if (shootDelay >= 20 /** 60*/)
            {
                for (int i = 0; i < 20; i++)
                {
                    if (Main.netMode != 1)
                        Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, (float)Math.Cos(Math.PI / 4 * i) * 12, (float)Math.Sin(Math.PI / 4 * i) * 12, ModContent.ProjectileType<npcs.paperevent.pencilcloudofdust>(), (int)(80), 3, Main.myPlayer);
                }
                shootDelay = 0;
            }
            if (player.inventory[player.selectedItem].shoot == projectile.type)
            {
                projectile.scale = player.inventory[player.selectedItem].scale;
            }
            projectile.width = (int)(34 * projectile.scale);
            projectile.height = (int)(34 * projectile.scale);
            if (player.dead)
            {
                projectile.Kill();
                return false;
            }
            player.itemAnimation = 10;
            player.itemTime = 10;
            if (projectile.Center.X > player.Center.X)
            {
                projectile.direction = 1;
            }
            else
            {
                projectile.direction = -1;
            }
            Vector2 playerCenter = player.MountedCenter;
            Vector2 dir = player.DirectionTo(projectile.Center);
            if (Main.myPlayer == projectile.owner)
            {
                bool channeling = player.channel && !player.noItems && !player.CCed;
                if (channeling)
                {
                    dir = Main.MouseWorld - playerCenter;
                    dir.Normalize();
                    if (dir.HasNaNs())
                    {
                        dir = Vector2.UnitX * (float)player.direction;
                    }
                    playerCenter += dir * 22;
                    if (Main.MouseWorld.X > player.Center.X)
                    {
                        if (player.direction < 0 && ((Main.MouseWorld.Y < player.position.Y + player.height && player.gravDir > 0) || (Main.MouseWorld.Y > player.position.Y && player.gravDir < 0)))
                        {
                            player.bodyFrame.Y = player.bodyFrame.Height;
                        }
                    }
                    else
                    {
                        if (player.direction > 0 && ((Main.MouseWorld.Y < player.position.Y + player.height && player.gravDir > 0) || (Main.MouseWorld.Y > player.position.Y && player.gravDir < 0)))
                        {
                            player.bodyFrame.Y = player.bodyFrame.Height;
                        }
                    }
                    if (dir.X != projectile.velocity.X || dir.Y != projectile.velocity.Y)
                    {
                        projectile.netUpdate = true;
                    }
                }
            }
            player.itemRotation = (float)Math.Atan2((double)(dir.Y * (float)player.direction), (double)(dir.X * (float)player.direction));
            float num207 = playerCenter.X - projectile.Center.X;
            float num208 = playerCenter.Y - projectile.Center.Y;
            float num209 = (float)Math.Sqrt((double)(num207 * num207 + num208 * num208));
            if (projectile.ai[0] == 0f)
            {
                float num210 = 100f; //Distance before coming back
                projectile.tileCollide = false;
                if (num209 > num210)
                {
                    projectile.ai[0] = 1f;
                    projectile.netUpdate = true;
                }
                else if (!player.channel)
                {
                    if (projectile.velocity.Y < 0f)
                    {
                        projectile.velocity.Y = projectile.velocity.Y * 0.9f;
                    }
                    projectile.velocity.Y = projectile.velocity.Y + 1f;
                    projectile.velocity.X = projectile.velocity.X * 0.9f;
                }
            }
            else if (projectile.ai[0] == 1f)
            {
                float num211 = 14f / player.meleeSpeed;
                float num212 = 0.9f / player.meleeSpeed;
                float num213 = 300f;
                float num214 = Math.Abs(num207);
                float num215 = Math.Abs(num208);
                if (projectile.ai[1] == 1f)
                {
                    projectile.tileCollide = false;
                }
                if (!player.channel || num209 > num213 || !projectile.tileCollide || projectile.timeLeft < 600)
                {
                    projectile.ai[1] = 1f;
                    if (projectile.tileCollide)
                    {
                        projectile.netUpdate = true;
                    }
                    projectile.tileCollide = false;
                    if (num209 < 20f)
                    {
                        projectile.Kill();
                    }
                }
                if (!projectile.tileCollide)
                {
                    num212 *= 2f;
                }
                int num216 = 20;
                if (num209 > (float)num216 || !projectile.tileCollide)
                {
                    num209 = num211 / num209;
                    num207 *= num209;
                    num208 *= num209;
                    Vector2 vector21 = new Vector2(projectile.velocity.X, projectile.velocity.Y);
                    float num217 = num207 - projectile.velocity.X;
                    float num218 = num208 - projectile.velocity.Y;
                    float num219 = (float)Math.Sqrt((double)(num217 * num217 + num218 * num218));
                    num219 = num212 / num219;
                    num217 *= num219;
                    num218 *= num219;
                    projectile.velocity.X = projectile.velocity.X * 0.98f;
                    projectile.velocity.Y = projectile.velocity.Y * 0.98f;
                    projectile.velocity.X = projectile.velocity.X + num217;
                    projectile.velocity.Y = projectile.velocity.Y + num218;
                }
                else
                {
                    if (Math.Abs(projectile.velocity.X) + Math.Abs(projectile.velocity.Y) < 6f)
                    {
                        projectile.velocity.X = projectile.velocity.X * 0.96f;
                        projectile.velocity.Y = projectile.velocity.Y + 0.2f;
                    }
                    if (Main.player[projectile.owner].velocity.X == 0f)
                    {
                        projectile.velocity.X = projectile.velocity.X * 0.96f;
                    }
                }
            }
            if (projectile.velocity.X < 0f)
            {
                projectile.rotation -= (Math.Abs(projectile.velocity.X) + Math.Abs(projectile.velocity.Y)) * 0.01f;
                if (player.direction < 0)
                {
                    player.heldProj = projectile.whoAmI;
                }
            }
            else
            {
                projectile.rotation += (Math.Abs(projectile.velocity.X) + Math.Abs(projectile.velocity.Y)) * 0.01f;
                if (player.direction > 0)
                {
                    player.heldProj = projectile.whoAmI;
                }
            }
            return false;
        }
        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            Texture2D texture = ModContent.GetTexture("gracosmod123/npcs/paperevent/paperFlailChain");
            Player player = Main.player[projectile.owner];
            Vector2 position = projectile.Center;
            Vector2 playerCenter = player.MountedCenter;
            if (player.bodyFrame.Y == player.bodyFrame.Height * 3)
            {
                playerCenter.X += 8 * player.direction;
                playerCenter.Y += 2 * player.gravDir;
            }
            else if (player.bodyFrame.Y == player.bodyFrame.Height * 2)
            {
                playerCenter.X += 6 * player.direction;
                playerCenter.Y += -12 * player.gravDir;
            }
            else if (player.bodyFrame.Y == player.bodyFrame.Height * 4)
            {
                playerCenter.X += 6 * player.direction;
                playerCenter.Y += 8 * player.gravDir;
            }
            else if (player.bodyFrame.Y == player.bodyFrame.Height)
            {
                playerCenter.X += -10 * player.direction;
                playerCenter.Y += -14 * player.gravDir;
            }
            Rectangle? sourceRectangle = new Microsoft.Xna.Framework.Rectangle?();
            Vector2 origin = new Vector2((float)texture.Width * 0.5f, (float)texture.Height * 0.5f);
            float num1 = (float)texture.Height * projectile.scale;
            Vector2 vector2_4 = playerCenter - position;
            float rotation = (float)Math.Atan2((double)vector2_4.Y, (double)vector2_4.X) - 1.57f;
            bool flag = true;
            if (float.IsNaN(position.X) && float.IsNaN(position.Y))
                flag = false;
            if (float.IsNaN(vector2_4.X) && float.IsNaN(vector2_4.Y))
                flag = false;
            while (flag)
            {
                if ((double)vector2_4.Length() < (double)num1 + 1.0)
                {
                    flag = false;
                }
                else
                {
                    Vector2 vector2_1 = vector2_4;
                    vector2_1.Normalize();
                    position += vector2_1 * num1;
                    vector2_4 = playerCenter - position;
                    Color color2 = Lighting.GetColor((int)position.X / 16, (int)((double)position.Y / 16.0));
                    color2 = projectile.GetAlpha(color2);
                    Main.spriteBatch.Draw(texture, position - Main.screenPosition, sourceRectangle, color2, rotation, origin, projectile.scale, SpriteEffects.None, 0.0f);
                }
            }
            Texture2D tex = Main.projectileTexture[projectile.type];
            SpriteEffects effects = SpriteEffects.None;
            if (projectile.spriteDirection == -1)
            {
                effects = SpriteEffects.FlipHorizontally;
            }
            Color color = Lighting.GetColor((int)(projectile.Center.X / 16), (int)(projectile.Center.Y / 16.0));
            spriteBatch.Draw(tex, projectile.Center - Main.screenPosition + new Vector2(0f, projectile.gfxOffY), new Rectangle?(new Rectangle(0, 0, tex.Width, tex.Height)), color, projectile.rotation, new Vector2(tex.Width / 2, tex.Height / 2), projectile.scale, effects, 0f);
            return false;
        }
    }
}
