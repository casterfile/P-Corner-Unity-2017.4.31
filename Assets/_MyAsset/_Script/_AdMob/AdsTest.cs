using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using GoogleMobileAds.Api;

public class AdsTest : MonoBehaviour {

//	private BannerView bannerView;
	public string appID = "ca-app-pub-4378773022879105~6383918752";

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
	// Use this for initialization
	void Start () {
//		isIntern = false;
//		MobileAds.Initialize (appID);
//		AD = new InterstitialAd (regularAD);
//		request = new AdRequest.Builder ().Build ();
//		AD.LoadAd (request);
	}
	
	// Update is called once per frame
	void Update () {
//		if (AD.IsLoaded()) {
//			if(isIntern == false){
//				isIntern = true;
//				AD.Show();
//			}
//		}
	}

	public void OnClickShowBanner(){
		RequestBanner ();
	}

	public void OnClickShowAd(){
		
		RequestRegularAd ();
	}

	private void RequestRegularAd(){
//		AD = new InterstitialAd (regularAD);
//		request = new AdRequest.Builder ().Build ();
//		AD.LoadAd (request);
		isIntern = false;

//		if (AD.IsLoaded()) {
//			AD.Show();
//		}
	}

	private void RequestBanner(){
//		bannerView = new BannerView (bannerID, AdSize.Banner, AdPosition.Bottom);
//		AdRequest request = new AdRequest.Builder ().Build ();
//		bannerView.LoadAd (request);
	}

}
