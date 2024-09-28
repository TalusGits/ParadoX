
using Terraria.ID;
using Terraria.ModLoader;
using System;
using Microsoft.Xna.Framework;
using Terraria;
namespace gracosmod123.items.botany.copper
{
    public class copperwave2 : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Harvest"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
        }
        public static reloadplayer ModPlayer(Player player)
        {
            return player.GetModPlayer<reloadplayer>();
        }
        public override void SetDefaults()
        {
            projectile.width = 22;
            projectile.height = 22;
            //projectile.aiStyle = 684;
            projectile.ranged = true;
            //aiType = ProjectileID.SwordBeam;
            projectile.CloneDefaults(ProjectileID.FrostWave);//ProjectileID.FrostWave
            projectile.friendly = true;
            projectile.hostile = false;
            projectile.tileCollide = false;

        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            var modplayer123 = Main.player[Main.myPlayer].GetModPlayer<reloadplayer>();
            target.AddBuff(ModContent.BuffType<items.botany.EtherealFlames>(), 1800 * 12 / 16);
            reloadplayer.dabuff = true;
            if (reloadplayer.dabuff == true)
            {
                modplayer123.player.AddBuff(ModContent.BuffType<ReloadBuff>(), reloadplayer.dabuffictime);
            }

        }
        public override void Kill(int timeLeft)
        {
            //harvesterCopper.var1 = 4;
        }

    }
}
