using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using gracosmod123.items;
namespace gracosmod123.items.extras
{
    public class BorealWoodSpear : ModItem//MysticItem
    {
        public override void SetDefaults()
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
            item.ranged = false;
            item.magic = false;
            item.thrown = false;
            item.summon = false;
            Item.rare = 0;
            Item.UseSound = SoundID.Item1;
            Item.shoot = ModContent.ProjectileType("BorealWoodSpear");
            Item.value = Item.sellPrice(0, 0, 0, 21);
            item.noUseGraphic = true;
            Item.autoReuse = false;
            Item.maxStack = 999;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Derp spear");
            Tooltip.SetDefault("its broken   ERROR14254123 100PLUSLOOP DETECTED");//, its broken
        }
    }
}
