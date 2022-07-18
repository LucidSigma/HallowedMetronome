using Terraria.ModLoader;

namespace HallowedMetronomeMod
{
    public class MetronomePlayer
        : ModPlayer
    {
        public bool HasHellstoneMetronomeEquipped { get; internal set; } = false;

        public override void ResetEffects()
        {
            HasHellstoneMetronomeEquipped = false;
        }
    }
}
