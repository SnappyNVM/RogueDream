using System;
using UnityEngine;
using Zenject;

public class PlayerHealth : IDamagable, IHealable
{ 
    private int _health;
    private int _maxHealth;
    private HealthBar _healthBar;
    private Player _player;

    public Action Die;

    public int Health => _health;
    public bool IsInInvulnerability => _player.DamageCooldownCounter.CurrentCooldown > 0;

    public PlayerHealth(HealthBar healthBar, int startHealth, Player player)
    {
        _healthBar = healthBar;
        _maxHealth = startHealth;
        _health = _maxHealth;
        _player = player;
    }

    public void TakeDamage(IDamager damager)
    {
        if (IsInInvulnerability) return;


        if (damager.Damage <= 0)
            throw new ArgumentException("Damage can't equals zero or lower than it.");

        _health -= damager.Damage;
        _health = Mathf.Clamp(_health, 0, _maxHealth);

        _healthBar.UpdateHearts();

        _player.DamageCooldownCounter.CurrentCooldown = _player.PlayerConfig.DamageCooldown;

        if (_health <= 0)
            OnDie();
    }

    private void OnDie()
    {
        Die?.Invoke();
        _player.MovementHandler.IsAbleToWalk = false;
        _player.Alive = false;
    }

    public void Heal(int healPoints)
    {
        if (healPoints <= 0)
            throw new ArgumentException("Heal points can't equals zero or lower than it.");

        _health += healPoints;
        _health = Mathf.Clamp(_health, 0, _maxHealth);

        _healthBar.UpdateHearts();
    }
  
}
