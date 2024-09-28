using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace gracosmod123.projectiles.summons
{
    public class bambimper : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("bamboo imp");
            Description.SetDefault("The bamboo imp will fight for you");
            Main.buffNoSave[Type] = true;
            Main.buffNoTimeDisplay[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            exampleplayer modPlayer = player.GetModPlayer<exampleplayer>();
            if (player.ownedProjectileCounts[ProjectileType<projectiles.summons.Bambooimp>()] > 0)
            {
                modPlayer.purityMinion = true;
            }
            if (!modPlayer.purityMinion)
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