public class EffectFunctional : IItemFunctional
{
    private ItemFunctionalHandler _itemFunctionalHandler;
    private readonly EffectItemConfig _effectConfig;

    public bool IsMouseButtonPressed { get; set; }

    public void Initialize(ItemFunctionalHandler itemFunctionalHandler) =>
        _itemFunctionalHandler = itemFunctionalHandler;

    public void Work()
    {
    }

    public EffectFunctional(InventoryItemConfig config) =>
        _effectConfig = (EffectItemConfig)config;
}
