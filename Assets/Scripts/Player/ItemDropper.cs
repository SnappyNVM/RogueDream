using UnityEngine;

public class ItemDropper : MonoBehaviour
{
    [SerializeField] private Player _player;

    public void OnValidate() =>
        _player = GetComponent<Player>();

    public InventoryItem DropItem(int cellID)
    {
        var spawnedObject = Instantiate(_player.Inventory.Items[cellID].FormulaicItem, _player.transform.position, Quaternion.identity);
        spawnedObject.Config = _player.Inventory.Items[cellID];
        _player.Inventory.ReplaceItem(null, cellID);
        return spawnedObject;
    }
}
