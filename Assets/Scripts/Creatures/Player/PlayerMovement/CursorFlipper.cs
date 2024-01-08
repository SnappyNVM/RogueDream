using UnityEngine;

public class CursorFlipper : MonoBehaviour
{
    private Player _player;
    private Vector3 _mousePosition;
    private float _startYScale;

    public void Initialize(Player player)
    {
        _startYScale = transform.localScale.y;
        _player = player;
    }

    private void Update()
    {
        _mousePosition = _player.MovementHandler.MousePosition;
        transform.localScale = new Vector3(transform.localScale.x,
           transform.position.x < _mousePosition.x ? _startYScale : -_startYScale,
           transform.localScale.z);
    }
}
