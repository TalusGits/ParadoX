using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace gracosmod123.items.extras.Ammo
{
    public class arrowsand : ModItem
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("sandy torch arrow"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
            Tooltip.SetDefault("sheild your eyes!!!");
        }
        public override void SetDefaults()
        {

            item.Size = new Vector2(8);
            Item.value = Item.buyPrice(copper: 20);
            Item.rare = ItemRarityID.Blue;

            Item.consumable = true;
            Item.maxStack = 999;

            item.ranged = true;
            Item.DamageType = 14;
            Item.knockBack = 3.25f;

            Item.shoot = ProjectileType<projectiles.ammo.sandarrow>();
            Item.shootSpeed = 5.25f;
            Item.ammo = AmmoID.Arrow;
        }
    }
}
