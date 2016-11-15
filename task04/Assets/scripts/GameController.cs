using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class GameController : MonoBehaviour {
	public GameObject ballTemp;
	public Text TimerText;
	public float Seconds = 59;
	public float Minutes = 0;

	public Text firstPlayerScore;
	public Text secondPlayerScore;

	private int firstPlayerScoreCounter;
	private int secondPlayerScoreCounter;

	void Update()
	{
		if(Seconds <= 0)
		{
			Seconds = 59;
			if(Minutes >= 1)
			{
				Minutes--;
			}
			else
			{
				Minutes = 0;
				Seconds = 0;
				TimerText.text = Minutes.ToString("f0") + ":0" + Seconds.ToString("f0");

			}
		}
		else
		{
			Seconds -= Time.deltaTime;
		}

		if(Mathf.Round(Seconds) <= 9)
		{
			TimerText.text = Minutes.ToString("f0") + ":0" + Seconds.ToString("f0");
		}
		else
		{
			TimerText.text = Minutes.ToString("f0") + ":" + Seconds.ToString("f0");
		}
	}

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
