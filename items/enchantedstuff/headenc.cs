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
    [AutoloadEquip(EquipType.Head)]
    public class headenc : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Enchanted Helmet");
            Tooltip.SetDefault("Set Bonus: Increased knockback, damage, and critical strike chance for harvest weapons. Increased speed and regen.");
        }
        public override void SetDefaults()
        {
            item.Size = new Vector2(18);
            item.value = Item.sellPrice(silver: 26);
            item.rare = ItemRarityID.Blue;
            item.defense = 7;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ItemType<chestorama>() && legs.type == ItemType<egreav>();
        }

        public override void UpdateArmorSet(Player player)
        {
            ExampleDamagePlayer modPlayer = ExampleDamagePlayer.ModPlayer(player);
            player.AddBuff(mod.BuffType("BlazingFeet"), 20, true);
            player.moveSpeed += 3f;
			modPlayer.exampleDamageMult *= 1.2f; // add 20% to the multiplicative bonus
			modPlayer.exampleCrit += 15; // add 15% crit
			modPlayer.exampleKnockback += 5; // add 5 knockback        
            player.lifeRegen += 2;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemType<ore.eliasBar>(), 6);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
