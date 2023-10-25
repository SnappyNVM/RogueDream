using UnityEngine;

public class ItemDropper : MonoBehaviour
{
    [SerializeField] private Player _player;

    public void OnValidate() =>
        _player = GetComponent<Player>();

    public void DropItem(int cellID)
    {
        var spawnedObject = Instantiate(_player.Inventory.Items[cellID].FormulaicItem, _player.transform.position, Quaternion.identity);
        spawnedObject.Config = _player.Inventory.Items[cellID];
        _player.Inventory.ChangeItem(null, cellID);
    }
}
