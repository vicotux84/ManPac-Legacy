using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(AudioSource))]
public class PointGame : MonoBehaviour{

    public Text PointText, Ganaste_text;
    public string Ganaste= "Ganaste!!!";
    public int _colectables, _total_Items;
    public AudioClip Ganaste_Audio;
    //public CameraController _Camera;
    public GameObject QuitButton,PauseButton;
    
    AudioSource audioSource;

    void Update() {
		
    }
    private void Start() {
        Ganaste_text.text="";
        audioSource=GetComponent<AudioSource>();
    }

    public void SoundFX(AudioClip Audio) {
        audioSource.clip=Audio;
        audioSource.Play();
    }

    public void Update_Colectables(){
        PointText.text =": "+ _colectables.ToString();
        if(_colectables==_total_Items){
        Ganaste_text.text=Ganaste;
        SoundFX(Ganaste_Audio);
         //_Camera.enabled=false;
         QuitButton.SetActive(true);
         PauseButton.SetActive(false);
		Time.timeScale = 0;
        }
    }
}
