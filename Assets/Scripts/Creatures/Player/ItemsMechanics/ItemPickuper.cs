using UnityEngine;
using Zenject;

public class ItemPickuper : MonoBehaviour
{
    private Player _player;
    private bool _isConfigReplaced;
    private bool _isTakenItemThisPress;
    private InventoryItem _takingItem;

    [Inject]
    public void Construct(Player player) =>
        _player = player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out InventoryItem inventoryItem))
            _takingItem = inventoryItem;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (_player.MovementHandler.IsInteractiveButtonPressed && _isTakenItemThisPress == false)
        {
            if (_takingItem == null) return;
            _isConfigReplaced = false;
            for (int i = 0; i < _player.Inventory.Items.Length; i++)
            {
                if (_player.Inventory.Items[i] == null)
                {
                    _isConfigReplaced = true;
                    _player.Inventory.ReplaceItem(_takingItem.Config, i);
                    break;
                }
            }

            if (_isConfigReplaced == false) 
            {
                _player.ItemDropper.DropItem(_player.Inventory.InventoryPanel.CurrentSelectedCell);
                _player.Inventory.ReplaceItem(_takingItem.Config,
                _player.Inventory.InventoryPanel.CurrentSelectedCell);
            }

            _isTakenItemThisPress = true;

            Destroy(_takingItem.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision) =>
        _takingItem = null;

    public void ChangeItemPressFlagToFalse() =>
        _isTakenItemThisPress = false;
}
