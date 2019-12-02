using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterMovement2 : MonoBehaviour {

	public Transform target, target_Start;
	private Transform LocationReset;
	public Image imgItem;
    private float speed = 60;
    private float resize = 100;
    public static bool isCharacterReset_2 = false;
    private float TotalSpeed, TotalSpeedTemp;
    public static bool isOnLocation_2;
    public static bool isServeWell_2;
    public static bool isMovingRigh_2 = false;
    float stepGoingBack,step;
	void Start(){
		isOnLocation_2 = false;
		isServeWell_2 = false;
		isCharacterReset_2 = false;
		isMovingRigh_2 = false;

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
            if(isMovingRigh_2 == true){
            	TotalSpeed =  TotalSpeedTemp; //(GameController.ScoreCount * 10) +
                step = TotalSpeed * Time.deltaTime;
                stepGoingBack = TotalSpeedTemp * Time.deltaTime;
            }

            if(transform.position == target.position && isServeWell_2 == false){
                if(isOnLocation_2 == false){
                    GameController.isCharacterOn_2Postion = true;
                }
                isOnLocation_2 = true;
            }else{
                isOnLocation_2 = false;
            }

            if(isCharacterReset_2 == true){
                isCharacterReset_2 = false;
                transform.position = new Vector2(target_Start.position.x, target_Start.position.y);
                // Destroy(gameObject);
            }

            if(isServeWell_2 == true){
                transform.position = Vector3.MoveTowards(transform.position, target_Start.position, stepGoingBack);
            }else{
                if(isMovingRigh_2 == true){
                    transform.position = Vector3.MoveTowards(transform.position, target.position, step);
                }
            }
        }
    }

}
