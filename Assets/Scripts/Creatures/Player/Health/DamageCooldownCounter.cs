using UnityEngine;
using Zenject;

public class DamageCooldownCounter : MonoBehaviour
{
    public float CurrentCooldown { get ; set; }

    private Player _player;

    [Inject]
    private void Construct(Player player) =>
        _player = player;

    private void Update() =>
        CurrentCooldown -= Time.deltaTime;
}
