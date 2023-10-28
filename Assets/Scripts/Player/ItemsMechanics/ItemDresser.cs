using UnityEngine;

public class ItemDresser : MonoBehaviour
{
    private InventoryItemConfig _currentConfig;
    private GameObject _useableItem;
    private SpriteRenderer _useableItemRenderer;
    [SerializeField] private Player _player;

    public GameObject UseableItem => _useableItem;

    public void OnValidate() =>
        _player = GetComponent<Player>();

    public void Initialize(GameObject bodyPartSpawnPos, GameObject useableItem)
    {
        _useableItem = useableItem;
        _useableItemRenderer = _useableItem.GetComponent<SpriteRenderer>();
        _player.Inventory.InventoryFillingChanged += OnInventoryFillingChanged;
    }

    private void OnDisable() =>
        _player.Inventory.InventoryFillingChanged -= OnInventoryFillingChanged;

    public void OnInventoryFillingChanged(InventoryItemConfig config, int index) =>
        UpdateItem();

    public void UpdateItem()
    {
        _currentConfig = _player.Inventory.Items[_player.Inventory.InventoryPanel.CurrentSelectedCell];
        _useableItemRenderer.enabled = _currentConfig != null;
        if (_currentConfig == null)
        {
            _player.ItemFunctionalHandler.UpdateFunctional(_currentConfig);
            return;
        }
        _useableItemRenderer.sprite = _currentConfig.Sprite;
        _player.ItemFunctionalHandler.UpdateFunctional(_currentConfig);
    }
}
