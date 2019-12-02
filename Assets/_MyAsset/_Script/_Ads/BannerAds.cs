using System.Collections;
using UnityEngine;
//using UnityEngine.Advertisements;

public class BannerAds : MonoBehaviour {

	public string bannerPlacement = "banner";
	public bool testMode = false;

	#if UNITY_IOS
	public const string gameID = "2881690";
	#elif UNITY_ANDROID
	public const string gameID = "2881688";
	#elif UNITY_EDITOR
	public const string gameID = "2881690";
	#endif

//	void Start () {
//	Advertisement.Initialize (gameID, testMode);
//	StartCoroutine (ShowBannerWhenReady ());
//	}
//
//	IEnumerator ShowBannerWhenReady () {
//	while (!Advertisement.IsReady ("banner")) {
//	yield return new WaitForSeconds (0.5f);
//	}
//	Advertisement.Banner.Show (bannerPlacement);
//	}


}