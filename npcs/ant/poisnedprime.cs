using Terraria;
using Terraria.ModLoader;

namespace gracosmod123.npcs.ant
{
    // Ethereal Flames is an example of a buff that causes constant loss of life.
    // See exampleplayer.UpdateBadLifeRegen and ExampleGlobalNPC.UpdateLifeRegen for more information.
    public class poisnedprime : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("poisned prime");
            Description.SetDefault("Losing life");
            Main.debuff[Type] = true;
            Main.pvpBuff[Type] = true;
            Main.buffNoSave[Type] = true;
            longerExpertDebuff = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.GetModPlayer<exampleplayer>().eFlames = true;
        }

        /*public override void Update(NPC npc, ref int buffIndex)
        {
            npc.GetGlobalNPC<ExampleGlobalNPC>().eFlames = true;
        }*/
    }
}