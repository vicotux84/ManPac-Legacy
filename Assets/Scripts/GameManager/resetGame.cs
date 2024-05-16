using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class resetGame : MonoBehaviour{
    [SerializeField] GameManager gamemanager;

    void Start(){
        gamemanager = FindObjectOfType<GameManager>();
    }
    public void LoadScene(string Scene){
        SceneManager.LoadScene (Scene);
        gamemanager.StartGame();
    }
    
}
