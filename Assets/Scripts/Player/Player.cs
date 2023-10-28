using UnityEngine;
using Zenject;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    private InputHandler _movementHandler;
    private PlayerConfig _playerConfig;
    private Inventory _inventory;
    private ItemPickuper _itemPickuper;
    private CapsuleCollider2D _collider;
    private Rigidbody2D _rigidbody;
    private ItemDresser _itemDresser;
    private ItemDropper _itemDropper;
    private ItemFunctionalHandler _itemFunctionalHandler;

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
