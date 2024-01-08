using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    [Header("Objects")]
    [SerializeField] private Animator _playerAnimator;
    [SerializeField] private PlayerAnimationChanger _playerAnimationChanger;
    [SerializeField] private Player _player;
    [SerializeField] private GameObject _itemsSpawnPos;
    [SerializeField] private InventoryPanel _inventoryPanel;
    [SerializeField] private GameObject _useableItem;
    [SerializeField] private CursorFollower _cursorFollower;
    [SerializeField] private CursorFlipper _cursorFlipper;
    [SerializeField] private ItemFunctionalHandler _itemFunctionalHandler;
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private CloseCombatAnimator _closeCombatAnimator;
    [SerializeField] private HealthBar _healthBar;
    [SerializeField] private Heart _heartPrefab;

    private void Awake()
    {
        _player.Initialize(_healthBar, _heartPrefab);
        _playerAnimationChanger.Initialize(_playerAnimator);
        _player.Inventory.Initialize(_inventoryPanel);
        _inventoryPanel.Initialize();
        _player.ItemDresser.Initialize(_itemsSpawnPos, _useableItem);
        _cursorFollower.Initialize(_player);
        _cursorFlipper.Initialize(_player);
    }
}
