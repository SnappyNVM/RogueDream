using UnityEngine;
using Zenject;

public class CloseCombatAnimator : MonoBehaviour
{
    [SerializeField] private Animator _closeCombat;
    private Player _player;

    private void OnValidate() =>
        _closeCombat ??= GetComponent<Animator>();

    [Inject]
    private void Construct(Player player) =>
        _player = player;

    public void OnHit()
    {
        if (_player.ItemFunctionalHandler.CurrentItemFunctional is CloseCombatWeaponFunctional)
            ((CloseCombatWeaponFunctional)_player.ItemFunctionalHandler.CurrentItemFunctional).Hit();
    }

    public void StartHit() =>
        _closeCombat.SetBool("PressedAndReady", true);

    public void EndHit() =>
    _closeCombat.SetBool("PressedAndReady", false);
}
