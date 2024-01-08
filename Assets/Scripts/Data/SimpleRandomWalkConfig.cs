using UnityEngine;

[CreateAssetMenu(fileName = "SimpleRandomWalkParamenters_", menuName = "PCG/SimpleRandomWalkConfig")]
public class SimpleRandomWalkConfig : ScriptableObject
{
    [field: SerializeField] public int Iterations { get; private set; }
    [field: SerializeField] public int WalkLength { get; private set; }
    [field: SerializeField] public bool StartRandomlyEachIteration { get; private set; }
}
