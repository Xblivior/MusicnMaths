using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class TutorialController : MonoBehaviour 
{
	//canvases
	public Canvas mainCanvas;
	public Canvas adCanvas;
	public Canvas subCanvas;
	public Canvas multiCanvas;
	public Canvas divCanvas;

	//tute images
	public GameObject[] subtractionImages;
	public GameObject[] multiImages;
	public GameObject[] divImages;

	//numbers used to go to next part of tutes
	int multiNext = 0;
	int divNext = 0;

	// Use this for initialization
	void Start () 
	{
		//tutorial canavas disabled
		adCanvas.enabled = false;
		subCanvas.enabled = false;
		multiCanvas.enabled = false;
		divCanvas.enabled = false;

		//multi images are disabled 
		multiImages[0].SetActive(false);
		multiImages[1].SetActive(false);
		multiImages[2].SetActive(false);
		multiImages[3].SetActive(false);
		multiImages[4].SetActive(false);
		multiImages[5].SetActive(false);

		//division images are disabled
		divImages[0].SetActive(false);
		divImages[1].SetActive(false);
		divImages[2].SetActive(false);
		divImages[3].SetActive(false);
		divImages[4].SetActive(false);

	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	public void AdditionTute()
	{
		//make addition canvas active
		adCanvas.enabled = true;

		//make other canvases false
		subCanvas.enabled = false;
		multiCanvas.enabled = false;
		divCanvas.enabled = false;
	}

	public void SubtractionTute()
	{
		//make subtraction canvas active
		subCanvas.enabled = true;

		//make other canvases false
		adCanvas.enabled = false;
		multiCanvas.enabled = false;
		divCanvas.enabled = false;
	}

	public void SubtractionNext()
	{
		//hide boxes 3-5
		subtractionImages[2].SetActive(false);
		subtractionImages[3].SetActive(false);
		subtractionImages[4].SetActive(false);
	}

	public void MultiplicationTute()
	{
		//make mulitplication tute active
		multiCanvas.enabled = true;
		multiImages[0].SetActive(true);
		multiImages[1].SetActive(true);

		//make other canvases false
		adCanvas.enabled = false;
		subCanvas.enabled = false;
		divCanvas.enabled = false;
	}

	public void MultiplicationNext()
	{
		//if mnext is 0
		if (multiNext == 0)
		{
			//show next 2 boxes
			multiImages[2].SetActive(true);
			multiImages[3].SetActive(true);

			//add 1 
			multiNext ++;
		}

		//else if its 1
		else if (multiNext == 1)
		{
			//show the last 2 boxes
			multiImages[4].SetActive(true);
			multiImages[5].SetActive(true);

			//add 1
			multiNext ++;
		}

		//else if its 2
		else if (multiNext == 2)
		{
			//hide images 
			multiImages[2].SetActive(false);
			multiImages[3].SetActive(false);
			multiImages[4].SetActive(false);
			multiImages[5].SetActive(false);

			//reset mnext
			multiNext = 0;
		}
	}

	public void DivisionTute()
	{
		//make division tute active
		divCanvas.enabled = true;

		//make other canvases false
		adCanvas.enabled = false;
		subCanvas.enabled = false;
		multiCanvas.enabled = false;
	}

	public void DivisionNext()
	{
		//if dnext is 0
		if (divNext == 0)
		{
			//show splits and numbers
			divImages[0].SetActive(true);
			divImages[1].SetActive(true);
			divImages[2].SetActive(true);
			divImages[3].SetActive(true);
			divImages[4].SetActive(true);

			//add 1 to dnext
			divNext ++;

		}

		//else if dnext is 1
		else if (divNext == 1)
		{
			//show splits and numbers
			divImages[0].SetActive(false);
			divImages[1].SetActive(false);
			divImages[2].SetActive(false);
			divImages[3].SetActive(false);
			divImages[4].SetActive(false);

			//reset dnext
			divNext = 0;
		}
			
	}

	public void Menu()
	{
		//load the main menu
		SceneManager.LoadScene ("Menu");
	}
}
