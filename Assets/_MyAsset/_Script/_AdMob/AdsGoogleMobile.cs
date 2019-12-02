using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using GoogleMobileAds.Api;

public class AdsGoogleMobile : MonoBehaviour {

	public void Start()
	{
		#if UNITY_ANDROID
		string initializeAppId = "ca-app-pub-4378773022879105~1952761290"; // ca-app-pub-4378773022879105/8799286961 //ca-app-pub-4378773022879105~1952761290
		#elif UNITY_IPHONE
		string initializeAppId = "ca-app-pub-4378773022879105~6383918752";// ca-app-pub-4378773022879105/7812550496 //ca-app-pub-4378773022879105~6383918752
		#else
		string initializeAppId = "unexpected_platform";
		#endif

		// Initialize the Google Mobile Ads SDK.
//		MobileAds.Initialize(initializeAppId);
		RequestInterstitial ();
	}


	private void RequestInterstitial()
	{
		#if UNITY_ANDROID
		string adUnitId = "ca-app-pub-4378773022879105/8799286961";
		#elif UNITY_IPHONE
		string adUnitId = "ca-app-pub-4378773022879105/7812550496";
		#else
		string adUnitId = "unexpected_platform";
		#endif

		// Initialize an InterstitialAd.
//		InterstitialAd interstitial = new InterstitialAd(adUnitId);
//		// Create an empty ad request.
//		AdRequest request = new AdRequest.Builder().Build();
//		// Load the interstitial with the request.
//		interstitial.LoadAd(request);
//
//		if (interstitial.IsLoaded()) {
//			interstitial.Show();
//		}
	}
}


	