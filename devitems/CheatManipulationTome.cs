using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;

namespace gracosmod123.devitems
{
    public class CheatManipulationTome : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Tome of Greater Manipulation");
            Tooltip.SetDefault("--Cheat Item--\n" + 
                "Allows you to pick up and move NPCs\n" +
                "Right click while holding the NPC to rapidly damage the NPC\n" +
                "Life regenerates and infinite immunity frames while held");
        }
        public override void SetDefaults()
        {
            Item.width = 28;
            Item.height = 30;
            Item.noMelee = true;
            Item.useTime = 5;
            Item.useAnimation = 5;
            item.reuseDelay = 5;
            Item.autoReuse = true;
            item.channel = true;
            item.useStyle = 4;
            Item.value = 0;
            Item.rare = 10;
            Item.shoot = ModContent.ProjectileType("CheatManipulation");
        }
        public override void ModifyTooltips(List<TooltipLine> list)
        {
            foreach (TooltipLine line2 in list)
            {
                if (line2.mod == "Terraria" && line2.Name == "ItemName")
                {
                    line2.overrideColor = new Color(255, 0, 0);
                }
            }
        }
        public override void HoldItem(Player player)
        {
            player.immune = true;
            player.immuneNoBlink = true;
            player.immuneTime = 20;
            player.noFallDmg = true;
            player.statLife++;
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            position = Main.MouseWorld;
            damage = 25;
            return true;
        }
    }
}

