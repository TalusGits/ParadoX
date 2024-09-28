using System;//uses the systems
using Microsoft.Xna.Framework;//uses math and other properties
using Terraria;// uses terraria stuff
using Terraria.ID;// uses projectile and item IDs
using Terraria.ModLoader;//uses tmodloader stuff
using Terraria.GameContent.Events;//uses moments like raining or in the jungle
using Terraria.Localization;//uses the localization folders
using System.IO;//what?
using Microsoft.Xna.Framework.Graphics;//framework
using System.Collections.Generic;
using Terraria.Graphics.Shaders;
namespace gracosmod123.NPCs.Glichfolder//location in the folders
{
    [AutoloadBossHead]//AntlionQueen_Head_Boss
    public class Glich : ModNPC
    {
        Vector2 targetPos;// declares the vector targetpos
        public float tVel = 0f;// declares the tvel variable
        public float vMax = 8f;// declares the vMax variable
        public float vAccel = .2f;// declares the vaccel variable
        public float vMag = 0f;// declares the vMag variable
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Glich");// projectile name is aquatic knife
        }
        public override void SetDefaults()
        {
            NPC.width = 88;//NPC width
            NPC.height = 92;//NPC hight
            NPC.damage = 10;// damage
            NPC.defense = 21;// defence
            NPC.LifeMax = 50000;//max life
            NPC.HitSound = SoundID.NPCHit4;//hit sound
            NPC.DeathSound = SoundID.NPCDeath14;//death sound
            NPC.value = 60f;//drop in money
            NPC.knockBackResist = 0f;//will not take knockback
            NPC.lavaImmune = true;//will not get killed by lava
            NPC.noGravity = true;//has no gravity
            NPC.NoTileCollide = true;//doesn't collide with tiles
            NPC.boss = true;//is a boss
            NPC.dontTakeDamage = true;
        }
        private float timer;
        public override void AI()//programming the NPC
        {
            ++timer;
            Player player = Main.player[NPC.target];
            Vector2 vector;
            NPC.position.X = player.Center.X - 20f;
            NPC.position.Y = player.Center.Y - 400f;
            if (NPC.life == NPC.LifeMax)
            {
                NPC.velocity.X = player.velocity.X;
                NPC.velocity.Y = player.velocity.Y;
            }
            if (timer >= 180f && timer % 20f == 0f)
            {
                
            }
        }
        public override bool CheckDead()//if the NPC is dead
        {
            SetDefaults();//set the defaults at the top
            return base.CheckDead();// return
        }
    }
}
