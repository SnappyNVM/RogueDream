using UnityEngine;

public abstract class WeaponConfig : InventoryItemConfig
{
    public override IItemFunctional ItemFunctional { get; protected set; }
    [field: SerializeField] public int DamagePerHit { get; private set; }
    [field: SerializeField] public float DamageCooldown { get; private set; }
}
