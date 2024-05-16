using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPS_rotar_controller : MonoBehaviour {

	public Transform Rotate;
	public bool lockCursor;
	[Range(0, 10)] public float lookSensitivity;

	void Start(){
		if(lockCursor) {
			Cursor.lockState = CursorLockMode.Locked;
			Cursor.visible = false;
		}
	}
	void Update(){
		rotar_Camera();
	}
	private void LateUpdate() {

	}


	private void rotar_Camera() {
		Rotate.Rotate(0, Input.GetAxis("Mouse X") * lookSensitivity, 0);
	}
}
