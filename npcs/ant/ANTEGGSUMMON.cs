using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace gracosmod123.NPCs.ant
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
            Item.width = 78;
            Item.height = 78;
            Item.maxStack = 9999;
            Item.rare = 3;
            Item.useAnimation = 45;
            Item.useTime = 45;
            item.useStyle = 5;
            Item.UseSound = SoundID.Item44;
            Item.consumable = false;
        }

        public override bool CanUseItem(Player player)
        {
            if (!NPC.AnyNPCs(ModContent.NPCType("AntlionQueen")))
            {
                NPC.SpawnOnPlayer(player.whoAmI, ModContent.NPCType("AntlionQueen"));
                SoundEngine.PlaySound(SoundID.Roar, player.position, 0);
                item.stack--;
                return true;
            }
            return false;
        }

        public override void AddRecipes()
        {
            Recipe recipe = new Recipe(mod);
            recipe.AddIngredient(ItemID.AdamantiteBar / ItemID.TitaniumBar, 20);
            recipe.AddIngredient(ItemID.BeeWax, 20);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.Register();
        }
    }
}