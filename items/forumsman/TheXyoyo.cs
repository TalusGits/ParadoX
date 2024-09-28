using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using static Terraria.ModLoader.ModContent;
using Microsoft.Xna.Framework;

namespace gracosmod123.items.forumsman
{
    public class TheXyoyo : ModItem
    {

        public override void SetStaticDefaults()
        {
            ItemID.Sets.Yoyo[item.type] = true;
            ItemID.Sets.GamepadExtraRange[item.type] = 205;//15
            ItemID.Sets.GamepadSmartQuickReach[item.type] = true;
            DisplayName.SetDefault("The X");
            Tooltip.SetDefault("Super-Speed spin");

        }

        public override void SetDefaults()
        {
            item.Size = new Vector2(24);
            Item.rare = ItemRarityID.Blue;
            Item.value = Item.sellPrice(silver: 25);

            Item.useTime = 25;
            Item.useAnimation = 25;
            item.useStyle = ItemUseStyleID.HoldingOut;
            Item.UseSound = SoundID.Item1;

            item.melee = true;
            item.channel = true;
            Item.noMelee = true;
            item.noUseGraphic = true;

            Item.DamageType = 300;
            Item.knockBack = 3.5f;
            Item.shoot = ProjectileType<items.forumsman.TheXyoyoProj>();
            Item.shootSpeed = 16.5f;
        }
    }
}
