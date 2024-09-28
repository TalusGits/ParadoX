using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System;

namespace gracosmod123.items.forumsman
{
    public class chile : ModItem
    {
        public override void SetDefaults()
        {
            item.damage = 26;
            item.melee = true;
            item.width = 36;
            item.height = 38;
            item.useTime = 25;
            item.useAnimation = 25;
            item.useStyle = 1;
            item.knockBack = 10;
            item.value = Item.sellPrice(0, 4, 0, 0);
            item.rare = 4;
            item.UseSound = SoundID.Item71;
            item.autoReuse = true;
            item.useTurn = true;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Chile Pepper");
            Tooltip.SetDefault("careful, it's hot");
        }
        public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(BuffID.OnFire, 180);
        }
    }
}
