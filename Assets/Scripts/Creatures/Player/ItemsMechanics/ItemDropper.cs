using UnityEngine;
using Zenject;

public class ItemDropper : MonoBehaviour
{
    private Player _player;

    [Inject]
    private void Construct(Player player) =>
        _player = player;

    public InventoryItem DropItem(int cellID)
    {
        var spawnedObject = Instantiate(_player.Inventory.Items[cellID].FormulaicItem, _player.transform.position, Quaternion.identity);
        spawnedObject.Config = _player.Inventory.Items[cellID];
        _player.Inventory.ReplaceItem(null, cellID);
        return spawnedObject;
    }
}
