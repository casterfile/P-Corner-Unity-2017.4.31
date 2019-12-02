using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalVarReset : MonoBehaviour {
	// Use this for initialization
	void Start () {
		ResetDataGlobal ();

	}



	public static void ResetDataGlobal(){
		GameController.isCharacterOn_1Postion = false;
		GameController.isCharacterOn_2Postion = false;
		GameController.isCharacterOn_3Postion = false;
		GameController.EnemeySequences = 1;
		GameController.isGamePause = false;
		GameController.ScoreCount = 0;


		CharacterMovement.isOnLocation_1 = false;
		CharacterMovement.isServeWell_1 = false;
		CharacterMovement.isCharacterReset_1 = false;
		CharacterMovement.isMovingRigh_1 = false;


		CharacterMovement2.isOnLocation_2 = false;
		CharacterMovement2.isServeWell_2 = false;
		CharacterMovement2.isCharacterReset_2 = false;
		CharacterMovement2.isMovingRigh_2 = false;



		CharacterMovement3.isOnLocation_3 = false;
		CharacterMovement3.isServeWell_3 = false;
		CharacterMovement3.isCharacterReset_3 = false;
		CharacterMovement3.isMovingRigh_3 = false;

	}
}
