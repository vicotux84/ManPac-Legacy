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
    public static int HighScore;

    public GameState currentGameState;
    public float espera_Reespawn;
    public string MainMenu;
    [Header ("UI")]
    [SerializeField] int Colectables;
    [SerializeField] int Life,Healt;

    [Header ("Asignaciones Previas")]  
    [SerializeField] SoundFXManagerv FXManager;
    [Header ("Players")] 
    [SerializeField] GameObject Player;
    [SerializeField] GameObject Player1,Player2;
    [SerializeField] Vector3 position;    
    [SerializeField]  string Tag_Player="Player";
    [Header ("Sound Efects")]
    [SerializeField]float volMusic, volSFX;    
    public AudioClip Dead;
    public AudioClip Danger;
    
     
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
        Time.timeScale = 1;     
        
	   SceneManager.LoadScene (SceneToLoad);
       if(SceneToLoad==MainMenu){
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
         SceneManager.LoadScene (MainMenu);

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
    }
    void livesCount(){
        if(lives==0){
            GameOver(MainMenu);
           
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

