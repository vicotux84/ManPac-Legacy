using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class EnemyGrunt_ia : MonoBehaviour{

    NavMeshAgent _Agent;
    Vector3 moveTo;
    Animator anim;
    [SerializeField]string TagJugador;
    public Transform Destino;

    void Agent(){        
    _Agent.SetDestination(moveTo);   
    anim.SetBool("IsRun", true);
    }

    void Awake() {
        mover();
        _Agent=GetComponent<NavMeshAgent>();
        anim=GetComponent<Animator>();
    }

    void Update(){
        Agent(); 
        mover();
        }
    void OnTriggerEnter(Collider other) {
        if (other.tag == TagJugador){
          anim.SetBool("Atack", true);
            }
        }
    private void OnTriggerExit(Collider other) {
       if (other.tag == TagJugador){
          anim.SetBool("Atack", false);
        }
    }
    void mover(){
    moveTo=Destino.position;
    }
    
     

}
