using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace gracosmod123.npcs.paperevent
{
    public class PaperStaff : ModItem
    {
        //public override void HoldItem(Player player) { AntiarisGlowMask2.AddGlowMask(mod.ItemType(GetType().Name), "Antiaris/Glow/" + GetType().Name + "_GlowMask"); }
        //public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI) { AntiarisUtils.DrawItemGlowMaskWorld(spriteBatch, item, mod.GetTexture("Glow/" + GetType().Name + "_GlowMask"), rotation, scale); }

        public override void SetDefaults()
        {
            item.damage = 500;
            item.magic = true;
            item.mana = 14;
            item.width = 36;
            item.height = 36;
            item.useTime = 19;
            item.useAnimation = 19;
            item.useStyle = 5;
            item.noMelee = true;
            item.knockBack = 2.0f;
            item.value = Item.sellPrice(0, 1, 0, 0);
            item.rare = 3;
            item.UseSound = SoundID.Item73;
            item.autoReuse = false;
            item.shoot = mod.ProjectileType("sheetpaperdagger");
            item.shootSpeed = 6.0f;
            item.autoReuse = true;
            Item.staff[item.type] = true;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Wand of Paper");
            Tooltip.SetDefault("Wait a little bit...\n' Wait 5 seconds of while holding the staff and Paper Daggers will begin to fly around!'");
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            for (int i = 0; i < 11; i++)
            {
                //if (Main.rand.Next(5) == 0)
                Projectile.NewProjectile((int)((item.position.X - 500) + Main.rand.Next(1000)), (int)((item.position.Y - 500) + Main.rand.Next(1000)), 0.0f, 0.0f, mod.ProjectileType("sheetpaperdaggerNH"), item.damage / 3, 4.5f);
            }
            return true;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod, "PaperStaffV2", 1);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
