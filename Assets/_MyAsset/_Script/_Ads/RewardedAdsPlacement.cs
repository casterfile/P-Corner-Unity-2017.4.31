using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//using UnityEngine.Monetization;

public class RewardedAdsPlacement : MonoBehaviour {

	public string placementId = "rewardedVideo";
	#if UNITY_IOS
	public const string gameID = "2881690";
	#elif UNITY_ANDROID
	public const string gameID = "2881688";
	#elif UNITY_EDITOR
	public const string gameID = "2881690";
	#endif

	public void ShowAd () {
//		StartCoroutine (WaitForAd ());
	}

//	IEnumerator WaitForAd () {
//		while (!Monetization.IsReady (placementId)) {
//			yield return null;
//		}
//
//		ShowAdPlacementContent ad = null;
//		ad = Monetization.GetPlacementContent (placementId) as ShowAdPlacementContent;
//
//		if (ad != null) {
//			ad.Show (AdFinished);
//		}
//	}

//	void AdFinished (ShowResult result) {
//		if (result == ShowResult.Finished) {
//			// Reward the player
//		}
//	}

}
