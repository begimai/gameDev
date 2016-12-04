using UnityEngine;
using System.Collections;

public class PedalController : MonoBehaviour {

	public Vector3 eulerAngleVelocity;
	public Rigidbody rb;
	void Start() {
		rb = GetComponent<Rigidbody>();
	}
	void FixedUpdate() {
		Quaternion deltaRotation = Quaternion.Euler(eulerAngleVelocity * Time.deltaTime);
		rb.MoveRotation(rb.rotation * deltaRotation);
	}
}


/*
using UnityEngine;
using System.Collections;


public class Flipper : MonoBehaviour
{
	public float maxAngle = 20.0f;
	public float flipTime = 1.0f;
	public string buttonName = "Fire1";
	
	private Quaternion initialOrientation;
	private Quaternion finalOrientation;
	private float t;

	void Start ()
	{
		initialOrientation = transform.rotation;
		finalOrientation.eulerAngles = new Vector3(initialOrientation.eulerAngles.x, initialOrientation.eulerAngles.y + maxAngle, initialOrientation.eulerAngles.z);
	}
	
	void Update ()
	{
		if(Input.GetButton(buttonName))
		{
			transform.rotation = Quaternion.Slerp(initialOrientation, finalOrientation, t/flipTime);
			t += Time.deltaTime;
			if(t > flipTime)
			{
				t = flipTime;
			}
		}
		else
		{
			transform.rotation = Quaternion.Slerp(initialOrientation, finalOrientation, t/flipTime);
			t -= Time.deltaTime;
			if(t < 0)
			{
				t = 0;
			}
		}
	}
}
*/