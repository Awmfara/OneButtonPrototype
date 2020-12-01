using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    SpawnPoint[] spawnPoints = default;
    [SerializeField]
    float timeBtwSpwan = default;
    float timer = 10;
    [SerializeField]
    GameObject flyPrefab;
    private void Awake()
    {
        spawnPoints=FindObjectsOfType<SpawnPoint>();
    }
    private void Start()
    {
        timer = timeBtwSpwan;
    }
    private void Update()
    {
        ///Spawns fly at a random spawn point and resets timer to a random point up to 5 seconds
        if (timer<=0)
        {
            Instantiate(flyPrefab,spawnPoints[Random.Range(0,spawnPoints.Length)].transform,false);
            timer = timeBtwSpwan;
            timeBtwSpwan = Random.Range(0, 5);


        }
        else
        {
            timer -= Time.deltaTime;
        }
    }
    
}
