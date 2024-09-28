using Terraria;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;
using Terraria.ID;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace gracosmod123.NPCs.ocean.oceanitems.armor
{
    [AutoloadEquip(EquipType.Head)]
    public class Aquatichelmet : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Aquatic Helmet");
        }
        public override void SetDefaults()
        {
            item.Size = new Vector2(18);
            Item.value = Item.sellPrice(silver: 26);
            Item.rare = ItemRarityID.Blue;
            item.defense = 35;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ItemType<aquaticshestplate>() && legs.type == ItemType<aquaticgraeaves>();
        }
        public override void UpdateArmorSet(Player player)
        {
            player.moveSpeed += 30f;
            player.maxMinions += 10;
            player.statManaMax += 50;
            player.manaRegen += 20;
            player.lifeRegen += 20;
            player.statLifeMax = 700;
            player.magicDamageMult += 1.5f;
            //player.Addbuff = ModContent.BuffType.Wet;
            player.noFallDmg = true;
            player.AddBuff(ModContent.BuffType.Wet, 180);
            for (int k = 0; k < 2; k++) Projectile.NewProjectileDirect(player.Center.X, player.Center.Y, 0.0f, 0.0f, ModContent.ProjectileType("LifeRingEffect"), 0, 0.0f, player.whoAmI, (float)k, 0.0f);
            player.wingTimeMax = 180;
            player.meleeSpeed += 20f;

            if (player.name == "Talus" || player.name == "talus" || player.name == "talos" || player.name == "Talos" || player.name == "PandaG")
            {
                player.meleeDamageMult += 100f;
                player.meleeSpeed += 100f;
                player.longInvince = true;    //Acts like the Cross Necklace
                player.waterWalk = true;    //can walk on water
                player.iceSkate = true;    //better control on ice
                player.rangedDamageMult += 100f;
                player.magicDamageMult += 100f;
                player.thrownDamage += 100f;
                player.minionDamage += 100f;
                player.lifeRegen += 100;
                player.moveSpeed += 100f;
                player.manaRegen = +100;
                player.statLifeMax = 1000;
                player.buffImmune[44] = true;
                player.buffImmune[46] = true;
                player.buffImmune[47] = true;
                player.buffImmune[20] = true;
                player.buffImmune[22] = true;
                player.buffImmune[24] = true;
                player.buffImmune[23] = true;
                player.buffImmune[30] = true;
                player.buffImmune[31] = true;
                player.buffImmune[32] = true;
                player.buffImmune[33] = true;
                player.buffImmune[35] = true;
                player.buffImmune[36] = true;
                player.buffImmune[69] = true;
                player.buffImmune[70] = true;
                player.buffImmune[80] = true;
                player.buffImmune[144] = true;
                player.maxMinions += 10;
                for (int k = 0; k < 2; k++) Projectile.NewProjectileDirect(player.Center.X, player.Center.Y, 0.0f, 0.0f, ModContent.ProjectileType("LifeRingEffect"), 0, 0.0f, player.whoAmI, (float)k, 0.0f);
                for (int k = 0; k < 2; k++) Projectile.NewProjectileDirect(player.Center.X, player.Center.Y, 0.0f, 0.0f, ModContent.ProjectileType("LifeRingEffect"), 0, 0.0f, player.whoAmI, (float)k, 0.0f);
                for (int k = 0; k < 2; k++) Projectile.NewProjectileDirect(player.Center.X, player.Center.Y, 0.0f, 0.0f, ModContent.ProjectileType("LifeRingEffect"), 0, 0.0f, player.whoAmI, (float)k, 0.0f);
                for (int k = 0; k < 2; k++) Projectile.NewProjectileDirect(player.Center.X, player.Center.Y, 0.0f, 0.0f, ModContent.ProjectileType("LifeRingEffect"), 0, 0.0f, player.whoAmI, (float)k, 0.0f);
                for (int k = 0; k < 2; k++) Projectile.NewProjectileDirect(player.Center.X, player.Center.Y, 0.0f, 0.0f, ModContent.ProjectileType("LifeRingEffect"), 0, 0.0f, player.whoAmI, (float)k, 0.0f);
                for (int k = 0; k < 2; k++) Projectile.NewProjectileDirect(player.Center.X, player.Center.Y, 0.0f, 0.0f, ModContent.ProjectileType("LifeRingEffect"), 0, 0.0f, player.whoAmI, (float)k, 0.0f);
                for (int k = 0; k < 2; k++) Projectile.NewProjectileDirect(player.Center.X, player.Center.Y, 0.0f, 0.0f, ModContent.ProjectileType("LifeRingEffect"), 0, 0.0f, player.whoAmI, (float)k, 0.0f);
                for (int k = 0; k < 2; k++) Projectile.NewProjectileDirect(player.Center.X, player.Center.Y, 0.0f, 0.0f, ModContent.ProjectileType("LifeRingEffect"), 0, 0.0f, player.whoAmI, (float)k, 0.0f);
                for (int k = 0; k < 2; k++) Projectile.NewProjectileDirect(player.Center.X, player.Center.Y, 0.0f, 0.0f, ModContent.ProjectileType("LifeRingEffect"), 0, 0.0f, player.whoAmI, (float)k, 0.0f);
            }
        }
        public override void AddRecipes()
        {
            Recipe recipe = new Recipe(mod);
            recipe.AddIngredient(ItemType<oreaqua.Aquabar>(), 6);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this, 1);
            recipe.Register();
        }
    }
}
