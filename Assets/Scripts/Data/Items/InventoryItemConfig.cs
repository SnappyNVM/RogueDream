using UnityEngine;
using System;

public abstract class InventoryItemConfig : ScriptableObject
{
    [field: SerializeField] public string Name { get; private set; }
    [field: SerializeField] public Sprite Icon { get; private set; }
    [field: SerializeField] public Sprite Sprite { get; private set; }
    [field: SerializeField] public string Description { get; private set; }
    [field: SerializeField] public InventoryItem FormulaicItem { get; private set; }

    private void OnValidate()
    {
        switch (GetType().Name)
        {
            case nameof(FirearmsConfig):
                if (FormulaicItem is not Firearms) 
                    ThrowInvalidPrefabExeption(nameof(Firearms));
                break;

            case nameof(CloseCombatWeapon):
                if (FormulaicItem is not CloseCombatWeapon)
                    ThrowInvalidPrefabExeption(nameof(CloseCombatWeapon));
                break;

            case nameof(EffectItemConfig):
                if (FormulaicItem is not EffectItem)
                    ThrowInvalidPrefabExeption(nameof(EffectItem));
                break;
        }
    }

    private void ThrowInvalidPrefabExeption(string typeToBe) =>
        throw new InvalidOperationException("FormulaicItem has to be " + typeToBe);
        
}
