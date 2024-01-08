using System.Collections.Generic;
using UnityEngine;

public static class CorridorsMagnifier
{
    public static List<Vector2Int> IncreaseCorridorSizeFrom1To2(List<Vector2Int> corridor)
    {
        List<Vector2Int> newCorridor = new List<Vector2Int>();
        Vector2Int prew = Vector2Int.zero;
        for (int i = 1; i < corridor.Count; i++)
        {
            Vector2Int directionFromCell = corridor[i] - corridor[i - 1];
            if (prew != Vector2Int.zero && directionFromCell != prew)
            {
                for (int x = -1; x < 2; x++)
                    for (int y = -1; y < 2; y++)
                        newCorridor.Add(corridor[i - 1] + new Vector2Int(x, y));
            }
            else
            {
                Vector2Int newCorridorTileOffset =
                    GetDirection90From(directionFromCell);
                newCorridor.Add(corridor[i - 1]);
                newCorridor.Add(corridor[i - 1] + newCorridorTileOffset);
            }
        }
        return newCorridor;
    }

    public static List<Vector2Int> IncreaseCorridorSizeFrom1To3(List<Vector2Int> corridor)
    {
        List<Vector2Int> newCorridor = new List<Vector2Int>();
        for (int i = 1; i < corridor.Count; i++)
            for (int x = -1; x < 2; x++)
                for (int y = -1; y < 2; y++)
                    newCorridor.Add(corridor[i - 1] + new Vector2Int(x, y));
        return newCorridor;
    }

    private static Vector2Int GetDirection90From(Vector2Int direction)
    {
        if (direction == Vector2Int.up) return Vector2Int.right;
        if (direction == Vector2Int.right) return Vector2Int.down;
        if (direction == Vector2Int.down) return Vector2Int.left;
        if (direction == Vector2Int.left) return Vector2Int.up;
        return Vector2Int.zero;
    }
}
