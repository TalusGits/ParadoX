using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ModLoader;

namespace gracosmod123.NPCs.ocean.oceanitems.expertitem
{
    public class aquaexpertitem : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Aquatic Staff");
            Tooltip.SetDefault("Moves you toward your cursor when used");
            Item.staff[item.type] = true; //this makes the useStyle animate as a staff instead of as a gun
        }

        public override void SetDefaults()
        {
            Item.width = 40;
            Item.height = 40;
            Item.maxStack = 1;
            Item.value = 0;
            Item.rare = 10;
            Item.value = 500;
            Item.rare = 9;
            item.expert = true;
            item.useStyle = 5;
            Item.useAnimation = 2;
            Item.useTime = 2;
            Item.autoReuse = true;
        }

        public override bool UseItem(Player player)
        {
            float direction = (Main.MouseWorld - player.Center).ToRotation();
            float distance = (Main.MouseWorld - player.Center).Length();
            player.armorEffectDrawShadow = true;
            player.direction = Main.MouseWorld.X > player.Center.X ? 1 : -1;

            player.velocity = new Vector2((float)Math.Cos(direction), (float)Math.Sin(direction)) * distance / 10;

            //int dust = Dust.NewDust(player.position, player.width, player.height, ModContent.DustType("B4PDust"), 0, 0);
            player.noFallDmg = true;
            return true;
        }
    }
}