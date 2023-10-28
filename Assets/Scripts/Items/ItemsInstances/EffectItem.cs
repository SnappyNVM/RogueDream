using UnityEngine;

public sealed class EffectItem : InventoryItem
{
    [field: SerializeField] public EffectItemConfig EffectItemConfig { get; private set; }

    private void Awake() => Config = EffectItemConfig;
}
