using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour{
    [SerializeField] string TagPlayer="Jugador";
    [SerializeField][Range(1,100)] int Value=1;
    [SerializeField]bool IsCoin;
    [SerializeField] GameObject Orco;
    [SerializeField]Animator anim;
    public EnemyGrunt_ia  ScriptIA;
    [SerializeField]bool IsDead;
    [SerializeField] CapsuleCollider ColiderEnemy;
    [SerializeField] AudioClip _Coin;
    [SerializeField] AudioClip _Dead;
    [SerializeField] Rigidbody RB;
    [SerializeField]int _Sound;


    GameManager GameManager;
    SoundFXManagerv FXManager;

    void Update(){
    }
    void Awake(){
        IsDead=false;
        SearchManagers();
        }
      
       void SearchManagers() {      
           if(GameManager==null){
        GameManager=FindObjectOfType<GameManager>();
        if(FXManager==null){
        FXManager=FindObjectOfType<SoundFXManagerv>();
        } 
      }   
    }

    
    void OnTriggerEnter(Collider other){
		if (other.tag == TagPlayer){
      FXManager.SoundPlay(_Coin, _Sound);
      GameManager.Hearts-=Value;
      GameManager.Points-=(Value/2);
      if (IsCoin==true&& IsDead==false){
        IsCoin=false;
        IsDead=true;
        FXManager.SoundPlay(_Dead, _Sound);
        GameManager.Points+=Value;
         anim.SetBool("Dead",true);
        ColiderEnemy.isTrigger = false;
        ColiderEnemy.radius=0.1f;
        ColiderEnemy.height=0.1f;
        transform.position=new Vector3(transform.position.x,0,transform.position.z);
         //RB.useGravity = true;         
         ScriptIA.enabled=false;
         Orco.SetActive(false);
         
         Value=0;
        }
      }
  } 
}
