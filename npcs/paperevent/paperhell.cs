using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace gracosmod123.npcs.paperevent
{
    public class paperhell : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Paper Thrower");
            Tooltip.SetDefault("Fires a crazy amount of Bullets\n" +
            "Right click to fire arrows instead of Bullets\n" +
            "Does 20% reduced damage for chlorophyte bullets\n" + 
            "whatever you do with this, dont try it with holy arrows, it looks too AWESOME!!!");
        }
        public override void SetDefaults()
        {
            item.damage = 100;
            item.ranged = true;
            item.width = 56;
            item.height = 48;
            item.useTime = 2;
            item.useAnimation = 16;
            item.reuseDelay = 12;
            item.useStyle = 5;
            item.noMelee = true;
            item.knockBack = 5;
            item.value = 300000;
            item.rare = 9;
            item.UseSound = SoundID.Item11;
            item.autoReuse = true;
            item.shoot = 10;
            item.shootSpeed = 10f;
            item.useAmmo = AmmoID.Bullet;
        }
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(0, 0);
        }
        public override bool ConsumeAmmo(Player player)
        {
            return player.itemAnimation < item.useAnimation / 2;
        }
        public override bool AltFunctionUse(Player player)
        {
            return true;
        }
        public override bool CanUseItem(Player player)
        {
            if (player.altFunctionUse == 2)
            {
                item.UseSound = SoundID.Item102;
                item.shoot = 1;
                item.useAmmo = AmmoID.Arrow;
            }
            else
            {
                item.UseSound = SoundID.Item11;
                item.shoot = 10;
                item.useAmmo = AmmoID.Bullet;
            }
            return base.CanUseItem(player);
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 32;
            if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
            {
                position += muzzleOffset;
            }
            if (type == ProjectileID.ChlorophyteBullet)
            {
                damage = (int)(damage * 0.8f);
            }
            float spread = 180f * 0.0174f;
            float baseSpeed = (float)Math.Sqrt(speedX * speedX + speedY * speedY);
            double startAngle = Math.Atan2(speedX, speedY) - spread / 2;
            double deltaAngle = spread / 16f;
            double offsetAngle;
            
            int dir = player.altFunctionUse == 2 ? player.itemAnimation : 15 - player.itemAnimation;
            Main.PlaySound(2, player.Center, player.altFunctionUse == 2 ? 102 : 11);
            offsetAngle = startAngle + deltaAngle * dir;
            Projectile.NewProjectile(position.X, position.Y, baseSpeed * (float)Math.Sin(offsetAngle), baseSpeed * (float)Math.Cos(offsetAngle), type, damage, knockBack, player.whoAmI);

            dir = player.altFunctionUse == 2 ? (player.itemAnimation - 1) : 15 - (player.itemAnimation - 1);
            offsetAngle = startAngle + deltaAngle * dir;
            Projectile.NewProjectile(position.X, position.Y, baseSpeed * (float)Math.Sin(offsetAngle), baseSpeed * (float)Math.Cos(offsetAngle), type, damage, knockBack, player.whoAmI);
            return false;
        }
    }
}
