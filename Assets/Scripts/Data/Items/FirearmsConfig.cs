using UnityEngine;

[CreateAssetMenu(fileName = "Firearms Config", menuName = "Data/Firearms Config")]
public sealed class FirearmsConfig : WeaponConfig
{
    public override IItemFunctional ItemFunctional => _itemFunctional;
    private IItemFunctional _itemFunctional;

    public override void Initialize() =>
        _itemFunctional = new FirearmsFunctional(this);

    [field: SerializeField] public float ProjectileSpeed;
    [field: SerializeField] public Projectile ProjectileSample;
}
