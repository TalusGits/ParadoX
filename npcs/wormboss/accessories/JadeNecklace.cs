using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace gracosmod123.npcs.wormboss.accessories
{
    [AutoloadEquip(EquipType.Neck)]
    public class JadeNecklace : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Jade Necklace");

            Tooltip.SetDefault("The eyes are open, the mouth moves, but Mr. Brain has long since departed.\n two more minions you get to walk on water");
        }
        public override void SetDefaults()
        {
            item.width = 22;
            item.height = 22;
            item.rare = 1;
            item.accessory = true;
            item.value = Item.sellPrice(0, 0, 50, 0);
            item.rare = ItemRarityID.Green;

        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod, "GlowingCrystalItem", 20);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.maxMinions += 2;
            player.waterWalk = true;
        }
    }
}
