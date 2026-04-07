using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;
using UnityEditor.MemoryProfiler;
using Unity.VisualScripting;

public class KeyProcGen : MonoBehaviour
{
    public GameObject keyPrefab;
    public ProcGenWalker pgw;
    public Tilemap tileMap;
    public bool stopSpawning = false;
    public DoorProcGen dpg;
    [SerializeField] float distanceApart = 10f;

    void Update()
    {
        if (!stopSpawning && pgw != null && pgw.gridHandler != null && dpg.stopSpawning)
        {
            stopSpawning = true;
        }
    }

    public void KeyGeneration(Vector2Int doorPos)
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

        List<Vector2Int> selectedTiles = new List<Vector2Int>();

        foreach (var p in floorTiles)
        {
            if (Vector2Int.Distance(p, doorPos) >= distanceApart)
            {
                selectedTiles.Add(p);
            }
        }

        Vector2Int chosen;

        if (selectedTiles.Count > 0)
        {
            chosen = selectedTiles[Random.Range(0, selectedTiles.Count)];
        }
        else
        {
            chosen = floorTiles[0];
            float maximumDistance = 0f;

            foreach (var p in floorTiles)
            {
                float distance = Vector2Int.Distance(p, doorPos);

                if (distance > maximumDistance)
                {
                    maximumDistance = distance;
                    chosen = p;
                }
            }
            
        }
        Vector3 spawned = tileMap.GetCellCenterWorld(new Vector3Int(chosen.x, chosen.y, 0));
        Instantiate(keyPrefab, spawned, Quaternion.identity);
    }
}

        
            

        
       
     