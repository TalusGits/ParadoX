using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Terraria.Localization;
using gracosmod123;
using System;
using Microsoft.Xna.Framework;
namespace gracosmod123.items.botany.copper
{
    public class harvesterCopper : botanyitem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Copper Harvester"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
            Tooltip.SetDefault("");
        }

        public override void SafeSetDefaults()
        {
            Item.DamageType = 2;
            Item.width = 32;
            Item.height = 32;
            Item.useTime = 12;
            Item.useAnimation = 22;
            item.useStyle = 1;
            Item.knockBack = 0;
            Item.value = Item.sellPrice(0, 0, 20, 0);
            Item.rare = 10;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
            Item.shoot = ModContent.ProjectileType("copperwave1");
            Item.shootSpeed = 20f;
            item.useTurn = true;
            item.melee = true;
        }
        public override bool AltFunctionUse(Player player)
        {
            return true;
        }
        public override bool CanUseItem(Player player)
        {

            if (player.altFunctionUse == 2 && reloadplayer.dabuff == false)
            {
                //Item.DamageType = var1 * 2;
                Item.shoot = ModContent.ProjectileType("copperwave2");
                Item.shootSpeed = 30f;//
            }
            else
            {
                SafeSetDefaults();

                //reloadplayer.buffbool = false;
            }
            return base.CanUseItem(player);
        }
    }
}

