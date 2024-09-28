using Terraria.ModLoader;
using Terraria;
using Terraria.ID;
using static Terraria.ModLoader.ModContent;

namespace gracosmod123.items.botany.accessoriesbot.plant
{
    class StarflowerGlobalTile : GlobalTile
    {
        public override bool CanPlace(int i, int j, int type)
        {
            if (type == TileID.ImmatureHerbs)
            {
                if (Main.tile[i, j].type == TileType<items.botany.accessoriesbot.plant.Starflowertile>())
                {
                    return false;
                }
            }
            return base.CanPlace(i, j, type);
        }
    }
}