using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace gracosmod123.npcs.ant
{
    [AutoloadEquip(EquipType.Head)]
    public class mechbemask : ModItem
    {
        public override void SetDefaults()
        {
            item.width = 16;
            item.height = 12;
            item.rare = 9;
            item.vanity = true;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("mechanical Queen bee mask");
            Tooltip.SetDefault("'The antenae broke off.'");
        }

    }
}
