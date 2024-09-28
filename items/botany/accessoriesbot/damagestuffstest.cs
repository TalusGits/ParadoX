/*using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace gracosmod123.items.botany.accessoriesbot
{
    //[AutoloadEquip(new EquipType[] { EquipType.HandsOn })]
    public class damagestuffstest : ModItem
    {
        public override void SetDefaults()
        {
            item.width = 28;
            item.height = 28;
            item.value = Item.sellPrice(0, 0, 90, 15);
            item.rare = 1;
            item.accessory = true;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("damage stuffs test");
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
			ExampleDamagePlayer modPlayer = ExampleDamagePlayer.ModPlayer(player);
			modPlayer.exampleDamageAdd += 0.2f; // add 20% to the additive bonus
			modPlayer.exampleDamageMult *= 1.2f; // add 20% to the multiplicative bonus
			modPlayer.exampleCrit += 15; // add 15% crit
			modPlayer.exampleKnockback += 5; // add 5 knockback        
        }
    }
}*/