using UnityEngine;

public abstract class InventoryItem : MonoBehaviour
{
    public InventoryItemConfig Config { get; set; }
    [SerializeField] private SpriteRenderer _renderer;

    private void Start()
    {
        Config.Initialize();
        _renderer.sprite = Config.Sprite;
    }

    private void OnValidate() =>
        _renderer ??= GetComponent<SpriteRenderer>();
}
