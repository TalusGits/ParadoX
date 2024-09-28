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

namespace gracosmod123.npcs.paperevent
{
    public class paperFlail : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("PaperCut");
        }

        public override void SetDefaults()
        {
            item.width = 22;
            item.height = 20;
            item.value = Item.sellPrice(silver: 5);
            item.rare = ItemRarityID.White;
            item.noMelee = true;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.useAnimation = 40;
            item.useTime = 20;
            item.knockBack = 200f;
            item.damage = 35;
            item.noUseGraphic = true;
            item.shoot = ModContent.ProjectileType<paperFlailProj>();
            item.shootSpeed = 30f;//15
            item.UseSound = SoundID.Item1;
            item.melee = true;
            item.crit = 9;
            item.channel = true;
        }
    }
}