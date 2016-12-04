using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	Food food;
	public GameObject myPreFab;
	public GameObject ballPreFab;
	GameObject go;
	Rigidbody rigidbody;
	static GameObject ball;
	Rigidbody rgBall;
	public GameObject dog;
	//static bool isCaught;

	// Use this for initialization
	void Start () {
	
		Doggo.setTarget (this.transform);
		food = new Food ();
		go = new GameObject ();
		rigidbody = new Rigidbody ();
		ball = new GameObject ();
		rgBall = new Rigidbody ();
		//isCaught = false;
	

	}

	// Update is called once per frame
	 void Update () {



		if (Input.GetKeyDown (KeyCode.C)) {
			//Instantiate (food.gameObject, transform.position + transform.forward * 2, transform.rotation);
			go = (GameObject)Instantiate (myPreFab, transform.position + transform.forward * 2, new Quaternion (-89.981f, 0, 0, 89.981f));
			rigidbody = go.AddComponent <Rigidbody> ();
			rigidbody.mass = 5;

		}
			

		try {
			if (go.transform.position.y < 0.3) {
				Destroy (rigidbody);
			}
		} catch (System.Exception e) {
		}


		if (Input.GetKeyDown (KeyCode.V)) {
			ball = (GameObject)Instantiate (ballPreFab, transform.position + transform.forward * 2, new Quaternion (0, 0, 0, 0));
			rgBall = go.AddComponent <Rigidbody> ();
			//rgBall.mass = 5;
			Doggo.setInput ("BALL");
			Doggo.setTarget (ball.transform);
			//isCaught = false;
		} else {
			//if (isCaught == false) {
			ball.transform.forward = this.transform.forward;
			ball.transform.rotation = new Quaternion (0, ball.transform.rotation.y, 0, ball.transform.rotation.w);
			for (int x = 0; x < 3; x++) {
				//ball.transform.position += new Vector3 (ball.transform.forward.x / 10, -ball.transform.forward.y, ball.transform.forward.z / 10);
				ball.transform.position += new Vector3 (ball.transform.forward.x / 16, -ball.transform.forward.y, ball.transform.forward.z / 16);
				Doggo.setBalCoords (ball.transform.position.x, ball.transform.position.y, ball.transform.position.z);
			}
			//}
		}
			
		if (Input.GetKeyDown (KeyCode.V)) {
			Doggo.setTarget (ball.transform);
			Doggo.setInput ("BALL");
		}

		if (Input.GetKeyDown (KeyCode.M)) {
			try {
				Doggo.setInput ("FOOD");
				Doggo.setTarget (go.transform);
			} catch (System.Exception e) {
			}
		}

		if (Input.GetKeyDown (KeyCode.Z) || Input.GetKeyDown (KeyCode.X)) {
			Doggo.setTarget (this.transform);
			Doggo.setInput ("PLAYER");
		}
	
	}

	public static GameObject getBall(){

		return ball;
	}
		


}
