using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformsGenerator : MonoBehaviour {

    public GameObject[] platformPrefabs;

    
    public float endOfMap = 32f;

    public float minHeight = -1f;
    public float maxHeight = 3.5f;

    public float minDistance = 4;
    public float maxDistance = 8;

    [Space]
    public float currentPos = 0;

    public List<GameObject> platformList;

    void Start () {




        while(currentPos <= endOfMap)
        {
            GameObject randomPlatform = platformPrefabs[ Mathf.RoundToInt(Random.Range(0, platformPrefabs.Length)) ];
            GameObject platform;
            float height = Random.Range(minHeight, maxHeight);
            float distance = Random.Range(minDistance, maxDistance);
            currentPos += distance;


            platform = Instantiate(randomPlatform);
            platform.transform.position = new Vector3(currentPos, height);

            
            platformList.Add(platform);
        }

        print(platformList.Count);

        gameObject.GetComponent<PlatformBezierLogic>().SetUp(platformList.ToArray());

       
        


    
	}
	
	
}
