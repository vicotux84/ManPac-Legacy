using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Follow : MonoBehaviour{
	
	float smoothSpeed=1f;
	GameObject Player;

	[Header ("Camera Follow")]
	[SerializeField] Vector3 _Distancia_a_seguir=Vector3.zero;
	[SerializeField] [Range (-90, 90.0f)]float RotX=45.0f, RotY=0;
    [SerializeField] string Tag_Seguir="player";


     void Awake() {
        if (Player == null)
            Player = GameObject.FindWithTag(Tag_Seguir);
            
    }
void Camera_follow(){
		Vector3 Seguir=Player.transform.position +_Distancia_a_seguir;
		Vector3 Smooth=Vector3.Lerp(Player.transform.position,Seguir,smoothSpeed);
		transform.position = Smooth;
		transform.eulerAngles = new Vector3(RotX,RotY,0);
		}
    void LateUpdate(){
        if (Player == null) {
            Player = GameObject.FindWithTag(Tag_Seguir);
            print("buscando jugador");
        } else {
           Camera_follow();     
        }
    }
}
