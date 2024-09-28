using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using System;


namespace gracosmod123.NPCs.wormboss.items
{
    public class JadeBlade : ModItem
    {
        public override void SetDefaults()
        {
            Item.DamageType = 40;
            item.melee = true;
            Item.width = 32;
            Item.height = 32;
            Item.useTime = 22;
            Item.useAnimation = 22;
            item.useStyle = 1;
            Item.knockBack = 6;
            Item.value = Item.sellPrice(0, 0, 20, 0);
            Item.rare = 2;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
            item.useTurn = true;
            Item.shootSpeed = 60f;
            Item.value = Item.sellPrice(0, 9, 0, 0);
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
            Recipe recipe = new Recipe(mod);
            recipe.AddIngredient(mod, "GlowingCrystalItem", 20);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this, 1);
            recipe.Register();
        }
    }
}
