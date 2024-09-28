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


namespace gracosmod123.items.enchantedstuff
{
    [AutoloadEquip(EquipType.Body)]
    public class chestorama : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Enchanted Chainmail");
            Tooltip.SetDefault("Set Bonus: Increased knockback, damage, and critical strike chance for harvest weapons. Increased speed and regen.");
        }
        public override void SetDefaults()
        {

            item.Size = new Vector2(18);
            Item.value = Item.sellPrice(silver: 24);
            Item.rare = ItemRarityID.Blue;
            item.defense = 8;
        }
        public override void AddRecipes()
        {
            Recipe recipe = new Recipe(mod);
            recipe.AddIngredient(ItemType<ore.eliasBar>(), 5);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.Register();
        }
    }
}
