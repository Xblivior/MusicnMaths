using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CompetitiveController : MonoBehaviour 
{
	public Canvas pauseMenu;
	public Canvas normUI;
	public Text overallTimerT;

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

	public void GameOver()
	{
		

	}
		
}
