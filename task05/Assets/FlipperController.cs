using UnityEngine;
using System.Collections;

public class FlipperController : MonoBehaviour {

	public float ForceAppliedToBallScale;
	public Rigidbody rb;
	void Start() {
		rb = GetComponent<Rigidbody>();
	}
	void FixedUpdate() {
		
	}
	void OnCollisionEnter(Collision c)
	{
		// force is how forcefully we will push the player away from the enemy.

		// If the object we hit is the enemy
		if(gameObject.CompareTag("ball")){
			GameObject ball = gameObject;
			float shift = ball.transform.position.z - transform.position.z;
			Vector3 force = new Vector3 (0, 0, shift);
			force = force * ForceAppliedToBallScale;
			ball.GetComponent<Rigidbody>().AddForce (force);
		}
	}
}
