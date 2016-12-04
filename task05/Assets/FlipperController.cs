using UnityEngine;
using System.Collections;

public class FlipperController : MonoBehaviour {

	public Vector3 eulerAngleVelocity;
	public Rigidbody rb;
	void Start() {
		rb = GetComponent<Rigidbody>();
	}
	void FixedUpdate() {
		
	}
}
