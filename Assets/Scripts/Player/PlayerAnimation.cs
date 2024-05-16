using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerAnimation : MonoBehaviour{
    
    Animator animator;
    
    void Awake(){
        animator=GetComponent<Animator>();
        
    }
    public void Animation(float MoveX,float MoveY){
        animator.SetFloat("SpeedY",MoveX);
        animator.SetFloat("SpeedX",MoveY);    
    }
}
