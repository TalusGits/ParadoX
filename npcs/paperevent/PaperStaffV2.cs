using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace gracosmod123.NPCs.paperevent
{
    public class PaperStaffV2 : ModItem
    {
        //public override void HoldItem(Player player) { AntiarisGlowMask2.AddGlowMask(ModContent.ItemType(GetType().Name), "Antiaris/Glow/" + GetType().Name + "_GlowMask"); }
        //public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI) { AntiarisUtils.DrawItemGlowMaskWorld(spriteBatch, item, mod.GetTexture("Glow/" + GetType().Name + "_GlowMask"), rotation, scale); }

        public override void SetDefaults()
        {
            Item.DamageType = 500;
            item.magic = true;
            Item.mana = 14;
            Item.width = 36;
            Item.height = 36;
            Item.useTime = 19;
            Item.useAnimation = 19;
            item.useStyle = 5;
            Item.noMelee = true;
            Item.knockBack = 2.0f;
            Item.value = Item.sellPrice(0, 1, 0, 0);
            Item.rare = 3;
            Item.UseSound = SoundID.Item73;
            Item.autoReuse = false;
            Item.shoot = ModContent.ProjectileType("Papercursorcentral");
            Item.shootSpeed = 32f;
            Item.staff[item.type] = true;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Wand of Paper V2");
            Tooltip.SetDefault("the second version of the paper wand\n' Creates a cage of inward moving daggers.'");
        }//Papercursorcentral

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            return true;
        }
        public override void AddRecipes()
        {
            Recipe recipe = new Recipe(mod);
            recipe.AddIngredient(mod, "PaperStaff", 1);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.Register();
        }
    }
}
