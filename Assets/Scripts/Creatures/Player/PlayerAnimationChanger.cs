using UnityEngine;
using Zenject;

public class PlayerAnimationChanger : MonoBehaviour
{
    private Player _player;

    private Animator _playerAnim;
    private IInput _input;

    [Inject]
    private void Constuct(IInput input, Player player)
    {
        _input = input;
        _player = player;
    }

    public void Initialize(Animator playerAnimator)
    {
        _playerAnim = playerAnimator;
        _playerAnim.SetBool("Alive", true);
    }

    private void FixedUpdate()
    {
        if (_player.Alive)
            UpdateAnimations();
        else
            _playerAnim.SetBool("Alive", false);
    }

    private void UpdateAnimations()
    {
        if (_player.MovementHandler.IsAbleToWalk)
        {
            _playerAnim.SetFloat("Vertical", _input.MovingDirection.y);
            _playerAnim.SetFloat("Horizontal", _input.MovingDirection.x);
            _playerAnim.SetFloat("Speed", _input.MovingDirection.sqrMagnitude);
        }
        else
        {
            _playerAnim.SetFloat("Vertical", 0);
            _playerAnim.SetFloat("Horizontal", 0);
            _playerAnim.SetFloat("Speed", 0);
        }
    }

   
}
