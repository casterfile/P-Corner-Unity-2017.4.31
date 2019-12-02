using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestingScript : MonoBehaviour {
	public static bool isTesting = true;
	// Use this for initialization
	void Awake () {
		#if UNITY_EDITOR
		isTesting = true;
		#endif	

		//print ("isTesting: "+ isTesting);
	}
}
