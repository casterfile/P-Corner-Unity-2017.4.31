using UnityEngine;
//using UnityEngine.Advertisements;

public class UnityAdsExample : MonoBehaviour
{	
	public string PlacementAds;
	public bool testMode = false;

	#if UNITY_IOS
	public const string gameID = "2881690";
	#elif UNITY_ANDROID
	public const string gameID = "2881688";
	#elif UNITY_EDITOR
	public const string gameID = "2881690";
	#endif

	void Start(){
//		Advertisement.Initialize (gameID, testMode);
		ShowRewardedAd ();
		//print ("ShowRewardedAd Start");
	}

	public void ShowRewardedAd()
	{
		//print ("ShowRewardedAd :"+Advertisement.IsReady("rewardedVideo"));
//		if (Advertisement.IsReady(PlacementAds))
//		{
////			var options = new ShowOptions { resultCallback = HandleShowResult };
////			Advertisement.Show(PlacementAds, options);
//			//print ("HandleShowResult");
//		}
	}

//	private void HandleShowResult(ShowResult result)
//	{
//		switch (result)
//		{
//		case ShowResult.Finished:
//			Debug.Log("The ad was successfully shown.");
//			//
//			// YOUR CODE TO REWARD THE GAMER
//			// Give coins etc.
//			break;
//		case ShowResult.Skipped:
//			Debug.Log("The ad was skipped before reaching the end.");
//			break;
//		case ShowResult.Failed:
//			Debug.LogError("The ad failed to be shown.");
//			break;
//		}
//	}
}