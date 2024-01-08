using Mono.Cecil.Cil;
using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class RoomFirstDungeonGeneration : RandomWalkGenerator
{
    [SerializeField] private int _minRoomWidth;
    [SerializeField] private int _minRoomHeight;

    [SerializeField] private int _dungeonWidth;
    [SerializeField] private int _dungeonHeight;

    [SerializeField, Range(0, 10)] private int _offset;

    [SerializeField] private bool _randomWalkRooms;

    [SerializeField] private bool _increaseCorridorTo3;

    protected override void RunProceduralGeneration() =>
        CreateRooms();

    private void CreateRooms()
    {
        var roomsList = ProceduralGenerationAlgorithms.BinarySpacePartitioning(
            new BoundsInt((Vector3Int)_startPosition,
            new Vector3Int(_dungeonWidth, _dungeonHeight, 0)),
            _minRoomWidth, _minRoomHeight);

        HashSet<Vector2Int> floor = new HashSet<Vector2Int>();

        if (_randomWalkRooms)
            floor = CreateRoomsRandomly(roomsList);
        else
            floor = CreateSimpleRooms(roomsList);

        List<Vector2Int> roomCenters = new List<Vector2Int>();

        foreach (var room in roomsList)
            roomCenters.Add((Vector2Int)Vector3Int.RoundToInt(room.center));

        List<List<Vector2Int>> corridors = ConnectRooms(roomCenters);

        for (int i = 0; i < corridors.Count; i++)
        {
            if (_increaseCorridorTo3)
                corridors[i] = CorridorsMagnifier.IncreaseCorridorSizeFrom1To3(corridors[i]);
            else
                corridors[i] = CorridorsMagnifier.IncreaseCorridorSizeFrom1To2(corridors[i]);
            floor.UnionWith(corridors[i]);
        }

        _tilemapVisualizer.PaintFloorTiles(floor);
        WallsGenerator.CreateWalls(floor, _tilemapVisualizer);
    }

    private HashSet<Vector2Int> CreateRoomsRandomly(List<BoundsInt> roomsList)
    {
        HashSet<Vector2Int> floor = new HashSet<Vector2Int>();
        for (int i = 0; i < roomsList.Count; i++)
        {
            var roomBounds = roomsList[i];
            //var roomCenter = new Vector2Int(Mathf.RoundToInt(roomBounds.center.x), Mathf.RoundToInt(roomBounds.center.y));
            var roomCenter = Vector2Int.RoundToInt(roomBounds.center);
            var roomFloor = RunRandomWalk(_randomWalkConfig, roomCenter);
            foreach (var position in roomFloor)
            {
                if (position.x >= (roomBounds.xMin + _offset)
                    && position.x <= (roomBounds.xMax - _offset)
                    && position.y >= (roomBounds.yMin - _offset)
                    && position.y <= (roomBounds.yMax - _offset))
                    floor.Add(position);
            }
        }
        return floor;
    }

    private List<List<Vector2Int>> ConnectRooms(List<Vector2Int> roomCenters)
    {
        List<List<Vector2Int>> corridors = new List<List<Vector2Int>>();
        var currentRoomCenter = roomCenters[Random.Range(0, roomCenters.Count)];
        roomCenters.Remove(currentRoomCenter);

        int iterator = 0;
        while(roomCenters.Count > 0)
        {
            Vector2Int closest = FindClosestPointTo(currentRoomCenter, roomCenters);
            roomCenters.Remove(closest);
            HashSet<Vector2Int> newCorridor = CreateCorridor(currentRoomCenter, closest);
            currentRoomCenter = closest;

            corridors.Add(new List<Vector2Int>());
            foreach (var position in newCorridor)
                corridors[iterator].Add(position);
            iterator++;
        }
        return corridors;
    }

    private HashSet<Vector2Int> CreateCorridor(Vector2Int currentRoomCenter, Vector2Int closest)
    {
        HashSet<Vector2Int> corridor = new HashSet<Vector2Int>();
        var position = currentRoomCenter;
        corridor.Add(position);
        while (position.y != closest.y)
        {
            if (closest.y > position.y)
                position += Vector2Int.up;
            else if (closest.y < position.y)
                position += Vector2Int.down;
            corridor.Add(position);
        }
        while (position.x != closest.x)
        {
            if (closest.x > position.x)
                position += Vector2Int.right;
            else if (closest.x < position.x)
                position += Vector2Int.left;
            corridor.Add(position);
        }
        return corridor;
    }

    private Vector2Int FindClosestPointTo(Vector2Int currentRoomCenter, List<Vector2Int> roomCenters)
    {
        Vector2Int closest = Vector2Int.zero;
        float distance = float.MaxValue;
        foreach (var center in roomCenters)
        {
            float currentDistance = Vector2.Distance(center, currentRoomCenter);
            if (currentDistance < distance)
            {
                distance = currentDistance;
                closest = center;
            }
        }
        return closest;
    }

    private HashSet<Vector2Int> CreateSimpleRooms(List<BoundsInt> roomsList)
    {
        HashSet<Vector2Int> floor = new HashSet<Vector2Int>();
        foreach (var room in roomsList)
        {
            for (int col  = _offset; col < room.size.x - _offset; col++)
            {
                for (int row = _offset; row < room.size.y - _offset; row++)
                {
                    Vector2Int position = (Vector2Int)room.min + new Vector2Int(col, row);
                    floor.Add(position);
                }
            }
        }
        return floor;
    }
}
