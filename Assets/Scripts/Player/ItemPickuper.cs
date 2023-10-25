using Unity.VisualScripting;
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
            bool configReplaced = false;
            for (int i = 0; i < _player.Inventory.Items.Length; i++)
            {
                if (_player.Inventory.Items[i] == null)
                {
                    configReplaced = true;
                    _player.Inventory.ChangeItem(_takingItem.Config, i);
                    break;
                }
            }

            if (configReplaced == false) 
            {
                _player.ItemDropper.DropItem(_player.Inventory.InventoryPanel.CurrentSelectedCell);
                _player.Inventory.ChangeItem(_takingItem.Config,
                _player.Inventory.InventoryPanel.CurrentSelectedCell);
            }

            Destroy(_takingItem.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _takingItem = null;
        _stayingInsideOfItem = true;
    }
}
