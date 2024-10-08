using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace gracosmod123.NPCs.Glichfolder//location in the folders
{
    public class Eggo : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("TEST");
            Tooltip.SetDefault("01110100 01101000 01101001 01110011 00100000 01101001 01110011 00100000 01100101 01101110 01110100 01101001 01110010 01100101 01101100 01111001 00100000 01100001 00100000 01110100 01100101 01110011 01110100 00100000 01101001 01110100 01100101 01101101");
            Item.staff[item.type] = true;
            ItemID.Sets.SortingPriorityBossSpawns[item.type] = 13;
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
            if (!NPC.AnyNPCs(ModContent.NPCType("Glich")))
            {
                NPC.SpawnOnPlayer(player.whoAmI, ModContent.NPCType("Glich"));
                Main.NewText("hello0, pr0101ype 5425635426", 255, 194, 40);
                Main.NewText("Y0u never had 10 g0 away ", 255, 194, 40);
                Main.NewText("N0W I1'S 1IME 10 BR1NG Y0U BACK ", 255, 194, 40);
                SoundEngine.PlaySound(SoundID.Roar, player.position, 0);
                item.stack--;
                return true;
            }
            return false;
        }
    }
}