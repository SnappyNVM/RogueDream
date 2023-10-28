public class CloseCombatWeaponFunctional : IItemFunctional
{
    private ItemFunctionalHandler _itemFunctionalHandler;
    private readonly CloseCombatWeaponConfig _closeCombatConfig;
    public bool IsMouseButtonPressed { get; set; }
    public void Initialize(ItemFunctionalHandler itemFunctionalHandler) =>
        _itemFunctionalHandler = itemFunctionalHandler;

    public void Work()
    {

    }

    public CloseCombatWeaponFunctional(InventoryItemConfig config) =>
        _closeCombatConfig = (CloseCombatWeaponConfig)config;
}
