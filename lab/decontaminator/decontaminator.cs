using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace gracosmod123.lab.decontaminator
{
    public class decontaminator : ModTile
    {


        public override void SetDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            Main.tileBlockLight[Type] = true;
            Main.tileSolid[Type] = true;

            TileObjectData.newTile.CopyFrom(TileObjectData.Style1x1);
            TileObjectData.newTile.AnchorTop = default(AnchorData);
            TileObjectData.newTile.AnchorBottom = default(AnchorData);
            TileObjectData.newTile.AnchorLeft = default(AnchorData);
            TileObjectData.newTile.AnchorRight = default(AnchorData);
            TileObjectData.newTile.Direction = TileObjectDirection.PlaceLeft;
            TileObjectData.newTile.StyleHorizontal = true;

            TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
            TileObjectData.newAlternate.Direction = TileObjectDirection.PlaceRight;
            TileObjectData.addAlternate(1);
            TileObjectData.addTile(Type);

            dustType = ModContent.DustType("labdust");
            soundType = 21;
            soundStyle = 2;
            minPick = 500;
            AddMapEntry(new Color(162, 184, 185));
            mineResist = 1;
            drop = ModContent.ItemType("decontaminatoritem");
        }

        public override bool CanPlace(int i, int j)
        {
            return Main.tile[i + 1, j].active() || Main.tile[i - 1, j].active() || Main.tile[i, j + 1].active() || Main.tile[i, j - 1].active(); ;
        }

        public override bool Slope(int i, int j)
        {
            int num248 = 0;

            switch (Main.tile[i, j].frameX / 18)
            {
                case 0:
                    num248 = 2;
                    break;

                case 1:
                    num248 = 3;
                    break;

                case 2:
                    num248 = 4;
                    break;

                case 3:
                    num248 = 5;
                    break;

                case 4:
                    num248 = 1;
                    break;

                case 5:
                    num248 = 0;
                    break;
            }

            Main.tile[i, j].frameX = (short)(num248 * 18);
            if (Main.netMode == 1)
            {
                NetMessage.SendTileSquare(-1, Player.tileTargetX, Player.tileTargetY, 1, TileChangeType.None);
            }
            return false;
        }

        public override void DrawEffects(int i, int j, SpriteBatch spriteBatch, ref Color drawColor, ref int nextSpecialDrawIndex)
        {
            if (Main.player[Main.myPlayer].dangerSense)
            {
                if (drawColor.R < 255)
                {
                    drawColor.R = 255;
                }
                if (drawColor.G < 50)
                {
                    drawColor.G = 50;
                }
                if (drawColor.B < 50)
                {
                    drawColor.B = 50;
                }
                drawColor.A = Main.mouseTextColor;
                if (!Main.gamePaused && Main.rand.Next(30) == 0)
                {
                    //int num51 = Dust.NewDust(new Vector2((float)(j * 16), (float)(i * 16)), 16, 16, 60, 0f, 0f, 100, default(Microsoft.Xna.Framework.Color), 0.3f);
                    //Main.dust[num51].fadeIn = 1f;
                    //Main.dust[num51].velocity *= 0.1f;
                    //Main.dust[num51].noLight = true;
                    //Main.dust[num51].noGravity = true;
                }
            }
        }

        public override void HitWire(int i, int j)
        {
            if (Wiring.CheckMech(i, j, 60))
            {
                Vector2 velocity = Vector2.Zero;
                if (Main.tile[i, j].frameX < 18)
                {
                    velocity = new Vector2(-.001f, 0);
                }
                else if (Main.tile[i, j].frameX < 36)
                {
                    velocity = new Vector2(.001f, 0);
                }
                else if (Main.tile[i, j].frameX < 72)
                {
                    velocity = new Vector2(0, -.001f);
                }
                else if (Main.tile[i, j].frameX < 108)
                {
                    velocity = new Vector2(0, .001f);
                }
                Projectile.NewProjectileDirect(new Vector2(i, j) * 16 + new Vector2(8, 8) + velocity.SafeNormalize(-Vector2.UnitY) * 16, velocity, ModContent.ProjectileType("decontaminatorproj"), 18, .5f, Main.myPlayer, 0f);
                Projectile.NewProjectileDirect(new Vector2(i, j) * 16 + new Vector2(8, 8) + velocity.SafeNormalize(-Vector2.UnitY) * 16, velocity, ModContent.ProjectileType("decontaminatorproj"), 18, .5f, Main.myPlayer, 20f);
                Projectile.NewProjectileDirect(new Vector2(i, j) * 16 + new Vector2(8, 8) + velocity.SafeNormalize(-Vector2.UnitY) * 16, velocity, ModContent.ProjectileType("decontaminatorproj"), 18, .5f, Main.myPlayer, 0f);
                Projectile.NewProjectileDirect(new Vector2(i, j) * 16 + new Vector2(8, 8) + velocity.SafeNormalize(-Vector2.UnitY) * 16, velocity, ModContent.ProjectileType("decontaminatorproj"), 18, .5f, Main.myPlayer, 20f);
                Projectile.NewProjectileDirect(new Vector2(i, j) * 16 + new Vector2(8, 8) + velocity.SafeNormalize(-Vector2.UnitY) * 16, velocity, ModContent.ProjectileType("decontaminatorproj"), 18, .5f, Main.myPlayer, 0f);
                Projectile.NewProjectileDirect(new Vector2(i, j) * 16 + new Vector2(8, 8) + velocity.SafeNormalize(-Vector2.UnitY) * 16, velocity, ModContent.ProjectileType("decontaminatorproj"), 18, .5f, Main.myPlayer, 20f);
                Projectile.NewProjectileDirect(new Vector2(i, j) * 16 + new Vector2(8, 8) + velocity.SafeNormalize(-Vector2.UnitY) * 16, velocity, ModContent.ProjectileType("decontaminatorproj"), 18, .5f, Main.myPlayer, 0f);
                Projectile.NewProjectileDirect(new Vector2(i, j) * 16 + new Vector2(8, 8) + velocity.SafeNormalize(-Vector2.UnitY) * 16, velocity, ModContent.ProjectileType("decontaminatorproj"), 18, .5f, Main.myPlayer, 20f);
                Projectile.NewProjectileDirect(new Vector2(i, j) * 16 + new Vector2(8, 8) + velocity.SafeNormalize(-Vector2.UnitY) * 16, velocity, ModContent.ProjectileType("decontaminatorproj"), 18, .5f, Main.myPlayer, 0f);
                Projectile.NewProjectileDirect(new Vector2(i, j) * 16 + new Vector2(8, 8) + velocity.SafeNormalize(-Vector2.UnitY) * 16, velocity, ModContent.ProjectileType("decontaminatorproj"), 18, .5f, Main.myPlayer, 20f);
                Projectile.NewProjectileDirect(new Vector2(i, j) * 16 + new Vector2(8, 8) + velocity.SafeNormalize(-Vector2.UnitY) * 16, velocity, ModContent.ProjectileType("decontaminatorproj"), 18, .5f, Main.myPlayer, 0f);
                Projectile.NewProjectileDirect(new Vector2(i, j) * 16 + new Vector2(8, 8) + velocity.SafeNormalize(-Vector2.UnitY) * 16, velocity, ModContent.ProjectileType("decontaminatorproj"), 18, .5f, Main.myPlayer, 20f);
                Projectile.NewProjectileDirect(new Vector2(i, j) * 16 + new Vector2(8, 8) + velocity.SafeNormalize(-Vector2.UnitY) * 16, velocity, ModContent.ProjectileType("decontaminatorproj"), 18, .5f, Main.myPlayer, 0f);
                Projectile.NewProjectileDirect(new Vector2(i, j) * 16 + new Vector2(8, 8) + velocity.SafeNormalize(-Vector2.UnitY) * 16, velocity, ModContent.ProjectileType("decontaminatorproj"), 18, .5f, Main.myPlayer, 20f);
                Projectile.NewProjectileDirect(new Vector2(i, j) * 16 + new Vector2(8, 8) + velocity.SafeNormalize(-Vector2.UnitY) * 16, velocity, ModContent.ProjectileType("decontaminatorproj"), 18, .5f, Main.myPlayer, 0f);
                Projectile.NewProjectileDirect(new Vector2(i, j) * 16 + new Vector2(8, 8) + velocity.SafeNormalize(-Vector2.UnitY) * 16, velocity, ModContent.ProjectileType("decontaminatorproj"), 18, .5f, Main.myPlayer, 20f);
                Projectile.NewProjectileDirect(new Vector2(i, j) * 16 + new Vector2(8, 8) + velocity.SafeNormalize(-Vector2.UnitY) * 16, velocity, ModContent.ProjectileType("decontaminatorproj"), 18, .5f, Main.myPlayer, 0f);
                Projectile.NewProjectileDirect(new Vector2(i, j) * 16 + new Vector2(8, 8) + velocity.SafeNormalize(-Vector2.UnitY) * 16, velocity, ModContent.ProjectileType("decontaminatorproj"), 18, .5f, Main.myPlayer, 20f);
                Projectile.NewProjectileDirect(new Vector2(i, j) * 16 + new Vector2(8, 8) + velocity.SafeNormalize(-Vector2.UnitY) * 16, velocity, ModContent.ProjectileType("decontaminatorproj"), 18, .5f, Main.myPlayer, 0f);
                Projectile.NewProjectileDirect(new Vector2(i, j) * 16 + new Vector2(8, 8) + velocity.SafeNormalize(-Vector2.UnitY) * 16, velocity, ModContent.ProjectileType("decontaminatorproj"), 18, .5f, Main.myPlayer, 20f);
                Projectile.NewProjectileDirect(new Vector2(i, j) * 16 + new Vector2(8, 8) + velocity.SafeNormalize(-Vector2.UnitY) * 16, velocity, ModContent.ProjectileType("decontaminatorproj"), 18, .5f, Main.myPlayer, 0f);
                Projectile.NewProjectileDirect(new Vector2(i, j) * 16 + new Vector2(8, 8) + velocity.SafeNormalize(-Vector2.UnitY) * 16, velocity, ModContent.ProjectileType("decontaminatorproj"), 18, .5f, Main.myPlayer, 20f);
                Projectile.NewProjectileDirect(new Vector2(i, j) * 16 + new Vector2(8, 8) + velocity.SafeNormalize(-Vector2.UnitY) * 16, velocity, ModContent.ProjectileType("decontaminatorproj"), 18, .5f, Main.myPlayer, 0f);
                Projectile.NewProjectileDirect(new Vector2(i, j) * 16 + new Vector2(8, 8) + velocity.SafeNormalize(-Vector2.UnitY) * 16, velocity, ModContent.ProjectileType("decontaminatorproj"), 18, .5f, Main.myPlayer, 20f);
                Projectile.NewProjectileDirect(new Vector2(i, j) * 16 + new Vector2(8, 8) + velocity.SafeNormalize(-Vector2.UnitY) * 16, velocity, ModContent.ProjectileType("decontaminatorproj"), 18, .5f, Main.myPlayer, 0f);
                Projectile.NewProjectileDirect(new Vector2(i, j) * 16 + new Vector2(8, 8) + velocity.SafeNormalize(-Vector2.UnitY) * 16, velocity, ModContent.ProjectileType("decontaminatorproj"), 18, .5f, Main.myPlayer, 20f);
                Projectile.NewProjectileDirect(new Vector2(i, j) * 16 + new Vector2(8, 8) + velocity.SafeNormalize(-Vector2.UnitY) * 16, velocity, ModContent.ProjectileType("decontaminatorproj"), 18, .5f, Main.myPlayer, 0f);
                Projectile.NewProjectileDirect(new Vector2(i, j) * 16 + new Vector2(8, 8) + velocity.SafeNormalize(-Vector2.UnitY) * 16, velocity, ModContent.ProjectileType("decontaminatorproj"), 18, .5f, Main.myPlayer, 20f);
                Projectile.NewProjectileDirect(new Vector2(i, j) * 16 + new Vector2(8, 8) + velocity.SafeNormalize(-Vector2.UnitY) * 16, velocity, ModContent.ProjectileType("decontaminatorproj"), 18, .5f, Main.myPlayer, 0f);
                Projectile.NewProjectileDirect(new Vector2(i, j) * 16 + new Vector2(8, 8) + velocity.SafeNormalize(-Vector2.UnitY) * 16, velocity, ModContent.ProjectileType("decontaminatorproj"), 18, .5f, Main.myPlayer, 20f);
                Projectile.NewProjectileDirect(new Vector2(i, j) * 16 + new Vector2(8, 8) + velocity.SafeNormalize(-Vector2.UnitY) * 16, velocity, ModContent.ProjectileType("decontaminatorproj"), 18, .5f, Main.myPlayer, 0f);
                Projectile.NewProjectileDirect(new Vector2(i, j) * 16 + new Vector2(8, 8) + velocity.SafeNormalize(-Vector2.UnitY) * 16, velocity, ModContent.ProjectileType("decontaminatorproj"), 18, .5f, Main.myPlayer, 20f);
                Projectile.NewProjectileDirect(new Vector2(i, j) * 16 + new Vector2(8, 8) + velocity.SafeNormalize(-Vector2.UnitY) * 16, velocity, ModContent.ProjectileType("decontaminatorproj"), 18, .5f, Main.myPlayer, 0f);
                Projectile.NewProjectileDirect(new Vector2(i, j) * 16 + new Vector2(8, 8) + velocity.SafeNormalize(-Vector2.UnitY) * 16, velocity, ModContent.ProjectileType("decontaminatorproj"), 18, .5f, Main.myPlayer, 20f);
                Projectile.NewProjectileDirect(new Vector2(i, j) * 16 + new Vector2(8, 8) + velocity.SafeNormalize(-Vector2.UnitY) * 16, velocity, ModContent.ProjectileType("decontaminatorproj"), 18, .5f, Main.myPlayer, 0f);
                Projectile.NewProjectileDirect(new Vector2(i, j) * 16 + new Vector2(8, 8) + velocity.SafeNormalize(-Vector2.UnitY) * 16, velocity, ModContent.ProjectileType("decontaminatorproj"), 18, .5f, Main.myPlayer, 20f);
                Projectile.NewProjectileDirect(new Vector2(i, j) * 16 + new Vector2(8, 8) + velocity.SafeNormalize(-Vector2.UnitY) * 16, velocity, ModContent.ProjectileType("decontaminatorproj"), 18, .5f, Main.myPlayer, 0f);
                Projectile.NewProjectileDirect(new Vector2(i, j) * 16 + new Vector2(8, 8) + velocity.SafeNormalize(-Vector2.UnitY) * 16, velocity, ModContent.ProjectileType("decontaminatorproj"), 18, .5f, Main.myPlayer, 20f);
                Projectile.NewProjectileDirect(new Vector2(i, j) * 16 + new Vector2(8, 8) + velocity.SafeNormalize(-Vector2.UnitY) * 16, velocity, ModContent.ProjectileType("decontaminatorproj"), 18, .5f, Main.myPlayer, 0f);
                Projectile.NewProjectileDirect(new Vector2(i, j) * 16 + new Vector2(8, 8) + velocity.SafeNormalize(-Vector2.UnitY) * 16, velocity, ModContent.ProjectileType("decontaminatorproj"), 18, .5f, Main.myPlayer, 20f);
                Projectile.NewProjectileDirect(new Vector2(i, j) * 16 + new Vector2(8, 8) + velocity.SafeNormalize(-Vector2.UnitY) * 16, velocity, ModContent.ProjectileType("decontaminatorproj"), 18, .5f, Main.myPlayer, 0f);
                Projectile.NewProjectileDirect(new Vector2(i, j) * 16 + new Vector2(8, 8) + velocity.SafeNormalize(-Vector2.UnitY) * 16, velocity, ModContent.ProjectileType("decontaminatorproj"), 18, .5f, Main.myPlayer, 20f);
                Projectile.NewProjectileDirect(new Vector2(i, j) * 16 + new Vector2(8, 8) + velocity.SafeNormalize(-Vector2.UnitY) * 16, velocity, ModContent.ProjectileType("decontaminatorproj"), 18, .5f, Main.myPlayer, 0f);
                Projectile.NewProjectileDirect(new Vector2(i, j) * 16 + new Vector2(8, 8) + velocity.SafeNormalize(-Vector2.UnitY) * 16, velocity, ModContent.ProjectileType("decontaminatorproj"), 18, .5f, Main.myPlayer, 20f);
                Projectile.NewProjectileDirect(new Vector2(i, j) * 16 + new Vector2(8, 8) + velocity.SafeNormalize(-Vector2.UnitY) * 16, velocity, ModContent.ProjectileType("decontaminatorproj"), 18, .5f, Main.myPlayer, 0f);
                Projectile.NewProjectileDirect(new Vector2(i, j) * 16 + new Vector2(8, 8) + velocity.SafeNormalize(-Vector2.UnitY) * 16, velocity, ModContent.ProjectileType("decontaminatorproj"), 18, .5f, Main.myPlayer, 20f);
                Projectile.NewProjectileDirect(new Vector2(i, j) * 16 + new Vector2(8, 8) + velocity.SafeNormalize(-Vector2.UnitY) * 16, velocity, ModContent.ProjectileType("decontaminatorproj"), 18, .5f, Main.myPlayer, 0f);
                Projectile.NewProjectileDirect(new Vector2(i, j) * 16 + new Vector2(8, 8) + velocity.SafeNormalize(-Vector2.UnitY) * 16, velocity, ModContent.ProjectileType("decontaminatorproj"), 18, .5f, Main.myPlayer, 20f);
                Projectile.NewProjectileDirect(new Vector2(i, j) * 16 + new Vector2(8, 8) + velocity.SafeNormalize(-Vector2.UnitY) * 16, velocity, ModContent.ProjectileType("decontaminatorproj"), 18, .5f, Main.myPlayer, 0f);
                Projectile.NewProjectileDirect(new Vector2(i, j) * 16 + new Vector2(8, 8) + velocity.SafeNormalize(-Vector2.UnitY) * 16, velocity, ModContent.ProjectileType("decontaminatorproj"), 18, .5f, Main.myPlayer, 20f);

            }
        }
    }
}