using UnityEngine;

public class FirearmsFunctional : IItemFunctional
{
    private ItemFunctionalHandler _itemFunctionalHandler;
    private readonly FirearmsConfig _firearmsConfig;
    private float _currentCooldown;
    private Projectile _projectile;
    public bool IsMouseButtonPressed { get; set; }

    public FirearmsFunctional(InventoryItemConfig config) =>
        _firearmsConfig = (FirearmsConfig)config;

    public void Initialize(ItemFunctionalHandler itemFunctionalHandler)
    {
        _itemFunctionalHandler = itemFunctionalHandler;
        _currentCooldown = _firearmsConfig.DamageCooldown;
    }


    public void Work() => Shoot();

    private void Shoot()
    {
        if (_currentCooldown <= 0 && IsMouseButtonPressed)
        {
            _projectile = GameObject.Instantiate(_firearmsConfig.ProjectileSample,
                _itemFunctionalHandler.ShootPoint.position,
                _itemFunctionalHandler.Player.ItemDresser.UseableItem.transform.rotation);
            _projectile.CurrentDamage = _firearmsConfig.DamagePerHit;
            _projectile.Rigidbody.AddForce(_firearmsConfig.ProjectileSpeed * _itemFunctionalHandler.ShootPoint.right, ForceMode2D.Impulse);
            _currentCooldown = _firearmsConfig.DamageCooldown;
        }
        _currentCooldown -= Time.deltaTime;
    }

}
