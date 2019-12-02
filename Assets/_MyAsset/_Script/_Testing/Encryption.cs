using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

public class Encryption : MonoBehaviour {

	// Use this for initialization
	void Start () {
		var lbyte=System.Text.Encoding.UTF8.GetBytes("ABC");
		print ("lbyte "+ lbyte);
		var lResult=System.Text.Encoding.UTF8.GetString(lbyte);
		print ("lResult "+ lResult);

		PlayerPrefs.SetString("Data", "Number");

		string globalScoreCount = PlayerPrefs.GetString("Data");

		print ("globalScoreCount: "+ globalScoreCount);
	}
		
}
