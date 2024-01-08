using UnityEngine;

[CreateAssetMenu(fileName = "Player Config", menuName = "Data/Player Config")]
public class PlayerConfig : ScriptableObject
{ 
    [field: SerializeField] public float Speed { get; private set; }
    [field: SerializeField] public int HealthPoints { get; set; }
    [field: SerializeField] public float DamageCooldown { get; private set; }
    [field: SerializeField] public float DamageImpulseForce { get; private set; }
    [field: SerializeField] public float DamageDizzinessDelay { get; private set; }

}
