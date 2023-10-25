using UnityEngine;

public abstract class InventoryItem : MonoBehaviour
{
    public InventoryItemConfig Config { get; set; }
    private Player _player;

    private void Start() =>
        GetComponent<SpriteRenderer>().sprite = Config.Sprite;    
}
