using UnityEngine;

public class Danger : MonoBehaviour, IDamager
{
    [SerializeField] private int _damage;

    public int Damage => _damage;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out ICreature creature))
        {
            creature.Damagable.TakeDamage(this);
            if (creature is IImpulseable)
                ((IImpulseable)creature).Impulser.Impulse(transform.position);
        }
    }
}
