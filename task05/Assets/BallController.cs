using UnityEngine;
using System.Collections;

public class BallController : MonoBehaviour {

	public float IntitialAngle = 0.0f;
	public float InputForceScale =  50.0f;
	public AudioSource audioSource;
	public AudioClip audioForWall;
	public AudioClip audioForPedal;
	public Rigidbody rigidBody;
	void Start () {
		
	}
	/*
	void Update () {
		
		rigidBody.GetComponent<Rigidbody> ();
		Vector3 force = Quaternion.Euler (0, IntitialAngle, 0) * Vector3.forward;
		force = force * InputForceScale;
		rigidBody.AddForce (force);

	}
	*/
	public float jumpPower;
	public float doubleJumppower;
	public int jumpCount;
	public float maxHieght;
	private float targetHieght;
	private int j;

	public bool isGrounded = true;
	public bool isJumping = false;
	float ReachHieght()
	{
		float v = 0;
		float u = GetComponent<Rigidbody> ().velocity.y;
		float a = Physics.gravity.y;
		float s = (Mathf.Pow (v, 2) - Mathf.Pow (u, 2)) / (2 * a);
		return s;
	}
	void Update () {
		if (ReachHieght () + transform.position.y >= targetHieght) 
		{
			isJumping = false;
		}
		if (Input.GetButtonDown ("Horizontal") && isGrounded == true && j != 0) 
		{    
			isJumping = true;
			targetHieght = maxHieght + transform.position.y;
			Vector3 velo = GetComponent<Rigidbody> ().velocity;
			velo.y = 0;
			GetComponent<Rigidbody> ().velocity = velo;

			jump ();
			j = j - 1;
		}
		else if(Input.GetButtonUp("Horizontal"))
		{
			isJumping = false;
		}
		if (isJumping) 
		{
			jump();
		}
		if (Input.GetButtonDown ("Horizontal") && isGrounded == false && j != 0)
		{    
			Vector3 velo = GetComponent<Rigidbody> ().velocity;
			velo.y = 0;
			GetComponent<Rigidbody> ().velocity = velo;

			Doublejump ();
			j = j - 1;
		}
	}

	void jump (){
		GetComponent<Rigidbody> ().AddForce (transform.up * jumpPower);
		Debug.Log("Jumped");
	}
	void Doublejump (){
		GetComponent<Rigidbody> ().AddForce (transform.up * doubleJumppower);
	}    
	void OnCollisionEnter(Collision other) {
		Debug.Log("Pusher");
		if(other.collider.tag == "Pusher")
		{    
			j = jumpCount;
			isGrounded = true;
		}
		else 
		{
			isGrounded = true;
		}
	}
}