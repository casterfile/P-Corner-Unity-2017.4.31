using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.Monetization;

public class TestAds : MonoBehaviour { 

	//string gameId = "2881690";
	public bool testMode = false;

	#if UNITY_IOS
	public const string gameId = "2881690";
	#elif UNITY_ANDROID
	public const string gameId = "2881688";
	#elif UNITY_EDITOR
	public const string gameId = "2881690";
	#endif

	void Start () {
//		Monetization.Initialize (gameId, testMode);
	}
}