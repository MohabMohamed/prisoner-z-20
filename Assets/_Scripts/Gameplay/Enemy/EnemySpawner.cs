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



	// Use this for initialization
	void Start ()
    {
        playerTransform = ServiceLocator.GetService<PlayerController>().transform;
        spawnedEnemies = new List<GameObject>();

        if(!isBossSpawner)
            Invoke("Generate", Random.Range(2f, SpawnRateInSec / 2));

	}

    void Generate()
    {
        if(Vector3.Distance(transform.position , playerTransform.position) >= 8 && ServiceLocator.GetService<GameManager>().isWaveOn && spawnedEnemies.Count < MaxEnemiesToGenerate && ServiceLocator.GetService<GameManager>().currentTotalSpawnedEnemies < ServiceLocator.GetService<GameManager>().CurrentMaxEnemiesCount)
        {
            spawnedEnemies.Add(Instantiate(AssociatedEnemies[Random.Range(0, AssociatedEnemies.Count)], transform.position, Quaternion.identity));
            spawnedEnemies[spawnedEnemies.Count - 1].transform.parent = transform;
            
            ServiceLocator.GetService<GameManager>().CurrentEnemiesCount++;
        }
        Invoke("Generate", SpawnRateInSec);

    }
    public void GenerateBoss()
    {
        
        if (isBossSpawner && ServiceLocator.GetService<GameManager>().isWaveOn && ServiceLocator.GetService<GameManager>().isBossON )
        {
            print("BossShouldGenerate");
            spawnedEnemies.Add(Instantiate(AssociatedEnemies[Random.Range(0, AssociatedEnemies.Count)], transform.position, Quaternion.identity));
            spawnedEnemies[spawnedEnemies.Count - 1].transform.parent = transform;

            ServiceLocator.GetService<GameManager>().CurrentEnemiesCount++;
        }
    }

    public void EnemyDied(GameObject enemyObject)
    {
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
