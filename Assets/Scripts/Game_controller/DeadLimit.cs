using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeadLimit : MonoBehaviour{
    
    public string TagJugador;     
    public Vector3 Destino;
    public string LevelNum;
    public Text levelText;
    public int EsperarTexto;
    
    GameManager GameManager;
    GameObject Player;


    void Awake(){
      SearchPlayer();
       levelText.text="Level: "+LevelNum;
       Invoke("DeadL", EsperarTexto);
      }
      void OnTriggerEnter(Collider other){
		if (other.tag == TagJugador){
        GameManager.lives--;
       Player.transform.position=Destino;
        levelText.text="lives: 0" + GameManager.lives.ToString();
        Invoke("DeadL", EsperarTexto);
       }
    } 
    private void DeadL() {
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
