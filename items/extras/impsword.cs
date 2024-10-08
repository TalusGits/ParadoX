using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace gracosmod123.items.extras
{
    public class impsword : ModItem
    {
        public override void SetDefaults()
        {
            Item.DamageType = 20;
            item.melee = true;
            Item.width = 32;
            Item.height = 32;
            Item.useTime = 22;
            Item.useAnimation = 22;
            //Use useStyle 1 for normal swinging or for throwing
            //use useStyle 2 for an item that drinks such as a potion,
            //use useStyle 3 to make the sword act like a shortsword
            //use useStyle 4 for use like a life crystal,
            //and use useStyle 5 for staffs or guns
            item.useStyle = 1;
            Item.knockBack = 6;
            Item.value = Item.sellPrice(0, 0, 20, 0);
            Item.rare = 2;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
            item.useTurn = true;
            Item.shoot = 15/*ProjectileID.ImpProjectile*/;//295//296//41
            Item.shootSpeed = 60f;
            Item.value = Item.sellPrice(0, 9, 0, 0);
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Imp Sword");
            Tooltip.SetDefault("Shoots out three Imp Shots at once, if the Wall of flesh is defeated, than it shoots out another");//, its broken
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            float numberProjectiles = 3;//3
            float rotation = MathHelper.ToRadians(10);
            position += Vector2.Normalize(new Vector2(speedX, speedY)) * 45f;
            for (int i = 0; i < numberProjectiles; i++)
            {
                Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1))) * .2f;
                if (Main.hardMode)
                {
                    Item.DamageType = 36;
                    Projectile.NewProjectileDirect(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, 295, damage, knockBack, player.whoAmI);
                    Projectile.NewProjectileDirect(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
                }
                Projectile.NewProjectileDirect(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
                Projectile.NewProjectileDirect(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, 41, damage, knockBack, player.whoAmI);

            }
            return false;
        }
    }
}
