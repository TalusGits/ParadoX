using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace gracosmod123.npcs.paperevent
{
    public class pencil : ModItem
    {
        /*public override void SetDefaults()
        {
            item.damage = 50;
            item.useStyle = 5;
            item.useAnimation = 28;
            item.useTime = 32;
            item.shootSpeed = 2f;
            item.knockBack = 10f;
            item.width = 32;
            item.height = 32;
            item.scale = 1f;
            item.melee = true;
            item.rare = 0;
            item.UseSound = SoundID.Item1;
            item.shoot = mod.ProjectileType("Pencil2");
            item.value = Item.sellPrice(0, 0, 0, 21);
            item.noUseGraphic = true;
            item.autoReuse = false;
        }*/
        public override void SetDefaults()
        {
            item.useStyle = 5;
            item.useAnimation = 14;
            item.useTime = 14;
            item.shootSpeed = 5.6f;
            item.knockBack = 6.2f;
            item.width = 56;
            item.height = 56;
            item.damage = 84;
            item.scale = 1.1f;
            item.UseSound = SoundID.Item1;
            item.shoot = mod.ProjectileType("pencil2");
            item.rare = 8;
            item.value = Item.sellPrice(0, 28, 25, 45);
            item.noMelee = true;
            item.noUseGraphic = true;
            item.melee = true;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("The Recently Sharpened Pencil");
            Tooltip.SetDefault("Just like in kindergarten\n flecks of torn paper rain down around you, the blood of slain foes\n shoots out the ledgenday pencil tip from a 6 year old's collection which does double the damage and creates clouds of paper.");
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Vector2 vector2 = new Vector2(speedX, speedY).RotatedByRandom((double)MathHelper.ToRadians(10.0f));
            speedX = vector2.X;
            speedY = vector2.Y;
            Projectile.NewProjectile(position.X, position.Y, speedX * 1.6f, speedY * 1.6f, type, damage, knockBack, player.whoAmI, 0.0f, 0.0f);
            return false;
        }
    }
}
