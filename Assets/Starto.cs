using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Starto : MonoBehaviour
{


  


    // Start is called before the first frame update

    [RuntimeInitializeOnLoadMethod]
    static void OnRuntimeMethodLoad()
    {
         Debug.Log("After Scene is loaded and game is running");
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
