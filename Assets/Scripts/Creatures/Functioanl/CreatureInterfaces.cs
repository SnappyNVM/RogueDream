using UnityEngine;

public interface ICreature
{
    public IDamagable Damagable{ get; }
}

public interface IDamagable
{
    public void TakeDamage(IDamager damager);
}

public interface IDamager
{
    public int Damage { get; }
}

public interface IHealable
{
    public void Heal(int healPoints);
}

public interface IImpulseable
{
    public Impulser Impulser { get; }
}

