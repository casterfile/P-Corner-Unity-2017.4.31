using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Text.RegularExpressions;

public class CheckForTotalRef : MonoBehaviour {
	
	public static string GlobalRefNumber = "";

	private string PrizeCountPHP_Url = "https://immersivemedia.ph/potatocornerDB/V3pc_CheckForTotalRef.php";
	protected string UserPhoneID = "";
	private bool isPrizeCount;
	public static string strPrizeCount;
	public static string Year, Month, Day;

	string[] Alphabet = new string[26] {"A","B","C","D","E","F","G","H","I","J","K","L","M","N","O","P","Q","R","S","T","U","V","W","X","Y","Z"};

	// Use this for initialization
	void Start () {
		string numString = GlobalRefNumber;
		int number;

		if (int.TryParse (numString, out number)) {
			if (TestingScript.isTesting == true) {
				print ("CheckForTotalRef Has Number");
			}
			strPrizeCount  = strPrizeCount;
			string Random_A = Alphabet [Random.Range (0, Alphabet.Length)];
			string Random_B = Alphabet [Random.Range (0, Alphabet.Length)];
			string Random_C = Alphabet [Random.Range (0, Alphabet.Length)];
			string Random_D = Alphabet [Random.Range (0, Alphabet.Length)];
			string Random_E = Alphabet [Random.Range (0, Alphabet.Length)];

			string String4Letter = UserPhoneID.Substring(UserPhoneID.Length - 5);

			if (int.TryParse (numString, out number)) {
				if (TestingScript.isTesting == true) {
					Debug.Log ("String is the number: " + number);
				}
				GlobalRefNumber = String4Letter + "-" + Random_A + Random_B + Random_C + Random_D + Random_E + "-000-" + strPrizeCount;
				if (TestingScript.isTesting == true) {
					print ("GlobalRefNumber: " + GlobalRefNumber);
				}
			}
		}else{
			GlobalRefNumber = "";
			int TotalScore = ZPlayerPrefs.GetInt("ScoreCount");
			int TotalPoints = TotalScore / 5;
			//setting points to limits 179
			if(TotalPoints >= 100){
				isPrizeCount = false;
				UserPhoneID = SystemInfo.deviceUniqueIdentifier;
				//print ("UserPhoneID: "+UserPhoneID);
				StartCoroutine(CheckForTotalRefProcess());
			}
		}
	}
		

	public void StartCheckForTotalRef () {;

		UserPhoneID = SystemInfo.deviceUniqueIdentifier;
//		StartCoroutine(CheckForTotalRefProcess());
	}

	IEnumerator CheckForTotalRefProcess()
	{
		if (isPrizeCount)
			yield return null;

		isPrizeCount = true;

		//Assigns the data we want to save
		//Where -> Form.AddField("name" = matching name of value in SQL database
		WWWForm mForm = new WWWForm();
		mForm.AddField("UserPhoneID", UserPhoneID); // adds the player password to the form

		//Creates instance of WWW to runs the PHP script to save data to mySQL database
		WWW www = new WWW(PrizeCountPHP_Url, mForm);
		if (TestingScript.isTesting == true) {
			Debug.Log ("Processing...");
		}
		yield return www;


		string xyz = www.text;
		string[] arrayData = xyz.Split('-');
//		Debug.Log("" + www.text);

		//print ("V3pc_CheckForTotalRef.php "+ arrayData[1]);

		string netData = arrayData[0];
		netData = netData.Trim ();
		int totalRef = int.Parse(netData);
		totalRef = totalRef + 1;
		string Random_A = Alphabet [Random.Range (0, Alphabet.Length)];
		string Random_B = Alphabet [Random.Range (0, Alphabet.Length)];
		string Random_C = Alphabet [Random.Range (0, Alphabet.Length)];
		string Random_D = Alphabet [Random.Range (0, Alphabet.Length)];
		string Random_E = Alphabet [Random.Range (0, Alphabet.Length)];

		string String4Letter = UserPhoneID.Substring(UserPhoneID.Length - 5);

		string numString = arrayData[0];


		strPrizeCount  = arrayData[0];

		//Date
		string DataSplit = arrayData[1];
		string[] arrayDataSplit = DataSplit.Split('/');
		Year = arrayDataSplit[0];
		Month = arrayDataSplit[1];
		Day = arrayDataSplit[2];

		int numberYear;
		string numYear = Year;
		if (int.TryParse (numYear, out numberYear)) {
			if (TestingScript.isTesting == true) {
				print ("Year: " + Year);
			}
		} else {
			Year = "";
		}

		int numberMonth;
		string numMonth = Month;
		if (int.TryParse (numMonth, out numberMonth)) {
			if (TestingScript.isTesting == true) {
				print ("Month: " + Month);
			}
		} else {
			Month = "";
		}

		int numberDay;
		string numDay = Day;
		if (int.TryParse (numDay, out numberDay)) {
			if (TestingScript.isTesting == true) {
				print ("Day: " + Day);
			}
		} else {
			Day = "";
		}
		if (TestingScript.isTesting == true) {
			print ("Current Date: " + Year + "/" + Month + "/" + Day);

			print ("totalRef: " + totalRef);
		}
		//Total Ref
		int number;

		if (int.TryParse (numString, out number)) {
			if (TestingScript.isTesting == true) {
				Debug.Log ("String is the number: " + number);
			}
			GlobalRefNumber = String4Letter + "-" + Random_A + Random_B + Random_C + Random_D + Random_E + "-000-" + totalRef;
			if (TestingScript.isTesting == true) {
				print ("GlobalRefNumber: " + GlobalRefNumber);
			}
		} 
		else 
		{
			GlobalRefNumber = "";
		}

		isPrizeCount = false;
	}
}
