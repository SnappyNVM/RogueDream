using UnityEngine;
using Zenject;

public class HealthBar : MonoBehaviour
{
    private Player _player;
    private PlayerHealth _health;
    private Heart _heartPrefab;
    private Heart[] _hearts;

    [Inject]
    private void Construct(Player player) =>
        _player = player;

    public void UpdateHearts()
    {
        _hearts = GetComponentsInChildren<Heart>();
        if (_hearts.Length == _health.Health)
            return;

        foreach (Heart heart in _hearts)
            Destroy(heart.gameObject);

        Debug.Log("Health is " + _health.Health);
        for (int i = 0; i < _health.Health; i++)
            Instantiate(_heartPrefab, Vector3.zero, Quaternion.identity, transform);
        
    }

    public void Initialize(PlayerHealth health, Heart heartPrefab)
    {
        _health = health;
        _heartPrefab = heartPrefab;
        UpdateHearts();
    }
}
