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
namespace gracosmod123.npcs.Glichfolder//location in the folders
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
            npc.width = 88;//npc width
            npc.height = 92;//npc hight
            npc.damage = 10;// damage
            npc.defense = 21;// defence
            npc.lifeMax = 50000;//max life
            npc.HitSound = SoundID.NPCHit4;//hit sound
            npc.DeathSound = SoundID.NPCDeath14;//death sound
            npc.value = 60f;//drop in money
            npc.knockBackResist = 0f;//will not take knockback
            npc.lavaImmune = true;//will not get killed by lava
            npc.noGravity = true;//has no gravity
            npc.noTileCollide = true;//doesn't collide with tiles
            npc.boss = true;//is a boss
            npc.dontTakeDamage = true;
        }
        private float timer;
        public override void AI()//programming the npc
        {
            ++timer;
            Player player = Main.player[npc.target];
            Vector2 vector;
            npc.position.X = player.Center.X - 20f;
            npc.position.Y = player.Center.Y - 400f;
            if (npc.life == npc.lifeMax)
            {
                npc.velocity.X = player.velocity.X;
                npc.velocity.Y = player.velocity.Y;
            }
            if (timer >= 180f && timer % 20f == 0f)
            {
                
            }
        }
        public override bool CheckDead()//if the npc is dead
        {
            SetDefaults();//set the defaults at the top
            return base.CheckDead();// return
        }
    }
}
