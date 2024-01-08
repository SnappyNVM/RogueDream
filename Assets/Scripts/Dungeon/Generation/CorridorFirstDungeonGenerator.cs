using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;

public class CorridorFirstDungeonGenerator : RandomWalkGenerator
{
    [SerializeField] private int _corridorLength;
    [SerializeField] private int _corridorCount;
    [SerializeField] private bool _increaseCorridorTo3;
    [field: SerializeField, Range(0.1f, 1f)] public float RoomPercent { get; private set; }

    protected override void RunProceduralGeneration() =>
        CorridorFirstGeneration();
   

    private void CorridorFirstGeneration()
    {
        HashSet<Vector2Int> floorPositions = new HashSet<Vector2Int>();
        HashSet<Vector2Int> potentialRoomPositions = new HashSet<Vector2Int>();

        List<List<Vector2Int>> corridors = CreateCorridors(floorPositions, potentialRoomPositions);

        HashSet<Vector2Int> roomsFloorPositions = CreateRooms(potentialRoomPositions);

        List<Vector2Int> deadEnds = FindAllDeadEnds(floorPositions);

        CreateRoomsAtDeadEnds(deadEnds, roomsFloorPositions);

        floorPositions.UnionWith(roomsFloorPositions);

        for (int i = 0; i < corridors.Count; i++) 
        {
            if (_increaseCorridorTo3)
                corridors[i] = CorridorsMagnifier.IncreaseCorridorSizeFrom1To3(corridors[i]);
            else
                corridors[i] = CorridorsMagnifier.IncreaseCorridorSizeFrom1To2(corridors[i]);
            floorPositions.UnionWith(corridors[i]);
        }

        _tilemapVisualizer.PaintFloorTiles(floorPositions);
        WallsGenerator.CreateWalls(floorPositions, _tilemapVisualizer);
    }

    private void CreateRoomsAtDeadEnds(List<Vector2Int> deadEnds, HashSet<Vector2Int> roomsFloorPositions)
    {
        foreach (var position in deadEnds)
            if (!roomsFloorPositions.Contains(position))
                roomsFloorPositions.UnionWith(RunRandomWalk(_randomWalkConfig, position));
    }

    private List<Vector2Int> FindAllDeadEnds(HashSet<Vector2Int> floorPositions)
    {
        List<Vector2Int> deadEnds = new List<Vector2Int>();
        foreach (var position in floorPositions)
        {
            int neighboursCount = 0;
            foreach (var direction in Direction2D.cardinalDirectionList) 
            { 
                if (floorPositions.Contains(position + direction))
                    neighboursCount++;
            }
            if (neighboursCount == 1)
                deadEnds.Add(position);
        }
        return deadEnds;
    }

    private HashSet<Vector2Int> CreateRooms(HashSet<Vector2Int> potentialRoomPositions)
    {
        HashSet<Vector2Int> roomPositions = new HashSet<Vector2Int>();
        int roomsToCreateCount = Mathf.RoundToInt(potentialRoomPositions.Count * RoomPercent);

        List<Vector2Int> roomsToCreate = potentialRoomPositions
            .OrderBy(x => Guid.NewGuid())
            .Take(roomsToCreateCount)
            .ToList();

        foreach(var roomPos in roomsToCreate)
        {
            var roomFloor = RunRandomWalk(_randomWalkConfig, roomPos);
            roomPositions.UnionWith(roomFloor);
        }
        return roomPositions;
    }

    private List<List<Vector2Int>> CreateCorridors(HashSet<Vector2Int> floorPosition, HashSet<Vector2Int> potentialRoomPositions)
    {
        var currentPosition = _startPosition;
        potentialRoomPositions.Add(currentPosition);
        List <List<Vector2Int>> corridors = new List<List<Vector2Int>>();

        for (int i = 0; i < _corridorCount; i++)
        {
            var path = ProceduralGenerationAlgorithms.GetRandomWalkCorridorPositions(currentPosition, _corridorLength);
            corridors.Add(path);
            currentPosition = path[path.Count - 1];
            potentialRoomPositions.Add(currentPosition);
            floorPosition.UnionWith(path);
        }
        return corridors;
    }
}