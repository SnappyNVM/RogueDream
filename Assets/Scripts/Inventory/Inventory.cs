using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Inventory", menuName = "Data/Inventory")]
public class Inventory : ScriptableObject
{
    public InventoryItemConfig[] Items => new InventoryItemConfig[] { Item1, Item2, Item3 };

    public InventoryItemConfig Item1 { get => _item1;
        set
        {
            _item1 = value;
            UpdateItem(value, 0);
        }
    }
    public InventoryItemConfig Item2 { get => _item2;
        set
        {
            _item2 = value;
            UpdateItem(value, 1);
        }
    }
    public InventoryItemConfig Item3 { get => _item3;
        set
        {
            _item3 = value;
            UpdateItem(value, 2);
        }
    }

    // Transmitted item and inventory index of it
    public event Action<InventoryItemConfig, int> InventoryFillingChanged;

    public InventoryPanel InventoryPanel { get; set; }

    public void ChangeItem(InventoryItemConfig inventoryItemConfig, int itemID)
    { 
    
    }

    [SerializeField] private InventoryItemConfig _item1;
    [SerializeField] private InventoryItemConfig _item2;
    [SerializeField] private InventoryItemConfig _item3;

    private void UpdateItem(InventoryItemConfig item, int index) =>
        InventoryFillingChanged?.Invoke(item, index);

    public void Initialize(InventoryPanel inventoryPanel)
    {
        _item1 = null;
        _item2 = null;
        _item3 = null;
        InventoryPanel = inventoryPanel;    
    }
}
