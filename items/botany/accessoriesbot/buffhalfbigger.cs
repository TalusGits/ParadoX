using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace gracosmod123.items.botany.accessoriesbot
{
    public class buffhalfbigger : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Mega Reload Potion");
            Main.buffNoTimeDisplay[Type] = false;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            reloadplayer.dabuffictime = reloadplayer.dabuffictime*1/4;
        }
    }
}