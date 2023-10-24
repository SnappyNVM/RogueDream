using UnityEngine;

public class ItemPickuper : MonoBehaviour
{
    [SerializeField] private Player _player;
    private bool _stayingInsideOfItem;
    private InventoryItem _takingItem;

    public void OnValidate() =>
        _player = GetComponent<Player>();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out InventoryItem inventoryItem))
        {
            _takingItem = inventoryItem;
            _stayingInsideOfItem = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (_player.MovementHandler.IsInteractiveButtonPressed && _stayingInsideOfItem)
        {
            if (_player.Inventory.Item1 == null)
                _player.Inventory.Item1 = _takingItem.Config;
            else if (_player.Inventory.Item2 == null)
                _player.Inventory.Item2 = _takingItem.Config;
            else if (_player.Inventory.Item3 == null)
                _player.Inventory.Item3 = _takingItem.Config;
            else
                _player.Inventory.Item1 = _takingItem.Config;
            // Rare case when copy paste probably justified, don't hit me!
            // 2hard2 realize it other way
            Destroy(_takingItem.gameObject);
            _takingItem = null;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _takingItem = null;
        _stayingInsideOfItem = true;
    }
}
