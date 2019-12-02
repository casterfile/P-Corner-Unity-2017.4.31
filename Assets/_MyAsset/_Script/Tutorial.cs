using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour {

	private GameObject A1,A2,A3,A4,A_All;
	private GameObject B1,B2,B3,B4,B5,B6,B7,B8,B_All;
	private GameObject btnPrev, btnNext;
	private int count = 1, countLimit = 13;

	// Use this for initialization
	void Start () {
		count = 1;
		A1 = GameObject.Find("TextBubble/A (1)");
		A2 = GameObject.Find("TextBubble/A (2)");
		A3 = GameObject.Find("TextBubble/A (3)");
		A4 = GameObject.Find("TextBubble/A (4)");
		A_All = GameObject.Find("TextBubble");


		B1 = GameObject.Find("Tutorial/B (1)");
		B2 = GameObject.Find("Tutorial/B (2)");
		B3 = GameObject.Find("Tutorial/B (3)");
		B4 = GameObject.Find("Tutorial/B (4)");
		B5 = GameObject.Find("Tutorial/B (5)");
		B6 = GameObject.Find("Tutorial/B (6)");
		B7 = GameObject.Find("Tutorial/B (7)");
		B8 = GameObject.Find("Tutorial/B (8)");
		B_All = GameObject.Find("Tutorial");

		btnPrev = GameObject.Find("Prev");
		btnNext = GameObject.Find("Next");

	}
	
	// Update is called once per frame
	void Update () {
		if(count == 1){
			btnPrev.SetActive(false);
		}else{
			btnPrev.SetActive(true);
		}


		if(count >= countLimit){
			//btnNext.SetActive(false);
			if (MainMenu.isFirstTime == true) {
				Application.LoadLevel ("Scene01_Game");
			} else {
				GoMain ();
			}
		}else{
			btnNext.SetActive(true);
		}
		AllBubble();
		AllTutorial();
		
	}

	public void GoMain(){
		Application.LoadLevel ("Scene00_MainMenu");
	}

	public void Next(){
		count = count + 1;
		if(count == 10){
			//count = 12;
		}
	}

	public void Prev(){
		count = count - 1;
		if(count >= 10){
			//count = 9;
		}
	}

	void AllBubble(){
		if(count == 1){
			A_All.SetActive(true);
			A1.SetActive(true);
			A2.SetActive(false);
			A3.SetActive(false);
			A4.SetActive(false);
		}else if(count == 2){
			A_All.SetActive(true);
			A1.SetActive(false);
			A2.SetActive(true);
			A3.SetActive(false);
			A4.SetActive(false);
			
		}else if(count == 3){
			A_All.SetActive(true);
			A1.SetActive(false);
			A2.SetActive(false);
			A3.SetActive(true);
			A4.SetActive(false);
		}else if(count == 4){
			A_All.SetActive(true);
			A1.SetActive(false);
			A2.SetActive(false);
			A3.SetActive(false);
			A4.SetActive(true);
		}else if(count == 5){
			A_All.SetActive(false);
			A1.SetActive(false);
			A2.SetActive(false);
			A3.SetActive(false);
			A4.SetActive(false);
		}
	}

	void AllTutorial(){
		if(count < 5){
			B_All.SetActive(false);
			B1.SetActive(false);
			B2.SetActive(false);
			B3.SetActive(false);
			B4.SetActive(false);
			B5.SetActive(false);
			B6.SetActive(false);
		}

		if(count == 5){
			B_All.SetActive(true);
			B1.SetActive(true);
			B2.SetActive(false);
			B3.SetActive(false);
			B4.SetActive(false);
			B5.SetActive(false);
			B6.SetActive(false);
			B7.SetActive(false);
			B8.SetActive(false);
		}else if(count == 6){
			B_All.SetActive(true);
			B1.SetActive(false);
			B2.SetActive(true);
			B3.SetActive(false);
			B4.SetActive(false);
			B5.SetActive(false);
			B6.SetActive(false);
			B7.SetActive(false);
			B8.SetActive(false);
		}else if(count == 7){
			B_All.SetActive(true);
			B1.SetActive(false);
			B2.SetActive(false);
			B3.SetActive(true);
			B4.SetActive(false);
			B5.SetActive(false);
			B6.SetActive(false);
			B7.SetActive(false);
			B8.SetActive(false);
		}else if(count == 8){
			B_All.SetActive(true);
			B1.SetActive(false);
			B2.SetActive(false);
			B3.SetActive(false);
			B4.SetActive(true);
			B5.SetActive(false);
			B6.SetActive(false);
			B7.SetActive(false);
			B8.SetActive(false);
		}else if(count == 9){
			B_All.SetActive(true);
			B1.SetActive(false);
			B2.SetActive(false);
			B3.SetActive(false);
			B4.SetActive(false);
			B5.SetActive(true);
			B6.SetActive(false);
			B7.SetActive(false);
			B8.SetActive(false);
		}else if(count == 10){
			B_All.SetActive(true);
			B1.SetActive(false);
			B2.SetActive(false);
			B3.SetActive(false);
			B4.SetActive(false);
			B5.SetActive(false);
			B6.SetActive(true);
			B7.SetActive(false);
			B8.SetActive(false);
		}else if(count == 11){
			B_All.SetActive(true);
			B1.SetActive(false);
			B2.SetActive(false);
			B3.SetActive(false);
			B4.SetActive(false);
			B5.SetActive(false);
			B6.SetActive(false);
			B7.SetActive(true);
			B8.SetActive(false);
		}else if(count == 12){
			B_All.SetActive(true);
			B1.SetActive(false);
			B2.SetActive(false);
			B3.SetActive(false);
			B4.SetActive(false);
			B5.SetActive(false);
			B6.SetActive(false);
			B7.SetActive(false);
			B8.SetActive(true);
		}
	}

	public void URLPotatocCornerTutorial(){ //http://immersivemedia.ph/potatocornerWebsite/
		Application.OpenURL("https://immersivemedia.ph/potatocornerWebsite/");//http://bit.ly/PotatoCornerCraze
	}
}
