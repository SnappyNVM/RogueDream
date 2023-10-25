using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class InventoryPanel : MonoBehaviour
{
    private Inventory _inventory;
    private InventoryCell[] _cells;
    private readonly Color _default = new Color(29, 96, 0, 255);

    public int CurrentSelectedCell { get; private set; }

    [Inject]
    private void Construct(Inventory inventory) =>
        _inventory = inventory;

    public void Initialize()
    {
        CurrentSelectedCell = 0;
        _cells = GetComponentsInChildren<InventoryCell>();
        DisableAllFrames();
        _cells[0].Frame.enabled = true;
        _inventory.InventoryFillingChanged += OnInventoryFillingChanged;
    }

    private void OnEnable() => _inventory.InventoryFillingChanged += OnInventoryFillingChanged;

    private void OnDisable() => _inventory.InventoryFillingChanged -= OnInventoryFillingChanged;

    private void OnInventoryFillingChanged(InventoryItemConfig config, int index)
    {
        var img = _cells[index].GetComponent<Image>();
        if (config == null)
        {
            img.sprite = null;
            img.color = _default;
        }
        else
        {
            img.sprite = config.Icon;
            img.color = Color.white;
        }
    }

    public void OnCellClick(int cellIndex)
    { 
        CurrentSelectedCell = cellIndex;
        DisableAllFrames();
        _cells[cellIndex].Frame.enabled = true;
    }

    private void DisableAllFrames()
    {
        for (int i = 0; i < _cells.Length; i++)
            _cells[i].Frame.enabled = false;
    }
}
