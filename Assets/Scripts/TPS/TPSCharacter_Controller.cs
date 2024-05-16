using UnityEngine;

public class TPSCharacter_Controller : MonoBehaviour {

	public Animator animator;
    [Header("Movement")]
    public CharacterController controller;
    [Range(0.5f, 20)] public float walkSpeed,RunSpeed;
    public string Horizontal,Vertical,Run;
    private Vector3 velocity = Vector3.zero;

    void Update() {
        Movement();
    }
    private void Movement() {
        float _InputZ=Input.GetAxis(Vertical);
        float _InputX=Input.GetAxis(Horizontal);
		//Animate( _InputZ,_InputX);
        velocity.z =_InputZ;
        velocity.x =_InputX;
		velocity = transform.TransformDirection(velocity);
		velocity.y += Physics.gravity.y * Time.deltaTime;
		if(Input.GetButton(Run)){               
			animator.SetBool("Runner", true); 
			animator.SetFloat("IsRunV",_InputZ);
			animator.SetFloat("IsRunH",_InputX); 
			controller.Move(velocity * Time.deltaTime * RunSpeed); 
		}else{
			animator.SetBool("Runner", false); 
			animator.SetFloat("SpeedZ", _InputZ);
			animator.SetFloat("SpeedY", _InputX);
			controller.Move(velocity * Time.deltaTime * walkSpeed);
		}
        
    }
	public void Animate(float SpeedZ,float SpeedY){
		;
	}

}
