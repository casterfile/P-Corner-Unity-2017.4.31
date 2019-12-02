using UnityEngine;
using UnityEngine.UI;
using System.Text;
using System.Security;
using System.Collections;

public class UpdateGetPrize : MonoBehaviour {
	private string GetPrizePHP_Url = "https://immersivemedia.ph/potatocornerDB/V3pc_GetPrize.php";//V3pc_GetPrize.php

    protected string UUID = "";
    public static string PrizeCount = "";
    private bool isGetPrize = false;

	public static bool ConnectionSuccessful = false;

	// Use this for initialization
	void Start () {
		if(ConnectionSuccessful == false){
			isGetPrize = false;
			UUID = SystemInfo.deviceUniqueIdentifier;
			int TotalScore = ZPlayerPrefs.GetInt("ScoreCount");
			int TotalPoints = TotalScore / 5;
			//setting points to limits 179
			if (TotalPoints >= 100) {
				StartCoroutine(RegisterProcess());
			}
		}

       
	}
        
    IEnumerator RegisterProcess()
    {
        if (isGetPrize)
            yield return null;

        isGetPrize = true;
        //Assigns the data we want to save
        //Where -> Form.AddField("name" = matching name of value in SQL database
        WWWForm mForm = new WWWForm();
        mForm.AddField("UUID", UUID); // adds the player name to the form

        //Creates instance of WWW to runs the PHP script to save data to mySQL database
        WWW www = new WWW(GetPrizePHP_Url, mForm);
		if (TestingScript.isTesting == true) {
			Debug.Log ("Processing...");
		}
        yield return www;

        // Debug.Log("" + www.text);
        
        if (www.text == "Done")
        {
			if (TestingScript.isTesting == true) {
				Debug.Log ("Registered Successfully.");
			}
			ConnectionSuccessful = true;
            
        }
        else
        {
			if (TestingScript.isTesting == true) {
				Debug.Log (www.text);
			}
			ConnectionSuccessful = false;

        }
        

		string numString = www.text;
		int number;

		if (int.TryParse (numString, out number)) {
			if (TestingScript.isTesting == true) {
				Debug.Log ("String is the number: " + number);
			}
			PrizeCount = www.text;
			if (TestingScript.isTesting == true) {
				print ("PrizeCount: " + www.text);
			}
			ConnectionSuccessful = true;
		} else {
			PrizeCount = "";
			ConnectionSuccessful = false;
		}

        isGetPrize = false;
    }
}


