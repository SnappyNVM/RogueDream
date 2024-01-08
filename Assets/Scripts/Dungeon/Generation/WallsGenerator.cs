using System;
using System.Collections.Generic;
using UnityEngine;

public static class WallsGenerator
{
    public static void CreateWalls(HashSet<Vector2Int> floorPosition, TilemapVisualizer tilemapVisualizer)
    {
        var basicalPositions = FindWallsInDirections(floorPosition, Direction2D.cardinalDirectionList);
        foreach(var position in basicalPositions)
            tilemapVisualizer.PaintSingleBasicWall(position);
    }

    private static HashSet<Vector2Int> FindWallsInDirections(HashSet<Vector2Int> floorPosition, List<Vector2Int> directionsList)
    {
        HashSet<Vector2Int> wallPositions = new HashSet<Vector2Int>();
        foreach (var position in floorPosition) 
            foreach (var direction in directionsList)
            {
                var neighbourPosition = position + direction;
                if (!floorPosition.Contains(neighbourPosition)) 
                    wallPositions.Add(neighbourPosition);
            }
        return wallPositions;
    }
}
