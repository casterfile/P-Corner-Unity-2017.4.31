using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CheckLowestNumber : MonoBehaviour {
	List<float> list = new List<float>();
	int index;
	// Use this for initialization
	void Start () {
		 // list.Add(50);
	  //    list.Add(70);
	  //    list.Add(30);

	  //    index = list.IndexOf(list.Min());
	  //    Debug.Log("index : " + index);
	  //    print("Print low Value"+ list[index]);
	     
	  //    list.Remove(list[index]);


	  //    index = list.IndexOf(list.Min());
	  //    Debug.Log("index : " + index);
	  //    print("Print low Value"+ list[index]);

		usedValues.Add(UniqueRandomInt(1, 6));
		usedValues.Add(UniqueRandomInt(1, 6));
		usedValues.Add(UniqueRandomInt(1, 6));
		usedValues.Add(UniqueRandomInt(1, 6));
		usedValues.Add(UniqueRandomInt(1, 6));

		//UniqueRandomInt(1, 5);

		print("usedValues[0] "+ usedValues[0]);
		print("usedValues[1] "+ usedValues[1]);
		print("usedValues[2] "+ usedValues[2]);
		print("usedValues[3] "+ usedValues[3]);
		print("usedValues[4] "+ usedValues[4]);
	}

	 List<int> usedValues = new List<int>();
	 public int UniqueRandomInt(int min, int max)
	 {
	     int val = Random.Range(min, max);
	     while(usedValues.Contains(val))
	     {
	         val = Random.Range(min, max);
	     }
	     return val;
	 }
}
