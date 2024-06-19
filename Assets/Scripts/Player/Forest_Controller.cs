using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Forest_Controller : MonoBehaviour{
    
    [SerializeField] Transform MeshPlayer;
    [SerializeField][Range(0.001f, 20.0f)]
    float Speed=0.1f,SpeedRun=0.1f;
    
   [SerializeField]bool CursorIsvisble=false;
   [SerializeField]string Horizontal="Horizontal", Vertical="Vertical", Run="Run";
    
    private  CharacterController _controller;
    
    float Axis_Horizontal, Axis_Vertical;
    Animator _anim;
    
    private void Awake(){
        _controller=GetComponent<CharacterController>();
        _anim=gameObject.GetComponent<Animator>();
		if(CursorIsvisble==false) {
			Cursor.lockState = CursorLockMode.Locked;
			Cursor.visible = false;
		}else {
			Cursor.visible =true;
		} 
     }
    void Update(){
		Axis_Horizontal=Input.GetAxis(Horizontal); 
		Axis_Vertical=Input.GetAxis(Vertical);

		Movement(Axis_Horizontal,Axis_Vertical);


    } 

        void Movement(float vertical, float horizontal){ 
        Vector3 Move=new Vector3(horizontal,0,vertical);
        Move.Normalize();            
            if(Input.GetButton(Run)){               
                _anim.SetBool("Runner", true); 
                _anim.SetFloat("IsRunV",Mathf.Abs(Axis_Vertical));
                _anim.SetFloat("IsRunH",Mathf.Abs(Axis_Horizontal)); 
                _controller.Move(Move * Time.deltaTime * SpeedRun); 
            }
            else{ 
                _anim.SetBool("Runner",false); 
                _anim.SetFloat("SpeedV",Mathf.Abs(Axis_Vertical));
                _anim.SetFloat("SpeedH",Mathf.Abs(Axis_Horizontal));
                _controller.Move(Move * Time.deltaTime * Speed);  
        }
        Rotate(Move);      
    } 
    void Rotate(Vector3 move){
        Vector3 Rotation=new Vector3 (move.x,0, move.z);        
         if (Axis_Horizontal!=0 || Axis_Vertical!=0){
          MeshPlayer.rotation= Quaternion.LookRotation(Rotation);
        }
    }
}
