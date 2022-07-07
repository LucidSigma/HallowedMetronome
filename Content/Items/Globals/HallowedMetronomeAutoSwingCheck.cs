using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace HallowedMetronomeMod.Content.Items.Globals
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

            Projectile projectile = new();
            projectile.SetDefaults(item.shoot);

            if (!CanItemAutoSwing(item, projectile))
            {
                return null;
            }

            return true;
        }

        public static bool CanItemAutoSwing(in Item item, in Projectile projectile)
        {
            // If item is in whitelist - return true.
            // If item is in blacklist - return null;

            if (item.damage <= 0)
            {
                return false;
            }

            if (item.DamageType == DamageClass.Summon && projectile.aiStyle != ProjAIStyleID.Whip)
            {
                return false;
            }

            if (item.sentry || item.channel)
            {
                return false;
            }

            if (projectile.aiStyle == ProjAIStyleID.MagicMissile)
            {
                return false;
            }

            return true;
        }

        public static bool HasHallowedMetronomeFavourited(in Player player)
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
