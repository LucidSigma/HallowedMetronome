using HallowedMetronomeMod.Content.Items.Globals;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace HallowedMetronomeMod.Content.Projectiles.Globals
{
    public class MetronomeAutoProjectileCheck
        : GlobalProjectile
    {
        public override void AI(Projectile projectile)
        {
            Player player = Main.player[projectile.owner];

            if (player is null)
            {
                return;
            }

            if (!MetronomeAutoSwingCheck.HasHallowedMetronomeFavourited(player) && !MetronomeAutoSwingCheck.HasHellstoneMetronomeEquipped(player))
            {
                return;
            }

            if (!MetronomeAutoSwingCheck.CanItemAutoSwing(player.HeldItem, projectile))
            {
                return;
            }

            if ((projectile.aiStyle == ProjAIStyleID.Spear || projectile.aiStyle == ProjAIStyleID.ForwardStab) &&
                projectile.timeLeft > player.itemAnimation)
            {
                projectile.timeLeft = player.itemAnimation;
                projectile.netUpdate = true;
            }
        }
    }
}
