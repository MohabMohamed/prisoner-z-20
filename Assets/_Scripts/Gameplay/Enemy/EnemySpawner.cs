using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    public List<GameObject> AssociatedEnemies;

    public float SpawnRateInSec;
    public int MaxEnemiesToGenerate;

    List<GameObject> spawnedEnemies;
    Transform playerTransform;



	// Use this for initialization
	void Start ()
    {
        playerTransform = ServiceLocator.GetService<PlayerController>().transform;
        spawnedEnemies = new List<GameObject>();
        Invoke("Generate", Random.Range(2 , SpawnRateInSec/2));
	}

    void Generate()
    {
        if(Vector3.Distance(transform.position , playerTransform.position) >= 8 && ServiceLocator.GetService<GameManager>().isWaveOn && spawnedEnemies.Count < MaxEnemiesToGenerate && ServiceLocator.GetService<GameManager>().currentTotalSpawnedEnemies < ServiceLocator.GetService<GameManager>().CurrentMaxEnemiesCount)
        {
            spawnedEnemies.Add(Instantiate(AssociatedEnemies[Random.Range(0, AssociatedEnemies.Count)], transform.position, transform.rotation));
            spawnedEnemies[spawnedEnemies.Count - 1].transform.parent = transform;
            
            ServiceLocator.GetService<GameManager>().CurrentEnemiesCount++;
        }

        Invoke("Generate",  SpawnRateInSec);
    }

    public void EnemyDied(GameObject enemyObject)
    {
        spawnedEnemies.Remove(enemyObject);
        ServiceLocator.GetService<GameManager>().CurrentEnemiesCount--;
    }

}
