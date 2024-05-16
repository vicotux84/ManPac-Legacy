using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeadLimit : MonoBehaviour{
    
    [SerializeField]string TagJugador;
   [SerializeField]GameManager GameManager;
    public GameObject Player;
    public Vector3 Destino;
    public float waitTime=3;
    public Text levelText;
    CharacterController controller;

    void Awake(){
      SearchPlayer();
      }
      void OnTriggerEnter(Collider other){
		if (other.tag == TagJugador){
        GameManager.lives--;
       Player.transform.position=Destino;
        levelText.text="lives: 0" + GameManager.lives.ToString();
        Invoke("DeadL", waitTime);
        
        

        }
    } 
    private void DeadL() {
      Player.transform.position=Destino;
      levelText.text="";      
      
    }
    private void Update() {
     SearchPlayer();
    }
    private void SearchPlayer() {
      if(GameManager==null){
        GameManager=FindObjectOfType<GameManager>();
        }
        Player=GameObject.FindGameObjectWithTag(TagJugador);
    }
  } 
