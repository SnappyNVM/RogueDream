using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "Effect Item Config", menuName = "Data/Effect Item Config")]
public sealed class EffectItemConfig : InventoryItemConfig
{
    public override IItemFunctional ItemFunctional { get => _itemFunctional; protected set { _itemFunctional = value; } }
    private IItemFunctional _itemFunctional;

    public override void Initialize() =>
        _itemFunctional = new EffectFunctional(this);
}
