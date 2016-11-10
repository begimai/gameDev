using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class GameController : MonoBehaviour {

	public GameObject ballTemp;

	public Text firstPlayerScore;
	public Text secondPlayerScore;

	private int firstPlayerScoreCounter;
	private int secondPlayerScoreCounter;

	void OnTriggerExit(Collider other) {
		GameObject gameObject = other.gameObject;

		if (gameObject.CompareTag ("ball")) {
			GameObject ball = gameObject;

			bool isToTheLeft = ball.transform.position.z < transform.position.z;

			if (isToTheLeft) {
				++firstPlayerScoreCounter;
				firstPlayerScore.text = firstPlayerScoreCounter.ToString();
			} else {
				++secondPlayerScoreCounter;
				secondPlayerScore.text = secondPlayerScoreCounter.ToString();
			}

			Destroy (ball);
			BallBehavior newBall = Instantiate (ballTemp).GetComponent<BallBehavior> ();

			if (isToTheLeft) {
				newBall.IntitialAngle = Random.Range(-75.0f, 75.0f);
			} else {
				newBall.IntitialAngle = Random.Range(-75.0f, 75.0f) - 180;
			}
		}
	}
}

