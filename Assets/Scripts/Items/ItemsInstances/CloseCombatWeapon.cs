using UnityEngine;

public class CloseCombatWeapon : Weapon
{
    [field: SerializeField] public CloseCombatWeaponConfig CloseCombatWeaponConfig { get; private set; }

    private void Awake()
    {
        WeaponConfig = CloseCombatWeaponConfig;
        Config = WeaponConfig;
    }
}
