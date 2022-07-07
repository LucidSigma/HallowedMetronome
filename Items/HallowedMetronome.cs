using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace HallowedMetronomeMod.Items
{
    public class HallowedMetronome
        : ModItem
    {
        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.EncumberingStone);
        }
    }
}
