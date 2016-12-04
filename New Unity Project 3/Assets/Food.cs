using UnityEngine;
using System.Collections;

public class Food : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if(Input.GetKeyDown(KeyCode.M)){
			Doggo.setTarget (this.transform);
			Doggo.setInput ("FOOD");
		}


	
	}
}
