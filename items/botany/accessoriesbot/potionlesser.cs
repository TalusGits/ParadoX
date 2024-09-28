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
           Item.width = 16;
           Item.height = 30;
           item.useStyle = ItemUseStyleID.EatingUsing;
           Item.useAnimation = 17;
           Item.useTime = 17;
           item.useTurn = true;
           Item.UseSound = SoundID.Item3;
           Item.maxStack = 30;
           Item.consumable = true;
           Item.rare = 1;
           Item.value = 80;
       }
 
       public override bool UseItem(Player player)
       {
           player.AddBuff(ModContent.BuffType("buffhalfsmall"), 18000);
           return true;
       }
 
       public override void AddRecipes()
       {
           Recipe recipe = new Recipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Starflower>());
            recipe.AddIngredient(ItemID.Daybloom);
            recipe.AddTile(TileID.Bottles);
            recipe.SetResult(this, (30));
            recipe.Register();
       }
 
   }
}