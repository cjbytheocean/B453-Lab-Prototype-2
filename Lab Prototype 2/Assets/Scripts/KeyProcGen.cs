using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;
using UnityEditor.MemoryProfiler;

public class KeyProcGen : MonoBehaviour
{

    public GameObject keyPrefab;
    public ProcGenWalker pgw;
    public Tilemap tileMap;

    public bool stopSpawning = false;

    public DoorProcGen dpg;

    void Update()
    {
        if (!stopSpawning && pgw != null && pgw.gridHandler != null)
        {
            KeyGeneration(dpg.doorPosition);
            stopSpawning = true;
        }
    }

    void KeyGeneration(Vector2Int doorPos)
    {
        List<Vector2Int> floorTiles = new List<Vector2Int>();

        for (int x = 0; x < pgw.MapWidth; x++)
        {
            for (int y = 0; y < pgw.MapHeight; y++)
            {
                if (pgw.gridHandler[x, y] == ProcGenWalker.Grid.FLOOR)
                {
                    Vector2Int pos = new Vector2Int(x, y);

                    if (pos != doorPos)
                    {
                        floorTiles.Add(pos);
                    }
                } 
            }
        }

        Vector2Int chosen = floorTiles[Random.Range(0, floorTiles.Count)];

        Vector3 spawned = tileMap.GetCellCenterWorld(new Vector3Int(chosen.x, chosen.y, 0));
        Instantiate(keyPrefab, spawned, Quaternion.identity);
    }
}

        
            

        
       
     