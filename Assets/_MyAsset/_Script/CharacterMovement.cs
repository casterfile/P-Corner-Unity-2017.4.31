using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterMovement : MonoBehaviour {

	public Transform target, target_Start;
	private Transform LocationReset;
	public Image imgItem;
    private float speed = 60;
    private float resize = 100;
    private float TotalSpeed, TotalSpeedTemp;

	public static bool isCharacterReset_1 = false;
    public static bool isOnLocation_1;
    public static bool isServeWell_1;
    public static bool isMovingRigh_1 = false;
    float stepGoingBack,step;
	void Start(){
    	isOnLocation_1 = false;
		isServeWell_1 = false;
		isCharacterReset_1 = false;
		isMovingRigh_1 = false;

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
            if(isMovingRigh_1 == true){
                TotalSpeed =  TotalSpeedTemp; //(GameController.ScoreCount * 10) +
                step = TotalSpeed * Time.deltaTime;
                stepGoingBack = TotalSpeedTemp * Time.deltaTime;
                
            }

            if(transform.position == target.position && isServeWell_1 == false){
                if(isOnLocation_1 == false){
                    GameController.isCharacterOn_1Postion = true;
                }
                isOnLocation_1 = true;
            }else{
                isOnLocation_1 = false;
            }

            if(isCharacterReset_1 == true){
                isCharacterReset_1 = false;
                transform.position = new Vector2(target_Start.position.x, target_Start.position.y);
                // Destroy(gameObject);
            }

            if(isServeWell_1 == true){
                transform.position = Vector3.MoveTowards(transform.position, target_Start.position, stepGoingBack);
            }else{
                if(isMovingRigh_1 == true){
                    transform.position = Vector3.MoveTowards(transform.position, target.position, step);
                }
            }
        }
        
    }

}
