using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ID;
namespace gracosmod123.NPCs.paperevent
{
    public class pencil2pro : ModProjectile
    {

        public override void SetDefaults()
        {
            projectile.width = 16;
            projectile.height = 16;
            projectile.scale = 1.0f;
            projectile.aiStyle = 27;
            projectile.friendly = true;
            projectile.melee = true;
            Projectile.Penetrate = 4;
            projectile.light = 0.5f;
            projectile.timeLeft = 80;
            projectile.tileCollide = false;
            aiType = ProjectileID.SwordBeam;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("The mystical tip");
            DisplayName.AddTranslation(GameCulture.Chinese, "泰拉长枪");
            DisplayName.AddTranslation(GameCulture.Russian, "Терра Копье");
        }

        public override void AI()
        {
            ++projectile.ai[1];
            if ((double)projectile.ai[1] % 10.0 == 0.0) Projectile.NewProjectileDirect(projectile.position, Vector2.Zero, ModContent.ProjectileType("pencilcloudofdust"), projectile.damage, (int)(projectile.knockBack * 0.7f), projectile.owner);
        }

        public override void Kill(int timeLeft)
        {
            SoundEngine.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 34);
            for (int k = 0; k < 16; k++)
            {
                int dust = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, ModContent.DustType("White"));
                Main.dust[dust].noGravity = true;
            }
        }
    }
}
