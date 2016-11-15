using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Timer : MonoBehaviour 
{
	public Text TimerText;
	public float Seconds = 59;
	public float Minutes = 0;

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
}