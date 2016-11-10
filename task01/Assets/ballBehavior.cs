using UnityEngine;
using System.Collections;

public class BallBehavior : MonoBehaviour {
	public float ForceScale = 10.0f;
	public Rigidbody rb;

	void Start () {
		rb.GetComponent<Rigidbody> ();
	}
	
	void FixedUpdate () {
		float horizontal = Input.GetAxis ("Horizontal");
		float vertical = Input.GetAxis ("Vertical");

		Vector3 force = new Vector3 (vertical, 0.0f, -horizontal);
		force = force * ForceScale;

		rb.AddForce (force);	
	}
}
