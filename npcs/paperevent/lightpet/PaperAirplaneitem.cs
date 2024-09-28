using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace gracosmod123.npcs.paperevent.lightpet
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
            item.CloneDefaults(ItemID.ZephyrFish);
            item.shoot = mod.ProjectileType("PaperAirplane");
            item.buffType = mod.BuffType("PaperAirplanebuff");
            item.noUseGraphic = true; // this defines if it does not use graphic
        }

        public override void UseStyle(Player player)
        {
            if (player.whoAmI == Main.myPlayer && player.itemTime == 0)
            {
                player.AddBuff(item.buffType, 3600, true);
            }
        }
    }
}
