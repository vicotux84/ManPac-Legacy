using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Controller : MonoBehaviour
{
    [Header("Player Movement")]
    [SerializeField][Range(0.1f, 10.0f)]float MaxSpeed=0.1f;

    private new Rigidbody rigidbody;
    string Axis_Horizontal="Horizontal";
    float MoveDirection=0;
    Animator anim;

    private void Start(){
        rigidbody=GetComponent<Rigidbody>();
        anim=gameObject.GetComponent<Animator>();
        Cursor.visible = true; 
       }
     
    void Update(){
        MoveDirection=-Input.GetAxis(Axis_Horizontal);
        Movement(MoveDirection);
        
    } 

        void Movement(float Horizontal){
        rigidbody.velocity=new Vector2(Horizontal*MaxSpeed, rigidbody.velocity.y);
       flip(Horizontal);
       anim.SetFloat("Speed",Mathf.Abs(Horizontal));
       //anim.SetFloat("Speed",Horizontal);
       flip(Horizontal);
    } 
    void flip(float H){
        if(H<=0.1f){
            //transform.localScale=Vector3.one;
            transform.localRotation = Quaternion.Euler(0, 0, 0);
                       
            }else if(H>=-0.0f){
           //transform.localScale=new Vector3(-1,1,1); 
           transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
    }
}
