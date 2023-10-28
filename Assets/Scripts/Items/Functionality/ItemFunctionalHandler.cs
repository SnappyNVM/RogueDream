using UnityEngine;

public class ItemFunctionalHandler : MonoBehaviour
{
    private IItemFunctional _currentItemFunctional;
    public Transform ShootPoint { get; set; }
    public Player Player { get; private set; }

    public void Initialize(Player player, Transform shootPoint)
    {
        ShootPoint = shootPoint;
        Player = player;
    }

    public void UpdateFunctional(InventoryItemConfig inventoryItemConfig)
    {
        if (inventoryItemConfig != null)
            _currentItemFunctional = inventoryItemConfig.ItemFunctional;
        else
            _currentItemFunctional = null;
        _currentItemFunctional?.Initialize(this);
    }

    private void Update() => _currentItemFunctional?.Work();
}
