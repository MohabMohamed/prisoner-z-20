
using UnityEngine;

public class Singlton : MonoBehaviour {
    public static Singlton instance;
    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

    }


}
