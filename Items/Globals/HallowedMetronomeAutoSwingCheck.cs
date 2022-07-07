using System;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace HallowedMetronomeMod.Items.Globals
{
    public class HallowedMetronomeAutoSwingCheck
        : GlobalItem
    {
        public override bool? CanAutoReuseItem(Item item, Player player)
        {
            if (!HasHallowedMetronomeFavourited(player))
            {
                return null;
            }

            return true;
        }

        private static bool HasHallowedMetronomeFavourited(in Player player)
        {
            if (player is null)
            {
                return false;
            }

            foreach (Item inventoryItem in player.inventory)
            {
                if (inventoryItem is not null && inventoryItem.ModItem is HallowedMetronome && inventoryItem.favorited)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
