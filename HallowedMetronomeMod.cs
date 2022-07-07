using System.Collections.Generic;
using Terraria.ModLoader;
using Terraria.ModLoader.Config;

namespace HallowedMetronomeMod
{
    public class HallowedMetronomeMod
        : Mod
    {
        public static List<ItemDefinition> ItemAutoSwingAllowList { get; internal set; }
        public static List<ItemDefinition> ItemAutoSwingDenyList { get; internal set; }

        public HallowedMetronomeMod()
        {
            ContentAutoloadingEnabled = true;
        }
    }
}
