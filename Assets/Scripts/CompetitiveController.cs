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

	public float livesTimer = 10f;
	public int lives = 3;
	public Image[] life;
	public Slider timerSlider;

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
			GameOver ();
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

		//reset lives timer
		livesTimer = 10f;

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
		//timer
		livesTimer -= Time.deltaTime;

		//show on slider
		timerSlider.value = livesTimer;

		//if lives <=0
		if (livesTimer <= 0f)
		{
			//TakeLife()
			TakeLife ();

			//Reset timer
			livesTimer = 10f;

		}

	}

	public void TakeLife()
	{
		//disable a life image
		life [lives - 1].color = new Color(0f,0f,0f,0f);

		//take life
		lives -= 1;

		//reset timer
		livesTimer = 10f;
	}

	public void GameOver()
	{
		PlayerPrefs.SetInt ("RecentScore", GetComponent<QuestionController> ().currentScore);
		SceneManager.LoadScene ("LoseScreen");
	}
		
}
