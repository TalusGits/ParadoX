using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace gracosmod123.npcs.wormboss.items
{
    public class JadeAxe : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Jade Axe");
            Tooltip.SetDefault("This is an insanely strong jade axe.");
        }

        public override void SetDefaults()
        {
            item.damage = 10;
            item.melee = true;
            item.width = 40;
            item.height = 40;
            item.useTime = 10;
            item.useAnimation = 10;
            item.axe = 1000;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.knockBack = 200;
            item.value = 10000;
            item.rare = ItemRarityID.Green;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod, "GlowingCrystalItem", 20);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }

        // public override void MeleeEffects(Player player, Rectangle hitbox)
        // {
        //     if (Main.rand.NextBool(10))
        //     {
        //         int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, ModContent.DustType<Sparkle>());
        //     }
        // }
    }
}