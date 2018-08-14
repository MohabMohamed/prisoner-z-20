using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformsGenerator : MonoBehaviour {

    [Header("• References")]
    public GameObject firstPlatform;
    public GameObject PlatformParent;
    public GameObject[] platformPrefabs;

    [Space]
    [Header("• Variables")]
    public float endOfMap;

    public float minDistance;
    public float maxDistance;
    
    [Space]
    public float high_minHeight;
    public float high_maxHeight;

    public float low_minHeight;
    public float low_maxHeight;



    [Space]
    public List<GameObject> platformList;
  //  public List<GameObject> lowplatformList;

    private float currentPos = 0;
    private int tmphigh;
    void Start () {


        platformList.Add(firstPlatform);
       // lowplatformList.Add(firstPlatform);

        while(currentPos <= endOfMap)
        {
            GameObject randomPlatform = platformPrefabs[Mathf.RoundToInt(Random.Range(0, platformPrefabs.Length))];
            GameObject platform;
            float distance = Random.Range(minDistance, maxDistance);
            currentPos += distance;

            if (Random.Range(0f,1f) <= .8f && tmphigh < 2) // high platform
            {
                float height = Random.Range(high_minHeight, high_maxHeight);
                platform = Instantiate(randomPlatform , new Vector3(currentPos, height),randomPlatform.transform.rotation ,PlatformParent.transform);
                platform.name = "HighPlatform";
                tmphigh++;
            }
            else // low platform
            {
                float height = Random.Range(low_minHeight, low_maxHeight);
                platform = Instantiate(randomPlatform, new Vector3(currentPos, height), randomPlatform.transform.rotation, PlatformParent.transform);
                platform.name = "LowPlatform";
                tmphigh = 0;

               // lowplatformList.Add(platform);
            }

            platformList.Add(platform);

        }

        

        gameObject.GetComponent<PlatformBezierLogic>().SetUp(platformList.ToArray());

       
        


    
	}
	
	
}
