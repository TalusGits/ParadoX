using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace gracosmod123.NPCs.paperevent.boss
{
    [AutoloadBossHead]
    public class paperCut : ModNPC
    {
        private int ai;
        private int attackTimer = 0;
        private bool checkDead = false;

        private double counting;
        private int deadTimer = 0;
        private bool fastSpeed = false;
        private int frame;
        private int healTime = 0;
        private int healTimeKey;
        private bool secondState;
        private bool secondState2;
        private bool stunned;
        private int stunnedTimer;

        public override void SetDefaults()
        {
            NPC.LifeMax = 9000;
            NPC.damage = 30;
            NPC.defense = 17;
            NPC.knockBackResist = 0f;
            NPC.width = 204;
            NPC.height = 160;
            NPC.NPCSlots = 5f;
            //NPC.HitSound = mod.GetLegacySoundSlot(Terraria.ModLoader.SoundType.Custom, "Sounds/NPCs/TowerKeeperHit");
            NPC.noGravity = true;
            NPC.NPCSlots = 5f;
            NPC.boss = true;
            NPC.value = Item.buyPrice(0, 11, 0, 0);
            NPC.NoTileCollide = true;
            Main.NPCFrameCount[NPC.type] = 6;
            //bossBag = ModContent.ItemType("TowerKeeperTreasureBag1");
            //music = mod.GetSoundSlot(Terraria.ModLoader.SoundType.Music, "Sounds/Music/TowerKeeper");
        }

        public override void ScaleExpertStats(int playerXPlayers, float bossLifeScale)
        {
            if (playerXPlayers > 1)
            {
                NPC.LifeMax = (int)(11000 + (double)NPC.LifeMax * 0.2 * (double)playerXPlayers);
            }
            else
            {
                NPC.LifeMax = 11000;
            }
            NPC.damage = (int)(NPC.damage * 0.65f);
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Paper Cut");
        }

        /*public override void NPCLoot()
        {
            //Gracmod.DownedTowerKeeper = true;///USE
            ///USE
            ///USE
            ///USE
            ///USE
            ///USE
            ///USE
            ///USE
            ///USE
            ///USE
            ///USE
            ///USE
            ///USE
            ///USE
            ///USE
            ///USE
            ///USE
            ///USE

            if (Main.expertMode)
            {
                NPC.DropBossBags();
            }
            if (!Main.expertMode)
            {
                Item.NewItem((int)NPC.position.X, (int)NPC.position.Y, NPC.width, NPC.height, ModContent.ItemType("BloodyChargedCrystal"), Main.rand.Next(15, 24), false, 0, false, false);
                Item.NewItem((int)NPC.position.X, (int)NPC.position.Y, NPC.width, NPC.height, ModContent.ItemType("MirrorShard"), Main.rand.Next(10, 15), false, 0, false, false);
                if (Main.rand.Next(7) == 0)
                {
                    Item.NewItem((int)NPC.position.X, (int)NPC.position.Y, NPC.width, NPC.height, ModContent.ItemType("TowerKeeperMask1"), 1, false, 0, false, false);
                }
                if (Main.rand.Next(7) == 0)
                {
                    Item.NewItem((int)NPC.position.X, (int)NPC.position.Y, NPC.width, NPC.height, ModContent.ItemType("GuardianHeart"), 1, false, 0, false, false);
                }
            }
            if (Main.rand.Next(10) == 0)
            {
                Item.NewItem((int)NPC.position.X, (int)NPC.position.Y, NPC.width, NPC.height, ModContent.ItemType("TowerKeeperTrophy1"), 1, false, 0, false, false);
            }
        }*/

        public override void BossLoot(ref string name, ref int potionType)
        {
            potionType = 188;
        }
        public override Color? GetAlpha(Color lightColor)
        {
            return Color.White;
        }
        public override void AI()
        {
            NPC.rotation += .4f;
            Player player = Main.player[NPC.target];
            Vector2 target = NPC.HasPlayerTarget ? player.Center : Main.NPC[NPC.target].Center;
            NPC.rotation = 0.0f;
            NPC.netAlways = true;
            NPC.TargetClosest(true);
            if (NPC.life >= NPC.LifeMax)
                NPC.life = NPC.LifeMax;
            if (NPC.target < 0 || NPC.target == 255 || player.dead || !player.active)
            {
                NPC.TargetClosest(false);
                NPC.direction = 1;
                NPC.velocity.Y = NPC.velocity.Y - 0.1f;
                if (NPC.timeLeft > 10)
                {
                    NPC.timeLeft = 10;
                    return;
                }
            }
            if (this.stunned)
            {
                NPC.velocity.Y = 0.0f;
                NPC.velocity.X = 0.0f;
                ++this.stunnedTimer;
                if (this.stunnedTimer >= 105)
                {
                    this.stunned = false;
                    this.stunnedTimer = 0;
                }
            }
            if (!this.secondState)
            {
                float distance = 160f;
                float k = 1.26f;
                for (int count = 0; count < 10; count++)
                {
                    Vector2 spawn = NPC.Center + distance * ((float)count * k).ToRotationVector2();
                    NPC.NewNPC((int)spawn.X, (int)spawn.Y, ModContent.NPCType("paperflightdagger"), 0, (float)NPC.whoAmI, 0.0f, (float)count, 0.0f, 255);
                }
                this.secondState = true;
            }
            ++this.ai;
            NPC.ai[0] = (float)this.ai * 1f;
            int velocity = (int)((double)NPC.ai[0] / 50f);
            bool speedB = ((double)NPC.life <= NPC.LifeMax * 0.6 ? true : false);
            int speedV = (int)(speedB ? 6f : 0f);
            if ((double)NPC.ai[0] < 350.0 && !this.stunned)
            {
                this.frame = 0;
                AntiarisHelper.MoveTowards(NPC, target, (int)(Vector2.Distance(target, NPC.Center) > 300 ? (Main.expertMode ? 24f : 20f) : (Main.expertMode ? 9f : 7f)) + speedV, 30f);
                for (int k = 0; k < 5 * (NPC.ai[0] / 50); k++)
                {
                    float scale = 0.4f;
                    if (NPC.ai[0] % 2 == 1) scale = 0.65f;
                    Vector2 sDust = NPC.Center + ((float)Main.rand.NextDouble() * 6.283185f).ToRotationVector2() * (12f - (float)(velocity * 2));
                    int index2 = Dust.NewDust(new Vector2(NPC.position.X, NPC.position.Y), NPC.width, NPC.height, ModContent.DustType("White"));
                    //                    int dust = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, ModContent.DustType("White"));
                    Main.dust[index2].position -= new Vector2(2f);
                    Main.dust[index2].velocity = Vector2.Normalize(NPC.Center - sDust) * 1.5f * (float)(10.0 - (double)velocity * 2.0) / 10f;
                    Main.dust[index2].noGravity = true;
                    Main.dust[index2].scale = scale;
                    Main.dust[index2].customData = (object)NPC;
                }
                NPC.netUpdate = true;
                if ((double)NPC.ai[0] % 349.0 == 0)
                {
                    this.healTime += 1;
                    //CombatText.NewText(new Rectangle((int)NPC.position.X, (int)NPC.position.Y, NPC.width, NPC.height), Color.Red, "+1", false, false);
                }
            }
            else if ((double)NPC.ai[0] >= 350.0 && (double)NPC.ai[0] < 450.0)
            {
                this.stunned = true;
                this.frame = 2;
                AntiarisHelper.MoveTowards(NPC, target, (int)(Vector2.Distance(target, NPC.Center) > 300 ? (Main.expertMode ? 24f : 20f) : (Main.expertMode ? 9f : 7f)) + speedV, 30f);
                for (int k = 0; k < 2 * (NPC.ai[0] / 45); k++)
                {
                    float scale = 0.65f;
                    if (NPC.ai[0] % 2 == 1) scale = 0.81f;
                    Vector2 sDust = NPC.Center + ((float)Main.rand.NextDouble() * 6.283185f).ToRotationVector2() * (12f - (float)(velocity * 2));
                    int index2 = Dust.NewDust(new Vector2(NPC.position.X, NPC.position.Y), NPC.width, NPC.height, ModContent.DustType("White"));
                    Main.dust[index2].position -= new Vector2(2f);
                    Main.dust[index2].velocity = Vector2.Normalize(NPC.Center - sDust) * 1.5f * (float)(10.0 - (double)velocity * 2.0) / 10f;
                    Main.dust[index2].noGravity = true;
                    Main.dust[index2].scale = scale;
                    Main.dust[index2].customData = (object)NPC;
                }
                player.AddBuff(ModContent.BuffType("Injured"), Main.expertMode ? 560 : 420, true);
                NPC.netUpdate = true;
            }
            if ((double)NPC.ai[0] >= 450.0)
            {
                this.frame = 1;
                this.stunned = false;
                NPC.defense = 40;
                if (!this.fastSpeed)
                {
                    if (Main.rand.Next(2) == 0)
                    {
                        this.fastSpeed = true;
                        NPC.ai[2] = 0f;
                    }
                    else
                    {
                        this.fastSpeed = true;
                        NPC.ai[2] = 1f;
                    }
                }
                else
                {
                    if ((double)NPC.ai[2] == 0.0)
                    {
                        if ((double)NPC.ai[0] % 50 == 0)
                        {
                            float speed = 21f + speedV;
                            if (Main.expertMode)
                                speed = 25f + speedV;
                            Vector2 vector_ = new Vector2(NPC.position.X + (float)NPC.width * 0.5f, NPC.position.Y + (float)NPC.height * 0.5f);
                            float x = player.position.X + (float)(player.width / 2) - vector_.X;
                            float y = player.position.Y + (float)(player.height / 2) - vector_.Y;
                            float distanse = (float)Math.Sqrt((double)x * (double)x + (double)y * (double)y);
                            float resuceFactor = speed / distanse;
                            NPC.velocity.X = x * resuceFactor;
                            NPC.velocity.Y = y * resuceFactor;
                        }
                    }
                    else
                    {
                        NPC.alpha = 180;
                        if ((double)NPC.ai[0] % 35 == 0)
                        {
                            float speed = 28f + speedV;
                            if (Main.expertMode)
                                speed = 30f + speedV;
                            Vector2 vector_ = new Vector2(NPC.position.X + (float)NPC.width * 0.5f, NPC.position.Y + (float)NPC.height * 0.5f);
                            float x = player.position.X + (float)(player.width / 2) - vector_.X;
                            float y = player.position.Y + (float)(player.height / 2) - vector_.Y;
                            float distanse = (float)Math.Sqrt((double)x * (double)x + (double)y * (double)y);
                            float resuceFactor = speed / distanse;
                            NPC.velocity.X = x * resuceFactor;
                            NPC.velocity.Y = y * resuceFactor;
                        }
                    }
                }
                NPC.netUpdate = true;
            }
            else
                NPC.defense = 22;
            if ((double)NPC.ai[0] >= 650.0)
            {
                this.ai = 0;
                NPC.alpha = 0;
                NPC.ai[2] = 0;
                this.fastSpeed = false;
            }
            if ((double)NPC.life <= NPC.LifeMax * 0.333)
            {
                NPC.alpha = 0;
                this.ai = 0;
                this.frame = 0;
                NPC.ai[1] += 1 + ((double)NPC.life <= NPC.LifeMax * 0.111 ? 1 : ((double)NPC.life <= NPC.LifeMax * 0.222 ? 1 : 0));
                NPC.defense = 25;
                if ((double)NPC.ai[1] < 200.0)
                {
                    this.frame = 2;
                    NPC.velocity.X = 0f; NPC.velocity.Y = 0f;
                }
                if ((double)NPC.ai[1] < 200.0)
                    for (int k = 0; k < 3 * (NPC.ai[1] / 50); k++)
                    {
                        float scale = 0.81f;
                        if (NPC.ai[0] % 2 == 1) scale = 1f;
                        Vector2 sDust = NPC.Center + ((float)Main.rand.NextDouble() * 6.283185f).ToRotationVector2() * (12f - (float)(velocity * 2));
                        int index2 = Dust.NewDust(sDust - Vector2.One * 12f, 24, 24, 60, NPC.velocity.X / 2f, NPC.velocity.Y /*/ 2f*/, 0, new Color(), 1f);
                        Main.dust[index2].position -= new Vector2(2f);
                        Main.dust[index2].velocity = Vector2.Normalize(NPC.Center - sDust) * 1.5f * (float)(10.0 - (double)velocity * 2.0) / 10f;
                        Main.dust[index2].noGravity = true;
                        Main.dust[index2].scale = scale;
                        Main.dust[index2].customData = (object)NPC;
                    }
                if ((double)NPC.ai[1] % 200.0 == 0 && (double)NPC.ai[1] <= 399.0)
                {
                    this.attackTimer += 1;
                    if (this.attackTimer <= 2)
                    {
                        Vector2 shootPos = NPC.Center;
                        float inaccuracy = 10f * (NPC.life / NPC.LifeMax);
                        Vector2 shootVel = target - shootPos + new Vector2(Main.rand.NextFloat(-inaccuracy, inaccuracy), Main.rand.NextFloat(-inaccuracy, inaccuracy));
                        shootVel.Normalize();
                        shootVel *= 14f;
                        SoundEngine.PlaySound(2, (int)NPC.position.X, (int)NPC.position.Y, 88);
                        for (int k = 0; k < (Main.expertMode ? 5 : 3); k++) Projectile.NewProjectileDirect(shootPos.X + (float)(-100 * NPC.direction) + (float)Main.rand.Next(-40, 41), shootPos.Y - (float)Main.rand.Next(-50, 40), shootVel.X, shootVel.Y, ModContent.ProjectileType("paperdagger"), NPC.damage / 3, 5f);
                    }
                    else
                    {
                        if (Main.expertMode)
                        {
                            for (int i = 0; i < 7; i++)
                                Projectile.NewProjectileDirect((int)((player.position.X - 50) + Main.rand.Next(100)), (int)((player.position.Y - 50) + Main.rand.Next(100)), 0.0f, 0.0f, ModContent.ProjectileType("sheetpaperdagger"), NPC.damage / 3, 4.5f);
                        }
                        for (int k = 0; k < (Main.expertMode ? 8 : 5); k++)
                        {
                            Vector2 shootPos = player.position + new Vector2(Main.rand.Next(-300, 300), -1000);
                            Vector2 shootVel = new Vector2(Main.rand.NextFloat(-3f, 3f), Main.rand.NextFloat(9f, 14f));
                            Projectile.NewProjectileDirect(shootPos, shootVel, ModContent.ProjectileType("paperdagger"), NPC.damage / 3, 4.5f);
                        }
                        SoundEngine.PlaySound(2, (int)NPC.position.X, (int)NPC.position.Y, 88);
                        this.attackTimer = 0;
                    }
                }
                if ((double)NPC.ai[1] > 200.0)
                {
                    AntiarisHelper.MoveTowards(NPC, player.Center, 8f + (float)((double)NPC.life <= NPC.LifeMax * 0.111 ? 3 : ((double)NPC.life <= NPC.LifeMax * 0.222 ? 2 : 0)), 8f + (float)((double)NPC.life <= NPC.LifeMax * 0.111 ? 3 : ((double)NPC.life <= NPC.LifeMax * 0.222 ? 2 : 0)));
                }
                if (NPC.ai[1] >= 350f)
                    NPC.ai[1] = 0f;
                NPC.netUpdate = true;
            }
            if ((double)NPC.life <= NPC.LifeMax * 0.135)
            {
                this.frame = 1;
                this.stunned = true;
                if (!this.secondState2)
                {
                    float distance = 160f;
                    float k = 1.26f;
                    for (int count = 0; count < 10; count++)
                    {
                        Vector2 spawn = NPC.Center + distance * ((float)count * k).ToRotationVector2();
                        NPC.NewNPC((int)spawn.X, (int)spawn.Y, ModContent.NPCType("paperflightdagger"), 0, (float)NPC.whoAmI, 0.0f, (float)count, 0.0f, 255);
                    }
                    this.secondState2 = true;
                }
                if (NPC.AnyNPCs(ModContent.NPCType("paperflightdagger")))
                {
                    //if ((double)this.ai % 215.0 == 0.0)
                    if (Main.rand.Next(5) == 0)
                        Projectile.NewProjectileDirect((int)((NPC.position.X - 500) + Main.rand.Next(1000)), (int)((NPC.position.Y - 500) + Main.rand.Next(1000)), 0.0f, 0.0f, ModContent.ProjectileType("sheetpaperdagger"), NPC.damage / 3, 4.5f);
                    NPC.dontTakeDamage = true;
                }
                else
                {
                    //if ((double)this.ai % 225.0 == 0.0)
                    if (Main.rand.Next(5) == 0)
                        Projectile.NewProjectileDirect((int)((NPC.position.X - 500) + Main.rand.Next(1000)), (int)((NPC.position.Y - 500) + Main.rand.Next(1000)), 0.0f, 0.0f, ModContent.ProjectileType("sheetpaperdagger"), NPC.damage / 3, 4.5f);
                    NPC.dontTakeDamage = false;
                }
            }
            if (this.healTime >= 3)
            {
                ++this.healTimeKey;
                if (this.healTimeKey >= 120)
                {
                    NPC.life += (int)(620 * (Main.expertMode ? 1.5f : 1f));
                    CombatText.NewText(new Rectangle((int)NPC.position.X, (int)NPC.position.Y, NPC.width, NPC.height), new Color(71, 180, 71), "+" + (int)(350 * (Main.expertMode ? 1.5f : 1f)), false, false);
                    Main.player[Main.myPlayer].statLife -= 50;
                    this.healTime = 0;
                    this.healTimeKey = 0;
                    NPC.netUpdate = true;
                }
            }
            if (this.checkDead)
            {
                this.ai = 0;
                NPC.ai[0] = 0;
                NPC.ai[1] = 0;
                NPC.velocity.X = NPC.velocity.Y = 0f;
                ++this.deadTimer;
                this.frame = 0;
                for (int k = 0; k < 5 * (this.deadTimer / 50); k++)
                {
                    NPC.dontTakeDamage = true;
                    float scale = 0.81f;
                    if (NPC.ai[0] % 2 == 1) scale = 1f;
                    Vector2 sDust = NPC.Center + ((float)Main.rand.NextDouble() * 6.283185f).ToRotationVector2() * (12f - (float)(velocity * 2));
                    int index2 = Dust.NewDust(new Vector2(NPC.position.X, NPC.position.Y), NPC.width, NPC.height, ModContent.DustType("White"));
                    Main.dust[index2].position -= new Vector2(2f);
                    Main.dust[index2].velocity = Vector2.Normalize(NPC.Center - sDust) * 1.5f * (float)(10.0 - (double)velocity * 2.0) / 10f;
                    Main.dust[index2].noGravity = true;
                    Main.dust[index2].scale = scale;
                    Main.dust[index2].customData = (object)NPC;
                }
                if (this.deadTimer == 100)
                {
                    SoundEngine.PlaySound(mod.GetLegacySoundSlot(Terraria.ModLoader.SoundType.Custom, "Sounds/NPCs/TowerKeeperDeath"), NPC.position);
                }
                if (this.deadTimer >= 300)
                {
                    this.frame = 1;
                    if (this.deadTimer >= 400)
                    {
                        NPC.life = 0;
                        NPC.HitEffect(0, 1337);
                        NPC.checkDead();
                        SoundEngine.PlaySound(4, (int)NPC.position.X, (int)NPC.position.Y, 43);
                        Gore.NewGore(NPC.position, NPC.velocity, mod.GetGoreSlot("Gores/TowerKeeperGore1"), 1f);
                        Gore.NewGore(NPC.position, NPC.velocity, mod.GetGoreSlot("Gores/TowerKeeperGore2"), 1f);
                        Gore.NewGore(NPC.position, NPC.velocity, mod.GetGoreSlot("Gores/TowerKeeperGore2"), 1f);
                        Gore.NewGore(NPC.position, NPC.velocity, mod.GetGoreSlot("Gores/TowerKeeperGore2"), 1f);
                        Gore.NewGore(NPC.position, NPC.velocity, mod.GetGoreSlot("Gores/TowerKeeperGore3"), 1f);
                        Gore.NewGore(NPC.position, NPC.velocity, mod.GetGoreSlot("Gores/TowerKeeperGore3"), 1f);
                        Gore.NewGore(NPC.position, NPC.velocity, mod.GetGoreSlot("Gores/TowerKeeperGore3"), 1f);
                        Gore.NewGore(NPC.position, NPC.velocity, mod.GetGoreSlot("Gores/TowerKeeperGore4"), 1f);
                        Gore.NewGore(NPC.position, NPC.velocity, mod.GetGoreSlot("Gores/TowerKeeperGore4"), 1f);
                        Gore.NewGore(NPC.position, NPC.velocity, mod.GetGoreSlot("Gores/TowerKeeperGore4"), 1f);
                        Gore.NewGore(NPC.position, NPC.velocity, mod.GetGoreSlot("Gores/TowerKeeperGore4"), 1f);
                    }
                }
                if (this.deadTimer >= 0)
                    Main.musicFade[Main.curMusic] = 1f / (float)(this.deadTimer / 15 * 0.5f);
            }
        }

        public override void ModifyHitByProjectile(Projectile projectile, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
        {
            if (Main.expertMode && this.frame == 1)
            {
                projectile.velocity.X = -projectile.velocity.X;
                projectile.velocity.Y = -projectile.velocity.Y;
                projectile.friendly = false;
                projectile.hostile = true;
                projectile.damage /= 3;
            }
        }

        /*public override void PostDraw(SpriteBatch spriteBatch, Color drawColor)
        {
            var GlowMask = mod.GetTexture("Glow/TowerKeeper_GlowMask");
            var Effects = NPC.direction == -1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally;
            spriteBatch.Draw(GlowMask, NPC.Center - Main.screenPosition + new Vector2(0, NPC.gfxOffY), NPC.frame, Color.White, NPC.rotation, NPC.frame.Size() / 2, NPC.scale, Effects, 0);
        }*/

        public override bool CheckDead()
        {
            if (this.deadTimer <= 0)
            {
                this.checkDead = true;
                NPC.dontTakeDamage = true;
                NPC.life = NPC.LifeMax;
                NPC.netUpdate = true;
                return false;
            }
            return base.CheckDead();
        }

        public override void FindFrame(int frameHeight)
        {
            NPC.frameCounter += 1.0;
            if (NPC.frameCounter > 24.0)
            {
                NPC.frame.Y = NPC.frame.Y + frameHeight;
                NPC.frameCounter = 0.0;
            }
            if (NPC.frame.Y > frameHeight * 2 && NPC.life > NPC.LifeMax * 2 / 3)
            {
                NPC.frame.Y = 0;
            }
            else if (NPC.frame.Y > frameHeight * 5 && NPC.life <= NPC.LifeMax * 2 / 3)
            {
                NPC.frame.Y = 3 * frameHeight;
            }
        }
    }
}
