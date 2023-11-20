using UnityEngine;

public class ItemFunctionalHandler : MonoBehaviour
{
    private IItemFunctional _currentItemFunctional;
    public Transform ShootPoint { get; set; }
    public CloseCombatAnimator CloseCombatAnimator { get; private set; }
    public Player Player { get; private set; }
    public IItemFunctional CurrentItemFunctional => _currentItemFunctional;

    public void Initialize(Player player, Transform shootPoint, CloseCombatAnimator closeCombatAnimator)
    {
        ShootPoint = shootPoint;
        Player = player;
        CloseCombatAnimator = closeCombatAnimator;
    }

    public void UpdateFunctional(InventoryItemConfig inventoryItemConfig)
    {
        _currentItemFunctional = inventoryItemConfig != null ? inventoryItemConfig.ItemFunctional  : null; 
        _currentItemFunctional?.Initialize(this);
    }

    private void Update() => _currentItemFunctional?.Work();
}
