using UnityEngine;
using System.Collections;
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
		a = Random.Range(0,11);
		b = Random.Range(0,11);

		question.text = a + " + " + b; 

	}

	void Subtraction()
	{
		a = Random.Range(0,11);
		b = Random.Range(0,11);

		question.text = a + " - " + b; 
	}

	void Multiplication()
	{
		a = Random.Range(0,11);
		b = Random.Range(0,11);

		question.text = a + " * " + b; 
	}

	//NOTE: need to figure out a better way to do division
	void Division()
	{
		a = Random.Range(0,11);
		b = Random.Range(0,11);

		question.text = a + " / " + b; 
	}

	public void CheckAnswer()
	{
		
	}
}
