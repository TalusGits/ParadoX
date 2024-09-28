
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.IO;
using System.Linq;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameInput;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using static Terraria.ModLoader.ModContent;
using gracosmod123.items.botany;
namespace gracosmod123.items.botany
{
    // ModPlayer classes provide a way to attach data to Players and act on that data. exampleplayer has a lot of functionality related to 
    // several effects and items in ExampleMod. See SimpleModPlayer for a very simple example of how ModPlayer classes work.
    public class reloadplayer : ModPlayer
    {
        public static bool dabuff;
        public static int dabuffictime;
        public static int dadebuffictime;
        public override void ResetEffects()
        {
            dabuff = false;
            dabuffictime = 1800/2;
        }
        //player.AddBuff(BuffType<Buffs.Undead>(), 1800, false);
        public override void PreUpdateBuffs()
        {

        }
    }

}

