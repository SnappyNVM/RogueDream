using UnityEngine;

public class CloseCombatWeaponFunctional : IItemFunctional
{
    private ItemFunctionalHandler _itemFunctionalHandler;
    private readonly CloseCombatWeaponConfig _closeCombatConfig;
    private float _currentCooldown;

    public bool IsMouseButtonPressed { get; set; }

    public void Initialize(ItemFunctionalHandler itemFunctionalHandler)
    {
        _itemFunctionalHandler = itemFunctionalHandler;
        _currentCooldown = _closeCombatConfig.DamageCooldown;
    }

    public void Work() => TryHit();

    private void TryHit()
    {
        if (_currentCooldown <= 0 && IsMouseButtonPressed)
        {
            _itemFunctionalHandler.CloseCombatAnimator.StartHit();
            _currentCooldown = _closeCombatConfig.DamageCooldown;
        }
        else
        {
            _itemFunctionalHandler.CloseCombatAnimator.EndHit();
        }
        _currentCooldown -= Time.deltaTime;
    }

    public void Hit()
    {
        // there have to be damage mechanics
        Debug.Log("Hit");
    }

    public CloseCombatWeaponFunctional(InventoryItemConfig config) =>
        _closeCombatConfig = (CloseCombatWeaponConfig)config;
}
