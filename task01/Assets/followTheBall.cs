using UnityEngine;
using System.Collections;

public class followTheBall : MonoBehaviour {
	public GameObject ball;
	public float rotationSpeed;
	public Rigidbody rigidBody;

	// Use this for initialization
	void Start () {
		rigidBody = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		GameObject gameObject = ball;
		transform.position += transform.forward *
		Time.deltaTime * rotationSpeed;
	}
}

