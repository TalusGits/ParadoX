using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace gracosmod123.items.forumsman
{
    public class liltommy : ModItem
    {
        public override void SetDefaults()
        {
            item.damage = 20;
            item.ranged = true;
            item.width = 60;
            item.height = 22;
            item.useAnimation = 12;
            item.useTime = 5;
            item.useStyle = 5;
            item.noMelee = true;
            item.reuseDelay = 2;
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
            DisplayName.SetDefault("Li'l Tommy gun");
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
			return true;// HOLY ****! this works!;
		}
    }
}
