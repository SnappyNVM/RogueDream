using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private Animator _playerAnimator;
    [SerializeField] private PlayerAnimationChanger _playerAnimationChanger;
    [SerializeField] private Player _player;
    [SerializeField] private GameObject _itemsSpawnPos;
    [SerializeField] private InventoryPanel _inventoryPanel;
    [SerializeField] private GameObject _useableItem;

    private void Awake()
    {
        _playerAnimationChanger.Initialize(_playerAnimator);
        _player.Inventory.Initialize(_inventoryPanel);
        _inventoryPanel.Initialize();
        _player.ItemDresser.Initialize(_itemsSpawnPos, _useableItem);
    }
}
