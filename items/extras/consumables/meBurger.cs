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
            Item.width = 16;
            Item.height = 30;
            item.useStyle = ItemUseStyleID.EatingUsing;
            Item.useAnimation = 17;
            Item.useTime = 17;
            item.useTurn = true;
            Item.UseSound = SoundID.Item2;
            Item.maxStack = 30;
            Item.consumable = true;
            Item.rare = 1;
            Item.value = 80;
        }

        public override bool UseItem(Player player)
        {
            player.AddBuff(ModContent.BuffType.WellFed, 9999999);
            return true;
        }

        public override void AddRecipes()
        {
            Recipe recipe = new Recipe(mod);
            recipe.AddIngredient(195, 1);//flesh block
            recipe.AddTile(301);//flesh cloning vat
            recipe.SetResult(this, (30));
            recipe.Register();
        }

    }
}