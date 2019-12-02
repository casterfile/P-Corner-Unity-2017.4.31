using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Facebook.Unity;
using Facebook.Unity.Example;
using System;
using UnityEngine.UI;

public class FBLoginMenu : MonoBehaviour {
	private GameObject FBTest;
	private Text FBTest_text;
	void Awake(){
		FB.Init (SetInit, OnHidenUnity);
	}

	void Start(){
		FBTest = GameObject.Find ("FBTest");
		FBTest_text = GameObject.Find ("FBTest_text").GetComponent<Text>();
		if (TestingScript.isTesting == true) {
			FBTest.SetActive (false);
		} else {
			FBTest.SetActive (false);
		}

	}

	void SetInit(){
		if (FB.IsLoggedIn) {
			Debug.Log ("FB is logged is");
			CrashReport ("FB is logged in");
		} else {
			Debug.Log ("FB is not logged in");
			CrashReport ("FB is not logged in");
		}
		DealWithFBMenus (FB.IsLoggedIn);
	}

	void OnHidenUnity(bool isGameShown){
		if (!isGameShown) {
			Time.timeScale = 0;
		} else {
			Time.timeScale = 1;
		}
	}

	public void FBLogin(){
		List<string> permissions = new List<string> ();
		permissions.Add ("public_profile");
		permissions.Add ("email");
		permissions.Add ("user_friends");
//		permissions.Add ("user_email");
//		permissions.Add ("user_relationships");
//		permissions.Add ("user_hometown");

		FB.LogInWithReadPermissions (permissions, AuthCallBack);
	}

	void AuthCallBack(IResult result){
		if (result.Error != null) {
			Debug.Log (result.Error);
        } else {
			if (FB.IsLoggedIn) {
				Debug.Log ("FB is logged in");
				CrashReport ("FB is logged in");
			} else {
				Debug.Log ("FB is not logged in");
				CrashReport ("FB is not logged in");
			}
			DealWithFBMenus (FB.IsLoggedIn);
        }
	}
		

	public void DealWithFBMenus(bool isLoggedIn){
		if (isLoggedIn) {
			//FB.API ("/me?fields=email" , HttpMethod.GET, DisplayEmail);
//			FB.API ("/me?fields=email,name,gender,id" , HttpMethod.GET, DisplayInfo);

			FB.API ("/me?fields=email,name,id" , HttpMethod.GET, DisplayInfo);
//			FB.API ("/me/picture?type=square&height=128&width=128", HttpMethod.GET, DisplayProfile);
//			FB.API ("/me?fields=user_hometown" , HttpMethod.GET, Displayhometown);

//			Application.LoadLevel ("Scene01_Game");	

//			if(FB.IsLoggedIn == false){
//				
//			}

			if (PlayerPrefs.HasKey ("YouOnFB") == false) {
				PlayerPrefs.SetInt("YouOnFB", 0);
			}

			if (PlayerPrefs.GetInt ("YouOnFB") == 0) {
				PlayerPrefs.SetInt("YouOnFB", 1);
				PlayerPrefs.SetInt("LifePlay", 5);
				LifePlayController.isNoLifePlaySuccessFb = true;
				LifePlayController.isNoLifePlaySuccessVideo = false;
			}
		} 
	}

	private void DisplayInfo(IResult result){
		if (result.Error == null) {
			
//			string L_FBGender = result.ResultDictionary ["gender"]+"";
			string L_FBEmailAddress = "";
			string L_FBUserID = "";
			string L_FBName = "";

			try {
				L_FBUserID = result.ResultDictionary ["id"]+"";
			}
			catch (Exception e) {
				L_FBUserID = "Not Available";
			}

			try {
				L_FBName = result.ResultDictionary ["name"]+"";
			}
			catch (Exception e) {
				L_FBName = "Not Available";
			}

			try {
				L_FBEmailAddress = result.ResultDictionary ["email"]+"";
			}
			catch (Exception e) {
				L_FBEmailAddress = "Not Available";
			}



			if(FBGlobalVar.FBUserID != "" && FBGlobalVar.FBUserID != null){
				print ("DDDDDDDDDDDD: "+L_FBUserID);
				PlayerPrefs.SetString("FB_UserID", FBGlobalVar.FBUserID);
				PlayerPrefs.SetString("FB_Name", FBGlobalVar.FBName);
				PlayerPrefs.SetString("FB_Gender", FBGlobalVar.FBGender);
				PlayerPrefs.SetString("FB_Email_Address", FBGlobalVar.FBEmailAddress);


//				PlayerPrefs.SetString("FB_Gender_2", L_FBGender);
//				
			}

			PlayerPrefs.SetString("FB_UserID_2", L_FBUserID);
			PlayerPrefs.SetString("FB_Name_2", L_FBName);
			PlayerPrefs.SetString("FB_Email_Address_2", L_FBEmailAddress);

			print ("Hellow WORLD 1111"+ result.RawResult);
			Debug.Log (result.Error);
		} else {
			Debug.Log (result.Error);
		}
	}
		

	private void DisplayEmail(IResult result){
		if (result.Error == null) {
			Debug.Log (result.Error);
		} else {
			Debug.Log (result.Error);
		}
	}

	private void Displayhometown(IResult result){
		if (result.Error == null) {
//			Location.text = "Location: " + result.ResultDictionary["user_hometown"];
			Debug.Log (result.Error);
		} else {
			Debug.Log (result.Error);
		}
	}

	private void DisplayProfile(IGraphResult result){
		if (result.Texture != null) {
//			ProfilePic.sprite = Sprite.Create (result.Texture, new Rect (0, 0, 128, 128), new Vector2 ());
			FBGlobalVar.ProfilePic = Sprite.Create (result.Texture, new Rect (0, 0, 128, 128), new Vector2 ());
		} else {
			Debug.Log (result.Error);
		}
	}


	private void CrashReport(string Data){
//		ReportMessage.text = Data;
	}

	private void Update(){
		string FBUserID = "";
		string FBName = "";
		string FBEmailAddress = "";
		if (PlayerPrefs.HasKey ("FB_UserID_2") == false) {

			FBUserID = "Not Yet Available";
			FBName  = "Not Yet Available";
			FBEmailAddress  = "Not Yet Available";

//			FBUserID = PlayerPrefs.GetString ("FB_UserID_2");
//			FBName = PlayerPrefs.GetString ("FB_Name_2");
//			FBEmailAddress = PlayerPrefs.GetString ("FB_Email_Address_2");

			PlayerPrefs.SetString("FB_UserID_2", FBUserID);
			PlayerPrefs.SetString("FB_Name_2", FBName);
			PlayerPrefs.SetString("FB_Email_Address_2", FBEmailAddress);
		} else {
			
			FBUserID = PlayerPrefs.GetString ("FB_UserID_2");
			FBName = PlayerPrefs.GetString ("FB_Name_2");
			FBEmailAddress = PlayerPrefs.GetString ("FB_Email_Address_2");
		}



//		string FBGender = PlayerPrefs.GetString ("FB_Gender_2");



		if (FBUserID != "" && FBUserID != null) {
//			FBTest.SetActive (true);
//			FBTest_text.text = "FBUserID: "+FBUserID+" || "+ "FBName: "+FBName+" || "+  "FBEmailAddress: "+FBEmailAddress;
//

//			print ("FBGlobalVar.FBGender: " + FBGender);
//			print ("FBGlobalVar.FBUserID: " + FBUserID);
//			print ("FBGlobalVar.FBName: " + FBName);
//			print ("FBGlobalVar.FBEmailAddress: " + FBEmailAddress);

//			print ("gggggg: "+FBUserID);
		} else {
//			print ("xxxxx");
			FBUserID = "Not Yet Available";
			FBName  = "Not Yet Available";
			FBEmailAddress  = "Not Yet Available";

			PlayerPrefs.SetString("FB_UserID_2", FBUserID);
			PlayerPrefs.SetString("FB_Name_2", FBName);
			PlayerPrefs.SetString("FB_Email_Address_2", FBEmailAddress);

//			print ("FBGlobalVar.FBUserID: " + FBUserID);
//			print ("FBGlobalVar.FBName: " + FBName);
//			print ("FBGlobalVar.FBEmailAddress: " + FBEmailAddress);
		}


	}


}
