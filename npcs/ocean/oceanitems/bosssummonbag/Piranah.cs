using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using gracosmod123.npcs.ocean;
namespace gracosmod123.npcs.ocean.oceanitems.bosssummonbag
{
    public class Piranah : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ocean Servant");
            Main.npcFrameCount[npc.type] = 6;
        }

        public override void SetDefaults()
        {
            npc.width = 28;
            npc.height = 44;
            //npc.aiStyle = 67;
            npc.defense = 20;

            //npc.HitSound = SoundID.NPCHit1;
            //npc.DeathSound = SoundID.NPCDeath1;
            //npc.npcSlots = 0.5f;
            //npc.noGravity = true;
            //npc.catchItem = 2007;

            npc.CloneDefaults(58);
            //npc.aiStyle = 0;
            aiType = 58;
            animationType = 58;
            if (Main.expertMode == true)
            {
                npc.lifeMax = 1000;
                npc.damage = 128;
            }
            else
            {
                npc.lifeMax = 1000;
                npc.damage = 80;
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
            var player = Main.player[npc.target];
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
                    if (!NPC.AnyNPCs(mod.NPCType("POSIDEN")))
                    {
                        NPC.SpawnOnPlayer(player.whoAmI, mod.NPCType("POSIDEN"));
                        Main.PlaySound(SoundID.Roar, player.position, 0);
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
