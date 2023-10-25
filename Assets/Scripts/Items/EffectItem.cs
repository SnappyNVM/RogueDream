using UnityEngine;

public class EffectItem : InventoryItem
{
    [field: SerializeField] public EffectItemConfig EffectItemConfig { get; private set; }

    private void Awake() => Config = EffectItemConfig;
}
