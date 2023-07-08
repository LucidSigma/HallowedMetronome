using System.Collections.Generic;
using Terraria.ModLoader.Config;

namespace HallowedMetronomeMod.Configs
{
    // [Label("$Mods.HallowedMetronomeMod.AllowedItemsConfig.Label")]
    public class AllowedItemsConfig
        : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ClientSide;

        [Header("$Mods.HallowedMetronomeMod.Configs.AllowedItemsConfig.Headers.GeneralOptions")]

        // [Label("$Mods.HallowedMetronomeMod.AllowedItemsConfig.AllowList.Label")]
        // [Tooltip("$Mods.HallowedMetronomeMod.AllowedItemsConfig.AllowList.Tooltip")]
        public List<ItemDefinition> AllowList = new();

        // [Label("$Mods.HallowedMetronomeMod.AllowedItemsConfig.DenyList.Label")]
        // [Tooltip("$Mods.HallowedMetronomeMod.AllowedItemsConfig.DenyList.Tooltip")]
        public List<ItemDefinition> DenyList = new();

        public override void OnChanged()
        {
            HallowedMetronomeMod.ItemAutoSwingAllowList = AllowList;
            HallowedMetronomeMod.ItemAutoSwingDenyList = DenyList;
        }
    }
}
