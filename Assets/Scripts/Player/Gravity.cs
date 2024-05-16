using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour{
    public float gravity = 20.0F;
    private Vector3 JumpDirection = Vector3.zero;    
    CharacterController controller;
    
        void Awake() {
        controller = GetComponent<CharacterController>(); 
    }
    void Update() {
        Jumping();
     
     }   
        
     void Jumping() {      
        JumpDirection.y -= gravity * Time.deltaTime;
        controller.Move(JumpDirection * Time.deltaTime);
    }
}
