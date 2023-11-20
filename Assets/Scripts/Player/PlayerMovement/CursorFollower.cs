using UnityEngine;

public class CursorFollower : MonoBehaviour
{
    private Player _player;
    private Vector3 _mousePosition;
    private float _angle;

    public void Initialize(Player player) =>
        _player = player;

    private void Update()
    {
        _mousePosition = _player.MovementHandler.MousePosition;
        _angle = Vector2.Angle(Vector2.right, _mousePosition - transform.position);
        transform.eulerAngles = new Vector3(0f, 0f, transform.position.y < _mousePosition.y ? _angle : -_angle);
    }
}
