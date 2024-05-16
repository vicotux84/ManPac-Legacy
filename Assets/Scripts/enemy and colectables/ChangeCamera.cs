using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCamera : MonoBehaviour{

    public Camera TopDown, SideScroll;
    public GameObject PlayTop, PlaySide;
    void Start()
    {
        TopDown.enabled=true;
        SideScroll.enabled=false;
        PlayTop.SetActive(true);
        PlaySide.SetActive(false);

    }

    // Update is called once per frame
    public void UpdateCamera(bool Ena){
        TopDown.enabled=Ena;
        SideScroll.enabled=!Ena;
        PlayTop.SetActive(Ena);
        PlaySide.SetActive(!Ena);

    }
}
