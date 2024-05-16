#region previous assignments
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
#endregion
#region GameStates
public enum GameState{
    inGame, pause, gameOver
}
#endregion

public class GameManager : MonoBehaviour{
    
#region Asignaciones previas
    public static GameManager gameManager;
    public static GameManager GM_Lives;
    public static int lives=10,Points=0, Coins=0,Hearts=100;
    [SerializeField] SoundFXManagerv FXManager;

    [SerializeField] GameObject Player, Player1,Player2;
    [SerializeField] Vector3 position;
    public float espera_Reespawn;
    //int prefabPlayer=0;
    [SerializeField]  string Tag_Player="Player";

    public static int HighScore;
    public string NexLevel;
    public GameState currentGameState;
    [SerializeField]private int Life,Healt, Colectables;
    [SerializeField]float volMusic, volSFX;

    [Header ("Sound Efects")]    
    public AudioClip Dead;
    public AudioClip Danger;
    

    private bool _IsCoin=false;
    //public bool IsCoin{
        //get=>_IsCoin;
        //set=>_IsCoin=value;
       // }
    
     
#endregion
    void Awake() {
         Singleton();
         SearchManagers();
    }
    void Update(){
        livesCount();
        UpdateInts();
        HeartsCount();
        HealtScore();
        SearchManagers();      
    }
#region metodos extras

  public void StartGame(){
        currentGameState=GameState.inGame;
        Time.timeScale = 1;
    }
    public void PauseGame(){
        currentGameState=GameState.pause;
        Time.timeScale = 0;
    }
    public void GameOver(string SceneToLoad){
        //currentGameState=GameState.gameOver;
        Time.timeScale = 1;     
        
	   SceneManager.LoadScene (SceneToLoad);
       if(SceneToLoad=="MainMenu"){
           if(HighScore<=Points){
            HighScore=Points;
            Debug.Log("gameOver");
        }
           ResetGame();
       }
        
	}
    public void HealtScore(){
     if (Hearts >= 300){
         Hearts=100;
        lives++;        
        }
    }
    public void DeadMain() {
        ResetGame();
         SceneManager.LoadScene ("MainMenu");

    }

    public void ResetGame(){
        lives=8;
        Hearts=100;
        Points=0;
        Coins=0;     
        Time.timeScale =
        Time.timeScale == 0 ? 1: 0;
    }
    public void NextLive(){    
        Time.timeScale = 1;
		Instantiate(Player1,position,Quaternion.identity);
         //Player.transform.position=position;
         //Player.SetActive(true);  
    }
    void livesCount(){
        if(lives==0){
            GameOver("MainMenu");
           
        }        
    }
    void HeartsCount(){
        if(Hearts<=0){
            FXManager.SoundPlay(Dead, 3);
            Player.SetActive(false);
			Destroy (Player);
            lives--;
            Hearts=100;           
           Time.timeScale = 0;
            Invoke("NextLive", espera_Reespawn);
        }
    }
    void UpdateInts(){
        Life=lives;
        Healt=Hearts;        
        Colectables=Coins;
    }
    public void PlayerChoise(int value) {
        if(value==1){
            Instantiate(Player1,position,Quaternion.identity);
        }
        if (value==2){
            Instantiate(Player2,position,Quaternion.identity);
    }
    }

    void SearchManagers() {
        
        if(FXManager==null){
        FXManager=FindObjectOfType<SoundFXManagerv>();
        }
        if (Player == null){
            Player = GameObject.FindWithTag(Tag_Player);
    }
        }
#endregion

#region singleton
        
    void Singleton(){
        if (gameManager!=null){
    Destroy(this.gameObject);      
    }else{ 
        gameManager=this;
    DontDestroyOnLoad(this.gameObject);
    }
}
#endregion    
}    

