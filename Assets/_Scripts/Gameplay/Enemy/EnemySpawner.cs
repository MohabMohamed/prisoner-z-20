using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    public List<GameObject> AssociatedEnemies;

    public float SpawnRateInSec;
    public int MaxEnemiesToGenerate;
    public bool isBossSpawner;
    List<GameObject> spawnedEnemies;
    Transform playerTransform;


    [HideInInspector]
    public bool bossGenerated;

	// Use this for initialization
	void Start ()
    {
        bossGenerated = false;
        playerTransform = ServiceLocator.GetService<PlayerController>().transform;
        spawnedEnemies = new List<GameObject>();

        if(!isBossSpawner)
            Invoke("Generate", Random.Range(2f, SpawnRateInSec / 2));

	}

    void Generate()
    {
        if(ServiceLocator.GetService<GameManager>().isWaveOn && spawnedEnemies.Count < MaxEnemiesToGenerate && ServiceLocator.GetService<GameManager>().currentTotalSpawnedEnemies < ServiceLocator.GetService<GameManager>().CurrentMaxEnemiesCount)
        {
            //Debug.Log(Vector3.Distance(transform.position, playerTransform.position));
            if (Vector3.Distance(transform.position, playerTransform.position) >= 8)
            {
                spawnedEnemies.Add(Instantiate(AssociatedEnemies[Random.Range(0, AssociatedEnemies.Count)], transform.position, Quaternion.identity));
                spawnedEnemies[spawnedEnemies.Count - 1].transform.parent = transform;

                ServiceLocator.GetService<GameManager>().CurrentEnemiesCount++;
                Invoke("Generate", SpawnRateInSec);
            }
            else
            {
                Invoke("Generate", SpawnRateInSec / 3f);
            }
        }
        else
        {
            Invoke("Generate", SpawnRateInSec / 2);
        }
    }
    public void GenerateBoss()
    {
        if (isBossSpawner && ServiceLocator.GetService<GameManager>().isBossON  && !bossGenerated)
        {
            bossGenerated = true;
            print("BossShouldGenerate");
            spawnedEnemies.Add(Instantiate(AssociatedEnemies[Random.Range(0, AssociatedEnemies.Count)], transform.position, Quaternion.identity));
            spawnedEnemies[spawnedEnemies.Count - 1].transform.parent = transform;

            ServiceLocator.GetService<GameManager>().CurrentEnemiesCount++;
        }
    }

    public void EnemyDied(GameObject enemyObject)
    {
        bossGenerated = false;
        spawnedEnemies.Remove(enemyObject);
        ServiceLocator.GetService<GameManager>().CurrentEnemiesCount--;
    }

    public void SpawnOne()
    {
        spawnedEnemies.Add(Instantiate(AssociatedEnemies[Random.Range(0, AssociatedEnemies.Count)], transform.position, transform.rotation));
        spawnedEnemies[spawnedEnemies.Count - 1].transform.parent = transform;
        ServiceLocator.GetService<GameManager>().CurrentEnemiesCount++;
    }
}
