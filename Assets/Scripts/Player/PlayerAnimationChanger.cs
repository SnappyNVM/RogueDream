using UnityEngine;
using Zenject;

public class PlayerAnimationChanger : MonoBehaviour
{
    private Animator _player;

    private IInput _input;

    [Inject]
    private void Constuct(IInput input) => _input = input;

    public void Initialize(Animator playerAnimator) =>
         _player = playerAnimator;

    private void FixedUpdate() => UpdateAnimations();

    private void UpdateAnimations()
    {
        _player.SetFloat("Vertical", _input.MovingDirection.y);
        _player.SetFloat("Horizontal", _input.MovingDirection.x);
        _player.SetFloat("Speed", _input.MovingDirection.sqrMagnitude);
    }
}
