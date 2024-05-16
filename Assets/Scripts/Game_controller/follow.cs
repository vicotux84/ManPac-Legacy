using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class follow : MonoBehaviour{

    
    [SerializeField] Vector3 _Distancia_a_seguir=Vector3.zero;
	[SerializeField][Range (0.01f, 1.0f)]float smoothSpeed=0.1f;
	[SerializeField][Range (0, 180.0f)]float RotateX=30.0f,RotateY=10;
    [SerializeField] Camera Main;
    void Camera_follow(){
		Vector3 Seguir=transform.position +_Distancia_a_seguir;
		Vector3 Smooth=Vector3.Lerp(Main.transform.position,Seguir,smoothSpeed);
		Main.transform.eulerAngles=new Vector3(RotateX,RotateY,0);
		Main.transform.position = Smooth;
		}
        void Start(){
            Main.transform.eulerAngles=new Vector3(RotateX,RotateY,0);

            if(Main==null){
            Main=Camera.main;
            }
        }

        void LateUpdate(){
		Camera_follow();
        }
}