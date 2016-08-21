using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class QuestionController : MonoBehaviour 
{
	public int currentScore = 0;
	public Text scoreText;
	public Text question;
	public Text[] answers;
	public Text timeLeftT; 

	float timeLeft = 30f;

	public AudioSource audio;
	public AudioClip correctSound;
	public AudioClip incorrectSound;

	//float[] timeBetweenQs;

	int a;
	int b;
	int c;

	// Use this for initialization
	void Start () 
	{
		RandomType (); 
	}
	
	// Update is called once per frame
	void Update () 
	{
		//show score
		scoreText.text = "Score: " + currentScore;
	
		//start timer
//		timeLeft -= Time.deltaTime;

		//timer to nearest second
		int seconds = Mathf.RoundToInt (timeLeft);

		//if timer is 0 go to gameover
//		if (timeLeft <= 0f)
//		{
//			GetComponent<CompetitiveController> ().GameOver ();
//		}

		//show timer
//		timeLeftT.text = "Time Left: " + seconds + "sec";
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
		c = Random.Range (1, 25);

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
		c = Random.Range (1, 25);

		//make random b
		b = Random.Range(0, c);

		//then a = c+b
		a = c + b;

		//show text
		question.text = a + " - " + b; 

		//play CreateAnswer
		CreateAnswers ();
	}


	//NOTE: finish it
	void Multiplication()
	{
		//make random a
		a = Random.Range (1, 11);

		//make random b
		b = Random.Range(1, 11);

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

			//add lives time
			GetComponent<CompetitiveController> ().livesTimer = 10f;

			//next question
			RandomType ();
		}

		else
		{
			//take 5 scores
			currentScore -= 5;

			//play incorrect sound effect
			audio.PlayOneShot(incorrectSound);

			//lose a live
			GetComponent<CompetitiveController> ().TakeLife();

			//next question
			RandomType ();
		}
	}
}
