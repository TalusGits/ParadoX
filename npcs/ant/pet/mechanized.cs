using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace gracosmod123.NPCs.ant.pet
{
    public class mechanized : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("mechanical wasp");
            Description.SetDefault("The mechanical wasp will fight for you");
            Main.buffNoSave[Type] = true;
            Main.buffNoTimeDisplay[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            exampleplayer modPlayer = player.GetModPlayer<exampleplayer>();
            if (player.ownedProjectileCounts[ProjectileType<NPCs.ant.pet.mechwasp>()] > 0)
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