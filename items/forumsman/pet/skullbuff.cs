using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace gracosmod123.items.forumsman.pet
{
    public class skullbuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Enchanted Skull");
            Description.SetDefault("The Enchanted Skull will fight for you");
            Main.buffNoSave[Type] = true;
            Main.buffNoTimeDisplay[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            exampleplayer modPlayer = player.GetModPlayer<exampleplayer>();
            if (player.ownedProjectileCounts[ProjectileType<items.forumsman.pet.skullproj>()] > 0)
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