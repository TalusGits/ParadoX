using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria;
using Microsoft.Xna.Framework;


namespace gracosmod123.items.extras.hellflame_book
{
    public class BookofHellflame : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Book of Hellflame");
        }

        public override void SetDefaults()
        {
            Item.DamageType = 40;
            item.magic = true;
            Item.width = 20;
            Item.height = 20;
            Item.useTime = 10;
            Item.useAnimation = 10;
            item.useStyle = 5;
            Item.knockBack = 1;
            Item.value = 10000;
            Item.rare = 4;
            Item.mana = 10;
            Item.shoot = ModContent.ProjectileType("HellFlameBurst");
            Item.shootSpeed = 5f;
            Item.UseSound = SoundID.Item20;
            Item.noMelee = true;
            Item.autoReuse = true;



        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            int numberProjectiles = 1 + Main.rand.Next(3);
            for (int i = 0; i < numberProjectiles; i++)
            {
                Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(80));

                Projectile.NewProjectileDirect(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
            }
            return false;
        }
        public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(ModContent.BuffType.OnFire, 60);
        }
        public override void AddRecipes()
        {
            Recipe recipe = new Recipe(mod);
            recipe.AddIngredient(ItemID.HellstoneBar, 15);
            recipe.AddIngredient(ItemID.Book, 1);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.Register();
        }
    }
}