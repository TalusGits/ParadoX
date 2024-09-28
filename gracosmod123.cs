
using System.Linq;
using Terraria.DataStructures;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent.UI;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.UI;
namespace gracosmod123
{
    public class gracosmod123 : Mod
    {
        internal Item hoveredItem;

        internal const string ModifyAntiSocialConfig_Permission = "ModifyAntisocialConfig";
        internal const string ModifyAntiSocialConfig_Display = "Modify Antisocial Config";

        public override void Load()
        {
            On.Terraria.UI.ItemSlot.MouseHover_ItemArray_int_int += ItemSlot_MouseHover_ItemArray_int_int;
        }
        private void ItemSlot_MouseHover_ItemArray_int_int(On.Terraria.UI.ItemSlot.orig_MouseHover_ItemArray_int_int orig, Item[] inv, int context, int slot)
        {
            orig(inv, context, slot);
            // EquipArmorVanity = 9;
            // EquipAccessoryVanity = 11;
            hoveredItem = null;
            if (context == 11)
            {
                int socialAccessories = ModContent.GetInstance<ServerConfig>().SocialAccessories;
                if (slot < (socialAccessories == -1 ? 18 + Main.LocalPlayer.extraAccessorySlots : 13 + socialAccessories))
                {
                    hoveredItem = Main.HoverItem;
                    Main.HoverItem.social = false;
                }
            }
            if (context == 9 && ModContent.GetInstance<ServerConfig>().SocialArmor)
            {
                hoveredItem = Main.HoverItem;
                Main.HoverItem.social = false;
            }
        }
        ///SYSTEMSERVERNOTE
        ///SYSTEMSERVERNOTE
        ///SYSTEMSERVERNOTE
        ///SYSTEMSERVERNOTE
        ///SYSTEMSERVERNOTE
        ///SYSTEMSERVERNOTE
        ///SYSTEMSERVERNOTE
        ///SYSTEMSERVERNOTE
        ///SYSTEMSERVERNOTE
        ///SYSTEMSERVERNOTE
        ///SYSTEMSERVERNOTE
        ///SYSTEMSERVERNOTE
        ///SYSTEMSERVERNOTE

        public override void ModifyInterfaceLayers(List<GameInterfaceLayer> layers)
        {
            Mod mod = ModLoader.GetMod("gracosmod123");
            var aPlayer = Main.player[Main.myPlayer].GetModPlayer<exampleplayer>();
            int MouseTextIndex = layers.FindIndex(layer => layer.Name.Equals("Vanilla: Inventory"));
            if (aPlayer.OpenWindow)
            {
                var index = layers.FindIndex(layer => layer.Name.Equals("Vanilla: Inventory"));
                var UIState = new LegacyGameInterfaceLayer("gracosmod123: UI",
                    delegate
                    {
                        DrawButton(Main.spriteBatch);
                        return true;
                    },
                    InterfaceScaleType.UI);
                layers.Insert(index, UIState);
            }
        }
        public void DrawButton(SpriteBatch spriteBatch)
        {
            var mod = ModLoader.GetMod("gracosmod123");
            var background = mod.GetTexture("NoteBackground");
            string note = Language.GetTextValue("NAME: frank, LogDate: 2/6/4356\n government use RESET bomb to set over world only 200 left, world changed\n people can respawn, we have chemist, engieneer, person whose brain was fried by bomb or something else, many more.\n fried person named jack, ");
            spriteBatch.Draw(background, new Rectangle(Main.screenWidth / 2, 500, background.Width, background.Height), null, Color.White, 0f, new Vector2(background.Width / 2, background.Height / 2), SpriteEffects.None, 0f);
            Utils.DrawBorderStringFourWay(spriteBatch, Main.fontMouseText, note, Main.screenWidth / 2 - 200, 300, new Color((int)Main.mouseTextColor, (int)Main.mouseTextColor, (int)Main.mouseTextColor, (int)Main.mouseTextColor), Color.Black, new Vector2());
        }
        ///SYSTEMSERVERNOTE
        ///SYSTEMSERVERNOTE
        ///SYSTEMSERVERNOTE
        ///SYSTEMSERVERNOTE
        ///SYSTEMSERVERNOTE
        ///SYSTEMSERVERNOTE
        ///SYSTEMSERVERNOTE
        ///SYSTEMSERVERNOTE
        ///SYSTEMSERVERNOTE
        ///SYSTEMSERVERNOTE
        ///SYSTEMSERVERNOTE
        ///SYSTEMSERVERNOTE
        ///SYSTEMSERVERNOTE
        ///SYSTEMSERVERNOTE
        ///SYSTEMSERVERNOTE
        ///SYSTEMSERVERNOTE
        ///SYSTEMSERVERNOTE
        public override void PostSetupContent()
        {
            Mod HEROsMod = ModLoader.GetMod("HEROsMod");
            if (HEROsMod != null)
            {
                HEROsMod.Call(
                    "AddPermission",
                    ModifyAntiSocialConfig_Permission,
                    ModifyAntiSocialConfig_Display
                );
            }
        }
    }

    public class AntisocialPlayer : ModPlayer
    {
        public override void OnEnterWorld(Player player)
        {
            Main.NewText("Thank you for playing the ParadoX mod", 255, 194, 40);
            Main.NewText("If you want to give me ideas, contact @Talus on the terraria forums!", 255, 194, 40);
        }
        public override void UpdateEquips(ref bool wallSpeedBuff, ref bool tileSpeedBuff, ref bool tileRangeBuff)
        {
            int start = ModContent.GetInstance<ServerConfig>().SocialArmor ? 10 : 13;
            int socialAccessories = ModContent.GetInstance<ServerConfig>().SocialAccessories;
            int end = socialAccessories == -1 ? 18 + player.extraAccessorySlots : 13 + socialAccessories;
            end = Utils.Clamp(end, 13, 18 + player.extraAccessorySlots);

            bool olddd2Accessory = player.dd2Accessory;
            for (int k = start; k < end; k++)
            {
                player.VanillaUpdateEquip(player.armor[k]);
            }
            for (int l = start; l < end; l++)
            {
                player.VanillaUpdateAccessory(player.whoAmI, player.armor[l], false /*player.hideVisual[l]*/, ref wallSpeedBuff, ref tileSpeedBuff, ref tileRangeBuff);
            }

            //PlayerHooks.UpdateEquips is after this in vanilla, so we need to fix manually
            if (!olddd2Accessory && player.dd2Accessory)
            {
                player.minionDamage += 0.1f;
                player.maxTurrets++;
            }
        }

        // some problems, such as Chlorophyte rapid fire.
        public override void PostUpdateEquips()
        {
            if (ModContent.GetInstance<ServerConfig>().SocialArmor)
            {
                Utils.Swap<Item>(ref player.armor[0], ref player.armor[10]);
                Utils.Swap<Item>(ref player.armor[1], ref player.armor[11]);
                Utils.Swap<Item>(ref player.armor[2], ref player.armor[12]);
                player.head = player.armor[0].headSlot;
                player.body = player.armor[1].bodySlot;
                player.legs = player.armor[2].legSlot;
                player.UpdateArmorSets(player.whoAmI);
                Utils.Swap<Item>(ref player.armor[0], ref player.armor[10]);
                Utils.Swap<Item>(ref player.armor[1], ref player.armor[11]);
                Utils.Swap<Item>(ref player.armor[2], ref player.armor[12]);
                player.head = player.armor[0].headSlot;
                player.body = player.armor[1].bodySlot;
                player.legs = player.armor[2].legSlot;
            }
        }
    }

    public class AntisocialGlobalItem : GlobalItem
    {
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            // leaving social this late means .defense tooltips not added.
            //bool addTooltip = false;
            //if (item.social && item.accessory) {
            //	addTooltip = true;
            //}
            //if (item.social && (item.headSlot > 0 || item.bodySlot > 0 || item.legSlot > 0) && ModContent.GetInstance<ServerConfig>().SocialArmor) {
            //	addTooltip = true;
            //}
            if (item == ModContent.GetInstance<gracosmod123>().hoveredItem)
            {
                //tooltips.RemoveAll(x => x.Name == "Social" || x.Name == "SocialDesc");
                tooltips.Add(new TooltipLine(mod, "SocialCheat", "Antisocial: Stats WILL be gained"));
            }//using Terraria.ID;
            if (item.type == 798)//deathbringer
            {
                tooltips.Add(new TooltipLine(mod, "", "Now able to mine Enchanted Ore"));
            }
            if (item.type == 103)//nightmare
            {
                tooltips.Add(new TooltipLine(mod, "", "Now able to mine Enchanted Ore"));
            }
        }
    }

}

