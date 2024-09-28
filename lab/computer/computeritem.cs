using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace gracosmod123.lab.computer
{
    public class computeritem : ModItem
    {
        public override void SetDefaults()
        {
            item.maxStack = 999;
            //item.consumable = true;
            item.value = Item.sellPrice(0, 0, 15, 0);
            item.width = 38;
            item.height = 42;
            item.rare = 0;
            item.useTurn = true;
            item.autoReuse = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.useStyle = 1;
            item.createTile = mod.TileType("computer");

        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Computer");
            //Tooltip.SetDefault("<right> to open");
        }

        /*public override bool CanRightClick()
        {
            return true;
        }*/

        /*public override void RightClick(Player player)
        {
            Main.NewText("Here's some starter loot.", 125, 200, 255);
            player.QuickSpawnItem(ItemID.CopperCoin, Main.rand.Next(15, 90));
            player.QuickSpawnItem(ItemID.SilverCoin, Main.rand.Next(15, 50));
            player.QuickSpawnItem(ItemID.GoldCoin, Main.rand.Next(1, 2));
            player.QuickSpawnItem(29, 1);
            //player.QuickSpawnItem(mod.ItemType("accessory "), Main.rand.Next(1, 2));
            player.QuickSpawnItem(ItemID.Torch, Main.rand.Next(30, 60));
            player.QuickSpawnItem(ItemID.Rope, Main.rand.Next(200, 270));
            player.QuickSpawnItem(ItemID.GrapplingHook, Main.rand.Next(1, 1));
            player.QuickSpawnItem(109, Main.rand.Next(3, 4));
            if (Main.expertMode)
            {
            player.QuickSpawnItem(29, Main.rand.Next(1, 1));
            Main.NewText("Here's another life crystal because this world's expert.", 125, 200, 255);
            }
            if (Main.netMode == NetmodeID.MultiplayerClient)
            {
                Main.NewText("Everything's doubled so don't forget to share!", 125, 200, 255);
                player.QuickSpawnItem(ItemID.CopperCoin, Main.rand.Next(15, 90));
                player.QuickSpawnItem(ItemID.SilverCoin, Main.rand.Next(15, 50));
                player.QuickSpawnItem(ItemID.GoldCoin, Main.rand.Next(1, 2));
                player.QuickSpawnItem(29, 1);
                //player.QuickSpawnItem(mod.ItemType("accessory "), Main.rand.Next(1, 2));
                player.QuickSpawnItem(ItemID.Torch, Main.rand.Next(30, 60));
                player.QuickSpawnItem(ItemID.Rope, Main.rand.Next(200, 270));
                player.QuickSpawnItem(ItemID.GrapplingHook, Main.rand.Next(1, 1));
                player.QuickSpawnItem(109, Main.rand.Next(3, 4));
                if (Main.expertMode)
                {
                player.QuickSpawnItem(29, Main.rand.Next(1, 1));
                }
            }
        }*/
    }
}
