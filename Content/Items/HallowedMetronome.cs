using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace HallowedMetronomeMod.Content.Items
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
