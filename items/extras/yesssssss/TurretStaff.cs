using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace gracosmod123.items.extras.yesssssss
{
    public class TurretStaff : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Turret Staff");
            Tooltip.SetDefault("Summons deadly turret to fight for you");
            DisplayName.AddTranslation(GameCulture.Russian, "Посох турели");
            Tooltip.AddTranslation(GameCulture.Russian, "Призывает смертоносную турель ГЛаДОС");
            DisplayName.AddTranslation(GameCulture.Chinese, "G姐炮塔召唤杖");
            Tooltip.AddTranslation(GameCulture.Chinese, "召唤致命的G姐炮塔为你而战");

        }

        public override void SetDefaults()
        {
            Item.DamageType = 36;
            Item.mana = 100;
            Item.width = 32;
            Item.height = 32;
            Item.useTime = 30;
            Item.useAnimation = 30;
            item.useStyle = 1;
            item.noUseGraphic = true;
            Item.noMelee = true;
            Item.knockBack = 10;
            Item.value = Item.buyPrice(5, 0, 0, 0);
            Item.rare = 10;
            Item.autoReuse = true;
            Item.shoot = ModContent.ProjectileType("Turret");
            item.summon = true;
            item.sentry = true;
            Item.buffType = ModContent.BuffType("Turretbuff");
        }

        public override bool AltFunctionUse(Player player)
        {
            return true;
        }

        public override void UseStyle(Player player)
        {
            if (player.whoAmI == Main.myPlayer && player.itemTime == 0)
            {
                player.AddBuff(Item.buffType, 3600, true);
            }
        }

        public override bool UseItem(Player player)
        {
            if (player.altFunctionUse == 2)
            {
                player.MinionNPCTargetAim();
            }
            return base.UseItem(player);
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Vector2 SPos = Main.screenPosition + new Vector2(Main.mouseX, Main.mouseY);
            position = SPos;
            if (player.ownedProjectileCounts[ModContent.ProjectileType("Turret")] < player.maxTurrets)
            {
                return true;
            }
            return false;
        }
        public override void AddRecipes()
        {
            Recipe recipe = new Recipe(mod);
            recipe.AddIngredient(2860, 20);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.Register();
        }
    }
}
