using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using System;
using System.Security.Cryptography;
using System.Text;

public class Test : MonoBehaviour {

	// Use this for initialization
	void Start () {
		ZPlayerPrefs.Initialize("what'sYourName", "salt12issalt");


		ZPlayerPrefs.SetInt("Int1", 5000);

		Debug.Log("Get Value Int1: " + ZPlayerPrefs.GetInt("Int1") + ", Encrypt: " + ZPlayerPrefs.GetRowString("Int1"));
	}
	

}
