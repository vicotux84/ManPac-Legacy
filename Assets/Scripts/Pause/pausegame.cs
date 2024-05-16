using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pausegame : MonoBehaviour{


    // Update is called once per frame
    void Update()
    {
        if(Time.timeScale==0){
            Debug.Log("pause");
             }
        
    }
}
