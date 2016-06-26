using UnityEngine;
using System.Collections;

public class ColourChange : MonoBehaviour 
{
	public Material mat;
	public Color lerpedColour;
	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		mat.color = lerpedColour;
		lerpedColour = Color.Lerp(Color.red, Color.blue, Mathf.PingPong(Time.time, 1));
	}
}
