using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace gracosmod123.items.extras.consumables
{
    public class meBurger : ModItem
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Meburger");
            Tooltip.SetDefault("I love Meburgers, I eat one every day!\n Read 'Project Hail Mary' by Andy Wier, one of the best books ever!\n gives you the 'Well Fed' buff for a day!");
        }

        public override void SetDefaults()
        {
            item.width = 16;
            item.height = 30;
            item.useStyle = ItemUseStyleID.EatingUsing;
            item.useAnimation = 17;
            item.useTime = 17;
            item.useTurn = true;
            item.UseSound = SoundID.Item2;
            item.maxStack = 30;
            item.consumable = true;
            item.rare = 1;
            item.value = 80;
        }

        public override bool UseItem(Player player)
        {
            player.AddBuff(BuffID.WellFed, 9999999);
            return true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(195, 1);//flesh block
            recipe.AddTile(301);//flesh cloning vat
            recipe.SetResult(this, (30));
            recipe.AddRecipe();
        }

    }
}