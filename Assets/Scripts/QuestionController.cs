using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class QuestionController : MonoBehaviour 
{
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

		if (rNum = 0)
		{
			Addition();
		}

		else if (rNum = 1)
		{
			Subtraction();
		}

		else if (rNum = 2)
		{
			Multiplication();
		}

		else (rNum = 3)
		{
			Division();
		}

	}

	void Addition()
	{
		
	}

	void Subtraction()
	{

	}

	void Multiplication()
	{

	}

	void Division()
	{

	}
}
