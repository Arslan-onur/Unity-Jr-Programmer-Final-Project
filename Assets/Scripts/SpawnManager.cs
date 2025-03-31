using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] List<GameObject> platforms = new List<GameObject>();
    private float spawnPosXlimit = 9f;
    private float distanceBetweenPlatforms = 1f;
    private float startRate = 1f;
    private float spawnIntervalRate = 3f;

    public GameObject starPowerUp;
    //private float startHighFromPlatform = 1f;

    [SerializeField]public PlayerController playerController;

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
        if (!playerController.isGameOver)
        {
            int spawnStarChance = Random.Range(0,2);
            int platformNumber = Random.Range(0,platforms.Count);
            Vector3 spawnPos = new Vector3(Random.Range(-spawnPosXlimit,spawnPosXlimit),10,0);
            for (int i = 0; i<platformNumber; i++ )
            {
                int indexNumber = Random.Range(0,platforms.Count);
                Instantiate(platforms[indexNumber],spawnPos,Quaternion.identity);
                float boxcolliderlong = platforms[indexNumber].gameObject.GetComponent<BoxCollider>().size.x;
                float newSpawnPos = spawnPos.x + boxcolliderlong + distanceBetweenPlatforms;
                spawnPos = new Vector3(newSpawnPos,10,0);
            }

            if (spawnStarChance == 1)
            {
                Vector3 spawnPosStar = new Vector3(Random.Range(-spawnPosXlimit,spawnPosXlimit),12,0);
                Instantiate(starPowerUp,spawnPosStar,Quaternion.identity);
            }
        }

    }
}
