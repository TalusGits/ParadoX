using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace gracosmod123.items.enchantedstuff
{
    public class BlazingFeet : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("enchanted");
        }

        public override void Update(Player player, ref int buffIndex)
        {
            //player.AddDust(ModContent.DustType("ret"), 20, true);
            Dust.NewDust(player.position - new Vector2(15f, 0f), player.width, player.height, ModContent.DustType("ret"));// 6, 0, 0, 0, Color.Blue);
        }
    }
}

