using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using System;

public class LifePlayController : MonoBehaviour {
	private GameObject LifePlayGroup,LifePlay, LifePlayCountDown, LifePlayPopUp,NoLifePlayPopup,NoLifePlaySuccessFb,NoLifePlaySuccessVideo,VideosPlayerPopup,VideosPlayerPopupClose, NoLifePlayPopup_fbDisable;
	private Text LifePlayNumber,LifePlayCountDownNumber,LifePlayPopUpCountDownNumber;
	private DateTime theTime, lastTime, CurrentDate;
	private bool isCountDown = false;
	const int CurrentCountDownTimeMin = 15;
	private int CountDownTimeMin = CurrentCountDownTimeMin;
	private int CurrentLifePlay;
	private int NewCountDownTimeMin;
	private VideoPlayer m_VideoPlayer;
	private bool isVideoPlayOnce = false;
	private bool isAddLifeOnlyOne = false;
	private bool isPlayVideoOnce = false;
//	public VideoClip videoClips1,videoClips2,videoClips3,videoClips4,videoClips5,videoClips6,videoClips7,videoClips8,videoClips9;

	public static bool isLifePlayPopUp = false;
	public static bool isNoLifePlaySuccessFb = false;
	public static bool isNoLifePlaySuccessVideo = false;
	public static bool isNoLifePlayPopup = false;
	public static int LastAdsVideo = 0;


	// Use this for initialization
	void Start () {
		CountDownTimeMin = CurrentCountDownTimeMin;
		isAddLifeOnlyOne = false;
		isVideoPlayOnce = false;
		isPlayVideoOnce = false;
		theTime = DateTime.Now;
//		lastTime =lastTime.AddMinutes(5);
		lastTime = theTime;
		if (PlayerPrefs.HasKey ("lastTime") == false ) {
			DateTime lastTimeFinal = DateTime.Now;
			lastTimeFinal = lastTimeFinal.AddMinutes(CurrentCountDownTimeMin);
			PlayerPrefs.SetString("lastTime", lastTimeFinal.ToBinary().ToString());

			lastTime = lastTimeFinal;//new System.DateTime (NewlastTime_Year, NewlastTime_Month, NewlastTime_Day, NewlastTime_Hour, NewlastTime_Minute, NewlastTime_Second);

			PlayerPrefs.SetInt ("LifePlay", 5);
			CurrentLifePlay = 5;
		} else {
			long tempLastTime = Convert.ToInt64(PlayerPrefs.GetString("lastTime"));
			DateTime lastTimeCurrent = DateTime.FromBinary(tempLastTime);
//			print ("lastTimeCurrent: "+lastTimeCurrent);

			lastTime = lastTimeCurrent;
			CurrentDate = lastTimeCurrent; 

			CurrentLifePlay = PlayerPrefs.GetInt("LifePlay");
		}
		//to be Delete
//		CurrentLifePlay = 5;


		NoLifePlayPopup_fbDisable = GameObject.Find("NoLifePlayPopup_fbDisable");
		LifePlayPopUp  = GameObject.Find("LifePlayPopUp");
		NoLifePlayPopup  = GameObject.Find("NoLifePlayPopup");
		NoLifePlaySuccessFb  = GameObject.Find("NoLifePlaySuccessFb");
		NoLifePlaySuccessVideo  = GameObject.Find("NoLifePlaySuccessVideo");
		VideosPlayerPopupClose = GameObject.Find("VideosPlayerPopupClose");

		m_VideoPlayer = GameObject.Find("VideoPlayerController").GetComponent<VideoPlayer>();


		VideosPlayerPopup  = GameObject.Find("VideosPlayerPopup");

		LifePlayGroup  = GameObject.Find("LifePlayGroup");
		LifePlay  = GameObject.Find("LifePlayGroup/LifePlay");
		LifePlayCountDown  = GameObject.Find("LifePlayGroup/LifePlayCountDown");

		LifePlayNumber  = GameObject.Find("LifePlayGroup/LifePlayNumber").GetComponent<Text>();
		LifePlayCountDownNumber  = GameObject.Find("LifePlayGroup/LifePlayCountDown/LifePlayCountDownNumber").GetComponent<Text>();

		LifePlayPopUpCountDownNumber  = GameObject.Find("LifePlayPopUpCountDownNumber").GetComponent<Text>();

		LifePlayGroup.SetActive (true);
		LifePlay.SetActive (true);
		LifePlayCountDown.SetActive(false);

		LifePlayPopUp.SetActive (false);
		NoLifePlayPopup.SetActive (false);
		NoLifePlaySuccessFb.SetActive (false);
		NoLifePlaySuccessVideo.SetActive (false);
		VideosPlayerPopup.SetActive (false);
		VideosPlayerPopupClose.SetActive (false);

//		print ("theTime.Minute: "+ theTime);
//		print ("lastTime.Minute: "+ lastTime);
		//int TimeMin = theTime.Minute - lastTime.Minute;



		int checkYouOnFB = PlayerPrefs.GetInt("YouOnFB");
		if (checkYouOnFB == 1) {
			NoLifePlayPopup_fbDisable.SetActive (true);
		} else {
			NoLifePlayPopup_fbDisable.SetActive (false);
		}

	}
	
	// Update is called once per frame
	private void SettingTimeAndCalling(){
		try {
			isAddLifeOnlyOne = false;

			long tempLastTime = Convert.ToInt64(PlayerPrefs.GetString("lastTime"));
			DateTime lastTimeCurrent = DateTime.FromBinary(tempLastTime);

			lastTime = lastTimeCurrent;

		}
		catch (Exception e) {
			print("error: "+e);
		} 
	}

	void Update () {
		theTime = DateTime.Now;
//		print ("Current lastTime: "+ lastTime);
//		print ("Current theTime: "+ theTime);
		if (CurrentLifePlay < 5) {
			isCountDown = true;
			SettingTimeAndCalling ();
//			print ("Below Life");
		
		}else if (CurrentLifePlay == 5){
//			print ("CurrentLifePlay: "+CurrentLifePlay);
			isCountDown = false;
			isAddLifeOnlyOne = false;



			try {
				DateTime lastTimeFinal = DateTime.Now;
//				print("lastTimeFinal1: "+ lastTimeFinal);
				lastTimeFinal = lastTimeFinal.AddMinutes(CurrentCountDownTimeMin);
//				print("lastTimeFinal2: "+ lastTimeFinal);
				PlayerPrefs.SetString("lastTime", lastTimeFinal.ToBinary().ToString());

				long tempLastTime = Convert.ToInt64(PlayerPrefs.GetString("lastTime"));
				DateTime lastTimeCurrent = DateTime.FromBinary(tempLastTime);

				lastTime = lastTimeCurrent;
				CurrentDate = lastTimeCurrent;
			}
			catch (Exception e) {

				print("error: "+e);
			}
		}

		if(isCountDown == true){
//			print ("isCountDown = "+ isCountDown);

			TimeSpan travelTime = lastTime - theTime;
			//		string time = new System.DateTime(travelTime.Ticks).ToString("mm:ss");

			LifePlayCountDownNumber.text = toStr(travelTime);
			LifePlayPopUpCountDownNumber.text = toStr(travelTime);

			if (lastTime <= theTime || lastTime < theTime) {
				

				if(isAddLifeOnlyOne == false){
					isCountDown = false;

					isAddLifeOnlyOne = true;
					isCountDown = false;
					int Local_CurrentLifePlay = CurrentLifePlay;
					if(Local_CurrentLifePlay < 5){
						isAddLifeOnlyOne = false;

						DateTime lastTimeFinal = CurrentDate;
						lastTimeFinal = lastTimeFinal.AddMinutes(CurrentCountDownTimeMin);
						PlayerPrefs.SetString("lastTime", lastTimeFinal.ToBinary().ToString());

						SettingTimeAndCalling ();

						Local_CurrentLifePlay = Local_CurrentLifePlay + 1;
						PlayerPrefs.SetInt("LifePlay", Local_CurrentLifePlay);
					}



//					SettingTimeAndCalling ();
				}


			} else {
				LifePlay.SetActive (false);
				LifePlayCountDown.SetActive(true);

			}
		}

		if (CurrentLifePlay >= 5) {
			LifePlay.SetActive (true);
			LifePlayCountDown.SetActive (false);
			//lastTime = theTime;
		}

		//to be Delete
		CurrentLifePlay = PlayerPrefs.GetInt("LifePlay");
		LifePlayNumber.text = CurrentLifePlay +"";

		if (isLifePlayPopUp == true && isNoLifePlaySuccessFb == false && isNoLifePlaySuccessVideo == false) {
			LifePlayPopUp.SetActive (true);
			NoLifePlayPopup.SetActive (true);
			NoLifePlaySuccessFb.SetActive (false);
			NoLifePlaySuccessVideo.SetActive (false);
			isVideoPlayOnce = false;
		}else if (isLifePlayPopUp == true && isNoLifePlaySuccessFb == true && isNoLifePlaySuccessVideo == false) {
			LifePlayPopUp.SetActive (true);
			NoLifePlayPopup.SetActive (false);
			NoLifePlaySuccessFb.SetActive (true);
			NoLifePlaySuccessVideo.SetActive (false);
			isCountDown = false;
			LifePlay.SetActive (true);
			LifePlayCountDown.SetActive (false);
			VideosPlayerPopup.SetActive (false);
			isVideoPlayOnce = false;
		} else if (isLifePlayPopUp == true && isNoLifePlaySuccessFb == false && isNoLifePlaySuccessVideo == true) {
			LifePlayPopUp.SetActive (true);
			NoLifePlayPopup.SetActive (false);
			NoLifePlaySuccessFb.SetActive (false);
			NoLifePlaySuccessVideo.SetActive (true);

//			LifePlay.SetActive (true);
//			LifePlayCountDown.SetActive (false);
//			if(isVideoPlayOnce == false){
//				isVideoPlayOnce = true;
//				VideosPlayerPopup.SetActive (true);
//				InvokeRepeating("checkOver", .1f,.1f);
//			}
			if(isPlayVideoOnce == false){
				
				PlayRandomNumber ();

			}


		} else {
			LifePlayPopUp.SetActive (false);
			NoLifePlayPopup.SetActive (true);
			NoLifePlaySuccessFb.SetActive (false);
//			NoLifePlaySuccessVideo.SetActive (false);
//			VideosPlayerPopup.SetActive (false);
		}

	}

//	private void checkOver()
//	{
//		long playerCurrentFrame = m_VideoPlayer.GetComponent<VideoPlayer>().frame;
//		long playerFrameCount = Convert.ToInt64(m_VideoPlayer.GetComponent<VideoPlayer>().frameCount);
//
//		if(playerCurrentFrame < playerFrameCount)
//		{
//			print ("VIDEO IS PLAYING");
//		}
//		else
//		{
//			//isCountDown = false;
//			VideosPlayerPopup.SetActive (false);
//			PlayerPrefs.SetInt("LifePlay", 1);
//			print ("VIDEO IS OVER");
//			//Do w.e you want to do for when the video is done playing.
//
//			//Cancel Invoke since video is no longer playing
//			CancelInvoke("checkOver");
//		}
//	}

	void PlayRandomNumber(){
		isPlayVideoOnce = true;
		int number = UnityEngine.Random.Range(0,10);

		if (LastAdsVideo == number) {
			if (LastAdsVideo == 8) {
				number = 1;
			} if (LastAdsVideo > 8) {
				number = 2;
			} else {
				number = number + 1;
			}
		}
		LastAdsVideo = number;

		StartCoroutine(VideoPlayClose(15f));
//		if(number == 1){
//			m_VideoPlayer.clip = videoClips1;
//			StartCoroutine(VideoPlay(10f));
//		}else if(number == 2){
//			m_VideoPlayer.clip = videoClips2;
//			StartCoroutine(VideoPlay(10f));
//		}else if(number == 3){
//			m_VideoPlayer.clip = videoClips3;
//			StartCoroutine(VideoPlay(10f));
//		}else if(number == 4){
//			m_VideoPlayer.clip = videoClips4;
//			StartCoroutine(VideoPlay(10f));
//		}else if(number == 5){
//			m_VideoPlayer.clip = videoClips5;
//			StartCoroutine(VideoPlay(10f));
//		}else if(number == 6){
//			m_VideoPlayer.clip = videoClips6;
//			StartCoroutine(VideoPlay(86f));
//		}else if(number == 7){
//			m_VideoPlayer.clip = videoClips7;
//			StartCoroutine(VideoPlay(82f));
//		}else if(number == 8){
//			m_VideoPlayer.clip = videoClips8;
//			StartCoroutine(VideoPlay(92f));
//		}else {
//			m_VideoPlayer.clip = videoClips9;
//			StartCoroutine(VideoPlay(17f));
//		}


	}

	IEnumerator VideoPlay(float time)
	{
		isVideoPlayOnce = true;
		VideosPlayerPopup.SetActive (true);
		yield return new WaitForSeconds(time);
		VideosPlayerPopup.SetActive (false);
//		isNoLifePlaySuccessVideo = false;
		isVideoPlayOnce = false;
		PlayerPrefs.SetInt("LifePlay", 1);
		print ("VIDEO IS OVER");
	}

	IEnumerator VideoPlayClose(float time)
	{
		VideosPlayerPopupClose.SetActive (false);
		yield return new WaitForSeconds(time);
		VideosPlayerPopupClose.SetActive (true);
	}

	public void CloseVideo(){
		VideosPlayerPopup.SetActive (false);
		isVideoPlayOnce = false;
		PlayerPrefs.SetInt("LifePlay", 1);
		print ("VIDEO IS Close");
	}
		

	private string toStr(TimeSpan t)
	{
//		return t.Hours + ":" + t.Minutes + ":" + t.Seconds + "." + t.Milliseconds;
		string NewSecond = t.Seconds+"";
		if(t.Seconds < 10){
			NewSecond = "0" + t.Seconds + "";
		}
		return t.Minutes + ":" + NewSecond;
	}

	public void CloseLifePlayPopUp(){
		isLifePlayPopUp = false;
		isNoLifePlaySuccessFb = false;
		isNoLifePlaySuccessVideo = false;
	}

	public void FuncNoLifePlaySuccessVideo(){
		isLifePlayPopUp = true;
		isNoLifePlaySuccessFb = false;
		isNoLifePlaySuccessVideo = true;

	}
}
