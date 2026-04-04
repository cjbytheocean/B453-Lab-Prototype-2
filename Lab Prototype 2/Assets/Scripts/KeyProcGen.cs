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
        if (gb.gameStarted && !stopSpawning)
        {
            KeyGeneration();
            stopSpawning = true;
        }
    }

    void KeyGeneration()
    {
        spawnPositions.Clear();
        
        int t = 0;

        while (spawnPositions.Count < 1 && t < 5000)
        {
            t++;
            
            float xPosition = Random.Range(minimum.x + wallMargin, maximum.x - wallMargin);
            float yPosition = Random.Range(minimum.y + wallMargin, maximum.y - wallMargin);

            Vector2 spawned = new Vector2(xPosition, yPosition);

            if (WithinConstraints(spawned))
            {
                spawnPositions.Add(spawned);
            } 
        }

        for (int i = 0; i < spawnPositions.Count; i++)
        {
            Instantiate(circles[0], spawnPositions[0], Quaternion.identity); 
        } 
    }

    bool WithinConstraints(Vector2 v)
    {
        foreach (Vector2 sp in spawnPositions)
        {
            if (Vector2.Distance(v, sp) < baseMargin)
            {
                return false;
            }
        }
        return true; 
    }
}
