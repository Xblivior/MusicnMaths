using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour 
{
	
	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	public void Competitive ()
	{
		SceneManager.LoadScene ("Competitive");
	}

	public void Tutorials()
	{
		SceneManager.LoadScene ("Tutorial");
	}

	public void Practice()
	{
		SceneManager.LoadScene("Practice");
	}

	public void Credits()
	{
		SceneManager.LoadScene("Credits");
	}

	public void Highscore()
	{
		SceneManager.LoadScene("Highscore");
	}

	public void Menu()
	{
		SceneManager.LoadScene("Menu");
	}

	public void Exit()
	{
		Application.Quit ();
	}


}
