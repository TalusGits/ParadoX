using Terraria;
using Terraria.ModLoader;
namespace gracosmod123.items.botany
{
    public class ReloadBuff : ModBuff
    {

        public override void SetDefaults()
        {
            DisplayName.SetDefault("Realoding");
            Description.SetDefault("Realoding the harvest blast");
            Main.debuff[Type] = true;
            Main.pvpBuff[Type] = true;
            Main.buffNoSave[Type] = true;
            longerExpertDebuff = true;
            Main.buffNoTimeDisplay[Type] = false;

        }



        public override void Update(Player player, ref int buffIndex)
        {
            reloadplayer.dabuff = true;
        }

    }
}

