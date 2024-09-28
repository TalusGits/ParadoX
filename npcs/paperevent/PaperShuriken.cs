using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace gracosmod123.NPCs.paperevent
{
    public class PaperShuriken : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Paper Shuriken");
            Tooltip.SetDefault("Sticks to tiles damaging enemies that touch them");
        }

        public override void SetDefaults()
        {
            Item.DamageType = 35;
            item.melee = true;
            Item.knockBack = 5;
            Item.value = Item.sellPrice(gold: 2);
            Item.rare = 3;
            Item.width = 34;
            Item.height = 34;
            item.useStyle = 1;
            Item.shootSpeed = 14f;
            Item.useTime = 18;
            Item.useAnimation = 18;
            Item.shoot = ModContent.ProjectileType("PaperShurikenP");
            item.noUseGraphic = true;
            Item.noMelee = true;
            Item.autoReuse = true;
            Item.maxStack = 999;
            Item.consumable = true;
        }
    }

    public class PaperShurikenP : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Paper Shuriken");
        }

        public override void SetDefaults()
        {
            projectile.aiStyle = 2;
            aiType = ProjectileID.Shuriken;
            projectile.width = 18;
            projectile.height = 18;
            projectile.friendly = true;
            Projectile.Penetrate = 7;
            projectile.melee = true;
            projectile.timeLeft = 450;
            projectile.tileCollide = true;
        }

        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            Texture2D texture = mod.GetTexture("NPCs/paperevent/PaperShurikenP");
            spriteBatch.Draw(texture, new Vector2(projectile.Center.X - Main.screenPosition.X, projectile.Center.Y - Main.screenPosition.Y + 2),
                        new Rectangle(0, 0, texture.Width, texture.Height), lightColor, projectile.rotation,
                        new Vector2(texture.Width * 0.5f, texture.Height * 0.5f), 1f, SpriteEffects.None, 0f);
            return false;
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            projectile.Kill();
            base.OnHitNPC(target, damage, knockback, crit);
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            projectile.velocity = Vector2.Zero;
            projectile.aiStyle = 0;
            return false;
        }
    }
}