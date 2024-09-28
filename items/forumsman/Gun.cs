using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace gracosmod123.items.forumsman       //We need this to basically indicate the folder where it is to be read from, so you the texture will load correctly
{
    public class Gun : ModItem
    {
        public override void SetDefaults()
        {
            Item.DamageType = 20;
            item.ranged = true;
            Item.width = 60;
            Item.height = 22;
            Item.useAnimation = 12;
            Item.useTime = 5;
            item.useStyle = 5;
            Item.noMelee = true;
            item.reuseDelay = 2;
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
            DisplayName.SetDefault("Random Gun");
            Tooltip.SetDefault("What could Happen");
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
            if (Main.rand.Next(1) == 0)
            {
                type = (Main.rand.Next(4000));
            }

            else
            {
                Main.NewText("Da Under Dessert", 125, 200, 255);
            }
            return true;
        }
    }
}
