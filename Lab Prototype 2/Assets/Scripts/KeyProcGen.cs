using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Tilemaps;

public class KeyProcGen : MonoBehaviour
{

    public GameObject keyPrefab;
    public ProcGenWalker pgw;
    public Tilemap tileMap;

    public bool stopSpawning = false;

    void Update()
    {
        if (!stopSpawning && pgw != null && pgw.gridHandler != null)
        {
            KeyGeneration();
            stopSpawning = true;
        }
    }

    void KeyGeneration()
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
        Vector3 spawned = tileMap.GetCellCenterWorld(new Vector3Int(chosen.x, chosen.y, 0));
        Instantiate(keyPrefab, spawned, Quaternion.identity);
    }
}

        
            

        
       
     