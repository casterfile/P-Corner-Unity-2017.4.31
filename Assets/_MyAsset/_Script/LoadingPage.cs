using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingPage : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StartCoroutine(StartGame(1.2f));
	}

	IEnumerator StartGame(float time)
	{
		
		yield return new WaitForSeconds(time);
		Application.LoadLevel ("Scene01_Game");
	}
}
