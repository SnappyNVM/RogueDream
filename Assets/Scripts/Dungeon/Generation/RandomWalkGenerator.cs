using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;
using Random = UnityEngine.Random;

public class RandomWalkGenerator : AbstractDungeonGenerator
{
    [SerializeField] protected SimpleRandomWalkConfig _randomWalkConfig;

    public void Initialize(TilemapVisualizer tilemapVisualizer)
    {
        _tilemapVisualizer = tilemapVisualizer;
    }

    protected override void RunProceduralGeneration()
    {
        HashSet<Vector2Int> floorPosition = RunRandomWalk(_randomWalkConfig, _startPosition);
        _tilemapVisualizer.Clear();
        _tilemapVisualizer.PaintFloorTiles(floorPosition);
        WallsGenerator.CreateWalls(floorPosition, _tilemapVisualizer);
    }

    protected HashSet<Vector2Int> RunRandomWalk(SimpleRandomWalkConfig parameters, Vector2Int spawnPosition)
    {
        var currentPosition = spawnPosition;
        HashSet<Vector2Int> floorPositions = new HashSet<Vector2Int>();
        for (int i = 0; i < parameters.Iterations; i++)
        {
            var path = ProceduralGenerationAlgorithms.GetSimpleRandomWalkPositions(currentPosition, parameters.WalkLength);
            floorPositions.UnionWith(path);
            if (_randomWalkConfig.StartRandomlyEachIteration) 
                currentPosition = floorPositions.ElementAt(Random.Range(0, floorPositions.Count));
        }
        return floorPositions;
    }

}
