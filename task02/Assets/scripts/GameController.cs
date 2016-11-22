using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour {
	public GameObject ballTemplate;

	public Text firstPlayerScore;
	public Text secondPlayerScore;

	private int firstPlayerScoreCounter;
	private int secondPlayerScoreCounter;

	void OnTriggerExit(Collider other) {
		GameObject gameObject = other.gameObject;
		if (gameObject.CompareTag ("ball")) {
			GameObject ball = gameObject;

            if (ball.transform.position.z < transform.position.z) {
                    ++firstPlayerScoreCounter;
                    firstPlayerScore.text = firstPlayerScoreCounter.ToString();
            } else {
                    ++secondPlayerScoreCounter;
                    secondPlayerScore.text = secondPlayerScoreCounter.ToString();
            }
            Destroy (ball);
			Instantiate (ballTemplate) ;
        }
	}
}
