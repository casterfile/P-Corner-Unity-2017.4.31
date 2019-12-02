using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterMovement3 : MonoBehaviour {

	public Transform target, target_Start;
	private Transform LocationReset;
	public Image imgItem;
    private float speed = 60;
    private float resize = 100;
    public static bool isCharacterReset_3 = false;
    private float TotalSpeed, TotalSpeedTemp;
    public static bool isOnLocation_3;
    public static bool isServeWell_3;
    public static bool isMovingRigh_3 = false;
    float stepGoingBack,step;
	void Start(){
		isOnLocation_3 = false;
		isServeWell_3 = false;
		isCharacterReset_3 = false;
		isMovingRigh_3 = false;

    	imgItem.rectTransform.sizeDelta = new Vector2(0, 0f);
    	transform.position = new Vector2(target_Start.position.x, target_Start.position.y);
    	// LocationReset = GameObject.Find("LocationReset").transform;

    	
    	// print("TotalSpeed "+ TotalSpeed);
    }

	void Update() {
		if(GameController.timeleftCounter <= 90 && GameController.timeleftCounter >= 60){
			speed = 60 * 2;
		}else if(GameController.timeleftCounter <= 60 && GameController.timeleftCounter >= 30){
			speed = 60 * 3;
		}else if(GameController.timeleftCounter <= 30){
			speed = 60 * 4;
		}

		TotalSpeed = (Screen.width / 200.0f) * speed;
		TotalSpeedTemp = TotalSpeed;

        if(GameController.isGamePause == false){
            if(isMovingRigh_3 == true){
            	TotalSpeed =  TotalSpeedTemp; //(GameController.ScoreCount * 10) +
                step = TotalSpeed * Time.deltaTime;
                stepGoingBack = TotalSpeedTemp * Time.deltaTime;
      
            }
            if(transform.position == target.position && isServeWell_3 == false){
                if(isOnLocation_3 == false){
                    GameController.isCharacterOn_3Postion = true;
                }
                isOnLocation_3 = true;
            }else{
                isOnLocation_3 = false;
            }

            if(isCharacterReset_3 == true){
                isCharacterReset_3 = false;
                transform.position = new Vector2(target_Start.position.x, target_Start.position.y);
                // Destroy(gameObject);
            }

            if(isServeWell_3 == true){
                transform.position = Vector3.MoveTowards(transform.position, target_Start.position, stepGoingBack);
            }else{
                if(isMovingRigh_3 == true){
                    transform.position = Vector3.MoveTowards(transform.position, target.position, step);
                }
            }
        }
    }

}
