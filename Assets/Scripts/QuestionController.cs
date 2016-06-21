using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class QuestionController : MonoBehaviour 
{
	public Text score;
	public Text question;
	public Text[] answers;

	int a;
	int b;
	int c;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{

	}

	public void RandomType()
	{
		int rNum = Random.Range (0,4);

		if (rNum == 0)
		{
			Addition();
		}

		else if (rNum == 1)
		{
			Subtraction();
		}

		else if (rNum == 2)
		{
			Multiplication();
		}

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
		a = Random.Range(1,26);

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
		b = Random.Range(0,11);

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
		//make an answer
		c = Random.Range (1, 100);

		//make random b
		b = Random.Range(1,11);

		//then a = c/b
		a = c / b;

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
		//make a list possibleAnswer = new list {answer(c), 10 +/- of answer(c),} has 4 elements (1 for each button)
		//{c, c+Random.Range(-10,11), c+Random.Range(-10,11), c+Random.Range(-10,11)}
		List<int> possibleAnswers = new List<int>(); 
		possibleAnswers.Add (c);
		for(int i = 1; i < 4; i++)
		{
			int d = c + Random.Range (-10, 11);

			if (d == c || d == possibleAnswers.Exists(int.Equals(d)))
			{
				
			}

			else
			{
				possibleAnswers.Add (d); 
			}

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

	public void CheckAnswer()
	{
		
	}
}
