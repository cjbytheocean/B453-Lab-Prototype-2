using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Tilemaps;

public class DoorProcGen : MonoBehaviour
{

    public GameObject doorPrefab;
    public ProcGenWalker pgw;
    public Tilemap tileMap;

    public bool stopSpawning = false;

    public Vector2Int doorPosition;

    void Update()
    {
        if (!stopSpawning && pgw != null && pgw.gridHandler != null)
        {
            DoorGeneration();
            stopSpawning = true;
        }
    }

    void DoorGeneration()
    {
        List<Vector2Int> floorTiles = new List<Vector2Int>();

        for (int x = 0; x < pgw.MapWidth; x++)
        {
            for (int y = 0; y < pgw.MapHeight; y++)
            {
                if (pgw.gridHandler[x, y] == ProcGenWalker.Grid.FLOOR)
                {
                    floorTiles.Add(new Vector2Int(x, y));
                } 
            }
        }

        Vector2Int chosen = floorTiles[Random.Range(0, floorTiles.Count)];
        doorPosition = chosen;
        Vector3 spawned = tileMap.GetCellCenterWorld(new Vector3Int(chosen.x, chosen.y, 0));
        Instantiate(doorPrefab, spawned, Quaternion.identity);
    }
}

        
       