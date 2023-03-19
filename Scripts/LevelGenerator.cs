using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [Header("Settings")]

    public int numberOfPlatforms = 0;
    public int maxPlatforms = 0;
    public int platformAmount = 0;
    public float levelWidth = 0f;
    public float SpawnDistance = 500f;

    public float Distance;

    [Header("Objects")]

    public GameObject platformPrefab;
    public GameObject KillerPrefab;
    public GameObject BoosterPrefab;
    public GameObject OneHitPrefab;
    //public DistanceMeter dM;

    [Header("Normal")]
    public float NminY = 5f;
    public float NmaxY = 15f;

    [Header("Boost")]
    public float BminY = 0f;
    public float BmaxY = 0f;

    [Header("OneHit")]
    public float OHminY = 0f;
    public float OHmaxY = 0f;

    [Header("Death")]

    public float DminY = 0f;
    public float DmaxY = 0f;

    void Start()
    {

        Distance = GameObject.Find("Camera").GetComponent<DistanceMeter>().distance;
        //Distance = dM.distance;
        
        PlatformSpawning();
    }

    void Update()
    {
        Debug.Log("Distance " + Distance);

        if (Distance >= SpawnDistance)
        {
            numberOfPlatforms = 0;
            PlatformSpawning();
            SpawnDistance = SpawnDistance + 500f;
            Debug.Log("DistanceSpawner: Platform Spawned");
        }
    }
    
    


    void PlatformSpawning()
    {
        Vector3 spawnPosition = new Vector3();


        for (int platformAmount = 0; platformAmount < numberOfPlatforms; platformAmount++)
        {
            Debug.Log("PlatformSpawned");
            spawnPosition.y += Random.Range(NminY, NmaxY);
            spawnPosition.x = Random.Range(-levelWidth, levelWidth);
            Instantiate(platformPrefab, spawnPosition, Quaternion.identity);

            spawnPosition.y += Random.Range(DminY, DmaxY);
            spawnPosition.x = Random.Range(-levelWidth, levelWidth);
            Instantiate(KillerPrefab, spawnPosition, Quaternion.identity);

            spawnPosition.y += Random.Range(BminY, BmaxY);
            spawnPosition.x = Random.Range(-levelWidth, levelWidth);
            Instantiate(BoosterPrefab, spawnPosition, Quaternion.identity);

            spawnPosition.y += Random.Range(OHminY, OHmaxY);
            spawnPosition.x = Random.Range(-levelWidth, levelWidth);
            Instantiate(OneHitPrefab, spawnPosition, Quaternion.identity);
            

        }
    }
}
