using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    public List<GameObject> AssociatedEnemies;

    public float SpawnRateInSec;
    public int MaxEnemiesToGenerate;
    public float GeneratedSize;

    List<GameObject> spawnedEnemies;
    Transform playerTransform;



	// Use this for initialization
	void Start ()
    {
        playerTransform = ServiceLocator.GetService<PlayerController>().transform;
        spawnedEnemies = new List<GameObject>();
        Invoke("Generate", Random.Range(0 , SpawnRateInSec/2));
	}

    void Generate()
    {
        if(Vector3.Distance(transform.position , playerTransform.position) >= 5 && ServiceLocator.GetService<GameManager>().isGameON && spawnedEnemies.Count < MaxEnemiesToGenerate && ServiceLocator.GetService<GameManager>().CurrentEnemiesCount < ServiceLocator.GetService<GameManager>().MaxConcurrentEnemiesCount)
        {
            spawnedEnemies.Add(Instantiate(AssociatedEnemies[Random.Range(0, AssociatedEnemies.Count)], transform.position, transform.rotation, transform ));

            spawnedEnemies[spawnedEnemies.Count - 1].transform.localScale = new Vector3(GeneratedSize,GeneratedSize);

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
