using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using gracosmod123.NPCs.ocean;
namespace gracosmod123.NPCs.ocean.oceanitems.bosssummonbag
{
    public class Piranah : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ocean Servant");
            Main.NPCFrameCount[NPC.type] = 6;
        }

        public override void SetDefaults()
        {
            NPC.width = 28;
            NPC.height = 44;
            //NPC.aiStyle = 67;
            NPC.defense = 20;

            //NPC.HitSound = SoundID.NPCHit1;
            //NPC.DeathSound = SoundID.NPCDeath1;
            //NPC.NPCSlots = 0.5f;
            //NPC.noGravity = true;
            //NPC.catchItem = 2007;

            NPC.CloneDefaults(58);
            //NPC.aiStyle = 0;
            aiType = 58;
            animationType = 58;
            if (Main.expertMode == true)
            {
                NPC.LifeMax = 1000;
                NPC.damage = 128;
            }
            else
            {
                NPC.LifeMax = 1000;
                NPC.damage = 80;
            }
        }
        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {

            if (NPC.downedMoonlord)
            {
                var x = spawnInfo.spawnTileX;
                var y = spawnInfo.spawnTileY;
                var tile = (int)Main.tile[x, y].type;
                return spawnInfo.player.ZoneBeach ? 0.03f : 0f;
            }
            return 0f;
        }
        public override bool CheckDead()
        {
            var player = Main.player[NPC.target];
            switch (Main.rand.Next(4))
            {
                case 0:
                    Main.NewText("You Puny Mortals Try Against POSIDEN And FAIL", 125, 200, 255);
                    break;
                case 1:
                    Main.NewText("HE WILL WIN", 125, 200, 255);
                    break;
                case 2:
                    Main.NewText("Just Surrender To His LordShip", 125, 200, 255);
                    break;
                case 3:
                    if (!NPC.AnyNPCs(ModContent.NPCType("POSIDEN")))
                    {
                        NPC.SpawnOnPlayer(player.whoAmI, ModContent.NPCType("POSIDEN"));
                        SoundEngine.PlaySound(SoundID.Roar, player.position, 0);
                        return true;
                    }
                    return false;
                    break;
                default:
                    Main.NewText("My Master Will Remove you From This Universe...", 125, 200, 255);
                    break;
            }
            return base.CheckDead();// return
        }
    }
}
