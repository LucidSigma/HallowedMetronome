using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace HallowedMetronomeMod.Content.Items
{
    public class HellstoneMetronome
        : ModItem
    {
        public override void SetStaticDefaults()
        {
            if (Main.dedServ)
            {
                return;
            }

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 30;
            Item.height = 36;

            Item.rare = ItemRarityID.Orange;

            Item.maxStack = 1;
            Item.value = Item.sellPrice(0, 0, 50, 0);

            Item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            MetronomePlayer metronomePlayer = player.GetModPlayer<MetronomePlayer>();

            if (metronomePlayer is not null)
            {
                metronomePlayer.HasHellstoneMetronomeEquipped = true;
            }
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();

            recipe.AddIngredient(ItemID.DynastyWood, 10);
            recipe.AddIngredient(ItemID.HellstoneBar, 8);
            recipe.AddIngredient(ItemID.Timer1Second, 1);

            recipe.AddTile(TileID.Anvils);

            recipe.Register();
        }
    }
}
