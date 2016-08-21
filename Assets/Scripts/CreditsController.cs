using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CreditsController : MonoBehaviour 
{
	public Text creditsOne;
	public Text creditsTwo;

	// Use this for initialization
	void Start () 
	{
		creditsOne.enabled = true;
		creditsTwo.enabled = false;
	}

	public void NextCredits()
	{
		creditsOne.enabled = false;
		creditsTwo.enabled = true;

	}
}
