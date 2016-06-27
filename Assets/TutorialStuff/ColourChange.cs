using UnityEngine;
using System.Collections;

public class ColourChange : MonoBehaviour 
{
	//material references and the RGB
	public Material mat;
	float currentR;
	float currentG;
	float currentB;

	//random RGB
	float rdmR;
	float rdmG;
	float rdmB;

	//timer 
	float timer = 2.5f;

	//look at target
	public GameObject target;


	// Use this for initialization
	void Start () 
	{
		//have current RGB = material RGB
		currentR = mat.color.r;
		currentG = mat.color.g;
		currentB = mat.color.b;

		//make traget = Transform 
		target = GameObject.FindGameObjectWithTag ("LookAt");

		//make Vector3 lookat which is the target position
		Vector3 lookAt = target.transform.position;

		//have cube look at Transform(target)
		transform.LookAt (lookAt);
	}
	
	// Update is called once per frame
	void Update () 
	{
		//make countdown timer
		timer = timer - Time.deltaTime;

		//if timer hits 0
		if (timer <= 0.0f)
		{
			//run ChangingColour
			ChangingColour();

			//reset timer
			timer = 2.5f;
		}
			
	}

	void ChangingColour()
	{
		//make random number for RGB
		rdmR = Random.Range(0.01f, 1.00f); 
		rdmG = Random.Range(0.01f, 1.00f);
		rdmB = Random.Range(0.01f, 1.00f);

		//lerp currentRGB to new RGB
		currentR = Mathf.Lerp(currentR, rdmR, Time.deltaTime * 10);
		currentG = Mathf.Lerp(currentG, rdmG, Time.deltaTime * 10);
		currentB = Mathf.Lerp(currentB, rdmB, Time.deltaTime * 10);

		//make the material colour the currentRGB
		mat.color = new Color(currentR, currentG, currentB);

	}
}

//Xblivior
