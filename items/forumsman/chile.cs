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
            Item.DamageType = 26;
            item.melee = true;
            Item.width = 36;
            Item.height = 38;
            Item.useTime = 25;
            Item.useAnimation = 25;
            item.useStyle = 1;
            Item.knockBack = 10;
            Item.value = Item.sellPrice(0, 4, 0, 0);
            Item.rare = 4;
            Item.UseSound = SoundID.Item71;
            Item.autoReuse = true;
            item.useTurn = true;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Chile Pepper");
            Tooltip.SetDefault("careful, it's hot");
        }
        public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(ModContent.BuffType.OnFire, 180);
        }
    }
}
