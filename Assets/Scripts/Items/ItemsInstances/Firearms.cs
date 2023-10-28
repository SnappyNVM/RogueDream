using UnityEngine;

public sealed class Firearms : Weapon
{
    [field: SerializeField] public FirearmsConfig FirearmsConfig { get; private set; }

    private void Awake()
    {
        WeaponConfig = FirearmsConfig;
        Config = WeaponConfig;
    }
}
