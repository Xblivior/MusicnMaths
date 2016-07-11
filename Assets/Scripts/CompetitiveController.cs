using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CompetitiveController : MonoBehaviour 
{
	public Canvas pauseMenu;
	public Canvas normUI;
	public Text overallTimerT;
	//public Text livesT;

	public float livesTimer = 7f;
	public int lives = 3;
	public Image[] life;

	float overallTimer;

	// Use this for initialization
	void Start () 
	{
		pauseMenu.enabled = false;


	}
	
	// Update is called once per frame
	void Update () 
	{
		//start overall timer
		overallTimer += Time.deltaTime;

		//round to nearest sec
		int secondsO = Mathf.RoundToInt (overallTimer);

		//show timer text
		overallTimerT.text = "Survived Time: " + secondsO + "sec";

		LivesTimer ();

		if (lives <= 0)
		{
			print ("GameOver");
		}

	}

	public void Pause()
	{
		//pause time
		Time.timeScale = 0.0f;

		//enable pause menu
		pauseMenu.enabled = true;

		//disable normal ui
		normUI.enabled = false;
	}

	public void Continue()
	{
		//reset time
		Time.timeScale = 1.0f;

		//get a new question
		GetComponent<QuestionController> ().RandomType ();

		//enable pause menu
		pauseMenu.enabled = false;

		//disable normal ui
		normUI.enabled = true;

	}

	public void Quit()
	{
		//reset time
		Time.timeScale = 1.0f;

		//go to menu
		SceneManager.LoadScene ("Menu");
	}

	public void LivesTimer()
	{
		livesTimer -= Time.deltaTime;

		if (livesTimer <= 0f)
		{

			TakeLife ();
			livesTimer = 5f;

		}

	}

	public void TakeLife()
	{
		life [lives - 1].color = new Color(0f,0f,0f,0f);
		lives -= 1;
	}
		
}
