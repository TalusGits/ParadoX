using Terraria;
using Terraria.ModLoader;

namespace gracosmod123.items.botany
{
	// Ethereal Flames is an example of a buff that causes constant loss of life.
	// See ExamplePlayer.UpdateBadLifeRegen and ExampleGlobalNPC.UpdateLifeRegen for more information.
	public class EtherealFlames : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Tetanus");
			Description.SetDefault("Losing life and paralysation");
			Main.debuff[Type] = true;
			Main.pvpBuff[Type] = true;
			Main.buffNoSave[Type] = true;
			longerExpertDebuff = true;
		}

		public override void Update(NPC npc, ref int buffIndex) {
			npc.GetGlobalNPC<ExampleGlobalNPC>().eFlames = true;
		}
	}
}
