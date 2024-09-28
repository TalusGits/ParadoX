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
            item.ranged = false;
            item.magic = false;
            item.thrown = false;
            item.summon = false;
            item.rare = 0;
            item.UseSound = SoundID.Item1;
            item.shoot = mod.ProjectileType("BorealWoodSpear");
            item.value = Item.sellPrice(0, 0, 0, 21);
            item.noUseGraphic = true;
            item.autoReuse = false;
            item.maxStack = 999;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Derp spear");
            Tooltip.SetDefault("its broken   ERROR14254123 100PLUSLOOP DETECTED");//, its broken
        }
    }
}
