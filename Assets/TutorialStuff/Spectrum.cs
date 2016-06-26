using UnityEngine;
using System.Collections;

public class Spectrum : MonoBehaviour 
{
	public GameObject cubes;
	public int numberOfObjects = 20;
	public float radius = 5f;

	public GameObject[] cubeArray;

	public Material mat; 
	float r;
	float g;
	float b;


	// Use this for initialization
	void Start () 
	{
		r = mat.color.r;
		g = mat.color.g;
		b = mat.color.b;

		for (int i = 0; i < numberOfObjects; i++)
		{
			float angle = i * Mathf.PI * 2 / numberOfObjects;
			Vector3 pos = new Vector3 (Mathf.Cos(angle), 0, Mathf.Sin(angle)) * radius;
			Instantiate(cubes, pos, Quaternion.identity);
		}

		cubeArray = GameObject.FindGameObjectsWithTag("Cube");
	}
	
	// Update is called once per frame
	void Update () 
	{
		float[] spectrum = AudioListener.GetSpectrumData(1024, 0, FFTWindow.Hamming);
		for (int i = 0; i < numberOfObjects; i++)
		{
			Vector3 previousScale = cubeArray[i].transform.localScale;
			previousScale.y = Mathf.Lerp(previousScale.y, spectrum[i] * 30, Time.deltaTime * 30);
			cubeArray[i].transform.localScale = previousScale;
		}

		//ColourChange();


	}

	void ColourChange()
	{
//		float rdmR = Random.Range((1/100),(101/100)); 
//		float rdmG = Random.Range((1/100),(101/100));
//		float rdmB = Random.Range((1/100),(101/100));

//		mat.color.r = Mathf.Lerp (r, rdmR, Time.deltaTime * 30);

//		mat.color = new Color(rdmR, rdmG, rdmB);
	}
		
}




//tutorial by The Developer Guy 
//https://www.youtube.com/watch?v=ELLANEFw5B8  
