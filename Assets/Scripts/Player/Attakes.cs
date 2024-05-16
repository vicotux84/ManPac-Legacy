using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attakes : MonoBehaviour{
    
    [SerializeField] string  _Attack,_Block;
    Animator _anim;

    private void Start(){
        _anim=gameObject.GetComponent<Animator>();
       }
     
    void Update(){
        Attack();
        Block();        
    } 
        void Attack(){
            if(Input.GetButtonDown(_Attack)){
                _anim.SetBool("Hit", true);
            }else{
                 _anim.SetBool("Hit", false);
            }
        }
        void Block(){
            if(Input.GetButtonDown(_Block)){
                _anim.SetBool("Block", true);
            }else{
                 _anim.SetBool("Block", false);
            }
        }
}
