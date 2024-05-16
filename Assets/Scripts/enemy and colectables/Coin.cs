using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour{
    [SerializeField] string TagPlayer="Jugador";
    [SerializeField] SphereCollider ColiderCoin;
    [SerializeField] GameObject thisCoin;
    [SerializeField]int Points=10;    
    [SerializeField] AudioClip _Coin;
    [SerializeField]SoundFXManagerv FXManager;
    [SerializeField]int Sound;
    
    GameManager GameManager;
    


    void OnTriggerEnter(Collider other){
		if (other.tag == TagPlayer){      
        GameManager.Points+=Points;
        GameManager.Coins--;
       thisCoin.SetActive(false);
       ColiderCoin.enabled=false;
       FXManager.SoundPlay(_Coin, Sound);
       }
    }  
    void Update() {
      SearchManagers();
    }
    void Awake(){
      SearchManagers();
      GameManager.Coins++;
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
