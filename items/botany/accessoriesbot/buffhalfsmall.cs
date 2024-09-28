using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace gracosmod123.items.botany.accessoriesbot
{
    public class buffhalfsmall : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Lesser Reload Potion");
            Main.buffNoTimeDisplay[Type] = false;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            reloadplayer.dabuffictime = (1800/2)*3/4;
        }
    }
}