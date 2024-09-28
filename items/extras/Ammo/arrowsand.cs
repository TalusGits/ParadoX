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
            item.value = Item.buyPrice(copper: 20);
            item.rare = ItemRarityID.Blue;

            item.consumable = true;
            item.maxStack = 999;

            item.ranged = true;
            item.damage = 14;
            item.knockBack = 3.25f;

            item.shoot = ProjectileType<projectiles.ammo.sandarrow>();
            item.shootSpeed = 5.25f;
            item.ammo = AmmoID.Arrow;
        }
    }
}
