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

	public Image[] subtractionImages;

	// Use this for initialization
	void Start () 
	{
		adCanvas.enabled = false;
		subCanvas.enabled = false;
		multiCanvas.enabled = false;
		divCanvas.enabled = false;
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
		subtractionImages[2].enabled = false;
		subtractionImages[3].enabled = false;
		subtractionImages[4].enabled = false;
	}

	public void MultiplicationTute()
	{
		//make mulitplication tute active
		multiCanvas.enabled = true;

		//make other canvases false
		adCanvas.enabled = false;
		subCanvas.enabled = false;
		divCanvas.enabled = false;
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
