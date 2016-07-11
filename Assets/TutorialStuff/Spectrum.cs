using UnityEngine;
using System.Collections;

public class Spectrum : MonoBehaviour 
{
	//references for outer cube ring
	public GameObject cubes;
	public int numberOfObjects = 20;
	public float radius = 5f;

	//references for inner cube ring
	public GameObject cubesT;
	public int numberOfObjectsT = 20;
	public float radiusT = 5f;

	//cube arrays
	public GameObject[] cubeArray;
	public GameObject[] cubeArrayT;

	//camera pivot
	public GameObject cameraPivot;

	//cube parent stuff
	public GameObject cubeParent;
	public GameObject cubeParentLookAt;


	// Use this for initialization
	void Start () 
	{
		//instantiating the outer cubes
		for (int i = 0; i < numberOfObjects; i++)
		{
			float angle = i * Mathf.PI * 2 / numberOfObjects;
			Vector3 pos = new Vector3 (Mathf.Cos(angle), 0, Mathf.Sin(angle)) * radius;
			Instantiate(cubes, pos, Quaternion.identity);
		}

		//instantiating the inner cubes + adding them to a parent
		for (int iT = 0; iT < numberOfObjectsT; iT++)
		{
			float angleT = iT * Mathf.PI * 2 / numberOfObjectsT;
			Vector3 posT = new Vector3 (Mathf.Cos(angleT), 0, Mathf.Sin(angleT)) * radiusT;
			GameObject cubesTC = (GameObject) Instantiate (cubesT, posT, Quaternion.identity);
			cubesTC.transform.parent = cubeParent.transform;

		}

		//get the cubeparent to look at cubeparentlookat to make the second ring of cubes turn around
		Vector3 parentLookAt = cubeParentLookAt.transform.position;
		cubeParent.transform.LookAt (parentLookAt);

		//add the cubes to the arrays
		cubeArray = GameObject.FindGameObjectsWithTag("Cube");
		cubeArrayT = GameObject.FindGameObjectsWithTag("CubeT");
	}
	
	// Update is called once per frame
	void Update () 
	{
		float[] spectrum = AudioListener.GetSpectrumData(1024, 0, FFTWindow.Hamming);
		for (int i = 0; i < numberOfObjects; i++)
		{
			Vector3 previousPosition = cubeArray[i].transform.position;

			//                                                   (how far out of the middle they spawn)                                         (how much they jump to music)
			previousPosition = Vector3.Lerp(previousPosition, (cameraPivot.transform.position + -cubeArray[i].transform.forward * 10) + -cubeArray[i].transform.forward * spectrum[i] * 20, Time.unscaledDeltaTime * 30);
			cubeArray[i].transform.position = previousPosition;
			GetComponent<LineRenderer> ().SetPosition (i, previousPosition);
			if (i == cubeArray.Length - 1)
			{
				GetComponent<LineRenderer> ().SetPosition (i + 1, cubeArray[0].transform.position);
			}
		}

		float[] spectrumT = AudioListener.GetSpectrumData(1024, 0, FFTWindow.Hamming);
		for (int iT = 0; iT < numberOfObjectsT; iT++)
		{
			Vector3 previousScaleT = cubeArrayT[iT].transform.localScale;
			previousScaleT.z = Mathf.Lerp(previousScaleT.z, spectrumT[iT] * 30, Time.unscaledDeltaTime * 30);
			cubeArrayT[iT].transform.localScale = previousScaleT;
		}

		//get camera to rotate around pivote for effect
		cameraPivot.transform.Rotate (0, 0.2f, 0);
	}
		
}




//tutorial by The Developer Guy 
//https://www.youtube.com/watch?v=ELLANEFw5B8  
//edited by Xblivior
