
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace gracosmod123.items.extras
{
    public class Alien_blaster : ModItem
    {
        public override void SetDefaults()
        {
            Item.DamageType = 60;
            item.ranged = true;
            Item.width = 60;
            Item.height = 22;
            Item.useAnimation = 12;
            Item.useTime = 5;
            item.useStyle = 5;
            Item.noMelee = true;
            item.reuseDelay = 6;
            Item.knockBack = 2;
            Item.rare = 3;
            Item.UseSound = SoundID.Item31;
            Item.autoReuse = true;
            Item.shoot = 10;
            Item.shootSpeed = 8f;
            Item.value = Item.buyPrice(0, 65, 0, 0);
            item.useAmmo = AmmoID.Bullet;
        }

        public override bool ConsumeAmmo(Player player)
        {
            return !(player.itemAnimation < Item.useAnimation - 2);
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Alien Blaster");
            Tooltip.SetDefault("SQUEEGLE SQUOO");
        }
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-6, 0);
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 25f;
            if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
            {
                position += muzzleOffset;
            }
            if (Main.rand.Next(6) == 0)
            {
                type = (442);
            }
            else if (Main.rand.Next(3) == 0)
            {
                type = (709);
            }
            else
            {
                type = (440);//440
            }

            float numberProjectiles = 3;//3
            float rotation = MathHelper.ToRadians(10);
            position += Vector2.Normalize(new Vector2(speedX, speedY)) * 45f;
            for (int i = 0; i < numberProjectiles; i++)
            {
                Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1))) * .2f;
                Projectile.NewProjectileDirect(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, 88, damage, knockBack, player.whoAmI);
            }
            return true;
        }
    }
}
