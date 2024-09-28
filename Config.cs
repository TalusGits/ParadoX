using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.Config;

namespace gracosmod123
{
    //[Label("Antisocial")]
    class ServerConfig : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ServerSide;

        [DefaultValue(-1)]
        [Range(-1, 7)]
        [Label("Accessories")]
        [Tooltip("Customize how many slots are Not social anymore. -1 means all.")]
        public int SocialAccessories { get; set; }

        [DefaultValue(false)]
        [Label("Armor")]
        [Tooltip("If true, social armor will also have effect. Be aware that it is buggy with some armor set bonuses.")]
        public bool SocialArmor { get; set; }

        public override bool AcceptClientChanges(ModConfig pendingConfig, int whoAmI, ref string message)
        {
            Mod HEROsMod = ModLoader.GetMod("HEROsMod");
            if (HEROsMod != null && HEROsMod.Version >= new Version(0, 2, 2))
            {
                if (HEROsMod.Call("HasPermission", whoAmI, gracosmod123.ModifyAntiSocialConfig_Permission) is bool result && result)
                    return true;
                message = $"You lack the \"{gracosmod123.ModifyAntiSocialConfig_Display}\" permission.";
                return false;
            }

            return base.AcceptClientChanges(pendingConfig, whoAmI, ref message);
        }
        [Label("Craftable razor planter boxes")]
        [Tooltip("Provides an alternative way of getting razor planter boxes,\nin case there's no room for the item in the dryad's shop because you have so many mods installed.\nRequires a reload to take effect.")]
        [DefaultValue(false)]
        [ReloadRequired]
        public bool isPlanterBoxCraftingEnabled;

        [Label("Starter House")]
        [Tooltip("A nice starter House, if you turn this off than you will not get the starter bag or crafting stations.")]
        [DefaultValue(false)]
        [ReloadRequired]
        public bool Houser;
        [Label("Starter Bag")]
        [Tooltip("A nice starter Bag that comes with the house.")]
        [DefaultValue(false)]
        [ReloadRequired]
        public bool Bags;
        [Label("Crafting stations")]
        [Tooltip("a work bench, an anvil, and a furnace spawn with the house.")]
        [DefaultValue(false)]
        [ReloadRequired]
        public bool Crafters;
        
    }
}
