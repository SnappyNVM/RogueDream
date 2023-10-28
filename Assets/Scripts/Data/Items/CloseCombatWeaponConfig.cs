using UnityEngine;

[CreateAssetMenu(fileName = "Close Combat Weapon Config", menuName = "Data/Close Combat Weapon Config")]
public sealed class CloseCombatWeaponConfig : WeaponConfig
{
    public override IItemFunctional ItemFunctional => _itemFunctional;
    private IItemFunctional _itemFunctional;

    public override void Initialize() =>
        _itemFunctional = new CloseCombatWeaponFunctional(this);
}
