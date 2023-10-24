using UnityEngine;
using Zenject;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    private MovementHandler _movementHandler;
    private PlayerConfig _playerConfig;
    private Inventory _inventory;
    private ItemPickuper _itemPickuper;

    [SerializeField] private CapsuleCollider2D _collider;
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private ItemDresser _itemDresser;

    public Rigidbody2D Rigidbody => _rigidbody;
    public MovementHandler MovementHandler => _movementHandler;
    public PlayerConfig PlayerConfig => _playerConfig;
    public Inventory Inventory => _inventory;
    public Collider2D Collider => _collider;
    public ItemPickuper ItemPickuper => _itemPickuper;  
    public ItemDresser ItemDresser => _itemDresser;

    private void OnValidate()
    {
        _collider ??= GetComponent<CapsuleCollider2D>();
        _rigidbody ??= GetComponent<Rigidbody2D>();
        _itemPickuper ??= GetComponent<ItemPickuper>();
        _itemDresser ??= GetComponent<ItemDresser>();
    }

    [Inject]
    private void Construct(PlayerConfig playerConfig, MovementHandler mh, Inventory inventory)
    { 
        _playerConfig = playerConfig;
        _movementHandler = mh;
        _inventory = inventory; 
    }
}
