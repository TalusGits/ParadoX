using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using System;


namespace gracosmod123.npcs.wormboss.items
{
    public class JadeBlade : ModItem
    {
        public override void SetDefaults()
        {
            item.damage = 40;
            item.melee = true;
            item.width = 32;
            item.height = 32;
            item.useTime = 22;
            item.useAnimation = 22;
            item.useStyle = 1;
            item.knockBack = 6;
            item.value = Item.sellPrice(0, 0, 20, 0);
            item.rare = 2;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.useTurn = true;
            item.shootSpeed = 60f;
            item.value = Item.sellPrice(0, 9, 0, 0);
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Jade Blade");
            Tooltip.SetDefault("Gives you swiftness on hitting an enemy\n");//, its broken
        }
        public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
        {
            player.AddBuff(3, 9999);
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod, "GlowingCrystalItem", 20);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
    }
}
