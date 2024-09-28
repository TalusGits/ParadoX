using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace gracosmod123.npcs.ant
{
    public class ANTEGGSUMMON : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("remote control");
            Tooltip.SetDefault("Summons the mechanical queen bee, only use in jungle");
            Item.staff[item.type] = true;
            ItemID.Sets.SortingPriorityBossSpawns[item.type] = 13; // this hel ps sort inventory know this is a boss summoning item.
            //return spawnInfo.player.ZoneJungle && y < Main.worldSurface ? 0.03f : 0f;return Main.dayTime &&;
            //can use only at night ZoneJungle
        }

        public override void SetDefaults()
        {
            item.width = 78;
            item.height = 78;
            item.maxStack = 9999;
            item.rare = 3;
            item.useAnimation = 45;
            item.useTime = 45;
            item.useStyle = 5;
            item.UseSound = SoundID.Item44;
            item.consumable = false;
        }

        public override bool CanUseItem(Player player)
        {
            if (!NPC.AnyNPCs(mod.NPCType("AntlionQueen")))
            {
                NPC.SpawnOnPlayer(player.whoAmI, mod.NPCType("AntlionQueen"));
                Main.PlaySound(SoundID.Roar, player.position, 0);
                item.stack--;
                return true;
            }
            return false;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.AdamantiteBar / ItemID.TitaniumBar, 20);
            recipe.AddIngredient(ItemID.BeeWax, 20);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}