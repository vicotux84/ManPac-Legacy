using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colectable : MonoBehaviour{
	public int Value=10;
	public PointGame pointGame;
    public AudioClip _audio;
	public GameObject _Colectable;
	[SerializeField] Vector3 Rotation;

    void Start(){
		pointGame._total_Items+=Value;
    }
    private void OnTriggerEnter(Collider other) {
        if(other.tag=="Player"){
            _Colectable.SetActive(false);
			pointGame._colectables+=Value;
			pointGame.Update_Colectables();
            pointGame.SoundFX(_audio);
        }
    }
		
	void Update(){ 
		XYZRotation();
	}
	void XYZRotation(){
		transform.Rotate(Rotation*Time.deltaTime); 
	}
}
