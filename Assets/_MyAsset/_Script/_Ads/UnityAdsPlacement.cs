using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//using UnityEngine.Monetization;

public class UnityAdsPlacement : MonoBehaviour {

	private string placementId = "rewardvideo";

	void Start(){
		ShowAd ();

	}

	public void ShowAd () {
//		StartCoroutine (ShowAdWhenReady ());
	}

//	private IEnumerator ShowAdWhenReady () {
//		int x = 0;
//		while (!Monetization.IsReady (placementId)) {
//			yield return new WaitForSeconds(0.25f);
//			//x++;
//			//print ("Loop: "+ x);
//		}
//
//		ShowAdPlacementContent ad = null;
//		ad = Monetization.GetPlacementContent (placementId) as ShowAdPlacementContent;
//
//		if(ad != null) {
//			ad.Show ();
//		}
		//print ("ad: "+ad);
//	}
}