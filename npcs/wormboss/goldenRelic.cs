using System;//uses the systems
using Microsoft.Xna.Framework;//uses math and other properties
using Terraria;// uses terraria stuff
using Terraria.ID;// uses projectile and item IDs
using Terraria.ModLoader;//uses tmodloader stuff
using Terraria.GameContent.Events;//uses moments like raining or in the jungle
using Terraria.Localization;//uses the localization folders
using System.IO;//what?
using Microsoft.Xna.Framework.Graphics;//framework
using Terraria.Utilities;
namespace gracosmod123.npcs.wormboss
{
    public class goldenRelic : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Golden Relic");
            Tooltip.SetDefault("Summons the jade wyrm in the underground desert\n if you try to use it in any other biome than it will become invincible in the second stage!");
            Item.staff[item.type] = true;
            ItemID.Sets.SortingPriorityBossSpawns[item.type] = 13;
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
            item.rare = ItemRarityID.Green;

        }

        public override bool CanUseItem(Player player)
        {
            if (!NPC.AnyNPCs(mod.NPCType("GrandCactusWormHead")))
            {
                NPC.SpawnOnPlayer(player.whoAmI, mod.NPCType("GrandCactusWormHead"));
                Main.PlaySound(SoundID.Roar, player.position, 0);
                item.stack--;
                return true;
            }
            return false;
        }
    }
}