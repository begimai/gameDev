using UnityEngine;
using System.Collections;

public class BallBehavior : MonoBehaviour {

	public float IntitialAngle = Random.Range(-75.0f, 75.0f);
	public float InputForceScale =  50.0f;
	public AudioSource audioSource;
	public AudioClip audioForWall;
	public AudioClip audioForPedal;
	public Rigidbody rigidBody;
	// Use this for initialization
	void Start () {
		rigidBody.GetComponent<Rigidbody> ();
		Vector3 force = Quaternion.Euler(0, IntitialAngle, 0) * Vector3.forward;
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

