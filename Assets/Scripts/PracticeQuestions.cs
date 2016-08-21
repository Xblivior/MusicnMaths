using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class PracticeQuestions : MonoBehaviour 
{
	public int currentScore = 0;
	public Text scoreText;
	public Text question;
	public Text[] answers;

	public Canvas pauseMenu;
	public Canvas normUI;
	public Canvas inputCanvas; 

	//float[] timeBetweenQs;

	int a;
	int b;
	int c;

	//mins and maxs
	public int addMax;
	public int addMin;
	public int subMax;
	public int subMin;
	public int multiMax;
	public int multiMin;

	//input fields
	public InputField addMaxField;
	public InputField addMinField;
	public InputField subMaxField;
	public InputField subMinField;
	public InputField multiMaxField;
	public InputField multiMinField;

	//audio effects
	public AudioSource audio;
	public AudioClip correctSound;
	public AudioClip incorrectSound;


	// Use this for initialization
	void Start () 
	{
		//RandomType ();
		pauseMenu.enabled = false;
		normUI.enabled = false;
		inputCanvas.enabled = true;
	}

	// Update is called once per frame
	void Update () 
	{
		//show score
		scoreText.text = "Score: " + currentScore;

	}

	public void InputTeacherData()
	{
		//convert the text in the input field into an int to use for the questions
		int.TryParse(addMaxField.text, out addMax);
		int.TryParse(addMinField.text, out addMin);
		int.TryParse(subMaxField.text, out subMax);
		int.TryParse(subMinField.text, out subMin);
		int.TryParse(multiMaxField.text, out multiMax);
		int.TryParse(multiMinField.text, out multiMin);

		//start the question
		RandomType();

		//turn off input canvas and turn on question canvas
		inputCanvas.enabled = false;
		normUI.enabled = true;

	}

	public void RandomType()
	{
		//make random number
		int rNum = Random.Range (0,4);

		//if 0 then do addition
		if (rNum == 0)
		{
			Addition();
		}

		//if 1 do subtraction
		else if (rNum == 1)
		{
			Subtraction();
		}

		//if 2 do multiplication
		else if (rNum == 2)
		{
			Multiplication();
		}

		//if 3 do division
		else if (rNum == 3)
		{
			Division(); 
		}

	}

	void Addition()
	{
		//make an answer
		c = Random.Range (addMin, addMax);

		//make a random a 
		a = Random.Range(1, c);

		//then b = c-a
		b = c-a;

		//show the text
		question.text = a + " + " + b; 

		//play CreateAnswer
		CreateAnswers ();

	}

	void Subtraction()
	{
		//make a random answer
		c = Random.Range (subMin, subMax);

		//make random b
		b = Random.Range(0, c);

		//then a = c+b
		a = c + b;

		//show text
		question.text = a + " - " + b; 

		//play CreateAnswer
		CreateAnswers ();
	}


	void Multiplication()
	{
		//make random a
		a = Random.Range (multiMin, multiMax);

		//make random b
		b = Random.Range(multiMin, multiMax);

		//then c = a*b
		c = a * b;

		//show text
		question.text = a + " * " + b; 

		//play CreateAnswer
		CreateAnswers ();
	}

	//NOTE: need to figure out a better way to do division
	void Division()
	{
		//c = a/b - get the smaller number first(b) random.range
		b = Random.Range(1,11);

		//a = b * random number to make the bigger number
		a = b * Random.Range(1,11);

		//c = a/b 
		c = a / b;

		//show text
		question.text = a + " / " + b; 

		//play CreateAnswer
		CreateAnswers ();
	}

	public void CreateAnswers()
	{
		//make a list with ints called possibleAnswers
		List<int> possibleAnswers = new List<int>(); 

		//add answer(c) into list
		possibleAnswers.Add (c);

		//for (int i (start at 1); while i < 4; add 1)
		for(int i = 1; i < 4; i++)
		{
			//create d = +/- 10 of answer(c)
			int d = c + Random.Range (-10, 11);

			//while list contains d
			while (possibleAnswers.Contains (d))
			{
				//add 1 to d
				d += 1;
			}

			//then add d
			possibleAnswers.Add (d); 
		}


		//for each answer in answer[]
		foreach(Text answer in answers)
		{
			//make an int - possibleAnswerNumber = random.range (0, possibleAnswer length)
			int possibleAnswerNumber = Random.Range (0, possibleAnswers.Count); 

			//change the answer text to a random possibleAnswer (in th list)
			answer.text = possibleAnswers [possibleAnswerNumber].ToString(); 

			//delete that answer from list
			possibleAnswers.RemoveAt (possibleAnswerNumber);
		}
	}

	public void CheckAnswer(Text givenAnswer)
	{

		//if (c equals button text)
		if (c == int.Parse (givenAnswer.text)) 
		{
			//add 5 scores
			currentScore += 5;

			//play correct sound effect
			audio.PlayOneShot(correctSound);

			//next question
			RandomType ();
		}

		else
		{
			//take 5 scores
			currentScore -= 5;

			//play incorrect sound effect
			audio.PlayOneShot(incorrectSound);

			//next question
			RandomType ();
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
		
}
