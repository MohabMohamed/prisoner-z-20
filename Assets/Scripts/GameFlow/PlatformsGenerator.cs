using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformsGenerator : MonoBehaviour {

    [Header("• References")]
    public GameObject PlatformParent;
    public GameObject[] platformPrefabs;

    [Space]
    [Header("• Variables")]
    public float endOfMap = 32f;

    public float minHeight = -1f;
    public float maxHeight = 3.5f;

    public float minDistance = 4;
    public float maxDistance = 8;

    [Space]
    private float currentPos = 0;
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

            platform.transform.parent = PlatformParent.transform;
            platformList.Add(platform);
        }

        

        gameObject.GetComponent<PlatformBezierLogic>().SetUp(platformList.ToArray());

       
        


    
	}
	
	
}
