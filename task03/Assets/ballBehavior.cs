using UnityEngine;
using System.Collections;

public class Status : MonoBehaviour {
	public float IntitialAngle = Random.Range(-75.0f, 75.0f);
}

public class ballBehavior : MonoBehaviour {


	public float InputForceScale =  50.0f;
	public AudioSource audioSource;
	public AudioClip audioForWall;
	public AudioClip audioForPedal;
	public Rigidbody rigidBody;
	// Use this for initialization
	void Start () {
		rigidBody.GetComponent<Rigidbody> ();
		Status status = GetComponent<Status> ();
		float t = status.IntitialAngle;
		Vector3 force = 
				Quaternion.Euler(0, t, 0)*
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
}

