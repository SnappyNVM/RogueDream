using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Inventory", menuName = "Data/Inventory")]
public class Inventory : ScriptableObject
{
    [SerializeField] private InventoryItemConfig _item1;
    [SerializeField] private InventoryItemConfig _item2;
    [SerializeField] private InventoryItemConfig _item3;

    public InventoryItemConfig[] Items => new InventoryItemConfig[] { _item1, _item2, _item3 };
    public InventoryItemConfig Item1 => _item1;
    public InventoryItemConfig Item2 => _item2;
    public InventoryItemConfig Item3  => _item3;
    public InventoryPanel InventoryPanel { get; set; }

    // Transmitted item and inventory index of it
    public event Action<InventoryItemConfig, int> InventoryFillingChanged;


    public void ReplaceItem(InventoryItemConfig inventoryItemConfig, int itemID)
    {
        if (itemID == 0)
            _item1 = inventoryItemConfig;
        else if (itemID == 1)
            _item2 = inventoryItemConfig;
        else if (itemID == 2)
            _item3 = inventoryItemConfig;
        // Probably rarely case when DRY will be not optimized way to code, just don't hit me
        
        InventoryFillingChanged?.Invoke(inventoryItemConfig, itemID);
    }

    public void Initialize(InventoryPanel inventoryPanel)
    {
        _item1 = null;
        _item2 = null;
        _item3 = null;
        InventoryPanel = inventoryPanel;    
    }
}
