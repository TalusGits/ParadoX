
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace gracosmod123.items.botany
{
	public class ExampleGlobalNPC : GlobalNPC
	{
		public override bool InstancePerEntity => true;
		
		public bool eFlames;

		public override void ResetEffects(NPC npc) {
			eFlames = false;
		}
		public override void UpdateLifeRegen(NPC npc, ref int damage) {
			if (eFlames) {
				if (npc.lifeRegen > 0) {
					npc.lifeRegen = 0;
				}
				npc.lifeRegen -= 16;
				if (damage < 2) {
					damage = 2;
				}
				//npc.velocity.X = npc.velocity.X - 20;
				//npc.velocity.Y = npc.velocity.Y - 20;
			}
			if (eFlames && !(npc.type == NPCID.TargetDummy)) //            if (npc.type == NPCID.Zombie)
			{
				npc.velocity.X = npc.velocity.X*15/16;
				npc.velocity.Y = npc.velocity.Y*15/16;
			}
		}
		public override void DrawEffects(NPC npc, ref Color drawColor) 
		{
			if (eFlames) 
			{
				if (Main.rand.Next(4) < 3) 
				{
					int dust = Dust.NewDust(npc.position - new Vector2(2f, 2f), npc.width + 4, npc.height + 4, ModContent.DustType<EtherealFlame>(), npc.velocity.X * 0.4f, npc.velocity.Y * 0.4f, 100, default(Color), 3.5f);
					Main.dust[dust].noGravity = true;
					Main.dust[dust].velocity *= 1.8f;
					Main.dust[dust].velocity.Y -= 0.5f;
					if (Main.rand.NextBool(4)) 
					{
						Main.dust[dust].noGravity = false;
						Main.dust[dust].scale *= 0.5f;
					}
				}
				Lighting.AddLight(npc.position, 0.1f, 0.2f, 0.7f);
			}
		}
		// Make any NPC with a chat complain to the player if they have the stinky debuff.
		public override void GetChat(NPC npc, ref string chat) {
			if (Main.LocalPlayer.HasBuff(BuffID.Stinky)) {
				switch (Main.rand.Next(3)) {
					case 0:
						chat = "Eugh, you smell of rancid fish!";
						break;
					case 1:
						chat = "What's that horrid smell?!";
						break;
					default:
						chat = "Get away from me, i'm not doing any business with you.";
						break;
				}
			}
		}

		// If the player clicks any chat button and has the stinky debuff, prevent the button from working.
		public override bool PreChatButtonClicked(NPC npc, bool firstButton) {
			return !Main.LocalPlayer.HasBuff(BuffID.Stinky);
		}


        
	}
}
