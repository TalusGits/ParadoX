/*using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace gracosmod123.NPCs.ant
{
    public class mecharrow : ModItem
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("mech arrow"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
            Tooltip.SetDefault("mech arrow");
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

            Item.shoot = ProjectileType<NPCs.ant.mecharrow2>();
            Item.shootSpeed = 5.25f;
            Item.ammo = AmmoID.Arrow;
        }
    }
}*/
