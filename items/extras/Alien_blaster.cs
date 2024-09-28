
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
            item.damage = 60;
            item.ranged = true;
            item.width = 60;
            item.height = 22;
            item.useAnimation = 12;
            item.useTime = 5;
            item.useStyle = 5;
            item.noMelee = true;
            item.reuseDelay = 6;
            item.knockBack = 2;
            item.rare = 3;
            item.UseSound = SoundID.Item31;
            item.autoReuse = true;
            item.shoot = 10;
            item.shootSpeed = 8f;
            item.value = Item.buyPrice(0, 65, 0, 0);
            item.useAmmo = AmmoID.Bullet;
        }

        public override bool ConsumeAmmo(Player player)
        {
            return !(player.itemAnimation < item.useAnimation - 2);
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
                Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, 88, damage, knockBack, player.whoAmI);
            }
            return true;
        }
    }
}
