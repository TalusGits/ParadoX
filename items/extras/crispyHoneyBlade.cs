using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using System;


namespace gracosmod123.items.extras
{
    public class crispyHoneyBlade : ModItem
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
            //item.shoot = 15/*ProjectileID.ImpProjectile*/;//295//296//41
            item.shootSpeed = 60f;
            item.value = Item.sellPrice(0, 9, 0, 0);
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Crispy honey blade");
            Tooltip.SetDefault("the perfect balence between sweet hot\n gives you the honey buff when you light enemies aflame!");//, its broken
        }
        public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(BuffID.OnFire, 60);
            player.AddBuff(BuffID.Honey, 180);
        }
        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            // if (Main.rand.NextBool(3))
            // {
            //Emit dusts when the sword is swung
            Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 153);
            // }
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(174, 20);//Hellstone
            recipe.AddIngredient(mod, "honeyBlade");
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
