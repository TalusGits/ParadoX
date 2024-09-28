using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace gracosmod123.NPCs.wormboss.items
{
    public class JadePickaxe : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Jade pickaxe");
            Tooltip.SetDefault("able to mine hellstone");
        }

        public override void SetDefaults()
        {
            Item.DamageType = 10;
            item.melee = true;
            Item.width = 40;
            Item.height = 40;
            Item.useTime = 10;
            Item.useAnimation = 10;
            item.pick = 70;
            item.useStyle = ItemUseStyleID.SwingThrow;
            Item.knockBack = 200;
            Item.value = 10000;
            Item.rare = ItemRarityID.Green;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
        }

        public override void AddRecipes()
        {
            Recipe recipe = new Recipe(mod);
            recipe.AddIngredient(mod, "GlowingCrystalItem", 20);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this, 1);
            recipe.Register();
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