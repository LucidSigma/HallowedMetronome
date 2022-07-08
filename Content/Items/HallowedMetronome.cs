using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace HallowedMetronomeMod.Content.Items
{
    public class HallowedMetronome
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

            Item.rare = ItemRarityID.Pink;

            Item.maxStack = 1;
            Item.value = Item.sellPrice(0, 5, 0, 0);
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();

            recipe.AddIngredient(ItemID.DynastyWood, 10);
            recipe.AddIngredient(ItemID.HallowedBar, 8);
            recipe.AddIngredient(ItemID.SoulofLight, 8);
            recipe.AddIngredient(ItemID.SoulofNight, 8);
            recipe.AddIngredient(ItemID.Timer1Second, 1);

            recipe.AddTile(TileID.MythrilAnvil);

            recipe.Register();
        }
    }
}
