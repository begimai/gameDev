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
                GameObject gameObject =
                        other.gameObject;

                if (gameObject.CompareTag ("ball")) {
                        GameObject ball =
                                gameObject;
			Status sb = GetComponent<Status>();
						if (ball.transform.position.z < transform.position.z) {
                                ++firstPlayerScoreCounter;
                                firstPlayerScore.text =
                                        firstPlayerScoreCounter.ToString();
								Destroy (ball);
				sb.IntitialAngle = Random.Range(-75.0f, 75.0f) + 180;
								Instantiate (ballTemp);

                        } else {
                                ++secondPlayerScoreCounter;
                                secondPlayerScore.text =
                                        secondPlayerScoreCounter.ToString();
								Destroy (ball);


								Instantiate (ballTemp);

                        }
                }
        }
}

