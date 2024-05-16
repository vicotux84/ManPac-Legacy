using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healt : MonoBehaviour{
    [SerializeField] string TagPlayer="Jugador";
    [SerializeField][Range(-100,100)] int HealtValue=10;
    [SerializeField] SphereCollider ColiderHealt;
    [SerializeField] GameObject thisHealt;
    [SerializeField] AudioClip _Healt;
    [SerializeField] int _Sound;
    
    GameManager GameManager;
    SoundFXManagerv FXManager;
    
     void Update() {
      SearchManagers();
    }
    void Awake(){
      SearchManagers();
    }  
    void OnTriggerEnter(Collider other){
		if (other.tag == TagPlayer){         
           GameManager.Hearts+=HealtValue;
           GameManager.Points+=(HealtValue/2);
            thisHealt.SetActive(false);
            ColiderHealt.enabled=false;
            FXManager.SoundPlay(_Healt, _Sound);           
      }
  } 
  void SearchManagers() {
           if(GameManager==null){
        GameManager=FindObjectOfType<GameManager>();
        if(FXManager==null){
        FXManager=FindObjectOfType<SoundFXManagerv>();
        }   
      }
    }




}
