using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManagerText: MonoBehaviour{
    public Text ganastes;
    public float waitTime=3;
    public string NextLevel, MainMenu="MainMenu";
    [SerializeField] GameManager gamanager;
    bool GameStart;
    
#region Funtion Unity
    void awake(){
        if (gamanager==null){
             gamanager = FindObjectOfType<GameManager>();
             }
    }

   void Update(){
       StartOtro();
      if ( gamanager.currentGameState==GameState.pause){
          ganastes.text="el juego esta pausado";  
      }

    }
    void Start(){
        gamanager = FindObjectOfType<GameManager>();
    }
#endregion

#region Funtion publics Creates
public void Dead(int liives){
    ganastes.text="te quedan : " + liives+ " vidas";
}

public void NextBola(){
    ganastes.text="lives:"+GameManager.lives.ToString();
        ganastes.text=" ";
    }
    public void ganaste(){
        ganastes.text="";
         gamanager.GameOver(NextLevel);  
    }

    public void StartOtro(){
        if (GameManager.Coins==0 && GameStart== true){
            if(NextLevel!=MainMenu){
                ganastes.text="Siguiente Nivel";
            }
            
            if(NextLevel==MainMenu){
                ganastes.text="Juego terminado";
            }
            GameStart=false;
            Invoke ("ganaste" ,waitTime);       
        }if(GameManager.Coins!=0){
            GameStart=true;
            gamanager.StartGame();
            ganastes.text=""; 
        }
}  
    #endregion
}
    

 
