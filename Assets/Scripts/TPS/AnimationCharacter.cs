using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationCharacter : MonoBehaviour{
    public Animator animator;
    
   public void Animate(bool Speed){
        animator.SetBool("Walk", Speed);
    }
}
