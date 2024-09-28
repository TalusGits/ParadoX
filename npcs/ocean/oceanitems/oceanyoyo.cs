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

namespace gracosmod123.NPCs.ocean.oceanitems
{
    public class oceanyoyo : ModItem
    {

        public override void SetStaticDefaults()
        {
            ItemID.Sets.Yoyo[item.type] = true;
            ItemID.Sets.GamepadExtraRange[item.type] = 205;//15
            ItemID.Sets.GamepadSmartQuickReach[item.type] = true;
            DisplayName.SetDefault("riptide");
            Tooltip.SetDefault("");

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
            Item.shoot = ProjectileType<NPCs.ocean.oceanitems.ript>();
            Item.shootSpeed = 16.5f;
        }
        public override void AddRecipes()
        {
            Recipe recipe = new Recipe(mod);
            recipe.AddIngredient(ItemType<oreaqua.Aquabar>(), 5);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this, 1);
            recipe.Register();
        }
    }
}
