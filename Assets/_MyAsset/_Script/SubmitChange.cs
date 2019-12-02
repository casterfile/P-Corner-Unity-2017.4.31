using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SubmitChange : MonoBehaviour {
	public Sprite sprClickOn, sprClickOff;
	public void SubmitOn(){
		this.GetComponent<Image>().sprite = sprClickOn;
	}

	public void SubmitOff(){
		this.GetComponent<Image>().sprite = sprClickOff;
	}
}
