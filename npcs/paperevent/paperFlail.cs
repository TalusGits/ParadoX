using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gracosmod123.NPCs.paperevent
{
    public class paperFlail : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("PaperCut");
        }

        public override void SetDefaults()
        {
            Item.width = 22;
            Item.height = 20;
            Item.value = Item.sellPrice(silver: 5);
            Item.rare = ItemRarityID.White;
            Item.noMelee = true;
            item.useStyle = ItemUseStyleID.HoldingOut;
            Item.useAnimation = 40;
            Item.useTime = 20;
            Item.knockBack = 200f;
            Item.DamageType = 35;
            item.noUseGraphic = true;
            Item.shoot = ModContent.ProjectileType<paperFlailProj>();
            Item.shootSpeed = 30f;//15
            Item.UseSound = SoundID.Item1;
            item.melee = true;
            item.crit = 9;
            item.channel = true;
        }
    }
}