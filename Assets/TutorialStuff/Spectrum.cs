using UnityEngine;
using System.Collections;

public class Spectrum : MonoBehaviour 
{
	public GameObject cubes;
	public int numberOfObjects = 20;
	public float radius = 5f;

	public GameObject cubesT;
	public int numberOfObjectsT = 20;
	public float radiusT = 5f;

	public GameObject[] cubeArray;
	public GameObject[] cubeArrayT;

	public GameObject cameraPivot;

	public GameObject cubeParent;
	public GameObject cubeParentLookAt;


	// Use this for initialization
	void Start () 
	{
		
		for (int i = 0; i < numberOfObjects; i++)
		{
			float angle = i * Mathf.PI * 2 / numberOfObjects;
			Vector3 pos = new Vector3 (Mathf.Cos(angle), 0, Mathf.Sin(angle)) * radius;
			Instantiate(cubes, pos, Quaternion.identity);
		}

		for (int iT = 0; iT < numberOfObjectsT; iT++)
		{
			float angleT = iT * Mathf.PI * 2 / numberOfObjectsT;
			Vector3 posT = new Vector3 (Mathf.Cos(angleT), 0, Mathf.Sin(angleT)) * radiusT;
			GameObject cubesTC = (GameObject) Instantiate (cubesT, posT, Quaternion.identity);
			cubesTC.transform.parent = cubeParent.transform;

		}

		Vector3 parentLookAt = cubeParentLookAt.transform.position;
		cubeParent.transform.LookAt (parentLookAt);
		cubeArray = GameObject.FindGameObjectsWithTag("Cube");
		cubeArrayT = GameObject.FindGameObjectsWithTag("CubeT");
	}
	
	// Update is called once per frame
	void Update () 
	{
		float[] spectrum = AudioListener.GetSpectrumData(1024, 0, FFTWindow.Hamming);
		for (int i = 0; i < numberOfObjects; i++)
		{
			Vector3 previousScale = cubeArray[i].transform.localScale;
			previousScale.z = Mathf.Lerp(previousScale.z, spectrum[i] * 30, Time.deltaTime * 30);
			cubeArray[i].transform.localScale = previousScale;
		}

		float[] spectrumT = AudioListener.GetSpectrumData(1024, 0, FFTWindow.Hamming);
		for (int iT = 0; iT < numberOfObjectsT; iT++)
		{
			Vector3 previousScaleT = cubeArrayT[iT].transform.localScale;
			previousScaleT.z = Mathf.Lerp(previousScaleT.z, spectrumT[iT] * 30, Time.deltaTime * 30);
			cubeArrayT[iT].transform.localScale = previousScaleT;
		}

		//get camera to rotate around pivote for effect
		cameraPivot.transform.Rotate (0, 0.2f, 0);
	}
		
}




//tutorial by The Developer Guy 
//https://www.youtube.com/watch?v=ELLANEFw5B8  
//edited by Xblivior
