using UnityEngine;

public class CursorFollower : MonoBehaviour
{
    private Player _player;
    private Vector3 _mousePosition;
    private float _angle;
    private float _startYScale;

    public void Initialize(Player player)
    {
        _startYScale = transform.localScale.y;
        _player = player;
    }

    private void Update()
    {
        _mousePosition = _player.MovementHandler.MousePosition;
        _angle = Vector2.Angle(Vector2.right, _mousePosition - transform.position);
        transform.eulerAngles = new Vector3(0f, 0f, transform.position.y < _mousePosition.y ? _angle : -_angle);
        transform.localScale = new Vector3(transform.localScale.x,
            transform.position.x < _mousePosition.x ? _startYScale : -_startYScale,
            transform.localScale.z);
    }
}
