using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.Config;

namespace HallowedMetronomeMod.Content.Items.Globals
{
    public class MetronomeAutoSwingCheck
        : GlobalItem
    {
        public override bool? CanAutoReuseItem(Item item, Player player)
        {
            if (!HasHallowedMetronomeFavourited(player) && !HasHellstoneMetronomeEquipped(player))
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
            if (HallowedMetronomeMod.ItemAutoSwingAllowList.Contains(new ItemDefinition(item.type)))
            {
                return true;
            }

            if (HallowedMetronomeMod.ItemAutoSwingDenyList.Contains(new ItemDefinition(item.type)))
            {
                return false;
            }

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

        public static bool HasHellstoneMetronomeEquipped(in Player player)
        {
            if (player is null)
            {
                return false;
            }

            MetronomePlayer metronomePlayer = player.GetModPlayer<MetronomePlayer>();

            if (metronomePlayer is not null && metronomePlayer.HasHellstoneMetronomeEquipped)
            {
                return true;
            }

            foreach (var accessory in player.armor.Skip(3))
            {
                if (accessory.type == ModContent.ItemType<HallowedMetronome>())
                {
                    return true;
                }
            }

            return false;
        }
    }
}
