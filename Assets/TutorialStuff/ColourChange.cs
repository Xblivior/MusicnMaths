using UnityEngine;
using System.Collections;

public class ColourChange : MonoBehaviour 
{
	public Material mat;
	float currentR;
	float currentG;
	float currentB;

	float rdmR;
	float rdmG;
	float rdmB;

	float timer = 2.5f;

	public GameObject target;


	// Use this for initialization
	void Start () 
	{
		currentR = mat.color.r;
		currentG = mat.color.g;
		currentB = mat.color.b;

		target = GameObject.FindGameObjectWithTag ("LookAt");
		Vector3 lookAt = target.transform.position;
		transform.LookAt (lookAt);
	}
	
	// Update is called once per frame
	void Update () 
	{
		timer = timer - Time.deltaTime;
		if (timer <= 0.0f)
		{
			ChangingColour();
			timer = 2.5f;
		}
			
	}

	void ChangingColour()
	{
		rdmR = Random.Range(0.01f, 1.00f); 
		rdmG = Random.Range(0.01f, 1.00f);
		rdmB = Random.Range(0.01f, 1.00f);

		currentR = Mathf.Lerp(currentR, rdmR, Time.deltaTime * 10);
		currentG = Mathf.Lerp(currentG, rdmG, Time.deltaTime * 10);
		currentB = Mathf.Lerp(currentB, rdmB, Time.deltaTime * 10);

		mat.color = new Color(currentR, currentG, currentB);

	}
}
