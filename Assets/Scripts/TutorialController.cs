using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class TutorialController : MonoBehaviour 
{
	public Canvas mainCanvas;
	public Canvas adCanvas;
	public Canvas subCanvas;
	public Canvas multiCanvas;
	public Canvas divCanvas;

	public GameObject[] subtractionImages;
	public GameObject[] multiImages;

	int multiNext = 0;

	// Use this for initialization
	void Start () 
	{
		//tutorial canavas disabled
		adCanvas.enabled = false;
		subCanvas.enabled = false;
		multiCanvas.enabled = false;
		divCanvas.enabled = false;

		//multi images are diables 
		multiImages[0].SetActive(false);
		multiImages[1].SetActive(false);
		multiImages[2].SetActive(false);
		multiImages[3].SetActive(false);
		multiImages[4].SetActive(false);
		multiImages[5].SetActive(false);

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
		if (multiNext == 0)
		{
			multiImages[2].SetActive(true);
			multiImages[3].SetActive(true);
			multiNext ++;
		}

		else if (multiNext == 1)
		{
			multiImages[4].SetActive(true);
			multiImages[5].SetActive(true);
			multiNext ++;
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

	public void Menu()
	{
		SceneManager.LoadScene ("Menu");
	}
}
