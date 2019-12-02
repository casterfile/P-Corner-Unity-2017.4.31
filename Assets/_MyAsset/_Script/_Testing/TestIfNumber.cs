using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestIfNumber : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		string numString = "sdasdasdas";
		int number;

		if(int.TryParse(numString, out number))
		{
			Debug.Log ("String is the number: " + number);
		}
	}
}
