using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChange : MonoBehaviour{

    [SerializeField]bool CursorIsvisble=false;
    [SerializeField]Camera Fps,Tps;
    
    void Start(){
    Cursor.visible = CursorIsvisble;        
    }
    public void Fpc(){
    Fps.enabled=true;
    Tps.enabled=false;   
    }
    public void Tpc(){
    Fps.enabled=false;
    Tps.enabled=true;   
    }

    // Update is called once per frame
    void Update(){
    Cursor.visible = CursorIsvisble;
    if (Input.GetButton("Fps"))  {
        Fpc();
    }if (Input.GetButton("Tps"))  {
        Tpc();
    }
}
}
