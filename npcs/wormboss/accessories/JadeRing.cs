using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using System;
using Microsoft.Xna.Framework;
namespace gracosmod123.npcs.wormboss.accessories
{
    [AutoloadEquip(new EquipType[] { EquipType.HandsOn })]
    public class JadeRing : ModItem
    {
        public override void SetDefaults()
        {
            item.width = 28;
            item.height = 28;
            item.value = Item.sellPrice(0, 0, 90, 15);
            item.rare = 1;
            item.accessory = true;
            item.rare = ItemRarityID.Green;

        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Jade Ring");
            Tooltip.SetDefault("Yes indeed, Percy, except that it's not really a nugget but more of a splat.\n gives you the thorns and ammo reservation buff, Poisons your enemies on hit");
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.AddBuff(BuffID.WeaponImbuePoison, 1);
            player.AddBuff(BuffID.Thorns, 1);
            player.AddBuff(BuffID.AmmoReservation, 1);

        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod, "GlowingCrystalItem", 20);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
    }
}/*
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("OP accessory"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
            Tooltip.SetDefault("you are a god");
        }
        public override void SetDefaults()
        {
            item.Size = new Vector2(20);
            item.accessory = true;
            item.value = Item.sellPrice(silver: 12);
            item.rare = ItemRarityID.Blue;
            item.defense = 1000000;

        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.meleeDamageMult += 100000f;
            player.meleeSpeed += 1000f;
            player.longInvince = true;    //Acts like the Cross Necklace
            player.waterWalk = true;    //can walk on water
            player.iceSkate = true;    //better control on ice
            player.rangedDamageMult += 100000f;
            player.magicDamageMult += 100000f;
            player.thrownDamage += 1000000f;
            player.minionDamage += 1000000f;
            player.statManaMax += 100000;
            player.manaRegenBonus += 1000000;
            player.lifeRegen += 1000000;
            player.endurance += 1000000f;
            player.moveSpeed += 9999999999999f;
            player.manaRegen = +100000;
            player.manaCost -= 0.001f;
            player.statLifeMax = 1000000000;
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
            player.maxMinions += 100000;
            //player.Inferno = true;

        }/*
                public override void UpdateEquip(Player player)
        {
            if (player.name == "PandaG")
            {
            player.meleeDamageMult += 100000f;
            player.meleeSpeed += 1000f;
            player.longInvince = true;    //Acts like the Cross Necklace
            player.waterWalk = true;    //can walk on water
            player.iceSkate = true;    //better control on ice
            player.rangedDamageMult += 100000f;
            player.magicDamageMult += 100000f;
            player.thrownDamage += 1000000f;
            player.minionDamage += 1000000f;
            player.statManaMax += 100000;
            player.manaRegenBonus += 1000000;
            player.lifeRegen += 1000000;
            player.endurance += 1000000f;
            player.moveSpeed += 1000000f;
            player.manaRegen = +100000;
            player.manaCost -= 0.001f;
            player.statLifeMax = 100000000;
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
            player.maxMinions += 10000000;
            }
        }
        *//*

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}*/

