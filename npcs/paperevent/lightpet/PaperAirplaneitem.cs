using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace gracosmod123.NPCs.paperevent.lightpet
{
    public class PaperAirplaneitem : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName and Tooltip are automatically set from the .lang files, but below is how it is done normally.
            DisplayName.SetDefault("Paper Airplane");
            Tooltip.SetDefault("Summons a Paper Airplane to follow aimlessly behind you");
        }

        public override void SetDefaults()
        {
            Item.DamageTypeType(ItemID.ZephyrFish);
            Item.shoot = ModContent.ProjectileType("PaperAirplane");
            Item.buffType = ModContent.BuffType("PaperAirplanebuff");
            item.noUseGraphic = true; // this defines if it does not use graphic
        }

        public override void UseStyle(Player player)
        {
            if (player.whoAmI == Main.myPlayer && player.itemTime == 0)
            {
                player.AddBuff(Item.buffType, 3600, true);
            }
        }
    }
}
