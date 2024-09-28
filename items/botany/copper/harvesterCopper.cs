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
            item.damage = 2;
            item.width = 32;
            item.height = 32;
            item.useTime = 12;
            item.useAnimation = 22;
            item.useStyle = 1;
            item.knockBack = 0;
            item.value = Item.sellPrice(0, 0, 20, 0);
            item.rare = 10;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("copperwave1");
            item.shootSpeed = 20f;
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
                //item.damage = var1 * 2;
                item.shoot = mod.ProjectileType("copperwave2");
                item.shootSpeed = 30f;//
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

