using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;
using System.Text.RegularExpressions;

using System;
using System.Security.Cryptography;
using System.Text;

public class MainMenu : MonoBehaviour {
	//DataBase Variable Login
	private string LoginPHP_Url = "https://immersivemedia.ph/potatocornerDB/pc_Account.php";
	protected string tblAccount_Username = "";
    protected string tblAccount_Password = "";
    private bool isLogin = false;
    
    //DataBase Variable Login
	private string PrizeCountPHP_Url = "https://immersivemedia.ph/potatocornerDB/pc_RegisterPrize.php";
	protected string tblPrizeCount_UserID = "";
    protected string tblPrizeCount_Storecode = "";
    protected string tbHighScore_Prize = "";
    private bool isPrizeCount = false;

    //Global Variable
	public static int globalScoreCount = 0;
	public static int globalTimeCount = 0;
	public static string globalFirstname = "First Name";
	public static string globalLastname = "Last Name";
	public static string globalEmail = "E-mail";
	public static string globalDUI = "None";
	private InputField InputFN,InputLN,InputEmail; 
	private GameObject GORegistration;
	private GameObject ErrorMessage;
	private GameObject HighScore;



	private const string
        constUsername = "PC272019",
        constPassword = "betterwithflavor";

	private Sprite sprClickOn, sprClickOff;
	private Image imgSubmit;

	//HighScore
	private GameObject TradeCoin_Background,HighScore_Background,NoPrizeClaim,YesPrizeClaim1,YesPrizeClaim2,YesPrizeClaim2_Error,YesPrizeClaim2_Success,YesPrizeClaim2_Error2Hack; 
	private GameObject TradeCoins, TradeCoinsBtn1,TradeCoinsBtn2,TradeCoinsCheck1,TradeCoinsCheck2;
	private InputField InputUsername,InputPassword;
	private GameObject ErrorMessage2,StoreCode_ErrorMessage;
	private GameObject NewLoading,NewLoading2;
	private string isAllDataGood = "";
	private bool isCheckIfAllOk = false;

	private GameObject YesPrizeClaim2_Success_Alert, YesPrizeClaim2_Success_Alert_Yes, YesPrizeClaim2_Success_Alert_No;

	private InputField StoreCode;
	private Text NumberOfClaims, YesPrizeClaim2_Email,YesPrizeClaim2_StoreCode,YesPrizeClaim2_Date;
	private Text RefNumber;

	private Dropdown BDay_Input_Month,BDay_Input_Day,BDay_Input_Year;
	public static int BDay_Input_MonthInt,BDay_Input_DayInt,BDay_Input_YearInt;

	private Text txtHighScore,txtTotalScore,txtTotalPoints, txtTotalPointsTC,txtTotalPackTC;

	public static bool isFirstTime = false;
	int TotalYear = 80;

	bool boolStartPrizeCount = false;

	private GameObject NeedRegistration; 

	private int PointsTotal = 100;//179;


	private GameObject ClaimingTitleBG;


	//Hide Buttons
	private GameObject btnHighScore,btnNoHighScore;
//	private int PointsTotal = 0;


	private void SetValue(){
        //PlayerPrefs.DeleteAll();
        ClaimingTitleBG = GameObject.Find ("ClaimingTitleBG");
		ClaimingTitleBG.SetActive (false);

		btnHighScore = GameObject.Find ("Buttons/btnHighScore");
		btnNoHighScore = GameObject.Find ("Buttons/btnNoHighScore");

		NewLoading = GameObject.Find ("NewLoading");
		NewLoading2 = GameObject.Find ("NewLoading2");

		NeedRegistration  = GameObject.Find ("NeedRegistration");

		YesPrizeClaim2_Success_Alert = GameObject.Find ("YesPrizeClaim2_Success_Alert");
		YesPrizeClaim2_Success_Alert_Yes = GameObject.Find ("YesPrizeClaim2_Success_Alert/Yes");
		YesPrizeClaim2_Success_Alert_No = GameObject.Find ("YesPrizeClaim2_Success_Alert/Yes");

		txtHighScore = GameObject.Find ("txtHighScore").GetComponent<Text>();
		txtTotalScore = GameObject.Find ("txtTotalScore").GetComponent<Text>();
		txtTotalPoints = GameObject.Find ("txtTotalPoints").GetComponent<Text>();
		txtTotalPointsTC = GameObject.Find ("txtTotalPointsTC").GetComponent<Text>();
		txtTotalPackTC = GameObject.Find ("txtTotalPackTC").GetComponent<Text>();

		InputUsername = GameObject.Find ("YesPrizeClaim1/Username").GetComponent<InputField>();
		InputPassword = GameObject.Find ("YesPrizeClaim1/Password").GetComponent<InputField>();
		ErrorMessage2 = GameObject.Find("ErrorMessage2");

		GORegistration = GameObject.Find("Registration");
		ErrorMessage = GameObject.Find("ErrorMessage");
		HighScore = GameObject.Find("HighScore");

		TradeCoins = GameObject.Find("TradeCoins");
		TradeCoinsBtn1 = GameObject.Find("TradeCoinsBtn1");
		TradeCoinsBtn2 = GameObject.Find("TradeCoinsBtn2");
		TradeCoinsCheck1 = GameObject.Find("TradeCoinsCheck1");
		TradeCoinsCheck2 = GameObject.Find("TradeCoinsCheck2");

		BDay_Input_Month = GameObject.Find ("BDay_Input_Month/InputDropdown").GetComponent<Dropdown>();
		BDay_Input_Day = GameObject.Find ("BDay_Input_Day/InputDropdown").GetComponent<Dropdown>();
		BDay_Input_Year = GameObject.Find ("BDay_Input_Year/InputDropdown").GetComponent<Dropdown>();

		HighScore_Background = GameObject.Find("HighScore/HighScore_Background");
		TradeCoin_Background = GameObject.Find("HighScore/TradeCoin_Background");
		NoPrizeClaim = GameObject.Find("HighScore/NoPrizeClaim");
		YesPrizeClaim1 = GameObject.Find("HighScore/YesPrizeClaim1");
		YesPrizeClaim2 = GameObject.Find("HighScore/YesPrizeClaim2");
		YesPrizeClaim2_Error = GameObject.Find("HighScore/YesPrizeClaim2_Error");
		YesPrizeClaim2_Error2Hack = GameObject.Find("HighScore/YesPrizeClaim2_Error2Hack");

		YesPrizeClaim2_Success = GameObject.Find("HighScore/YesPrizeClaim2_Success");
		StoreCode_ErrorMessage = GameObject.Find("StoreCode_ErrorMessage");

		StoreCode = GameObject.Find("YesPrizeClaim2_StoreCodeInput").GetComponent<InputField>();
		NumberOfClaims = GameObject.Find ("YesPrizeClaim2_NumberOfClaims").GetComponent<Text>();
		YesPrizeClaim2_Email = GameObject.Find ("YesPrizeClaim2_Email").GetComponent<Text>();
		YesPrizeClaim2_StoreCode = GameObject.Find ("YesPrizeClaim2_Success/YesPrizeClaim2_StoreCode").GetComponent<Text>();
		YesPrizeClaim2_Date = GameObject.Find ("YesPrizeClaim2_Date").GetComponent<Text>();
		RefNumber = GameObject.Find ("YesPrizeClaim2_RefNumber").GetComponent<Text>();

		InputFN = GameObject.Find ("InputField_Intput_FN").GetComponent<InputField>();
		InputLN = GameObject.Find ("InputField_Input_LN").GetComponent<InputField>();
		InputEmail = GameObject.Find ("InputField_Input_EMail").GetComponent<InputField>();
	}



	private const string MatchEmailPattern =
            @"^(([\w-]+\.)+[\w-]+|([a-zA-Z]{1}|[\w-]{2,}))@"
            + @"((([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\."
              + @"([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])){1}|"
            + @"([a-zA-Z]+[\w-]+\.)+[a-zA-Z]{2,4})$";

	// Use this for initialization
	void Start () {
		GlobalVarReset.ResetDataGlobal ();
		SetValue();
		BdayDropDown ();

		this.GetComponent<UpdateScore>().enabled = false;
		this.GetComponent<UpdateScore>().enabled = true;
		ErrorMessage.SetActive(false);
		ErrorMessage2.SetActive(false);
		NewLoading.SetActive (false);
		NeedRegistration.SetActive (true);


		ZPlayerPrefs.Initialize("what'sYourName", "salt12issalt");
		StoreCode_ErrorMessage.SetActive(false);
		BDay_Input_YearInt = 0;
		BDay_Input_MonthInt = 0;
		BDay_Input_DayInt = 0;

		if (PlayerPrefs.HasKey ("LifePlay") == false) {
			PlayerPrefs.SetInt("LifePlay", 5);
		}

		if (PlayerPrefs.HasKey("ScoreCount") == false) {

			//Incripted
			ZPlayerPrefs.SetInt("ScoreCount", 0);

			PlayerPrefs.SetInt("TimeCount", 0);
			PlayerPrefs.SetString("Firstname", globalFirstname);
			PlayerPrefs.SetString("Lastname", globalLastname);
			PlayerPrefs.SetString("Email", globalEmail);

			PlayerPrefs.SetInt("BDay_Input_YearInt", BDay_Input_YearInt);
			PlayerPrefs.SetInt("BDay_Input_MonthInt", BDay_Input_MonthInt);
			PlayerPrefs.SetInt("BDay_Input_DayInt", BDay_Input_DayInt);

			GORegistration.SetActive(true);
			isFirstTime = true;
		}else{
			//Incripted
			//ZPlayerPrefs.SetInt("ScoreCount", 100);
			#if UNITY_EDITOR
//				int TotalDataTemp = 1000;
//				ZPlayerPrefs.SetInt("ScoreCount", TotalDataTemp);
//				PlayerPrefs.SetInt("TimeCount", 3600);
			#endif
			if (TestingScript.isTesting == true) {
				int TotalDataTemp = 2000;
				ZPlayerPrefs.SetInt ("ScoreCount", TotalDataTemp);
				PlayerPrefs.SetInt ("TimeCount", 600);//3600
            }

			globalScoreCount = ZPlayerPrefs.GetInt("ScoreCount");
			if(globalScoreCount >= 1500){
				int TotalDataTemp = 1500;
				ZPlayerPrefs.SetInt ("ScoreCount", TotalDataTemp);

				if (FBGlobalVar.isClaimingTitleBG == false) {
					ClaimingTitleBG.SetActive (true);
				} else {
					ClaimingTitleBG.SetActive (false);
				}
			}

			globalScoreCount = ZPlayerPrefs.GetInt("ScoreCount");

			globalTimeCount = PlayerPrefs.GetInt("TimeCount");
			globalFirstname = PlayerPrefs.GetString("Firstname");
			globalLastname = PlayerPrefs.GetString("Lastname");
			globalEmail = PlayerPrefs.GetString("Email");

            //print("globalTimeCount: "+ globalTimeCount);

			BDay_Input_YearInt = PlayerPrefs.GetInt("BDay_Input_YearInt");
			BDay_Input_MonthInt = PlayerPrefs.GetInt("BDay_Input_MonthInt");
			BDay_Input_DayInt = PlayerPrefs.GetInt("BDay_Input_DayInt");

			BDay_Input_Year.captionText.text = ""+BDay_Input_YearInt;
			BDay_Input_Month.captionText.text = ""+BDay_Input_MonthInt;
			BDay_Input_Day.captionText.text = ""+BDay_Input_DayInt;

			GORegistration.SetActive(false);
			isFirstTime = false;
		}

		if (PlayerPrefs.HasKey("HighScoreCount") == false){
			PlayerPrefs.SetInt("HighScoreCount", 0);
			PlayerPrefs.SetInt("ScoreCount", 0);
		}
		int HighScoreCount = PlayerPrefs.GetInt("HighScoreCount");
		int TotalScore = ZPlayerPrefs.GetInt("ScoreCount");
		txtHighScore.text = HighScoreCount+"";
		txtTotalScore.text = TotalScore+"";

		int TotalPoints = TotalScore / 5;
		//setting points to limits 179
		if(TotalPoints >= 179){
			//TotalPoints = 179;
		}
		txtTotalPoints.text = TotalPoints+"";
		txtTotalPointsTC.text  = TotalPoints+"";
		int TotalPactTC = TotalPoints / 100;
		//txtTotalPackTC.text  = TotalPactTC+"";

		if (TotalPactTC == 0) {
			txtTotalPackTC.text = "YOU’RE ALMOST THERE!\n" +
				"EARN UP TO 100 COINS TO REDEEM YOUR P100 GIGA FRIES " +
				"DISCOUNT!";

//			btnHighScore.SetActive (false);
//			btnNoHighScore.SetActive (true);
			btnHighScore.SetActive (true);
			btnNoHighScore.SetActive (false);
		} else {
			txtTotalPackTC.text = "YOU NOW HAVE 100 COINS!\n" +
				"YOU CAN NOW REDEEM\nYOUR P100 GIGA FRIES\n" +
				"DISCOUNT!";

			btnHighScore.SetActive (true);
			btnNoHighScore.SetActive (false);
		}
		print ("TotalPactTC: "+TotalPactTC);



		InputFN.text = globalFirstname;
		InputLN.text = globalLastname;
		InputEmail.text = globalEmail;
		globalDUI = SystemInfo.deviceUniqueIdentifier;

		if(TestingScript.isTesting == true){
			print("globalTimeCount: "+ globalTimeCount);
		}




		HighScoreHide();
	}


	// Update is called once per frame
	void Update(){
		//Hide Force Registration
		NeedRegistration.SetActive (false);

		if(isAllDataGood == "No"){
			NewLoading2.SetActive (true);
		}else if(isAllDataGood == "Yes"){
			NewLoading2.SetActive (false);
		}else if(isAllDataGood == ""){
			NewLoading2.SetActive (false);
		}
		if(isCheckIfAllOk == true){

			if (UpdateGetPrize.ConnectionSuccessful == true  && UpdateScore.ConnectionSuccessful == true && CheckForTotalRef.GlobalRefNumber != "" && CheckForTotalRef.Day != "" && CheckForTotalRef.Month != "" && CheckForTotalRef.Year != "") {
				isAllDataGood = "Yes";
				isCheckIfAllOk = false;
			}
		}

	}


	public void FbtnStartGame () {
		//Incription
		//to be Delete
		int CurrentLifePlay = PlayerPrefs.GetInt("LifePlay");

		if (CurrentLifePlay <= 0) {
			LifePlayController.isLifePlayPopUp = true;
		} else {
//			CurrentLifePlay = 0;

			CurrentLifePlay = CurrentLifePlay - 1;
			PlayerPrefs.SetInt("LifePlay", CurrentLifePlay);


			//to be Delete
			CurrentLifePlay = PlayerPrefs.GetInt("LifePlay");
			print("CurrentLifePlay: "+CurrentLifePlay);

			globalScoreCount = ZPlayerPrefs.GetInt("ScoreCount");

			globalTimeCount = PlayerPrefs.GetInt("TimeCount");
			globalFirstname = PlayerPrefs.GetString("Firstname");
			globalLastname = PlayerPrefs.GetString("Lastname");
			globalEmail = PlayerPrefs.GetString("Email");

			if (isFirstTime == true) {
				Application.LoadLevel ("Scene02_Tutorial");
			} else {
				Application.LoadLevel ("Scene00_Loading2");
			}
		}

//		Application.LoadLevel ("Scene00_Loading2");
//		Application.LoadLevel ("Scene01_Game");

	}

	public void FbtnTutorial () {
		Application.LoadLevel ("Scene02_Tutorial");
	}

	public void SaveUserInfo(){
		//if (Email == "E-mail" || Firstname == "First Name" || Lastname == "Last Name" || Firstname.Contains("First") || Lastname.Contains("Last") || Firstname.Contains("Name") || Lastname.Contains("Name") || Firstname.Contains("name") || Lastname.Contains("name")) {
		bool LocIsBday = false;
		globalEmail = InputEmail.text;
		if (BDay_Input_YearInt != 0 && BDay_Input_MonthInt != 0 && BDay_Input_DayInt != 0 && BDay_Input_YearInt != null && BDay_Input_MonthInt != null && BDay_Input_DayInt != null) {
			PlayerPrefs.SetInt ("BDay_Input_YearInt", BDay_Input_YearInt);
			PlayerPrefs.SetInt ("BDay_Input_MonthInt", BDay_Input_MonthInt);
			PlayerPrefs.SetInt ("BDay_Input_DayInt", BDay_Input_DayInt);
			LocIsBday = true;
		} else {
			if (TestingScript.isTesting == true) {
				print ("Invalid Birthday!");
			}
            //ErrorMessage.GetComponent<Text> ().text = "Invalid Birthday!";
            //StartCoroutine(ExecuteShowMessage(3f,ErrorMessage));
            //LocIsBday = false;

            BDay_Input_YearInt = 2018;
            BDay_Input_MonthInt = 01;
            BDay_Input_DayInt = 01;
            PlayerPrefs.SetInt("BDay_Input_YearInt", BDay_Input_YearInt);
            PlayerPrefs.SetInt("BDay_Input_MonthInt", BDay_Input_MonthInt);
            PlayerPrefs.SetInt("BDay_Input_DayInt", BDay_Input_DayInt);
            LocIsBday = true;
        }

		if(IsEmail(globalEmail) == true){
			PlayerPrefs.SetString("Email", InputEmail.text);
			this.GetComponent<UpdateScore>().enabled = true;
			globalEmail = InputEmail.text;

		}else{
			if (TestingScript.isTesting == true) {
				print ("Invalid Email!");
			}
			ErrorMessage.GetComponent<Text>().text = "Invalid Email!";
			StartCoroutine(ExecuteShowMessage(3f,ErrorMessage));
		}


		if (InputLN.text != "" && InputLN.text != " " && InputLN.text != "Last Name" || InputLN.text.Contains("Name") || InputLN.text.Contains("Last")) {
			if (InputLN.text.Contains ("Name") || InputLN.text.Contains ("Last")|| InputLN.text.Contains ("First")) {
				ErrorMessage.GetComponent<Text>().text = "Invalid Last Name!";
				StartCoroutine(ExecuteShowMessage(3f,ErrorMessage));
			} else {
				PlayerPrefs.SetString("Lastname", InputLN.text);
			}

		} else {
			ErrorMessage.GetComponent<Text>().text = "Invalid Last Name!";
			StartCoroutine(ExecuteShowMessage(3f,ErrorMessage));
		}

		if (InputFN.text != "" && InputFN.text != " " && InputFN.text != "First Name") {
			if (InputFN.text.Contains ("Name") || InputFN.text.Contains ("First")|| InputFN.text.Contains ("Last")) {
				ErrorMessage.GetComponent<Text>().text = "Invalid First Name!";
				StartCoroutine(ExecuteShowMessage(3f,ErrorMessage));
			} else {
				PlayerPrefs.SetString ("Firstname", InputFN.text);
			}

		} else {
			ErrorMessage.GetComponent<Text>().text = "Invalid First Name!";
			StartCoroutine(ExecuteShowMessage(3f,ErrorMessage));
		}




		if(IsEmail(globalEmail) == true && InputFN.text != "" && InputFN.text != " " && InputFN.text != "First Name" && InputLN.text != "" && InputLN.text != " " && InputLN.text != "Last Name" && LocIsBday == true){
			if (InputLN.text.Contains ("Name") || InputLN.text.Contains ("Last") || InputLN.text.Contains ("First") || InputFN.text.Contains ("Name") || InputFN.text.Contains ("First") || InputFN.text.Contains ("Last") || InputFN.text == "First Name" || InputLN.text == "Last Name" || InputFN.text.Contains("First") || InputLN.text.Contains("Last") || InputFN.text.Contains("Name") || InputLN.text.Contains("Name") || InputFN.text.Contains("name") || InputLN.text.Contains("name")) {
				//ErrorMessage.GetComponent<Text>().text = "Invalid!";
				//StartCoroutine(ExecuteShowMessage(3f,ErrorMessage));
			} else {
				UpdateScore.UpdateRegistration = true;
				UpdateScore.ConnectionSuccessful = false;
				Back();
			}
		}
	}

	IEnumerator ExecuteShowMessage(float time,GameObject Error)
	{
		Error.SetActive(true);
		yield return new WaitForSeconds(time);
		Error.SetActive(false);
	}

	public static bool IsEmail(string email)
    {
        if (email != null) return Regex.IsMatch(email, MatchEmailPattern);
        else return false;
    }

	public void Back(){
		GORegistration.SetActive(false);
	}
	public void Registration(){
		this.GetComponent<UpdateScore>().enabled = false;
		bool isDataValid = false;
		string Email = PlayerPrefs.GetString("Email");
		string Lastname = PlayerPrefs.GetString("Lastname");
		string Firstname = PlayerPrefs.GetString("Firstname");
		if (Email == "E-mail" || Lastname == "First Name" || Lastname == "Last Name") {
			NeedRegistration.SetActive (true);
		} else {
			NeedRegistration.SetActive (false);
		}

		GORegistration.SetActive(true);
	}

	public void NeedRegistrationFunc(){
		NeedRegistration.SetActive (false);
	}

	public void HighScoreShow(){
		HighScore.SetActive(true);
		HighScore_Background.SetActive (true);
		TradeCoin_Background.SetActive (false);
		TradeCoins.SetActive(false);
		NoPrizeClaim.SetActive(false);
		NoPrizeClaim.SetActive(false);
		YesPrizeClaim1.SetActive(false);
		YesPrizeClaim2.SetActive(false);
		YesPrizeClaim2_Success.SetActive(false);
		YesPrizeClaim2_Error.SetActive(false);
		YesPrizeClaim2_Error2Hack.SetActive(false);
		YesPrizeClaim2_Success_Alert.SetActive (false);
		NumberOfClaims.text = UpdateGetPrize.PrizeCount;
		YesPrizeClaim2_Email.text = "Email: "+globalEmail;

		YesPrizeClaim2_Date.text ="Date: "+ CheckForTotalRef.Year+"/"+ CheckForTotalRef.Month+"/"+ CheckForTotalRef.Day;

//		string numString = UpdateGetPrize.PrizeCount+"";
//		int number;
//
//		if (int.TryParse (numString, out number)) {
//			
//		} else {
//			print ("UpdateGetPrize.PrizeCount Not Working");
//		}
//		print ("CheckForTotalRef.GlobalRefNumber: "+ CheckForTotalRef.GlobalRefNumber);
		RefNumber.text = CheckForTotalRef.GlobalRefNumber;
	}

	public void TradeCoin_BackgroundShow(){
		HighScore.SetActive(true);
		HighScore_Background.SetActive (false);
		TradeCoin_Background.SetActive (true);
		TradeCoins.SetActive(false);
		NoPrizeClaim.SetActive(false);
		NoPrizeClaim.SetActive(false);
		YesPrizeClaim1.SetActive(false);
		YesPrizeClaim2.SetActive(false);
		YesPrizeClaim2_Success.SetActive(false);
		YesPrizeClaim2_Error.SetActive(false);
		YesPrizeClaim2_Error2Hack.SetActive(false);
		YesPrizeClaim2_Success_Alert.SetActive (false);
		NumberOfClaims.text = UpdateGetPrize.PrizeCount;
		YesPrizeClaim2_Email.text = "Email: "+globalEmail;

		YesPrizeClaim2_Date.text ="Date: "+ CheckForTotalRef.Year+"/"+ CheckForTotalRef.Month+"/"+ CheckForTotalRef.Day;

		RefNumber.text = CheckForTotalRef.GlobalRefNumber;
	}



	public void HighScoreHide(){
		HighScore.SetActive(false);
		HighScore_Background.SetActive(false);
		TradeCoin_Background.SetActive (false);
		TradeCoins.SetActive(false);
		NoPrizeClaim.SetActive(false);
		YesPrizeClaim1.SetActive(false);
		YesPrizeClaim2.SetActive(false);
	}

	public void GetPrize(){
		//Incription
		int TotalScore = ZPlayerPrefs.GetInt("ScoreCount");
		int Points = TotalScore / 5;
		//Score Controller 179
		bool isDataValid = false;
		string Email = PlayerPrefs.GetString("Email");
		string Lastname = PlayerPrefs.GetString("Lastname");
		string Firstname = PlayerPrefs.GetString("Firstname");
		if (Email == "E-mail" || Firstname == "First Name" || Lastname == "Last Name" || Firstname.Contains("First") || Lastname.Contains("Last") || Firstname.Contains("Name") || Lastname.Contains("Name") || Firstname.Contains("name") || Lastname.Contains("name")) {
			isDataValid = false;
		} else {
			isDataValid = true;
		}

		if(Points >= PointsTotal){
			if (isDataValid == false) {
				Registration ();
			} else {
				//YesPrizeClaim1.SetActive(true);
				TradeCoins.SetActive (true);
				TradeCoinsFunc ();
				HighScore_Background.SetActive (false);
				TradeCoin_Background.SetActive (false);
				YesPrizeClaim2_Email.text = "Email: "+globalEmail;

				if (UpdateGetPrize.ConnectionSuccessful == true && CheckForTotalRef.GlobalRefNumber != "" && CheckForTotalRef.Day != "" && CheckForTotalRef.Month != "" && CheckForTotalRef.Year != "") {
					isAllDataGood = "Yes";
				} else {
					isAllDataGood = "No";
					isCheckIfAllOk = true;
				}
			}

		}else{
			if (isDataValid == false) {
				Registration ();
				NoPrizeClaim.SetActive (true);
				HighScore_Background.SetActive (false);
				TradeCoin_Background.SetActive (false);
			} else {
				NoPrizeClaim.SetActive (true);
				HighScore_Background.SetActive (false);
				TradeCoin_Background.SetActive (false);
			}
		}


	}

	public void NoPrizeClaimFuncClose(){
		HighScore.SetActive(false);
	}
		

	public void NoPrizeClaimFuncBack(){
		HighScore_Background.SetActive(true);
		TradeCoin_Background.SetActive (false);
		NoPrizeClaim.SetActive(false);
	}

	public void TradeCoinsFunc(){
		TradeCoinsBtn1.SetActive (false);
		TradeCoinsBtn2.SetActive (true);
		TradeCoinsCheck1.SetActive (true);
		TradeCoinsCheck2.SetActive (false);
	}

	public void TradeCoinsCheck1Func(){
		TradeCoinsBtn1.SetActive (true);
		TradeCoinsBtn2.SetActive (false);
		TradeCoinsCheck1.SetActive (false);
		TradeCoinsCheck2.SetActive (true);

	}

	public void TradeCoinsBtn1Func(){
		if (TestingScript.isTesting == true) {
			print ("UpdateScore.ConnectionSuccessful == " + UpdateScore.ConnectionSuccessful);
			print ("UpdateGetPrize.ConnectionSuccessful == " + UpdateGetPrize.ConnectionSuccessful);
			print ("CheckForTotalRef.GlobalRefNumber == " + CheckForTotalRef.GlobalRefNumber);//UpdateScore.ConnectionSuccessful == true && 
			print ("CheckForTotalRef.Date == " + CheckForTotalRef.Year + "/" + CheckForTotalRef.Month + "/" + CheckForTotalRef.Day);
		}
		if (UpdateGetPrize.ConnectionSuccessful == true && UpdateScore.ConnectionSuccessful == true && CheckForTotalRef.GlobalRefNumber != "" && CheckForTotalRef.Day != ""  && CheckForTotalRef.Month != ""  && CheckForTotalRef.Year != ""  ) {
			if(globalTimeCount >= 600){  //3600
				YesPrizeClaim1.SetActive(true);
				TradeCoins.SetActive(false);
			}else{
				HighScore_Background.SetActive (false);
				TradeCoin_Background.SetActive (false);
				YesPrizeClaim2_Error2Hack.SetActive(true);
			}

		} else {
			HighScore_Background.SetActive (false);
			TradeCoin_Background.SetActive (false);
			YesPrizeClaim2_Error.SetActive(true);
		}
	}

	public void YesPrizeClaim1Close(){
		HighScore.SetActive(false);
		YesPrizeClaim1.SetActive(false);
	}

	public void YesPrizeClaim1Login(){
		if (TestingScript.isTesting == true) {
			print ("CheckForTotalRef.GlobalRefNumber: " + CheckForTotalRef.GlobalRefNumber);
		}
		RefNumber.text = CheckForTotalRef.GlobalRefNumber;
		//CheckForTotalRef.GlobalRefNumber = "";
//		if (CheckForTotalRef.GlobalRefNumber != "") {
//			RefNumber.text = CheckForTotalRef.GlobalRefNumber;
//			//NewLoading.SetActive (true);
//			StartLogin ();
//		} else {
//			HighScore_Background.SetActive (false);
//			YesPrizeClaim2_Error.SetActive(true);
//		}

		StartLogin ();
	}

	public void YesPrizeClaim2Close(){
		YesPrizeClaim2.SetActive(false);
		HighScore.SetActive(false);
	}


	public void YesPrizeClaim2Submit(){
		if(StoreCode.text == "" || StoreCode.text == " " || StoreCode.text == null){
			StoreCode_ErrorMessage.GetComponent<Text>().text = "No Storecode";
			StartCoroutine(ExecuteShowMessage(3f,StoreCode_ErrorMessage));
		}else{
			if(boolStartPrizeCount == false){
				boolStartPrizeCount = true;
				NewLoading.SetActive (true);
				StartPrizeCount ();
			}

		}
	}

	public void YesPrizeClaim2_Success_CloseFunc(){
		YesPrizeClaim2_Success_Alert.SetActive (true);
	}

	public void YesPrizeClaim2_Success_AlertYesFunc(){
		YesPrizeClaim2_Success.SetActive(false);
		YesPrizeClaim2_Success_Alert.SetActive (false);
		YesPrizeClaim2_Error.SetActive(false);
		YesPrizeClaim2_Error2Hack.SetActive(false);
		YesPrizeClaim2_Success.SetActive(false);
		HighScore.SetActive(false);
	}

	public void YesPrizeClaim2_Success_AlertNoFunc(){
		YesPrizeClaim2_Success_Alert.SetActive (false);
	}

	public void YesPrizeClaim2_ErrorSuccessClose(){
		YesPrizeClaim2_Error.SetActive(false);
		YesPrizeClaim2_Error2Hack.SetActive(false);
		YesPrizeClaim2_Success.SetActive(false);
		HighScore.SetActive(false);
	}


	//Database Interaction
	private void StartLogin () {
		isLogin = false;
		//print ("constUsername: "+constUsername);
		//print ("constPassword: "+constPassword);
		tblAccount_Username = InputUsername.text;
		tblAccount_Password = InputPassword.text;
		if (tblAccount_Username == constUsername && tblAccount_Password == constPassword) {
			if (TestingScript.isTesting == true) {
				Debug.Log ("Registered Successfully.");
			}
			YesPrizeClaim2.SetActive (true);
			YesPrizeClaim1.SetActive (false);
			YesPrizeClaim2_Success.SetActive (false);
			YesPrizeClaim2_Error.SetActive (false);
			YesPrizeClaim2_Error2Hack.SetActive (false);
			boolStartPrizeCount = false;
			//NewLoading.SetActive (false);
		} else {
			ErrorMessage2.GetComponent<Text>().text = "Invalid Account";
			StartCoroutine(ExecuteShowMessage(3f,ErrorMessage2));
			boolStartPrizeCount = false;
			//NewLoading.SetActive (false);
		}
        //StartCoroutine(LoginProcess());
	}

	IEnumerator LoginProcess()
    {
        if (isLogin)
            yield return null;

        isLogin = true;
		NumberOfClaims.text = UpdateGetPrize.PrizeCount;
        //Assigns the data we want to save
        //Where -> Form.AddField("name" = matching name of value in SQL database
        WWWForm mForm = new WWWForm();
        mForm.AddField("tblAccount_Username", tblAccount_Username); // adds the player password to the form
        mForm.AddField("tblAccount_Password", tblAccount_Password); // adds the kill total to the form

        //Creates instance of WWW to runs the PHP script to save data to mySQL database
        WWW www = new WWW(LoginPHP_Url, mForm);
		if (TestingScript.isTesting == true) {
			Debug.Log ("Processing...");
		}
        yield return www;

		if (TestingScript.isTesting == true) {
			Debug.Log ("" + www.text);
		}
        if (www.text == "successful")
        {
			if (TestingScript.isTesting == true) {
				Debug.Log ("Registered Successfully.");
			}
            YesPrizeClaim2.SetActive(true);
			YesPrizeClaim1.SetActive(false);
			YesPrizeClaim2_Success.SetActive(false);
			YesPrizeClaim2_Error.SetActive(false);
			YesPrizeClaim2_Error2Hack.SetActive(false);
			boolStartPrizeCount = false;
			NewLoading.SetActive (false);
        }
        else
        {
			if (TestingScript.isTesting == true) {
				Debug.Log (www.text);
			}
            ErrorMessage2.GetComponent<Text>().text = "Invalid Account";
			StartCoroutine(ExecuteShowMessage(3f,ErrorMessage2));
			boolStartPrizeCount = false;
			NewLoading.SetActive (false);
        }
        isLogin = false;
    }

    private void StartPrizeCount () {
		isPrizeCount = false;
		tblPrizeCount_UserID = globalDUI+"";
		tblPrizeCount_Storecode = StoreCode.text;
		YesPrizeClaim2_StoreCode.text = "Store Code: "+StoreCode.text;
		int CurrentPrizeCount =  int.Parse(UpdateGetPrize.PrizeCount);
		int TotalPrizeCount = CurrentPrizeCount + 1;
		tbHighScore_Prize = TotalPrizeCount+"";

//		UpdateGetPrize.PrizeCount = null;
//		CheckForTotalRef.GlobalRefNumber = null;
		if (UpdateGetPrize.ConnectionSuccessful == true  && UpdateScore.ConnectionSuccessful == true && CheckForTotalRef.GlobalRefNumber != "" && CheckForTotalRef.Day != "" && CheckForTotalRef.Month != "" && CheckForTotalRef.Year != "") {
			if(UpdateGetPrize.PrizeCount == "" || CheckForTotalRef.GlobalRefNumber == "" || UpdateGetPrize.PrizeCount == null || CheckForTotalRef.GlobalRefNumber == null){
				YesPrizeClaim2_Error.SetActive(true);
				YesPrizeClaim2_Error2Hack.SetActive(false);
				YesPrizeClaim2.SetActive (false);
				NewLoading.SetActive (false);
			}else{
				StartCoroutine(PrizeCountProcess());
				NewLoading.SetActive (true);
			}
		}
	}

	IEnumerator PrizeCountProcess()
    {
        if (isLogin)
            yield return null;

        isPrizeCount = true;
		 
		string tblPrizeCount_RefNo = CheckForTotalRef.GlobalRefNumber;
        //Assigns the data we want to save
        //Where -> Form.AddField("name" = matching name of value in SQL database
        WWWForm mForm = new WWWForm();
        mForm.AddField("tblPrizeCount_UserID", tblPrizeCount_UserID); // adds the player password to the form
        mForm.AddField("tblPrizeCount_Storecode", tblPrizeCount_Storecode); // adds the kill total to the form
		mForm.AddField("tbHighScore_Prize", tbHighScore_Prize); // adds the kill total to the form
		mForm.AddField("tblPrizeCount_RefNo", tblPrizeCount_RefNo); // adds the kill total to the form

        //Creates instance of WWW to runs the PHP script to save data to mySQL database
        WWW www = new WWW(PrizeCountPHP_Url, mForm);
		if (TestingScript.isTesting == true) {
			Debug.Log ("PrizeCountProcess...");
		}
        yield return www;
		if (TestingScript.isTesting == true) {
			Debug.Log ("" + www.text);
		}

		InputPassword.text = "";
		InputUsername.text = "";
        if (www.text == "successful")
        {
			if (TestingScript.isTesting == true) {
				Debug.Log ("Registered Successfully.");
			}
            YesPrizeClaim2_Success.SetActive(true);
			YesPrizeClaim2.SetActive (false);

			//Incription
			int TotalScore = ZPlayerPrefs.GetInt("ScoreCount");

			int FinalTotalScore = TotalScore - 500;
			int TotalPoints = FinalTotalScore / 5;

			ZPlayerPrefs.SetInt("ScoreCount", FinalTotalScore);


			txtTotalScore.text = ""+FinalTotalScore;
			txtTotalPoints.text = ""+TotalPoints;
			txtTotalPointsTC.text = ""+TotalPoints;

			int TotalPactTC = TotalPoints / 100;
//			txtTotalPackTC.text  = TotalPactTC+"";

			if (TotalPactTC == 0) {
				txtTotalPackTC.text = "YOU’RE ALMOST THERE!\nEARN UP TO 100 COINS\nTO REDEEM YOU P100\nGIGA FRIES DISCOUNT!\n";
			} else {
				txtTotalPackTC.text = "CONGRATULATIONS!\nYOU CAN NOW REDEEM\nP100 GIGA FRIES DISCOUNT!\n";
			}

			NewLoading.SetActive (false);
        }
        else
        {
			if (TestingScript.isTesting == true) {
				Debug.Log (www.text);
			}
			YesPrizeClaim2_Error.SetActive(true);
			YesPrizeClaim2_Error2Hack.SetActive(false);
			YesPrizeClaim2.SetActive (false);
			NewLoading.SetActive (false);
        }
        isPrizeCount = false;
    }


	public void URLPotatocCornerTutorial(){
		Application.OpenURL("https://bit.ly/PotatoCornerCraze");
	}
	//DropDown
	public void BdayDropDown(){
		BDay_Input_Month.onValueChanged.AddListener (delegate {
			BDay_Input_MonthValueChangedHandler(BDay_Input_Month);
		});
		BDay_Input_Month.options.Clear();

		for(int x = 1; x < 13; x++){
			if (x < 10) {
				BDay_Input_Month.options.Add (new Dropdown.OptionData () { text = "0" + x });
			} else {
				BDay_Input_Month.options.Add (new Dropdown.OptionData () { text = "" + x });
			}
		}

		BDay_Input_Day.onValueChanged.AddListener (delegate {
			BDay_Input_DayValueChangedHandler(BDay_Input_Day);
		});
		BDay_Input_Day.options.Clear();

		for(int x = 1; x < 32; x++){
			if (x < 10) {
				BDay_Input_Day.options.Add (new Dropdown.OptionData () { text = "0" + x });
			} else {
				BDay_Input_Day.options.Add (new Dropdown.OptionData () { text = "" + x });
			}
		}

		BDay_Input_Year.onValueChanged.AddListener (delegate {
			BDay_Input_YearValueChangedHandler(BDay_Input_Year);
		});
		BDay_Input_Year.options.Clear();

		int currentYear = DateTime.Now.Year;

		for(int x = 1; x < TotalYear; x++){
			int SubYear = currentYear - x;
			BDay_Input_Year.options.Add (new Dropdown.OptionData () { text = "" + SubYear });
		}

	}

	private void BDay_Input_MonthValueChangedHandler(UnityEngine.UI.Dropdown target){

	}

	public void SetBDay_Input_MonthIndex(int index){
		BDay_Input_Month.value = index;
	}

	private void BDay_Input_DayValueChangedHandler(UnityEngine.UI.Dropdown target){

	}

	public void SetBDay_Input_DayIndex(int index){
		BDay_Input_Day.value = index;
	}

	private void BDay_Input_YearValueChangedHandler(UnityEngine.UI.Dropdown target){

	}

	public void SetBDay_Input_YearIndex(int index){
		BDay_Input_Day.value = index;
	}

	public void BDay_Input_YearFunc(){
		int currentYear = DateTime.Now.Year;
		for(int x = 0; x < TotalYear; x++){
			if(BDay_Input_Year.value == x){
				int SubYear = currentYear - (x+1);
				BDay_Input_YearInt = SubYear;
				if (TestingScript.isTesting == true) {
					print ("YEAR: " + BDay_Input_YearInt);
				}

			}
		}
	}

	public void BDay_Input_MonthFunc(){
		for(int x = 1; x < 13; x++){
			if(BDay_Input_Month.value == x){
				BDay_Input_MonthInt = x + 1;
				if (TestingScript.isTesting == true) {
					print ("MONTH: " + BDay_Input_MonthInt);
				}

			}
		}
	}


	public void BDay_Input_DayFunc(){
		for(int x = 1; x < 33; x++){
			if(BDay_Input_Day.value == x){
				BDay_Input_DayInt = x + 1;
				if (TestingScript.isTesting == true) {
					print ("DAY: " + BDay_Input_DayInt);
				}
			}
		}
	}

//	private Sprite sprClickOn, sprClickOff;
//	private Image imgSubmit;
	public void SubmitOn(){
		imgSubmit.sprite = sprClickOn;
	}

	public void SubmitOff(){
		imgSubmit.sprite = sprClickOff;
	}

	public void URLPotatocCornerTutorialMain(){ //https://immersivemedia.ph/potatocornerWebsite/
		Application.OpenURL("https://immersivemedia.ph/potatocornerWebsite/");//https://bit.ly/PotatoCornerCraze
	}

	public void ClaimingTitleBGFunc(){
		print ("Hello world 22223333");
		FBGlobalVar.isClaimingTitleBG = true;
		ClaimingTitleBG.SetActive (false);
	}
}
