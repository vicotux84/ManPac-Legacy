using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorsTransporter : MonoBehaviour{
    [SerializeField] string TagPlayer;
	[SerializeField] AudioClip _Door;
	[SerializeField]SoundFXManagerv FXManager;
	[SerializeField]int Sound;
    public GameObject Player;
    public Transform Destino;
    public Vector3 Offset;
    void Awake(){
		SearchManagers();
      }
      private void Update() {
		SearchManagers();
        } 


	void SearchManagers() {
		if(FXManager==null){
		FXManager=FindObjectOfType<SoundFXManagerv>();
			} 
		if (Player == null)
			Player=GameObject.FindGameObjectWithTag(TagPlayer);
		} 

    void OnTriggerEnter(Collider other){
		if (other.tag == TagPlayer ){
       other.transform.position=Destino.transform.position+Offset;
	   FXManager.SoundPlay(_Door,Sound);
			}
    } 
}
