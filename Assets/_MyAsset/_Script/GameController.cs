using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;

using System.Security.Cryptography;
using System.Text;

//using GoogleMobileAds.Api;
//using UnityEngine.Advertisements;

public class GameController : MonoBehaviour {
	public  static bool isCharacterOn_1Postion = false;
	public  static bool isCharacterOn_2Postion = false;
	public  static bool isCharacterOn_3Postion = false;
	public static int ScoreCount = 0;

	private int RDCharacter_1,RDCharacter_2,RDCharacter_3,RDCharacterChoice_1,RDCharacterChoice_2,RDCharacterChoice_3;
	private bool isCharacterOn_1,isCharacterOn_2,isCharacterOn_3;
	const float TimeOfTime = 90.0f;
	public static float timeleft = TimeOfTime;
	public static  float timeleftCounter = TimeOfTime;
	private bool isAngry_1 = false,isAngry_2 = false,isAngry_3 = false;
	private float TempTime_1,TempTime_2,TempTime_3;
	private int LifeCount;
	private bool isGrillerAnim = false;
	private GameObject OBCharChoicesList_1,OBCharChoicesList_2,OBCharChoicesList_3;

	private Image Character01_Angry_1,Character01_Angry_2,Character01_Angry_3;
	private int RDCharacterList_1,RDCharacterList_2,RDCharacterList_3;

	//timer 
	private Image WTimer_Cooldown_1,WTimer_Cooldown_2,WTimer_Cooldown_3;
	private const float constAgry = 6.0f, constWait = 12.0f;
	private float WTimer_WaitTime_1 = constWait,WTimer_WaitTime_2 = constWait,WTimer_WaitTime_3 = constWait;//12
	private float WTimer_Angry_1 = constAgry,WTimer_Angry_2 = constAgry,WTimer_Angry_3 =  constAgry;//10
    private bool isGrillerNotEmpty = false;
	private bool isSouce01,isSouce02,isSouce03,isSouce04,isSouce05,isSouce06;
    private bool isOrderWrong_1 = false,isOrderRight_1 = false;
    private bool isOrderWrong_2 = false,isOrderRight_2 = false;
    private bool isOrderWrong_3 = false,isOrderRight_3 = false;
    private float WTimer_Minus_1,WTimer_Minus_2,WTimer_Minus_3;
    private GameObject CharacterData1_1,CharacterData2_1,CharacterData3_1;
    private GameObject CharacterData1_2,CharacterData2_2,CharacterData3_2;
    private GameObject CharacterData1_3,CharacterData2_3,CharacterData3_3;
    private GameObject Happy_Bubbles_1,Happy_Bubbles_2,Happy_Bubbles_3;
    private GameObject Angry_Bubbles_1,Angry_Bubbles_2,Angry_Bubbles_3;

	private GameObject Griller01,Griller02, Griller_Anim;
	private GameObject Cap01,Cap02,Cap03,Cap04,Cap05,Cap06,Cap07;
	private GameObject EmptySouce01,EmptySouce02,EmptySouce03,EmptySouce04,EmptySouce05,EmptySouce06;
	private GameObject FriesSouce01,FriesSouce02,FriesSouce03,FriesSouce04,FriesSouce05,FriesSouce06;
	private GameObject Lives01,Lives02,Lives03;
	private GameObject CharacterList01_1,CharacterList02_1,CharacterList03_1;
	private GameObject CharacterList01_2,CharacterList02_2,CharacterList03_2;
	private GameObject CharacterList01_3,CharacterList02_3,CharacterList03_3;

	private Text TimeText, ScoreText;
	private GameObject EndGame;
	private GameObject SE_Griller;
	private AudioSource SE_Click, SE_SHAKER,SE_POINTS, SE_NOPOINTS;

	private Sprite Char01_Image_Happy,Char02_Image_Happy,Char03_Image_Happy;
	private Sprite Char01_Image_Angry,Char02_Image_Angry,Char03_Image_Angry;
	private Sprite Char01_Image_Smile,Char02_Image_Smile,Char03_Image_Smile;

	private float delayTime_1, delayTime_2, delayTime_3;
	private bool isFDelay_1,isFDelay_2,isFDelay_3;
	private Image btnCharacter_1_3,btnCharacter_2_3,btnCharacter_3_3;
	private Animator SharakerSouce,ScoreAnimate;
	private Animator CharacterAnim1,CharacterAnim2,CharacterAnim3;
	private bool isDataInput = false;

	private Text txtScore,txtTotalScore,txtTotalDuration,txtTotalPoints;
	public static int EnemeySequences = 0;
	private int CounterEnemy = 0, CounterEnemy1Value = 0, CounterEnemy2Value = 0, CounterEnemy3Value = 0;
	private List<float> CounterEnemylist = new List<float>();
	private int CounterEnemylistIndex;

	private Sprite FriesCapOn, FriesCapOff;
	private Image FriesCapOnOff;
	private Sprite PototosOn, PototosOff;
	private Image PototosOnOff;
	private Sprite TrashcanOn, TrashcanOff;
	private Image TrashcanOnOff;

	private bool CountDownDelayTimerBeforeStart = false;

	//PauseMenu
	private GameObject PauseMenu;
	public static bool isGamePause;


	//Ads Here
//	private BannerView bannerView;
	private string appID = "ca-app-pub-4378773022879105~6383918752";

	#if UNITY_ANDROID
	private string bannerID = "ca-app-pub-4378773022879105/5240058165";
	private string regularAD = "ca-app-pub-4378773022879105/8799286961";
	#elif UNITY_IPHONE
	private string bannerID = "ca-app-pub-4378773022879105/2667108982";
	private string regularAD = "ca-app-pub-4378773022879105/7812550496";
	#else
	private string bannerID = "ca-app-pub-4378773022879105/2667108982";
	private string regularAD = "ca-app-pub-4378773022879105/7812550496";
	#endif

//	InterstitialAd AD;
	bool isIntern = false;
//	AdRequest request;
	private bool isAdsShow = true;


	//Unity Ads
	private int AdsRandom;
	private string PlacementAds;
	public bool testMode = false;

	#if UNITY_IOS
	public const string gameID = "2881690";
	#elif UNITY_ANDROID
	public const string gameID = "2881688";
	#elif UNITY_EDITOR
	public const string gameID = "2881690";
	#endif



	private void GettingObject(){

		SharakerSouce = GameObject.Find("SharakerSouceHolder/SharakerSouce").GetComponent<Animator>();
		ScoreAnimate  = GameObject.Find("Head/ScoreAnimation").GetComponent<Animator>();

		Griller01 = GameObject.Find("Griller/Griller01");
		Griller02 = GameObject.Find("Griller/Griller02");
		Griller_Anim = GameObject.Find("Griller/Griller02/Griller_Anim");

		Cap01 = GameObject.Find("Capholder/Cap01");
		Cap02 = GameObject.Find("Capholder/Cap02");
		Cap03 = GameObject.Find("Capholder/Cap03");
		Cap04 = GameObject.Find("Capholder/Cap04");
		Cap05 = GameObject.Find("Capholder/Cap05");
		Cap06 = GameObject.Find("Capholder/Cap06");
		Cap07 = GameObject.Find("Capholder/Cap07");

		EmptySouce01 = GameObject.Find("Souces_2/EmptySouce01");
		EmptySouce02 = GameObject.Find("Souces_1/EmptySouce02");
		EmptySouce03 = GameObject.Find("Souces_2/EmptySouce03");
		EmptySouce04 = GameObject.Find("Souces_2/EmptySouce04");
		EmptySouce05 = GameObject.Find("Souces_1/EmptySouce05");
		EmptySouce06 = GameObject.Find("Souces_1/EmptySouce06");

		FriesSouce01 = GameObject.Find("Souces_2/FriesSouce01");
		FriesSouce02 = GameObject.Find("Souces_1/FriesSouce02");
		FriesSouce03 = GameObject.Find("Souces_2/FriesSouce03");
		FriesSouce04 = GameObject.Find("Souces_2/FriesSouce04");
		FriesSouce05 = GameObject.Find("Souces_1/FriesSouce05");
		FriesSouce06 = GameObject.Find("Souces_1/FriesSouce06");

		Lives01 = GameObject.Find("Lives/Lives (1)");
		Lives02 = GameObject.Find("Lives/Lives (2)");
		Lives03 = GameObject.Find("Lives/Lives (3)");

		CharacterList01_1 = GameObject.Find("ChGroup01/CharacterList01");
		CharacterList02_1 = GameObject.Find("ChGroup01/CharacterList02");
		CharacterList03_1 = GameObject.Find("ChGroup01/CharacterList03");

		CharacterList01_2 = GameObject.Find("ChGroup02/CharacterList01");
		CharacterList02_2 = GameObject.Find("ChGroup02/CharacterList02");
		CharacterList03_2 = GameObject.Find("ChGroup02/CharacterList03");

		CharacterList01_3 = GameObject.Find("ChGroup03/CharacterList01");
		CharacterList02_3 = GameObject.Find("ChGroup03/CharacterList02");
		CharacterList03_3 = GameObject.Find("ChGroup03/CharacterList03");

		TimeText = GameObject.Find ("CountDown").GetComponent<Text>();
		ScoreText = GameObject.Find ("CountScore").GetComponent<Text>();

		EndGame = GameObject.Find("EndGame/EndGamePopup");
		SE_Griller = GameObject.Find ("GrillerSound");

		SE_Click = GameObject.Find ("ClickSound").GetComponent<AudioSource>();
		SE_SHAKER = GameObject.Find ("ClickShaker").GetComponent<AudioSource>();
		SE_POINTS = GameObject.Find ("ClickPoints").GetComponent<AudioSource>();
		SE_NOPOINTS = GameObject.Find ("ClickNoPoints").GetComponent<AudioSource>();

		txtScore = GameObject.Find ("EndGameMenu/Score").GetComponent<Text>();
		txtTotalScore = GameObject.Find ("EndGameMenu/TotalScore").GetComponent<Text>();
		txtTotalDuration = GameObject.Find ("EndGameMenu/TotalDuration").GetComponent<Text>();
		txtTotalPoints = GameObject.Find ("EndGameMenu/TotalPoints").GetComponent<Text>();

		Char01_Image_Happy = Resources.Load <Sprite> ("Character01");
		Char02_Image_Happy = Resources.Load <Sprite> ("Character02");
		Char03_Image_Happy = Resources.Load <Sprite> ("Character03");

		Char01_Image_Angry = Resources.Load <Sprite> ("Character01_Angry");
		Char02_Image_Angry = Resources.Load <Sprite> ("Character02_Angry");
		Char03_Image_Angry = Resources.Load <Sprite> ("Character03_Angry");

		Char01_Image_Smile = Resources.Load <Sprite> ("Character01_Happy");
		Char02_Image_Smile = Resources.Load <Sprite> ("Character02_Happy");
		Char03_Image_Smile = Resources.Load <Sprite> ("Character03_Happy");

		FriesCapOn = Resources.Load <Sprite> ("FriesCapOn");
		FriesCapOff = Resources.Load <Sprite> ("FriesCapOff");
		FriesCapOnOff = GameObject.Find ("Foreground/FriesCap").GetComponent<Image>();

		PototosOn = Resources.Load <Sprite> ("PototosOn");
		PototosOff = Resources.Load <Sprite> ("PototosOff");
		PototosOnOff = GameObject.Find ("Foreground/Pototos").GetComponent<Image>();

		TrashcanOn = Resources.Load <Sprite> ("TrashcanOn");
		TrashcanOff = Resources.Load <Sprite> ("TrashcanOff");
		TrashcanOnOff = GameObject.Find ("Foreground/Trashcan").GetComponent<Image>();


		PauseMenu = GameObject.Find("PauseMenu/Pause_Background");
	}

	// Use this for initialization
	void Start () {
		GettingObject();
		isFDelay_1 = false;
		isFDelay_2 = false;
		isFDelay_3 = false;
		isOrderWrong_1 = false;
		isOrderRight_1 = false;
		isOrderWrong_2 = false;
		isOrderRight_2 = false;
		isOrderWrong_3 = false;
		isOrderRight_3 = false;
		isGrillerNotEmpty = false;
		isSouce01 = false;
		isSouce02 = false;
		isSouce03 = false;
		isSouce04 = false;
		isSouce05 = false;
		isSouce06 = false;
		LifeCount = 3;
		
	    CountDownDelayTimerBeforeStart = false;

		timeleft = TimeOfTime;
		timeleftCounter = TimeOfTime;
		ScoreCount = 0;
		Griller01.SetActive(true);
		Griller02.SetActive(false);
		Griller_Anim.SetActive(false);

		Cap01.SetActive(false);
		Cap02.SetActive(false);
		Cap03.SetActive(false);
		Cap04.SetActive(false);
		Cap05.SetActive(false);
		Cap06.SetActive(false);
		Cap07.SetActive(false);

		EmptySouces();

		Lives01.SetActive(true);
		Lives02.SetActive(true);
		Lives03.SetActive(true);

		EndGame.SetActive(false);
		isAngry_1 = false;
		isAngry_2 = false;
		isAngry_3 = false;
		isGrillerAnim = false;
		SE_Griller.SetActive(false);
		Character01_Angry_1 = GetComponent<Image>();
		Character01_Angry_2 = GetComponent<Image>();
		Character01_Angry_3 = GetComponent<Image>();

		// FriesCapOnOff = GetComponent<Image>();
		

		isCharacterOn_1 = false;
		isCharacterOn_1Postion = false;
		isCharacterOn_2 = false;
		isCharacterOn_2Postion = false;
		isCharacterOn_3 = false;
		isCharacterOn_3Postion = false;


		CounterEnemy = 0;
		CounterEnemy1Value = 0;
		CounterEnemy2Value = 0;
		CounterEnemy3Value = 0;

		PauseMenu.SetActive(false);

		EnemeySequences = 1;//Random.Range(1, 3);/static
		isGamePause = false;//Static

		ZPlayerPrefs.Initialize("what'sYourName", "salt12issalt");

		AdsSetting ();
//		UnityAdsSetting();

	}
	
	IEnumerator ExecuteStartMovement_1(float time)
	{
		
		yield return new WaitForSeconds(time);
		CharacterMovement.isMovingRigh_1 = false;
		
		if(RDCharacter_1 < 5){
			CharacterList01_1.SetActive(true);
			CharacterList02_1.SetActive(false);
			FuncCharacter(CharacterList01_1);
		}else{
			CharacterList01_1.SetActive(false);
			CharacterList02_1.SetActive(true);
			FuncCharacter(CharacterList02_1);
		}
	}

	IEnumerator ExecuteStartMovement_2(float time)
	{
		
		yield return new WaitForSeconds(time);
		CharacterMovement2.isMovingRigh_2 = false;
		
		if(RDCharacter_2 < 5){
			CharacterList01_2.SetActive(true);
			CharacterList02_2.SetActive(false);
			FuncCharacter2(CharacterList01_2);
		}else{
			CharacterList01_2.SetActive(false);
			CharacterList02_2.SetActive(true);
			FuncCharacter2(CharacterList02_2);
		}
	}
	
	IEnumerator ExecuteStartMovement_3(float time)
	{
		
		yield return new WaitForSeconds(time);
		CharacterMovement3.isMovingRigh_3 = false;

		if(RDCharacter_3 < 5){
			CharacterList01_3.SetActive(true);
			CharacterList02_3.SetActive(false);
			FuncCharacter3(CharacterList01_3);
		}else{
			CharacterList01_3.SetActive(false);
			CharacterList02_3.SetActive(true);
			FuncCharacter3(CharacterList02_3);
		}

	}
	private void EnemyStart1(){
		//Characterlist ChGroup01
		if(isCharacterOn_1 == false){
			RDCharacter_1 = Random.Range(0, 9);
			 delayTime_1 = Random.Range(0, 5);
			 delayTime_1 =  5;//delayTime_1 + 5;
			// RDCharacter_1 = 1;
			isCharacterOn_1 = true;
			isAngry_1 = false;
			isCharacterOn_1Postion = false;
			StartCoroutine(ExecuteStartMovement_1(0));

			CounterEnemy++;
			CounterEnemy1Value = CounterEnemy;
			EnemeIndexCounter(CounterEnemy);
		}
	}


	private void EnemyStart2(){
		//Characterlist ChGroup02
		if(isCharacterOn_2 == false){
			RDCharacter_2 = Random.Range(0, 9);
			 delayTime_2 = Random.Range(0, 5);//Random.Range(5, 10);
			 delayTime_2 =  5;//delayTime_2 + 5;
			// RDCharacter_1 = 1;
			isCharacterOn_2 = true;
			isAngry_2 = false;
			isCharacterOn_2Postion = false;
			StartCoroutine(ExecuteStartMovement_2(0));

			CounterEnemy++;
			CounterEnemy2Value = CounterEnemy;
			EnemeIndexCounter(CounterEnemy);
		}
	}

	private void EnemyStart3(){
		//Characterlist ChGroup03
		if(isCharacterOn_3 == false){
			RDCharacter_3 = Random.Range(0, 9);
			 delayTime_3 = Random.Range(0, 5);//Random.Range(10, 15);
			 delayTime_3 = 5;//delayTime_3 + 5;
			// RDCharacter_1 = 1;
			isCharacterOn_3 = true;
			isAngry_3 = false;
			isCharacterOn_3Postion = false;
			StartCoroutine(ExecuteStartMovement_3(0));

			CounterEnemy++;
			CounterEnemy3Value = CounterEnemy;
			EnemeIndexCounter(CounterEnemy);
		}
	}

	private void EnemeIndexCounter(float CounterEnemy){
		CounterEnemylist.Add(CounterEnemy);

		CounterEnemylistIndex = CounterEnemylist.IndexOf(CounterEnemylist.Min());
		if (TestingScript.isTesting == true) {
//			print ("Print low Value" + CounterEnemylist [CounterEnemylistIndex]);
		}

		if(CounterEnemy1Value == CounterEnemylist[CounterEnemylistIndex]){
			if (TestingScript.isTesting == true) {
//				print ("CounterEnemy1Value 111");
			}
		}else if(CounterEnemy2Value == CounterEnemylist[CounterEnemylistIndex]){
			if (TestingScript.isTesting == true) {
//				print ("CounterEnemy2Value 222");
			}
		}else if(CounterEnemy3Value == CounterEnemylist[CounterEnemylistIndex]){
			if (TestingScript.isTesting == true) {
//				print ("CounterEnemy3Value 333");
			}
		}
	}

	// Update is called once per frame
	void Update () {
		if(CountDownDelayTimerBeforeStart == false){
			CountDownDelayTimerBeforeStart = true;
			timeleft = TimeOfTime + 1;
			timeleftCounter = TimeOfTime + 1;
		}
		if(ScoreCount > 5){
			EnemyStart1();
			EnemyStart2();
			EnemyStart3();
		}else{
			// 0 4 6
			if((ScoreCount == 0 || ScoreCount == 4) && isCharacterOn_1 == false){
				EnemyStart1();
			}else if((ScoreCount == 1 || ScoreCount == 3) && isCharacterOn_2 == false){
				EnemyStart2();
			}else if((ScoreCount == 2 || ScoreCount == 5) && isCharacterOn_3 == false){
				EnemyStart3();
			}

		}
		/////////////////////////////////////////////////////////////////////////////////////
		//0 4 6
		if(ScoreCount > 5){
			CharacterMovement.isMovingRigh_1 = true;
			CharacterMovement2.isMovingRigh_2 = true;
			CharacterMovement3.isMovingRigh_3 = true;
		}else{
			if((ScoreCount == 0 || ScoreCount == 4 )){ //|| ScoreCount == 6
				CharacterMovement.isMovingRigh_1 = true;
			}else{
				CharacterMovement.isMovingRigh_1 = false;
			} 

			if((ScoreCount == 1 || ScoreCount == 3 )){//|| ScoreCount == 7
				CharacterMovement2.isMovingRigh_2 = true;
			}else{
				CharacterMovement2.isMovingRigh_2 = false;
			}

			if((ScoreCount == 2 || ScoreCount == 5)){ // || ScoreCount == 8
				CharacterMovement3.isMovingRigh_3 = true;
			}else{
				CharacterMovement3.isMovingRigh_3 = false;
			}
		}
	

		if(LifeCount > 0  && isGamePause == false){
			timeleft += Time.deltaTime;
			timeleftCounter -= Time.deltaTime;
			ScoreText.text = ""+ ScoreCount; 
			// if(ScoreCount < 10){
			// 	ScoreText.text = "000"+ ScoreCount; 
			// }else{
			// 	ScoreText.text = "00"+ ScoreCount; 
			// }
			ScoreText.text = ""+ ScoreCount; 

			if(timeleftCounter < 0){
				AdsShowHere ();

				EndGame.SetActive(true);
				//getting the time and score
				if(isDataInput == false){
					isDataInput = true;
					//Recording
					if (PlayerPrefs.HasKey("HighScoreCount") == false){
						PlayerPrefs.SetInt("HighScoreCount", ScoreCount);
					}
					int HighScoreCount = PlayerPrefs.GetInt("HighScoreCount");

					if(ScoreCount > HighScoreCount){
						PlayerPrefs.SetInt("HighScoreCount", ScoreCount);
						HighScoreCount = ScoreCount;
					}

					MainMenu.globalTimeCount = PlayerPrefs.GetInt("TimeCount");
					MainMenu.globalTimeCount = MainMenu.globalTimeCount + 90;

					//Incription
					int TotalScore = ZPlayerPrefs.GetInt("ScoreCount");
					TotalScore = TotalScore + ScoreCount;
					//Incription
					ZPlayerPrefs.SetInt("ScoreCount", TotalScore);

					PlayerPrefs.SetInt("TimeCount", MainMenu.globalTimeCount);

					txtScore.text = ScoreCount + "";
					if(TotalScore >= 1500){
						TotalScore = 1500;
					}
					txtTotalScore.text = TotalScore + "";
					txtTotalDuration.text = HighScoreCount+"";//MainMenu.globalTimeCount + "";

					int TotalPoints = TotalScore / 5;
					//setting points to limits 179/100
					if (TotalPoints >= 300) {
						TotalPoints = 300;
					}

//					int TotalPactTC = TotalPoints / 100;

					txtTotalPoints.text = TotalPoints +"";
				}
			}else {
				if (timeleftCounter < 10 && timeleftCounter > 0) {
					TimeText.text = ""+(int)timeleftCounter;//"00:0" + (int)timeleftCounter;
				}else {
					float TempCount = timeleftCounter / 60;
					float Second = ((int)timeleftCounter - (int)TempCount * 60);
					string strSecond;
					if(Second < 10){
						 strSecond = "0"+(int)Second;
					}else{
						 strSecond = ""+(int)Second;
					}

					if(TempCount < 10){
						TimeText.text = ""+ (int)timeleftCounter;
					}else{
						TimeText.text =  ""+ (int)timeleftCounter;
					}

					// if(TempCount < 10){
					// 	TimeText.text = "0"+ (int)TempCount +":" + strSecond;
					// }else{
					// 	TimeText.text =  (int)TempCount +":" + strSecond;
					// }
				} 
			}
		}

		if (LifeCount == 0) {
			//EndGame.SetActive(true);
			// TimeText.text = "00:00";
			// Application.LoadLevel ("Scene5");
		}

		if(isCharacterOn_1Postion == true && isGamePause == false){
			if(isAngry_1 == false){
				isAngry_1 = true;
				TempTime_1 = timeleft;
			}else{
				if(isOrderWrong_1 == true){
					
					WTimer_Minus_1 = -6.0f;
				}else if(isOrderRight_1 == true){
					
					WTimer_Minus_1 = -10.0f;
				}else{
					WTimer_Minus_1 = 0;
				}

				if(timeleft >= TempTime_1 + WTimer_Angry_1 + WTimer_Minus_1){
					if(RDCharacterList_1 == 0){
						
						if(isOrderRight_1 == true){
							Character01_Angry_1.sprite = Char01_Image_Smile;
							AnimationCharacter(1,2,CharacterAnim1);
						}else{
							Character01_Angry_1.sprite = Char01_Image_Angry;
							AnimationCharacter(1,3,CharacterAnim1);
						}
						if(isOrderWrong_1 == true){
							Character01_Angry_1.sprite = Char01_Image_Angry;
							AnimationCharacter(1,3,CharacterAnim1);
						}
						
					}else if(RDCharacterList_1 == 1){
						
						if(isOrderRight_1 == true){
							Character01_Angry_1.sprite = Char02_Image_Smile;
							AnimationCharacter(2,2,CharacterAnim1);
						}else{
							Character01_Angry_1.sprite = Char02_Image_Angry;
							AnimationCharacter(2,3,CharacterAnim1);
						}

						if(isOrderWrong_1 == true){
							Character01_Angry_1.sprite = Char02_Image_Angry;
							AnimationCharacter(2,3,CharacterAnim1);
						}
						
					}else{
						if(isOrderRight_1 == true){
							Character01_Angry_1.sprite = Char03_Image_Smile;
							AnimationCharacter(3,2,CharacterAnim1);
						}else{
							Character01_Angry_1.sprite = Char03_Image_Angry;
							AnimationCharacter(3,3,CharacterAnim1);
						}


						if(isOrderWrong_1 == true){
							Character01_Angry_1.sprite = Char03_Image_Angry;
							AnimationCharacter(3,3,CharacterAnim1);
						}
					}
				}


				if(timeleft >= TempTime_1 + WTimer_WaitTime_1 + WTimer_Minus_1){
					if(isOrderRight_1 == false){
						StartCoroutine(ExecuteAngry_1(2));
					}else{
						StartCoroutine(ExecuteSmile_1(1));
					}
				}
			}
			
		}

		if(CharacterMovement.isOnLocation_1 == true){
			OBCharChoicesList_1.SetActive(true);
			if(isGamePause == false){
				WTimer_Cooldown_1.fillAmount -= 1.0f / WTimer_WaitTime_1 * Time.deltaTime;
			}
		}else{
			if(OBCharChoicesList_1 != null){
				OBCharChoicesList_1.SetActive(false);
			}

			if(WTimer_Cooldown_1 != null){
				WTimer_Cooldown_1.fillAmount = 1.0f;
			}
			
		}

		

		if(isCharacterOn_2Postion == true && isGamePause == false){
			if(isAngry_2 == false){
				isAngry_2 = true;
				TempTime_2 = timeleft;
			}else{
				if(isOrderWrong_2 == true){
					
					WTimer_Minus_2 = -6.0f;
				}else if(isOrderRight_2 == true){
					
					WTimer_Minus_2 = -10.0f;
				}else{
					WTimer_Minus_2 = 0;
				}

				if(timeleft >= TempTime_2 + WTimer_Angry_2 + WTimer_Minus_2){
					if(RDCharacterList_2 == 0){
						
						if(isOrderRight_2 == true){
							Character01_Angry_2.sprite = Char01_Image_Smile;
							AnimationCharacter(1,2,CharacterAnim2);
						}else{
							Character01_Angry_2.sprite = Char01_Image_Angry;
							AnimationCharacter(1,3,CharacterAnim2);
						}
						if(isOrderWrong_2 == true){
							Character01_Angry_2.sprite = Char01_Image_Angry;
							AnimationCharacter(1,3,CharacterAnim2);
						}
						
					}else if(RDCharacterList_2 == 1){
						
						if(isOrderRight_2 == true){
							Character01_Angry_2.sprite = Char02_Image_Smile;
							AnimationCharacter(2,2,CharacterAnim2);
						}else{
							Character01_Angry_2.sprite = Char02_Image_Angry;
							AnimationCharacter(2,3,CharacterAnim2);
						}

						if(isOrderWrong_1 == true){
							Character01_Angry_2.sprite = Char02_Image_Angry;
							AnimationCharacter(2,3,CharacterAnim2);
						}
						
					}else{
						if(isOrderRight_2 == true){
							Character01_Angry_2.sprite = Char03_Image_Smile;
							AnimationCharacter(3,2,CharacterAnim2);
						}else{
							Character01_Angry_2.sprite = Char03_Image_Angry;
							AnimationCharacter(3,3,CharacterAnim2);
						}

						if(isOrderWrong_1 == true){
							Character01_Angry_2.sprite = Char03_Image_Angry;
							AnimationCharacter(3,3,CharacterAnim2);
						}
					}
				}


				if(timeleft >= TempTime_2 + WTimer_WaitTime_2 + WTimer_Minus_2){
					if(isOrderRight_2 == false){
						StartCoroutine(ExecuteAngry_2(2));
					}else{

						
						StartCoroutine(ExecuteSmile_2(1));
					}
				}
			}
		}
		if(CharacterMovement2.isOnLocation_2 == true){
			OBCharChoicesList_2.SetActive(true);
			if(isGamePause == false){
				WTimer_Cooldown_2.fillAmount -= 1.0f / WTimer_WaitTime_2 * Time.deltaTime;
			}
		}else{
			if(OBCharChoicesList_2 != null)
				OBCharChoicesList_2.SetActive(false);
			if(WTimer_Cooldown_2 != null)
				WTimer_Cooldown_2.fillAmount = 1.0f;
		}
		


		if(isCharacterOn_3Postion == true && isGamePause == false){
			if(isAngry_3 == false){
				isAngry_3 = true;
				TempTime_3 = timeleft;
			}else{
				if(isOrderWrong_3 == true){
					
					WTimer_Minus_3 = -6.0f;
				}else if(isOrderRight_3 == true){
					
					WTimer_Minus_3 = -10.0f;
				}else{
					WTimer_Minus_3 = 0;
				}

				if(timeleft >= TempTime_3 + WTimer_Angry_3 + WTimer_Minus_3){
					if(RDCharacterList_3 == 0){
						
						if(isOrderRight_3 == true){
							Character01_Angry_3.sprite = Char01_Image_Smile;
							AnimationCharacter(1,2,CharacterAnim3);
						}else{
							Character01_Angry_3.sprite = Char01_Image_Angry;
							AnimationCharacter(1,3,CharacterAnim3);
						}
						if(isOrderWrong_3 == true){
							Character01_Angry_3.sprite = Char01_Image_Angry;
							AnimationCharacter(1,3,CharacterAnim3);
						}
						
					}else if(RDCharacterList_3 == 1){
						
						if(isOrderRight_3 == true){
							Character01_Angry_3.sprite = Char02_Image_Smile;
							AnimationCharacter(2,2,CharacterAnim3);
						}else{
							Character01_Angry_3.sprite = Char02_Image_Angry;
							AnimationCharacter(2,3,CharacterAnim3);
						}

						if(isOrderWrong_3 == true){
							Character01_Angry_3.sprite = Char02_Image_Angry;
							AnimationCharacter(2,3,CharacterAnim3);
						}
						
					}else{
						if(isOrderRight_3 == true){
							Character01_Angry_3.sprite = Char03_Image_Smile;
							AnimationCharacter(3,2,CharacterAnim3);
						}else{
							Character01_Angry_3.sprite = Char03_Image_Angry;
							AnimationCharacter(3,3,CharacterAnim3);
						}

						if(isOrderWrong_3 == true){
							Character01_Angry_3.sprite = Char03_Image_Angry;
							AnimationCharacter(3,3,CharacterAnim3);
						}
					}
				}


				if(timeleft >= TempTime_3 + WTimer_WaitTime_3 + WTimer_Minus_3){
					if(isOrderRight_3 == false){
						StartCoroutine(ExecuteAngry_3(2));
					}else{

						
						StartCoroutine(ExecuteSmile_3(1));
					}
				}
			}
		}
		if(CharacterMovement3.isOnLocation_3 == true){
			OBCharChoicesList_3.SetActive(true);
			if(isGamePause == false){
				WTimer_Cooldown_3.fillAmount -= 1.0f / WTimer_WaitTime_3 * Time.deltaTime;
			}
			
		}else{
			if(OBCharChoicesList_3 != null)
				OBCharChoicesList_3.SetActive(false);
			if(WTimer_Cooldown_3 != null)
				WTimer_Cooldown_3.fillAmount = 1.0f;
		}
	}

	IEnumerator ExecuteSmile_1(float time)
	{
		Happy_Bubbles_1.SetActive(true);
		Angry_Bubbles_1.SetActive(false);
		yield return new WaitForSeconds(time);

		CharacterMovement.isServeWell_1 = true;
		StartCoroutine(ExecuteSmile_1_Delay(2));
	}


	IEnumerator ExecuteSmile_1_Delay(float time)
	{
		yield return new WaitForSeconds(time);
		isAngry_1 = false;
		isOrderWrong_1 = false;
		isOrderRight_1 = false;
		isCharacterOn_1 = false;

		CharacterData1_1.SetActive(false);
		CharacterData2_1.SetActive(false);
		CharacterData3_1.SetActive(false);
		CharacterMovement.isServeWell_1 = false;
		CharacterMovement.isCharacterReset_1 = true;

		//CharacterMovement.isMovingRigh_1 = false;
	}


	IEnumerator ExecuteSmile_2(float time)
	{
		Happy_Bubbles_2.SetActive(true);
		Angry_Bubbles_2.SetActive(false);
		yield return new WaitForSeconds(time);
		CharacterMovement2.isServeWell_2 = true;
		StartCoroutine(ExecuteSmile_2_Delay(2));
	}
	IEnumerator ExecuteSmile_2_Delay(float time)
	{
		yield return new WaitForSeconds(time);
		
		isAngry_2 = false;
		isOrderWrong_2 = false;
		isOrderRight_2 = false;
		isCharacterOn_2 = false;

		CharacterData1_2.SetActive(false);
		CharacterData2_2.SetActive(false);
		CharacterData3_2.SetActive(false);
		CharacterMovement2.isServeWell_2 = false;
		CharacterMovement2.isCharacterReset_2 = true;

		// CharacterMovement2.isMovingRigh_2 = false;
	}

	IEnumerator ExecuteSmile_3(float time)
	{
		Happy_Bubbles_3.SetActive(true);
		Angry_Bubbles_3.SetActive(false);
		yield return new WaitForSeconds(time);
		CharacterMovement3.isServeWell_3 = true;
		StartCoroutine(ExecuteSmile_3_Delay(2));
	}
	IEnumerator ExecuteSmile_3_Delay(float time)
	{
		yield return new WaitForSeconds(time);
		
		isAngry_3 = false;
		isOrderWrong_3 = false;
		isOrderRight_3 = false;
		isCharacterOn_3 = false;

		CharacterData1_3.SetActive(false);
		CharacterData2_3.SetActive(false);
		CharacterData3_3.SetActive(false);
		CharacterMovement3.isServeWell_3 = false;
		CharacterMovement3.isCharacterReset_3 = true;

		// CharacterMovement3.isMovingRigh_3 = false;
	}

	IEnumerator ExecuteAngry_1(float time){

		Happy_Bubbles_1.SetActive(false);
		Angry_Bubbles_1.SetActive(true);
		yield return new WaitForSeconds(time);
		isOrderWrong_1 = false;
		isOrderRight_1 = false;
		isCharacterOn_1 = false;
		CharacterData1_1.SetActive(false);
		CharacterData2_1.SetActive(false);
		CharacterData3_1.SetActive(false);
		CharacterMovement.isCharacterReset_1 = true;
		
		if(isAngry_1 == true){
			//LifeCount = LifeCount - 1;
			isAngry_1 = false;
		}
		
		if(LifeCount == 2){
			Lives01.SetActive(true);
			Lives02.SetActive(true);
			Lives03.SetActive(false);
		}else if(LifeCount == 1){
			Lives01.SetActive(true);
			Lives02.SetActive(false);
			Lives03.SetActive(false);
		}else if(LifeCount == 0){
			Lives01.SetActive(false);
			Lives02.SetActive(false);
			Lives03.SetActive(false);
		}
	}

	IEnumerator ExecuteAngry_2(float time){
		Happy_Bubbles_2.SetActive(false);
		Angry_Bubbles_2.SetActive(true);
		yield return new WaitForSeconds(time);
		isOrderWrong_2 = false;
		isOrderRight_2 = false;
		isCharacterOn_2 = false;
		CharacterData1_2.SetActive(false);
		CharacterData2_2.SetActive(false);
		CharacterData3_2.SetActive(false);
		CharacterMovement2.isCharacterReset_2 = true;
		
		if(isAngry_2 == true){
			//LifeCount = LifeCount - 1;
			isAngry_2 = false;
		}
		
		if(LifeCount == 2){
			Lives01.SetActive(true);
			Lives02.SetActive(true);
			Lives03.SetActive(false);
		}else if(LifeCount == 1){
			Lives01.SetActive(true);
			Lives02.SetActive(false);
			Lives03.SetActive(false);
		}else if(LifeCount == 0){
			Lives01.SetActive(false);
			Lives02.SetActive(false);
			Lives03.SetActive(false);
		}
	}

	IEnumerator ExecuteAngry_3(float time){
		Happy_Bubbles_3.SetActive(false);
		Angry_Bubbles_3.SetActive(true);
		yield return new WaitForSeconds(time);
		isOrderWrong_3 = false;
		isOrderRight_3 = false;
		isCharacterOn_3 = false;
		CharacterData1_3.SetActive(false);
		CharacterData2_3.SetActive(false);
		CharacterData3_3.SetActive(false);
		CharacterMovement3.isCharacterReset_3 = true;
		
		if(isAngry_3 == true){
			//LifeCount = LifeCount - 1;
			isAngry_3 = false;
		}
		
		if(LifeCount == 2){
			Lives01.SetActive(true);
			Lives02.SetActive(true);
			Lives03.SetActive(false);
		}else if(LifeCount == 1){
			Lives01.SetActive(true);
			Lives02.SetActive(false);
			Lives03.SetActive(false);
		}else if(LifeCount == 0){
			Lives01.SetActive(false);
			Lives02.SetActive(false);
			Lives03.SetActive(false);
		}
	}


	void FuncCharacter(GameObject GOCharacterList){
		RDCharacterList_1 = Random.Range(0, 3);
		  CharacterData1_1 = GOCharacterList.transform.GetChild (0).gameObject; 
		  CharacterData2_1 = GOCharacterList.transform.GetChild (1).gameObject; 
		  CharacterData3_1 = GOCharacterList.transform.GetChild (2).gameObject; 
		CharacterData1_1.SetActive(false);
		CharacterData2_1.SetActive(false);
		CharacterData3_1.SetActive(false);
		if(RDCharacterList_1 == 0){
			Character01_Angry_1 = CharacterData1_1.GetComponent<Image>();
			Character01_Angry_1.sprite = Char01_Image_Happy;
		}if(RDCharacterList_1 == 1){
			Character01_Angry_1 = CharacterData2_1.GetComponent<Image>();
			Character01_Angry_1.sprite = Char02_Image_Happy;
		}else{
			Character01_Angry_1 = CharacterData3_1.GetComponent<Image>();
			Character01_Angry_1.sprite = Char03_Image_Happy;
		}

		if(RDCharacterList_1 == 0){
			CharacterData1_1.SetActive(true);
			CharacterData2_1.SetActive(false);
			CharacterData3_1.SetActive(false);
			Character01_Angry_1 = CharacterData1_1.GetComponent<Image>();

			CharacterAnim1 = CharacterData1_1.GetComponent<Animator>();
			AnimationCharacter(1,1,CharacterAnim1);

			FuncCharacterChoices(CharacterData1_1);
		}else if(RDCharacterList_1 == 1){
			CharacterData1_1.SetActive(false);
			CharacterData2_1.SetActive(true);
			CharacterData3_1.SetActive(false);
			Character01_Angry_1 = CharacterData2_1.GetComponent<Image>();

			CharacterAnim1 = CharacterData2_1.GetComponent<Animator>();
			AnimationCharacter(2,1,CharacterAnim1);

			FuncCharacterChoices(CharacterData2_1);
		}else{
			CharacterData1_1.SetActive(false);
			CharacterData2_1.SetActive(false);
			CharacterData3_1.SetActive(true);
			Character01_Angry_1 = CharacterData3_1.GetComponent<Image>();

			CharacterAnim1 = CharacterData3_1.GetComponent<Animator>();
			AnimationCharacter(3,1,CharacterAnim1);

			FuncCharacterChoices(CharacterData3_1);
		}

	}

	void FuncCharacter2(GameObject GOCharacterList){
		RDCharacterList_2 = Random.Range(0, 3);
		  CharacterData1_2 = GOCharacterList.transform.GetChild (0).gameObject; 
		  CharacterData2_2 = GOCharacterList.transform.GetChild (1).gameObject; 
		  CharacterData3_2 = GOCharacterList.transform.GetChild (2).gameObject; 
		CharacterData1_2.SetActive(false);
		CharacterData2_2.SetActive(false);
		CharacterData3_2.SetActive(false);
		if(RDCharacterList_2 == 0){
			Character01_Angry_2 = CharacterData1_2.GetComponent<Image>();
			Character01_Angry_2.sprite = Char01_Image_Happy;
		}else if(RDCharacterList_2 == 1){
			Character01_Angry_2 = CharacterData2_2.GetComponent<Image>();
			Character01_Angry_2.sprite = Char02_Image_Happy;
		}else{
			Character01_Angry_2 = CharacterData3_2.GetComponent<Image>();
			Character01_Angry_2.sprite = Char03_Image_Happy;
		}

		if(RDCharacterList_2 == 0){
			CharacterData1_2.SetActive(true);
			CharacterData2_2.SetActive(false);
			CharacterData3_2.SetActive(false);
			Character01_Angry_2 = CharacterData1_2.GetComponent<Image>();

			CharacterAnim2 = CharacterData1_2.GetComponent<Animator>();
			AnimationCharacter(1,1,CharacterAnim2);

			FuncCharacterChoices2(CharacterData1_2);
		}else if(RDCharacterList_2 == 1){
			CharacterData1_2.SetActive(false);
			CharacterData2_2.SetActive(true);
			CharacterData3_2.SetActive(false);
			Character01_Angry_2 = CharacterData2_2.GetComponent<Image>();

			CharacterAnim2 = CharacterData2_2.GetComponent<Animator>();
			AnimationCharacter(2,1,CharacterAnim2);

			FuncCharacterChoices2(CharacterData2_2);
		}else{
			CharacterData1_2.SetActive(false);
			CharacterData2_2.SetActive(false);
			CharacterData3_2.SetActive(true);
			Character01_Angry_2 = CharacterData3_2.GetComponent<Image>();

			CharacterAnim2 = CharacterData3_2.GetComponent<Animator>();
			AnimationCharacter(3,1,CharacterAnim2);

			FuncCharacterChoices2(CharacterData3_2);
		}
	}

	void FuncCharacter3(GameObject GOCharacterList){
		RDCharacterList_3 = Random.Range(0, 3);
		  CharacterData1_3 = GOCharacterList.transform.GetChild (0).gameObject; 
		  CharacterData2_3 = GOCharacterList.transform.GetChild (1).gameObject; 
		  CharacterData3_3 = GOCharacterList.transform.GetChild (2).gameObject; 
		CharacterData1_3.SetActive(false);
		CharacterData2_3.SetActive(false);
		CharacterData3_3.SetActive(false);
		if(RDCharacterList_3 == 0){
			Character01_Angry_3 = CharacterData1_3.GetComponent<Image>();
			Character01_Angry_3.sprite = Char01_Image_Happy;
		}else if(RDCharacterList_3 == 1){
			Character01_Angry_3 = CharacterData2_3.GetComponent<Image>();
			Character01_Angry_3.sprite = Char02_Image_Happy;
		}else{
			Character01_Angry_3 = CharacterData3_3.GetComponent<Image>();
			Character01_Angry_3.sprite = Char03_Image_Happy;
		}

		if(RDCharacterList_3 == 0){
			CharacterData1_3.SetActive(true);
			CharacterData2_3.SetActive(false);
			CharacterData3_3.SetActive(false);
			Character01_Angry_3 = CharacterData1_3.GetComponent<Image>();

			CharacterAnim3 = CharacterData1_3.GetComponent<Animator>();
			AnimationCharacter(1,1,CharacterAnim3);

			FuncCharacterChoices3(CharacterData1_3);
		}else if(RDCharacterList_3 == 1){
			CharacterData1_3.SetActive(false);
			CharacterData2_3.SetActive(true);
			CharacterData3_3.SetActive(false);
			Character01_Angry_3 = CharacterData2_3.GetComponent<Image>();

			CharacterAnim3 = CharacterData2_3.GetComponent<Animator>();
			AnimationCharacter(2,1,CharacterAnim3);

			FuncCharacterChoices3(CharacterData2_3);
		}else{
			CharacterData1_3.SetActive(false);
			CharacterData2_3.SetActive(false);
			CharacterData3_3.SetActive(true);
			Character01_Angry_3 = CharacterData3_3.GetComponent<Image>();

			CharacterAnim3 = CharacterData3_3.GetComponent<Animator>();
			AnimationCharacter(3,1,CharacterAnim3);

			FuncCharacterChoices3(CharacterData3_3);
		}
	}

	void FuncCharacterChoices(GameObject Character){
		RDCharacterChoice_1 = Random.Range(0, 6);
		GameObject ChoicesList = Character.transform.GetChild (0).gameObject; 
		OBCharChoicesList_1 = ChoicesList;
		Happy_Bubbles_1 = Character.transform.GetChild (1).gameObject; 
		Angry_Bubbles_1 = Character.transform.GetChild (2).gameObject; 
		
		
		GameObject Choices1 = ChoicesList.transform.GetChild (0).gameObject;
		GameObject Choices1_WT = Choices1.transform.GetChild (0).gameObject;

		GameObject Choices2 = ChoicesList.transform.GetChild (1).gameObject; 
		GameObject Choices2_WT = Choices2.transform.GetChild (0).gameObject;

		GameObject Choices3 = ChoicesList.transform.GetChild (2).gameObject; 
		GameObject Choices3_WT = Choices3.transform.GetChild (0).gameObject;


		GameObject Choices4 = ChoicesList.transform.GetChild (3).gameObject; 
		GameObject Choices4_WT = Choices4.transform.GetChild (0).gameObject;

		GameObject Choices5 = ChoicesList.transform.GetChild (4).gameObject; 
		GameObject Choices5_WT = Choices5.transform.GetChild (0).gameObject;

		GameObject Choices6 = ChoicesList.transform.GetChild (5).gameObject; 
		GameObject Choices6_WT = Choices6.transform.GetChild (0).gameObject;
		

//		Choices1.SetActive(false);
//		Choices2.SetActive(false);
//		Choices3.SetActive(false);
//		Happy_Bubbles_1.SetActive(false);
//		Angry_Bubbles_1.SetActive(false);
//		if(RDCharacterChoice_1 == 0){ 
//			Choices1.SetActive(true);
//			Choices2.SetActive(false);
//			Choices3.SetActive(false);
//			WTimer_Cooldown_1 = Choices1_WT.GetComponent<Image>();
//		}else if(RDCharacterChoice_1 == 1){
//			Choices1.SetActive(false);
//			Choices2.SetActive(true);
//			Choices3.SetActive(false);
//			WTimer_Cooldown_1 = Choices2_WT.GetComponent<Image>();
//		}else{
//			Choices1.SetActive(false);
//			Choices2.SetActive(false);
//			Choices3.SetActive(true);
//			WTimer_Cooldown_1 = Choices3_WT.GetComponent<Image>();
//		}


		Choices1.SetActive(false);
		Choices2.SetActive(false);
		Choices3.SetActive(false);
		Choices5.SetActive(false);
		Choices6.SetActive(false);
		Happy_Bubbles_1.SetActive(false);
		Angry_Bubbles_1.SetActive(false);
		if(RDCharacterChoice_1 == 0){ 
			Choices1.SetActive(true);
			Choices2.SetActive(false);
			Choices3.SetActive(false);

			Choices4.SetActive(false);
			Choices5.SetActive(false);
			Choices6.SetActive(false);
			WTimer_Cooldown_1 = Choices1_WT.GetComponent<Image>();
		}else if(RDCharacterChoice_1 == 1){
			Choices1.SetActive(false);
			Choices2.SetActive(true);
			Choices3.SetActive(false);

			Choices4.SetActive(false);
			Choices5.SetActive(false);
			Choices6.SetActive(false);
			WTimer_Cooldown_1 = Choices2_WT.GetComponent<Image>();
		}else if(RDCharacterChoice_1 == 2){
			Choices1.SetActive(false);
			Choices2.SetActive(false);
			Choices3.SetActive(true);

			Choices4.SetActive (false);
			Choices5.SetActive(false);
			Choices6.SetActive(false);
			WTimer_Cooldown_1 = Choices3_WT.GetComponent<Image>();
		}else if(RDCharacterChoice_1 == 3){
			Choices1.SetActive(false);
			Choices2.SetActive(false);
			Choices3.SetActive(false);

			Choices4.SetActive(true);
			Choices5.SetActive(false);
			Choices6.SetActive(false);
			WTimer_Cooldown_1 = Choices4_WT.GetComponent<Image>();
		}else if(RDCharacterChoice_1 == 4){
			Choices1.SetActive(false);
			Choices2.SetActive(false);
			Choices3.SetActive(false);

			Choices4.SetActive(false);
			Choices5.SetActive(true);
			Choices6.SetActive(false);
			WTimer_Cooldown_1 = Choices5_WT.GetComponent<Image>();
		}else{
			Choices1.SetActive(false);
			Choices2.SetActive(false);
			Choices3.SetActive(false);

			Choices4.SetActive(false);
			Choices5.SetActive(false);
			Choices6.SetActive(true);
			WTimer_Cooldown_1 = Choices6_WT.GetComponent<Image>();
		}
		print ("RDCharacterChoice_1: "+RDCharacterChoice_1);
		WTimer_Cooldown_1.fillAmount = 1.0f;
		// print("RDCharacterChoice_1: "+RDCharacterChoice_1);
		if(isFDelay_1 == false){
			isFDelay_1 = true;
			delayTime_1 = 0;
		}		
		StartCoroutine(ExecuteFuncCharacterChoices_1Delay(delayTime_1));
	}
	IEnumerator ExecuteFuncCharacterChoices_1Delay(float time)
	{
		CharacterMovement.isMovingRigh_1 = false;
		yield return new WaitForSeconds(time);
	}


	void FuncCharacterChoices2(GameObject Character){
		RDCharacterChoice_2 = Random.Range(0, 6);
		GameObject ChoicesList = Character.transform.GetChild (0).gameObject; 
		OBCharChoicesList_2 = ChoicesList;
		Happy_Bubbles_2 = Character.transform.GetChild (1).gameObject; 
		Angry_Bubbles_2 = Character.transform.GetChild (2).gameObject; 

		GameObject Choices1 = ChoicesList.transform.GetChild (0).gameObject;
		GameObject Choices1_WT = Choices1.transform.GetChild (0).gameObject;

		GameObject Choices2 = ChoicesList.transform.GetChild (1).gameObject; 
		GameObject Choices2_WT = Choices2.transform.GetChild (0).gameObject;

		GameObject Choices3 = ChoicesList.transform.GetChild (2).gameObject; 
		GameObject Choices3_WT = Choices3.transform.GetChild (0).gameObject;


		GameObject Choices4 = ChoicesList.transform.GetChild (3).gameObject; 
		GameObject Choices4_WT = Choices4.transform.GetChild (0).gameObject;

		GameObject Choices5 = ChoicesList.transform.GetChild (4).gameObject; 
		GameObject Choices5_WT = Choices5.transform.GetChild (0).gameObject;

		GameObject Choices6 = ChoicesList.transform.GetChild (5).gameObject; 
		GameObject Choices6_WT = Choices6.transform.GetChild (0).gameObject;

		

//		Choices1.SetActive(false);
//		Choices2.SetActive(false);
//		Choices3.SetActive(false);
//		Happy_Bubbles_2.SetActive(false);
//		Angry_Bubbles_2.SetActive(false);
//		if(RDCharacterChoice_2 == 0){ 
//			Choices1.SetActive(true);
//			Choices2.SetActive(false);
//			Choices3.SetActive(false);
//			WTimer_Cooldown_2 = Choices1_WT.GetComponent<Image>();
//		}else if(RDCharacterChoice_2 == 1){
//			Choices1.SetActive(false);
//			Choices2.SetActive(true);
//			Choices3.SetActive(false);
//			WTimer_Cooldown_2 = Choices2_WT.GetComponent<Image>();
//		}else{
//			Choices1.SetActive(false);
//			Choices2.SetActive(false);
//			Choices3.SetActive(true);
//			WTimer_Cooldown_2 = Choices3_WT.GetComponent<Image>();
//		}

		Choices1.SetActive(false);
		Choices2.SetActive(false);
		Choices3.SetActive(false);
		Choices5.SetActive(false);
		Choices6.SetActive(false);
		Happy_Bubbles_2.SetActive(false);
		Angry_Bubbles_2.SetActive(false);
		if(RDCharacterChoice_2 == 0){ 
			Choices1.SetActive(true);
			Choices2.SetActive(false);
			Choices3.SetActive(false);

			Choices4.SetActive(false);
			Choices5.SetActive(false);
			Choices6.SetActive(false);
			WTimer_Cooldown_2 = Choices1_WT.GetComponent<Image>();
		}else if(RDCharacterChoice_2 == 1){
			Choices1.SetActive(false);
			Choices2.SetActive(true);
			Choices3.SetActive(false);

			Choices4.SetActive(false);
			Choices5.SetActive(false);
			Choices6.SetActive(false);
			WTimer_Cooldown_2 = Choices2_WT.GetComponent<Image>();
		}else if(RDCharacterChoice_2 == 2){
			Choices1.SetActive(false);
			Choices2.SetActive(false);
			Choices3.SetActive(true);

			Choices4.SetActive (false);
			Choices5.SetActive(false);
			Choices6.SetActive(false);
			WTimer_Cooldown_2 = Choices3_WT.GetComponent<Image>();
		}else if(RDCharacterChoice_2 == 3){
			Choices1.SetActive(false);
			Choices2.SetActive(false);
			Choices3.SetActive(false);

			Choices4.SetActive(true);
			Choices5.SetActive(false);
			Choices6.SetActive(false);
			WTimer_Cooldown_2 = Choices4_WT.GetComponent<Image>();
		}else if(RDCharacterChoice_2 == 4){
			Choices1.SetActive(false);
			Choices2.SetActive(false);
			Choices3.SetActive(false);

			Choices4.SetActive(false);
			Choices5.SetActive(true);
			Choices6.SetActive(false);
			WTimer_Cooldown_2 = Choices5_WT.GetComponent<Image>();
		}else{
			Choices1.SetActive(false);
			Choices2.SetActive(false);
			Choices3.SetActive(false);

			Choices4.SetActive(false);
			Choices5.SetActive(false);
			Choices6.SetActive(true);
			WTimer_Cooldown_2 = Choices6_WT.GetComponent<Image>();
		}
		print ("RDCharacterChoice_2: "+RDCharacterChoice_2);
		WTimer_Cooldown_2.fillAmount = 1.0f;
		// print("RDCharacterChoice_2: "+RDCharacterChoice_2);
		StartCoroutine(ExecuteFuncCharacterChoices_2Delay(delayTime_2));
		// if(isFDelay_2 == false){
		// 	isFDelay_2 = true;
		// 	delayTime_2 = 2;
		// }
	}
	IEnumerator ExecuteFuncCharacterChoices_2Delay(float time)
	{
		CharacterMovement2.isMovingRigh_2 = false;
		yield return new WaitForSeconds(time);
	}


	void FuncCharacterChoices3(GameObject Character){
		RDCharacterChoice_3 = Random.Range(0, 6);
		GameObject ChoicesList = Character.transform.GetChild (0).gameObject; 
		OBCharChoicesList_3 = ChoicesList;
		Happy_Bubbles_3 = Character.transform.GetChild (1).gameObject; 
		Angry_Bubbles_3 = Character.transform.GetChild (2).gameObject; 

		GameObject Choices1 = ChoicesList.transform.GetChild (0).gameObject;
		GameObject Choices1_WT = Choices1.transform.GetChild (0).gameObject;

		GameObject Choices2 = ChoicesList.transform.GetChild (1).gameObject; 
		GameObject Choices2_WT = Choices2.transform.GetChild (0).gameObject;

		GameObject Choices3 = ChoicesList.transform.GetChild (2).gameObject; 
		GameObject Choices3_WT = Choices3.transform.GetChild (0).gameObject;

		GameObject Choices4 = ChoicesList.transform.GetChild (3).gameObject; 
		GameObject Choices4_WT = Choices4.transform.GetChild (0).gameObject;

		GameObject Choices5 = ChoicesList.transform.GetChild (4).gameObject; 
		GameObject Choices5_WT = Choices5.transform.GetChild (0).gameObject;

		GameObject Choices6 = ChoicesList.transform.GetChild (5).gameObject; 
		GameObject Choices6_WT = Choices6.transform.GetChild (0).gameObject;

		

		Choices1.SetActive(false);
		Choices2.SetActive(false);
		Choices3.SetActive(false);
		Choices5.SetActive(false);
		Choices6.SetActive(false);
		Happy_Bubbles_3.SetActive(false);
		Angry_Bubbles_3.SetActive(false);
		if(RDCharacterChoice_3 == 0){ 
			Choices1.SetActive(true);
			Choices2.SetActive(false);
			Choices3.SetActive(false);

			Choices4.SetActive(false);
			Choices5.SetActive(false);
			Choices6.SetActive(false);
			WTimer_Cooldown_3 = Choices1_WT.GetComponent<Image>();
		}else if(RDCharacterChoice_3 == 1){
			Choices1.SetActive(false);
			Choices2.SetActive(true);
			Choices3.SetActive(false);

			Choices4.SetActive(false);
			Choices5.SetActive(false);
			Choices6.SetActive(false);
			WTimer_Cooldown_3 = Choices2_WT.GetComponent<Image>();
		}else if(RDCharacterChoice_3 == 2){
			Choices1.SetActive(false);
			Choices2.SetActive(false);
			Choices3.SetActive(true);

			Choices4.SetActive (false);
			Choices5.SetActive(false);
			Choices6.SetActive(false);
			WTimer_Cooldown_3 = Choices3_WT.GetComponent<Image>();
		}else if(RDCharacterChoice_3 == 3){
			Choices1.SetActive(false);
			Choices2.SetActive(false);
			Choices3.SetActive(false);

			Choices4.SetActive(true);
			Choices5.SetActive(false);
			Choices6.SetActive(false);
			WTimer_Cooldown_3 = Choices4_WT.GetComponent<Image>();
		}else if(RDCharacterChoice_3 == 4){
			Choices1.SetActive(false);
			Choices2.SetActive(false);
			Choices3.SetActive(false);

			Choices4.SetActive(false);
			Choices5.SetActive(true);
			Choices6.SetActive(false);
			WTimer_Cooldown_3 = Choices5_WT.GetComponent<Image>();
		}else{
			Choices1.SetActive(false);
			Choices2.SetActive(false);
			Choices3.SetActive(false);

			Choices4.SetActive(false);
			Choices5.SetActive(false);
			Choices6.SetActive(true);
			WTimer_Cooldown_3 = Choices6_WT.GetComponent<Image>();
		}
		print ("RDCharacterChoice_3: "+RDCharacterChoice_3);
		WTimer_Cooldown_3.fillAmount = 1.0f;
		// print("RDCharacterChoice_2: "+RDCharacterChoice_2);
		// if(isFDelay_3 == false){
		// 	isFDelay_3 = true;
		// 	delayTime_3 = 4;
		// }
		StartCoroutine(ExecuteFuncCharacterChoices_3Delay(delayTime_3));
	}

	IEnumerator ExecuteFuncCharacterChoices_3Delay(float time)
	{
		CharacterMovement3.isMovingRigh_3 = false;
		yield return new WaitForSeconds(time);
	}

	public void OnClickFries(){
		if(Cap01.activeSelf){
			Griller01.SetActive(false);
			Griller02.SetActive(true);
			SE_Click.Play();
			StartCoroutine(ExecuteSouces(1f));
		}
	}
	
	
	IEnumerator ExecuteSouces(float time)
	{
		SE_Griller.SetActive(true);
		Griller_Anim.SetActive(true);
		isGrillerAnim = true;
		yield return new WaitForSeconds(time);
		SE_Griller.SetActive(false);
		isGrillerAnim = false;
		Griller_Anim.SetActive(false);	
		isGrillerNotEmpty = true;
	}

	private void RemoveSouce(){
		Griller01.SetActive(true);
		Griller02.SetActive(false);

		FriesSouce01.SetActive(false);
		isSouce01 = false;
		FriesSouce02.SetActive(false);
		isSouce02 = false;
		FriesSouce03.SetActive(false);
		isSouce03 = false;


		FriesSouce04.SetActive(false);
		isSouce04 = false;
		FriesSouce05.SetActive(false);
		isSouce05 = false;
		FriesSouce06.SetActive(false);
		isSouce06 = false;
	}

	public void OnClickSouces1(){
		if(isGrillerNotEmpty == true){
			RemoveSouce ();
			isGrillerNotEmpty = false;
			Griller01.SetActive(true);
			Griller02.SetActive(false);
			FriesSouce01.SetActive(true);
			isSouce01 = true;
			SE_Click.Play();
			if (TestingScript.isTesting == true) {
				print ("Output: " + 1);
			}
		}
	}

	public void OnClickSouces2(){
		if(isGrillerNotEmpty == true){
			RemoveSouce ();
			isGrillerNotEmpty = false;
			Griller01.SetActive(true);
			Griller02.SetActive(false);
			FriesSouce02.SetActive(true);
			isSouce02 = true;
			SE_Click.Play();
			if (TestingScript.isTesting == true) {
				print ("Output: " + 2);
			}
		}
	}

	public void OnClickSouces3(){
		if(isGrillerNotEmpty == true){
			RemoveSouce ();
			isGrillerNotEmpty = false;
			Griller01.SetActive(true);
			Griller02.SetActive(false);
			FriesSouce03.SetActive(true);
			isSouce03 = true;
			SE_Click.Play();
			if (TestingScript.isTesting == true) {
				print ("Output: " + 3);
			}
		}
	}

	public void OnClickSouces4(){
		if(isGrillerNotEmpty == true){
				RemoveSouce ();
				isGrillerNotEmpty = false;
				Griller01.SetActive(true);
				Griller02.SetActive(false);
				FriesSouce04.SetActive(true);
				isSouce04 = true;
				SE_Click.Play();
				if (TestingScript.isTesting == true) {
					print ("Output: " + 4);
				}
		}
	}

	public void OnClickSouces5(){
		if(isGrillerNotEmpty == true){
			RemoveSouce ();
			isGrillerNotEmpty = false;
			Griller01.SetActive(true);
			Griller02.SetActive(false);
			FriesSouce05.SetActive(true);
			isSouce05 = true;
			SE_Click.Play();
			if (TestingScript.isTesting == true) {
				print ("Output: " + 5);
			}
		}
	}

	public void OnClickSouces6(){
		if(isGrillerNotEmpty == true){
			RemoveSouce ();
			isGrillerNotEmpty = false;
			Griller01.SetActive(true);
			Griller02.SetActive(false);
			FriesSouce06.SetActive(true);
			isSouce06 = true;
			SE_Click.Play();
			if (TestingScript.isTesting == true) {
				print ("Output: " + 6);
			}
		}
	}


	public void OnClickCopEmpty(){
		Cap01.SetActive(true);
		Cap02.SetActive(false);
		Cap03.SetActive(false);
		Cap04.SetActive(false);
		Cap05.SetActive(false);
		Cap06.SetActive(false);
		Cap07.SetActive(false);
		SE_Click.Play();
	}

	public void OnClickNoCop(){
		if(Cap02.activeSelf || Cap03.activeSelf || Cap04.activeSelf || Cap05.activeSelf || Cap06.activeSelf || Cap07.activeSelf){
			isSouce01 = isSouce02 = isSouce03 = isSouce04 = isSouce05 = isSouce06 = false ;
		}

		if(Cap01.activeSelf || Cap02.activeSelf || Cap03.activeSelf || Cap04.activeSelf || Cap05.activeSelf || Cap06.activeSelf || Cap07.activeSelf){
			Cap01.SetActive(false);
			Cap02.SetActive(false);
			Cap03.SetActive(false);
			Cap04.SetActive(false);
			Cap05.SetActive(false);
			Cap06.SetActive(false);
			Cap07.SetActive(false);
			if (TestingScript.isTesting == true) {
				print ("OnClickNoCop");
			}
		}
		
	}

	public void OnClickEmptyCapAddFries(){
		if(isSouce01 == true || isSouce02 == true || isSouce03 == true  || isSouce04 == true  || isSouce05 == true  || isSouce06 == true ){
			if(Cap01.activeSelf){
				StartCoroutine(ExecuteAddFriesStart(1f));
				
			}
		}
	}

	IEnumerator ExecuteAddFriesStart(float time)
	{
		if(isSouce01 == true){
			SharakerSouce.SetBool("ShakerBBQ", true);
		}else if(isSouce02 == true){
			SharakerSouce.SetBool("ShakerCheese", true);
		}else if(isSouce03 == true){
			SharakerSouce.SetBool("ShakerSC", true);
		}else if(isSouce04 == true){
			SharakerSouce.SetBool("ShakerSweetCorn", true);//ShakerSweetCorn //ShakerChiliBBQ //ShakerWasabi
		}else if(isSouce05 == true){
			SharakerSouce.SetBool("ShakerChiliBBQ", true);
		}else if(isSouce06 == true){
			SharakerSouce.SetBool("ShakerWasabi", true);
		}
		
		EmptySouces();
		float halfTime = time / 2;
		yield return new WaitForSeconds(halfTime);
		SE_SHAKER.Play();
		yield return new WaitForSeconds(halfTime);
		StartCoroutine(ExecuteAddFriesEnd(0f));
	}

	IEnumerator ExecuteAddFriesEnd(float time)
	{
		SharakerSouce.SetBool("ShakerBBQ", false);
		SharakerSouce.SetBool("ShakerCheese", false);
		SharakerSouce.SetBool("ShakerSC", false);

		SharakerSouce.SetBool("ShakerSweetCorn", false);
		SharakerSouce.SetBool("ShakerChiliBBQ", false);
		SharakerSouce.SetBool("ShakerWasabi", false);

		yield return new WaitForSeconds(time);
		SharakerSouce.SetBool("ShakerBBQ", false);
		SharakerSouce.SetBool("ShakerCheese", false);
		SharakerSouce.SetBool("ShakerSC", false);

		SharakerSouce.SetBool("ShakerSweetCorn", false);
		SharakerSouce.SetBool("ShakerChiliBBQ", false);
		SharakerSouce.SetBool("ShakerWasabi", false);
		if(isSouce01 == true){
			// isSouce01 = false;
			EmptySouce01.SetActive(true);
			FriesSouce01.SetActive(false);
			Cap01.SetActive(false);
			Cap02.SetActive(true);
			Cap03.SetActive(false);
			Cap04.SetActive(false);
			Cap05.SetActive(false);
			Cap06.SetActive(false);
			Cap07.SetActive(false);
			SE_Click.Play();
		}
		else if(isSouce02 == true){
			// isSouce02 = false;
			EmptySouce02.SetActive(true);
			FriesSouce02.SetActive(false);
			Cap01.SetActive(false);
			Cap02.SetActive(false);
			Cap03.SetActive(true);
			Cap04.SetActive(false);
			Cap05.SetActive(false);
			Cap06.SetActive(false);
			Cap07.SetActive(false);
			SE_Click.Play();
		}
		else if(isSouce03 == true){
			// isSouce03 = false;
			EmptySouce03.SetActive(true);
			FriesSouce03.SetActive(false);
			Cap01.SetActive(false);
			Cap02.SetActive(false);
			Cap03.SetActive(false);
			Cap04.SetActive(true);
			Cap05.SetActive(false);
			Cap06.SetActive(false);
			Cap07.SetActive(false);
			SE_Click.Play();
		}else if(isSouce04 == true){
		// isSouce03 = false;
			EmptySouce04.SetActive(true);
			FriesSouce04.SetActive(false);
			Cap01.SetActive(false);
			Cap02.SetActive(false);
			Cap03.SetActive(false);
			Cap04.SetActive(false);
			Cap05.SetActive(true);
			Cap06.SetActive(false);
			Cap07.SetActive(false);
			SE_Click.Play();
		}else if(isSouce05 == true){
		// isSouce03 = false;
			EmptySouce05.SetActive(true);
			FriesSouce05.SetActive(false);
			Cap01.SetActive(false);
			Cap02.SetActive(false);
			Cap03.SetActive(false);
			Cap04.SetActive(false);
			Cap05.SetActive(false);
			Cap06.SetActive(true);
			Cap07.SetActive(false);
			SE_Click.Play();
		}else if(isSouce06 == true){
		// isSouce03 = false;
			EmptySouce06.SetActive(true);
			FriesSouce06.SetActive(false);
			Cap01.SetActive(false);
			Cap02.SetActive(false);
			Cap03.SetActive(false);
			Cap04.SetActive(false);
			Cap05.SetActive(false);
			Cap06.SetActive(false);
			Cap07.SetActive(true);
			SE_Click.Play();
		}

		// isSouce01 = isSouce02 = isSouce03 = false ;
	}

	void EmptySouces(){
		EmptySouce01.SetActive(true);
		EmptySouce02.SetActive(true);
		EmptySouce03.SetActive(true);
		FriesSouce01.SetActive(false);
		FriesSouce02.SetActive(false);
		FriesSouce03.SetActive(false);

		EmptySouce04.SetActive(true);
		EmptySouce05.SetActive(true);
		EmptySouce06.SetActive(true);
		FriesSouce04.SetActive(false);
		FriesSouce05.SetActive(false);
		FriesSouce06.SetActive(false);

	}

	public void OnClickGiveToCustomer(){
		if(Cap02.activeSelf || Cap03.activeSelf || Cap04.activeSelf || Cap05.activeSelf || Cap06.activeSelf || Cap07.activeSelf){
			if((RDCharacterChoice_1 == 0 && isSouce01== true) || RDCharacterChoice_1 == 1 && isSouce02== true || RDCharacterChoice_1 == 2 && isSouce03== true
	|| RDCharacterChoice_1 == 3 && isSouce04== true  || RDCharacterChoice_1 == 4 && isSouce05== true  || RDCharacterChoice_1 == 5 && isSouce06== true){
				isSouce01 = isSouce02 = isSouce03 = isSouce04 = isSouce05 = isSouce06 = false ;
				isOrderRight_1 = true;
				Cap01.SetActive(false);
				Cap02.SetActive(false);
				Cap03.SetActive(false);
				Cap04.SetActive(false);
				Cap05.SetActive(false);
				Cap06.SetActive(false);
				Cap07.SetActive(false);
				StartCoroutine(FuncScoreAnimate(1f));
				SE_POINTS.Play();
				ScoreCount++;
				// isCharacterOn_1 = false;
				// CharacterMovement.isCharacterReset_1 = true;
			}else{
				isOrderWrong_1 = true;
				isSouce01 = isSouce02 = isSouce03 = isSouce04 = isSouce05 = isSouce06 = false ;
				Cap01.SetActive(false);
				Cap02.SetActive(false);
				Cap03.SetActive(false);
				Cap04.SetActive(false);
				Cap05.SetActive(false);
				Cap06.SetActive(false);
				Cap07.SetActive(false);
				SE_NOPOINTS.Play();
			}
		}
	}

	public void OnClickGiveToCustomer_2(){
		if(Cap02.activeSelf || Cap03.activeSelf || Cap04.activeSelf || Cap05.activeSelf || Cap06.activeSelf || Cap07.activeSelf){
			if((RDCharacterChoice_2 == 0 && isSouce01== true) || RDCharacterChoice_2 == 1 && isSouce02== true || RDCharacterChoice_2 == 2 && isSouce03== true
	|| RDCharacterChoice_2 == 3 && isSouce04== true || RDCharacterChoice_2 == 4 && isSouce05== true || RDCharacterChoice_2 == 5 && isSouce06== true){
				isSouce01 = isSouce02 = isSouce03 = isSouce04 = isSouce05 = isSouce06 = false ;
				isOrderRight_2 = true;
				Cap01.SetActive(false);
				Cap02.SetActive(false);
				Cap03.SetActive(false);
				Cap04.SetActive(false);
				Cap05.SetActive(false);
				Cap06.SetActive(false);
				Cap07.SetActive(false);
				StartCoroutine(FuncScoreAnimate(1f));
				SE_POINTS.Play();
				ScoreCount++;
				// isCharacterOn_1 = false;
				// CharacterMovement.isCharacterReset_2 = true;
			}else{
				isOrderWrong_2 = true;
				isSouce01 = isSouce02 = isSouce03 = isSouce04 = isSouce05 = isSouce06 = false ;
				Cap01.SetActive(false);
				Cap02.SetActive(false);
				Cap03.SetActive(false);
				Cap04.SetActive(false);
				Cap05.SetActive(false);
				Cap06.SetActive(false);
				Cap07.SetActive(false);
				SE_NOPOINTS.Play();
			}
		}
	}

	public void OnClickGiveToCustomer_3(){
		if(Cap02.activeSelf || Cap03.activeSelf || Cap04.activeSelf || Cap05.activeSelf || Cap06.activeSelf || Cap07.activeSelf){
			if((RDCharacterChoice_3 == 0 && isSouce01== true) || RDCharacterChoice_3 == 1 && isSouce02== true || RDCharacterChoice_3 == 2 && isSouce03== true
	|| RDCharacterChoice_3 == 3 && isSouce04== true || RDCharacterChoice_3 == 4 && isSouce05== true  || RDCharacterChoice_3 == 5 && isSouce06== true){
				isSouce01 = isSouce02 = isSouce03 = isSouce04 = isSouce05 = isSouce06 = false ;
				isOrderRight_3 = true;
				Cap01.SetActive(false);
				Cap02.SetActive(false);
				Cap03.SetActive(false);
				Cap04.SetActive(false);
				Cap05.SetActive(false);
				Cap06.SetActive(false);
				Cap07.SetActive(false);
				StartCoroutine(FuncScoreAnimate(1f));
				SE_POINTS.Play();
				ScoreCount++;
				// isCharacterOn_1 = false;
				// CharacterMovement.isCharacterReset_3 = true;
			}else{
				isOrderWrong_3 = true;
				isSouce01 = isSouce02 = isSouce03 = isSouce04 = isSouce05 = isSouce06 = false ;
				Cap01.SetActive(false);
				Cap02.SetActive(false);
				Cap03.SetActive(false);
				Cap04.SetActive(false);
				Cap05.SetActive(false);
				Cap06.SetActive(false);
				Cap07.SetActive(false);
				SE_NOPOINTS.Play();
			}
		}
	}



	//Animation for Score
	IEnumerator FuncScoreAnimate(float time)
	{
		ScoreAnimate.SetBool("ScoreAnimate", true);
		yield return new WaitForSeconds(time);
		ScoreAnimate.SetBool("ScoreAnimate", false);
	}

	//AnimationCharacter
	private void AnimationCharacter(int Character, int AnimState, Animator CharacterAnimLocal){
		

		CharacterAnimLocal.SetBool("Character01_Happy", false);
		CharacterAnimLocal.SetBool("Character01_Normal", false);
		CharacterAnimLocal.SetBool("Character01_Sad", false);

		CharacterAnimLocal.SetBool("Character02_Happy", false);
		CharacterAnimLocal.SetBool("Character02_Normal", false);
		CharacterAnimLocal.SetBool("Character02_Sad", false);

		CharacterAnimLocal.SetBool("Character03_Happy", false);
		CharacterAnimLocal.SetBool("Character03_Normal", false);
		CharacterAnimLocal.SetBool("Character03_Sad", false);

		
		if(Character == 1){
			if(AnimState == 1){
				CharacterAnimLocal.SetBool("Character01_Normal", true);
			}else if(AnimState == 2){
				CharacterAnimLocal.SetBool("Character01_Happy", true);
			}else if(AnimState == 3){
				CharacterAnimLocal.SetBool("Character01_Sad", true);
			}
		}
		if(Character == 2){
			if(AnimState == 1){
				CharacterAnimLocal.SetBool("Character02_Normal", true);
			}else if(AnimState == 2){
				CharacterAnimLocal.SetBool("Character02_Happy", true);
			}else if(AnimState == 3){
				CharacterAnimLocal.SetBool("Character02_Sad", true);
			}
		}
		if(Character == 3){
			if(AnimState == 1){
				CharacterAnimLocal.SetBool("Character03_Normal", true);
			}else if(AnimState == 2){
				CharacterAnimLocal.SetBool("Character03_Happy", true);
			}else if(AnimState == 3){
				CharacterAnimLocal.SetBool("Character03_Sad", true);
			}
		}

	}

	//PauseFunction
	public void PauseFunction(){
		PauseMenu.SetActive(true);
		isGamePause = true;
	}

	public void PauseResumeGame(){
		PauseMenu.SetActive(false);
		isGamePause = false;
	}

	public void PauseRestartGame(){
		FuncPlayAgain ();
	}

	public void PauseReturnHome(){
		FuncEndGame ();
	}

	public void CapOffSwitch(){
		FriesCapOnOff.sprite = FriesCapOff;
	}
	public void CapOnwitch(){
		FriesCapOnOff.sprite = FriesCapOn;
	}
	public void PototosOffSwitch(){
		PototosOnOff.sprite = PototosOff;
	}
	public void PototosOnwitch(){
		PototosOnOff.sprite = PototosOn;
	}
	public void TrashcanOffSwitch(){
		TrashcanOnOff.sprite = TrashcanOff;
	}
	public void TrashcanOnwitch(){
		TrashcanOnOff.sprite = TrashcanOn;
	}

	public void FuncPlayAgain(){
		GlobalVarReset.ResetDataGlobal ();
		Application.LoadLevel ("Scene01_Game");
		
		//to be Delete
		int CurrentLifePlay = PlayerPrefs.GetInt("LifePlay");

		if (CurrentLifePlay <= 0) {
			LifePlayController.isLifePlayPopUp = true;
			Application.LoadLevel ("Scene00_MainMenu");
		} else {
			CurrentLifePlay = CurrentLifePlay - 1;
			PlayerPrefs.SetInt ("LifePlay", CurrentLifePlay);


			CurrentLifePlay = PlayerPrefs.GetInt ("LifePlay");
			print ("CurrentLifePlay: " + CurrentLifePlay);
		}
	}

	public void FuncEndGame(){
		GlobalVarReset.ResetDataGlobal ();
		Application.LoadLevel ("Scene00_MainMenu");
	}


	//Ads Here
	void AdsSetting(){
		AdsRandom = Random.Range(1,5);
		isIntern = false;
//		MobileAds.Initialize (appID);
//		AD = new InterstitialAd (regularAD);
//		request = new AdRequest.Builder ().Build ();
//		AD.LoadAd (request);
	}

	void AdsShowHere(){
		if (isAdsShow == true) {
			//print ("AdsRandom: "+AdsRandom);
			if (AdsRandom >= 3) {
				if (isIntern == false) {
					isIntern = true;
//					ShowRewardedAd ();
				}
			} else {
				
//				if (AD.IsLoaded ()) {
//					if (isIntern == false) {
//						isIntern = true;
//						AD.Show ();
//					}
//				}
				
			}
		}
	}


	//UNity

//	void UnityAdsSetting(){
////		Advertisement.Initialize (gameID, testMode); //Remove this to show ads
////		ShowRewardedAd ();
//	}
//
//	public void ShowRewardedAd()
//	{
//		//print ("ShowRewardedAd :"+Advertisement.IsReady("rewardedVideo"));
//		if (Advertisement.IsReady(PlacementAds))
//		{
//			var options = new ShowOptions { resultCallback = HandleShowResult };
////			Advertisement.Show(PlacementAds, options); //Remove this to show ads
//			//print ("HandleShowResult");
//		}
//	}
//
//	private void HandleShowResult(ShowResult result)
//	{
//		switch (result)
//		{
//			case ShowResult.Finished:
//			Debug.Log("The ad was successfully shown.");
//			//
//			// YOUR CODE TO REWARD THE GAMER
//			// Give coins etc.
//			break;
//			case ShowResult.Skipped:
//			Debug.Log("The ad was skipped before reaching the end.");
//			break;
//			case ShowResult.Failed:
//			Debug.LogError("The ad failed to be shown.");
//			break;
//		}
//	}
//


}
