using UnityEngine;
using Zenject;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    [SerializeField] private InputHandler _movementHandler;
    [SerializeField] private PlayerConfig _playerConfig;
    [SerializeField] private Inventory _inventory;
    [SerializeField] private ItemPickuper _itemPickuper;
    [SerializeField] private CapsuleCollider2D _collider;
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private ItemDresser _itemDresser;
    [SerializeField] private ItemDropper _itemDropper;
    [SerializeField] private ItemFunctionalHandler _itemFunctionalHandler;

    public Rigidbody2D Rigidbody => _rigidbody;
    public InputHandler MovementHandler => _movementHandler;
    public PlayerConfig PlayerConfig => _playerConfig;
    public Inventory Inventory => _inventory;
    public Collider2D Collider => _collider;
    public ItemPickuper ItemPickuper => _itemPickuper;  
    public ItemDresser ItemDresser => _itemDresser;
    public ItemDropper ItemDropper => _itemDropper;
    public ItemFunctionalHandler ItemFunctionalHandler => _itemFunctionalHandler;

    private void OnValidate()
    {
        _collider ??= GetComponent<CapsuleCollider2D>();
        _rigidbody ??= GetComponent<Rigidbody2D>();
        _itemPickuper ??= GetComponent<ItemPickuper>();
        _itemDresser ??= GetComponent<ItemDresser>();
        _itemDropper ??= GetComponent<ItemDropper>();
        _itemFunctionalHandler ??= GetComponent<ItemFunctionalHandler>();
    }

    [Inject]
    private void Construct(PlayerConfig playerConfig, InputHandler mh, Inventory inventory)
    { 
        _playerConfig = playerConfig;
        _movementHandler = mh;
        _inventory = inventory; 
    }
}
