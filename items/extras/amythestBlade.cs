using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace gracosmod123.items.extras
{
    public class amythestBlade : ModItem
    {
        public override void SetDefaults()
        {
            Item.DamageType = 67;
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
            //Item.shoot = 15/*ProjectileID.ImpProjectile*/;//295//296//41
            Item.shootSpeed = 60f;
            Item.value = Item.sellPrice(0, 9, 0, 0);
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Amythest blade");
            Tooltip.SetDefault("We're back in modding!");//, its broken
        }
        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            // if (Main.rand.NextBool(3))
            // {
            //Emit dusts when the sword is swung
            Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, ModContent.DustType("Dustdarkpurp"));
            // }
        }
        public override void AddRecipes()
        {
            Recipe recipe = new Recipe(mod);
            recipe.AddIngredient(621, 20);//pearlwood
            recipe.AddIngredient(181, 20);//amythest
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.Register();
        }
    }
}
