using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour{
    [Header("Camera")]
	public Transform cam;
    public bool lockCursor;
    [Range(0, 10)] public float lookSensitivity;
    
    void Start(){
         if(lockCursor) {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = true;
            }
        }
    void Update(){
        rotar_Camera();
        }
        private void LateUpdate() {
            
        }


    private void rotar_Camera() {
		cam.Rotate(0, Input.GetAxis("Mouse X") * lookSensitivity, 0);
    }
}
