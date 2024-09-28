using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
 
namespace gracosmod123.items.botany.accessoriesbot
{
   public class potionmed : ModItem
   {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Greater Reload Potion");
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
           player.AddBuff(mod.BuffType("buffhalf"), 18000);
           return true;
       }
 
   }
}