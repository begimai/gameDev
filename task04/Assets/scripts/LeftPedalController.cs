using UnityEngine;
using System.Collections;

public class LeftPedalController : MonoBehaviour {

	private GameObject pedal;
	private GameObject ball;
	public float InputForceScale = 10.0f;
	public float ForceAppliedToBallScale = 10.0f;

	public Rigidbody rigidBody;

	void Start () {
		rigidBody = GetComponent<Rigidbody> ();
	}

	void FixedUpdate(){
		ball = GameObject.FindGameObjectWithTag ("ball");
		float verticalAxis = ball.transform.position.x ;
		Vector3 force = new Vector3 (verticalAxis, 0, 0); 
		force = force * InputForceScale;
		rigidBody.AddForce (force);
	}

	void OnCollisionEnter(Collision collision){
		GameObject gameObject = collision.gameObject;
		if(gameObject.CompareTag("ball")){
			GameObject ball = gameObject;
			float shift = ball.transform.position.z - transform.position.z;
			Vector3 force = new Vector3 (0, 0, shift);
			force = force * ForceAppliedToBallScale;
			ball.GetComponent<Rigidbody>().AddForce (force);
		}
	}
}
