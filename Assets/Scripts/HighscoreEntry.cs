using UnityEngine;
using System.Collections;

public class HighScoreEntry   
{

	public string playerName;
	public int playerScore;
	public float surviveTime;

	public float avrTime;

	public HighScoreEntry(string pN, int pS)
	{
		playerName = pN;
		playerScore = pS;
	}

}


//Xblivior