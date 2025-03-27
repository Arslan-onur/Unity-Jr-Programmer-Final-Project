using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] List<GameObject> platforms = new List<GameObject>();
    private float spawnPosXlimit = 9f;
    private float distanceBetweenPlatforms = 1f;
    private float startRate = 2f;
    private float spawnIntervalRate = 5f;

    void Start()
    {
        InvokeRepeating("RandomSpawner", startRate, spawnIntervalRate);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void RandomSpawner()
    {
        int platformNumber = Random.Range(0,platforms.Count);
        Vector3 spawnPos = new Vector3(Random.Range(-spawnPosXlimit,spawnPosXlimit),10,0);
        for (int i = 0; i<platformNumber; i++ )
        {
            int indexNumber = Random.Range(0,platforms.Count);
            Instantiate(platforms[indexNumber],spawnPos,Quaternion.identity);
            float boxcolliderlong = platforms[indexNumber].gameObject.GetComponent<BoxCollider>().size.x;
            spawnPos.x += boxcolliderlong + distanceBetweenPlatforms;
            spawnPos = new Vector3(spawnPos.x,10,0);
        }

    }
}
