using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_Controller : MonoBehaviour{
    private Vector3 moveDirection = Vector3.zero;
   [SerializeField]bool CursorIsvisble=false;
    [SerializeField]string Horizontal, Vertical;
    public float Speed;
    private  CharacterController _controller;
    Vector3 _move;
    float Axis_Horizontal, Axis_Vertical;
    Animator _anim;
    private void Start() {
        _anim=gameObject.GetComponent<Animator>();
        _controller=GetComponent<CharacterController>();
    }
    void Update(){
        Axis_Horizontal=Input.GetAxis(Horizontal);
        Axis_Vertical=Input.GetAxis(Vertical);
        _move=new Vector3(Axis_Vertical,0,Axis_Horizontal);
        Cursor.visible = CursorIsvisble;
        Rotate(_move);
        Movement(_move);       
    } 

        void Movement(Vector3 Moverse){ 
       
    // _move.Normalize();
        _controller.Move(Moverse * Time.deltaTime * Speed);       
          if (Axis_Horizontal!=0){           
                 _anim.SetBool("IsRunning",true);             
        }if (Axis_Horizontal==0){                 
             _anim.SetBool("IsRunning",false);             
        }if (Axis_Vertical>=0.1f){                 
             _anim.SetFloat("Speed",1.0f);             
        }if (Axis_Vertical==0){                 
             _anim.SetFloat("Speed",0.0f);             
        }if (Axis_Vertical<=-1f){                 
             _anim.SetFloat("Speed",1.0f);             
        }
        
    
    } 
      

void Rotate(Vector3 move){
        Vector3 Rotation=new Vector3 (move.x,0, move.z);        
         if (Axis_Horizontal!=0 || Axis_Vertical!=0){
          transform.rotation= Quaternion.LookRotation(Rotation);
        }
    }
    
}
