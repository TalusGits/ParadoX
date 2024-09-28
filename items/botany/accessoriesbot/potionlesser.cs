using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
 
namespace gracosmod123.items.botany.accessoriesbot
{
   public class potionlesser : ModItem
   {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Lesser Reload Potion");
        }       
 
       public override void SetDefaults()
       {
           item.width = 16;
           item.height = 30;
           item.useStyle = ItemUseStyleID.EatingUsing;
           item.useAnimation = 17;
           item.useTime = 17;
           item.useTurn = true;
           item.UseSound = SoundID.Item3;
           item.maxStack = 30;
           item.consumable = true;
           item.rare = 1;
           item.value = 80;
       }
 
       public override bool UseItem(Player player)
       {
           player.AddBuff(mod.BuffType("buffhalfsmall"), 18000);
           return true;
       }
 
       public override void AddRecipes()
       {
           ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod, "Starflower");
            recipe.AddIngredient(ItemID.Daybloom);
            recipe.AddTile(TileID.Bottles);
            recipe.SetResult(this, (30));
            recipe.AddRecipe();
       }
 
   }
}