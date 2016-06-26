using UnityEngine;
using System.Collections;

public class Spectrum : MonoBehaviour 
{
	public GameObject cubes;
	public int numberOfObjects = 20;
	public float radius = 5f;

	public GameObject[] cubeArray;

	// Use this for initialization
	void Start () 
	{
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
			previousScale.y = spectrum[i] * 20;
			cubeArray[i].transform.localScale = previousScale;
		}
	}
}
