using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace gracosmod123.NPCs.ant
{
    [AutoloadEquip(EquipType.Head)]
    public class mechbemask : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 16;
            Item.height = 12;
            Item.rare = 9;
            item.vanity = true;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("mechanical Queen bee mask");
            Tooltip.SetDefault("'The antenae broke off.'");
        }

    }
}
