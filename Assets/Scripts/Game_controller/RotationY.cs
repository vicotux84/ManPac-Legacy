using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationY : MonoBehaviour{
    
    [SerializeField] Vector3 Rotation;

    void FixedUpdate(){ 
        XYZRotation();
        }
        void XYZRotation(){
         
         transform.Rotate(Rotation); 
         }

}
