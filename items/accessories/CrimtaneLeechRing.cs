using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace gracosmod123.items.accessories
{
    [AutoloadEquip(new EquipType[] { EquipType.HandsOn })]
    public class CrimtaneLeechRing : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 28;
            Item.height = 28;
            Item.value = Item.sellPrice(0, 0, 90, 15);
            Item.rare = 1;
            item.accessory = true;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("sandstone ring");
            Tooltip.SetDefault("A sandstone ring forged by the antilon empire before it's collapse. increased melee speed");
        }
        /*public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(ModContent.BuffType.OnFire, 180);
        }*/
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.meleeSpeed += 2f;
            //player.AddBuff(ModContent.BuffType.Inferno, 180);

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
            Item.value = Item.sellPrice(silver: 12);
            Item.rare = ItemRarityID.Blue;
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
            Recipe recipe = new Recipe(mod);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.Register();
        }
    }
}*/

