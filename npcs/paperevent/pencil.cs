using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace gracosmod123.NPCs.paperevent
{
    public class pencil : ModItem
    {
        /*public override void SetDefaults()
        {
            Item.DamageType = 50;
            item.useStyle = 5;
            Item.useAnimation = 28;
            Item.useTime = 32;
            Item.shootSpeed = 2f;
            Item.knockBack = 10f;
            Item.width = 32;
            Item.height = 32;
            Item.scale = 1f;
            item.melee = true;
            Item.rare = 0;
            Item.UseSound = SoundID.Item1;
            Item.shoot = ModContent.ProjectileType("Pencil2");
            Item.value = Item.sellPrice(0, 0, 0, 21);
            item.noUseGraphic = true;
            Item.autoReuse = false;
        }*/
        public override void SetDefaults()
        {
            item.useStyle = 5;
            Item.useAnimation = 14;
            Item.useTime = 14;
            Item.shootSpeed = 5.6f;
            Item.knockBack = 6.2f;
            Item.width = 56;
            Item.height = 56;
            Item.DamageType = 84;
            Item.scale = 1.1f;
            Item.UseSound = SoundID.Item1;
            Item.shoot = ModContent.ProjectileType("pencil2");
            Item.rare = 8;
            Item.value = Item.sellPrice(0, 28, 25, 45);
            Item.noMelee = true;
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
            Projectile.NewProjectileDirect(position.X, position.Y, speedX * 1.6f, speedY * 1.6f, type, damage, knockBack, player.whoAmI, 0.0f, 0.0f);
            return false;
        }
    }
}
