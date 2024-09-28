using Terraria;
using Terraria.ModLoader;

namespace gracosmod123.NPCs.ocean.oceanitems.summonocean
{
    public class SwordMinionBuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Trident Minion");
            Description.SetDefault("The embodiment of force multiplication");
            Main.buffNoSave[Type] = true;
            Main.buffNoTimeDisplay[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            MinionManager modPlayer = player.GetModPlayer<MinionManager>();
            if (player.ownedProjectileCounts[ModContent.ProjectileType("SwordMinion")] > 0)
            {
                modPlayer.SwordMinion = true;
            }
            if (!modPlayer.SwordMinion)
            {
                player.DelBuff(buffIndex);
                buffIndex--;
            }
            else
            {
                player.buffTime[buffIndex] = 18000;
            }
        }
    }
}