using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class ScoreManager : MonoBehaviour 
{

	public InputField nameField;
	public List<Text> playerNames;
	public List<Text> playerScores;

	public GameObject gameOverCanvas;
	public GameObject scoreCanvas;

	public bool skipEntry = false;

	List <HighScoreEntry> myHighScores = new List <HighScoreEntry>();

	// Use this for initialization
	void Start () 
	{
		LoadScores();

		if (skipEntry == true)
		{
			ShowScores ();
		}
	}

	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown(KeyCode.P))
		{
			NewScores();
			SaveScore();
		}
	}

	void LoadScores()
	{
		for (int i = 0; i < 10; i++)
		{
			if (PlayerPrefs.HasKey("NameEntry" + i.ToString()))
			{
				myHighScores.Add(new HighScoreEntry(PlayerPrefs.GetString("NameEntry" + i.ToString()), PlayerPrefs.GetInt("ScoreEntry" + i.ToString())));

				Debug.Log (myHighScores[i].playerName + myHighScores[i].playerScore);
			}
		}

	}

	void SaveScore()
	{
		for (int i = 0; i < myHighScores.Count; i++)
		{
			PlayerPrefs.SetString ("NameEntry" + i.ToString(), myHighScores[i].playerName);
			PlayerPrefs.SetInt ("ScoreEntry" + i.ToString(), myHighScores[i].playerScore);
		}
	}

	void NewScores()
	{
		myHighScores.Add (new HighScoreEntry("John", 100));
	}

	public void SubmitScore()
	{
		bool wasAdded = false;
		//for i if i is < myHighScores
		for (int i = 0; i < myHighScores.Count; i++)
		{
			if (PlayerPrefs.GetInt("RecentScore") > myHighScores[i].playerScore)
			{
				HighScoreEntry newScore = new HighScoreEntry (nameField.text, PlayerPrefs.GetInt ("RecentScore"));
				myHighScores.Insert (i, newScore);
				wasAdded = true;

				break;
			}

		}

		if (!wasAdded)
		{
			HighScoreEntry newScore = new HighScoreEntry (nameField.text, PlayerPrefs.GetInt ("RecentScore"));
			myHighScores.Add (newScore);
		}

		if (myHighScores.Count > 10)
		{
			myHighScores.RemoveAt (10);
		}

		SaveScore (); 
		ShowScores ();

	}

	public void ShowScores()
	{
		gameOverCanvas.SetActive(false);
		scoreCanvas.SetActive(true);

		for (int i = 0; i < myHighScores.Count; i++)
		{
			playerNames[i].text = myHighScores[i].playerName;
			playerScores[i].text = myHighScores[i].playerScore.ToString();
		}
	}

	public void ClearScores()
	{
		PlayerPrefs.DeleteAll ();
		myHighScores.Clear ();

		for (int i = 0; i < playerNames.Count; i++)
		{
			playerNames[i].text = "NO SCORE";
			playerScores[i].text = "000";
		}
	}


}

//Jacob Kreck, Hadyn Lander, Xblivior
