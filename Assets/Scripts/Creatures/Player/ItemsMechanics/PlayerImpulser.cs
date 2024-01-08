using UnityEngine;
using Zenject;

public class PlayerImpulser : Impulser
{
    private Player _player;

    [Inject]
    private void Construct(Player player) =>
        _player = player;

    public override void Impulse(Vector2 impulsePoint2)
    {
        _player.Rigidbody.AddForce(((Vector2)gameObject.transform.position - impulsePoint2).normalized * _player.PlayerConfig.DamageImpulseForce, ForceMode2D.Impulse);
        _player.MovementHandler.IsAbleToWalk = false;
        Invoke(nameof(MakePlayerMove), _player.PlayerConfig.DamageDizzinessDelay);
    }

    private void MakePlayerMove() =>
        _player.MovementHandler.IsAbleToWalk = _player.Alive ? true : false;
}
