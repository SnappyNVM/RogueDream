using UnityEngine;
using UnityEngine.UI;

public class InventoryCell : MonoBehaviour
{
    [SerializeField] private Image _frame;

    public Image Frame => _frame;

    private void OnValidate() =>
        _frame ??= GetComponentInChildren<Image>();
}
