using UnityEngine;
using System.Collections;

public class ballBehavior : MonoBehaviour {


	public float InputForceScale = 10.0f;
	public float IntitialAngle = 45.0f;
	public AudioSource audioSource;
	public AudioClip audioForWall;
	public AudioClip audioForPedal;
	public Rigidbody rigidBody;
	// Use this for initialization
	void Start () {
		rigidBody.GetComponent<Rigidbody> ();
		Vector3 force = 
			Quaternion.Euler(0, IntitialAngle, 0)*
			Vector3.forward;
		force = force * InputForceScale;

		rigidBody.AddForce (force);
	}
	
	void OnCollisionEnter(Collision collision)
	{
		GameObject gameObject = collision.gameObject;
		if (gameObject.CompareTag ("pedal")) {
			audioSource.PlayOneShot (audioForPedal);
		} else if (gameObject.CompareTag ("wall")) {
			audioSource.PlayOneShot (audioForWall);
		}
	}
	public void RestartGame () {
		rigidBody.GetComponent<Rigidbody> ();
		Vector3 force = 
			Quaternion.Euler(0, IntitialAngle, 0)*
			Vector3.forward;
		force = force * InputForceScale;

		rigidBody.AddForce (force);
	}

}

