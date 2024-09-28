using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using Terraria.Graphics.Shaders;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;
using Terraria.DataStructures;
using Terraria.GameContent.Generation;
namespace gracosmod123.items.extras.randombox
{

    public class randombox2 : ModProjectile
    {
        private const int pickPower = 100;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Infinity Sided Dice");
        }

        public override void SetDefaults()
        {
            projectile.tileCollide = true;
            projectile.width = 88;
            projectile.height = 92;
            projectile.aiStyle = 16;
            projectile.friendly = true;
            Projectile.Penetrate = -1;
            projectile.timeLeft = 50;

            drawOffsetX = -15;
            drawOriginOffsetY = -15;
        }

        public override void Kill(int timeLeft)
        {
            //Create Bomb Sound

            //Create Bomb Damage
            //ExplosionDamage(5f, projectile.Center, 70, 20, projectile.owner);

            //Create Bomb Explosion
            Explosion();

            //Create Bomb Dust
            //Create Bomb Gore
        }

        public void Explosion()
        {
            Vector2 position = projectile.Center;

            int x = 0;
            int y = 0;

            int width = 88;
            int height = 92;
            for (int n = 0; n < Main.rand.Next(20, 500); n++)
            {
                NPC.NewNPC((int)position.X + Main.rand.Next(1000) - 500, (int)position.Y, Main.rand.Next(1, 500), 0, 0f, 0f, 0f, 0f, 255); //Spawn da bunnies
                Main.NewText("Error404", 0, 200, 255);
                Item.NewItem((int)projectile.position.X, (int)projectile.position.Y, projectile.width, projectile.height, Main.rand.Next(1, 4550));
            }
            Main.NewText("Chaos is done", 0, 200, 255);
        }
    }
}