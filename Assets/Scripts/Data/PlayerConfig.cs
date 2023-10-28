using UnityEngine;

[CreateAssetMenu(fileName = "Player Config", menuName = "Data/Player Config")]
public class PlayerConfig : ScriptableObject
{ 
    [field: SerializeField] public float Speed { get; private set; }
    [field: SerializeField] public float HealthPoints { get; set; }

}
