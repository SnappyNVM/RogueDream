using UnityEngine;
using Zenject;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour, ICreature, IImpulseable
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
    [SerializeField] private HealthBar _healthBar;
    [SerializeField] private PlayerImpulser _damageImpulser;
    [SerializeField] private DamageCooldownCounter _damageCooldownCounter;


    private PlayerHealth _health;

    public IDamagable Damagable => _health;
    public IHealable Healable => _health;
    public Rigidbody2D Rigidbody => _rigidbody;
    public InputHandler MovementHandler => _movementHandler;
    public PlayerConfig PlayerConfig => _playerConfig;
    public Inventory Inventory => _inventory;
    public Collider2D Collider => _collider;
    public ItemPickuper ItemPickuper => _itemPickuper;  
    public ItemDresser ItemDresser => _itemDresser;
    public ItemDropper ItemDropper => _itemDropper;
    public ItemFunctionalHandler ItemFunctionalHandler => _itemFunctionalHandler;
    public Impulser Impulser => _damageImpulser;
    public DamageCooldownCounter DamageCooldownCounter => _damageCooldownCounter;

    public bool Alive { get; set; }

    private void OnValidate()
    {
        _collider ??= GetComponent<CapsuleCollider2D>();
        _rigidbody ??= GetComponent<Rigidbody2D>();
        _itemPickuper ??= GetComponent<ItemPickuper>();
        _itemDresser ??= GetComponent<ItemDresser>();
        _itemDropper ??= GetComponent<ItemDropper>();
        _itemFunctionalHandler ??= GetComponent<ItemFunctionalHandler>();
        _damageImpulser ??= GetComponent<PlayerImpulser>();
        _damageCooldownCounter ??= GetComponent<DamageCooldownCounter>();
    }

    [Inject]
    private void Construct(PlayerConfig playerConfig, InputHandler mh, Inventory inventory)
    { 
        _playerConfig = playerConfig;
        _movementHandler = mh;
        _inventory = inventory; 
    }

    public void Initialize(HealthBar healthBar, Heart heartPrefab)
    {
        _health = new PlayerHealth(healthBar, _playerConfig.HealthPoints, this);
        healthBar.Initialize(_health, heartPrefab);
        Alive = true;
    }

}
