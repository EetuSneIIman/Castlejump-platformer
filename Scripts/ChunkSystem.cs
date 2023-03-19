using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkSystem : MonoBehaviour
{
    [Header("Settings")]
    public float Range = 25f;
    public float MaxRange = 150f;
    public int Chunkpick = 0;
    public int WidthPick = 0;
    public DistanceMeter distanceScript;
    private float nextActionTime = 0.0f;
    public float period = 0.2f;
    public GameManager gm;

    [Header("Chunks")]
    public GameObject Chunk1;
    public GameObject Chunk2;
    public GameObject Chunk3;
    public GameObject Chunk4;

    void Start()
    {
        GameObject PlayerPrefab = GameObject.Find("Player");
        
    }

    void Update()
    {
        
        if (Time.time > nextActionTime)
        { 
            nextActionTime += period;
            Debug.Log("<color=orange>Update: </color>Generate Prefabs | Limit 1 per sec");
            AmountHandler();
        }
        
        if (MaxRange <= distanceScript.distance + 200)
        {
            MaxRange = distanceScript.distance + 200;
        }
    }

    public void AmountHandler()
    {
        Chunkpick = Random.Range(1, 10);
        WidthPick = Random.Range(-35, 35);

        if (Range <= MaxRange)
        {
            if (Chunkpick <= 5)
            {
                Instantiate(Chunk1, new Vector3(WidthPick, Range, 0), Quaternion.identity);
                Range = Range + 10f;
                Debug.Log("<color=green>Prefab created: </color>Chunk 2");
            }
            if (Chunkpick == 6)
            {
                Instantiate(Chunk2, new Vector3(WidthPick, Range, 0), Quaternion.identity);
                Range = Range + 10f;
                Debug.Log("<color=green>Prefab created: </color>Chunk 1");
            }
            if (Chunkpick == 7)
            {
                Instantiate(Chunk3, new Vector3(WidthPick, Range, 0), Quaternion.identity);
                Range = Range + 10f;
                Debug.Log("<color=green>Prefab created: </color>Chunk 3");
            }
            if (Chunkpick >= 8)
            {
                Instantiate(Chunk4, new Vector3(WidthPick, Range, 0), Quaternion.identity);
                Range = Range + 10f;
                Debug.Log("<color=green>Prefab created: </color>Chunk 4");
            }

        }
    }

}