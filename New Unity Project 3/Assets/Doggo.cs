using UnityEngine;
using System.Collections;

public class Doggo : MonoBehaviour {

	Animator anim;
	bool isWalking;
	bool isSitting;
	bool isEating;
	bool isFollowing;
	//bool isFreeRoaming;
	double proximity;
	static Transform target;
	static string input;
	//private NavMeshAgent agent;
	RaycastHit hit;
	//public GameObject ball;
	static Vector3 ballCoords;
	Player player = new Player();


	// Use this for initialization
	void Start () {

		anim = GetComponent<Animator>();
		isWalking = false;
		isSitting = false;
		isEating = false;
		isFollowing = false;
		proximity = 2.5;
		//isFreeRoaming = true;
		input = "PLAYER";
		//agent = GetComponent<NavMeshAgent>();
		ballCoords = new Vector3(0.0f,0.0f,0.0f);


	}

	public static void setBalCoords(float x, float y, float z){

		ballCoords = new Vector3 (x, y, z);

	}

	// Update is called once per frame
	void Update () {
		
		FaceTarget ();


	//	if (input.Equals ("BALL")) {
	//		if (Mathf.Abs (ball.transform.position.x - this.transform.position.x) < 2 &&
	//		    Mathf.Abs (ball.transform.position.y - this.transform.position.y) < 2 &&
	//		    Mathf.Abs (ball.transform.position.z - this.transform.position.z) < 2) {
	//			ball.gameObject.GetComponent<Renderer> ().enabled = false;
	//		}
	//		isWalking = true;
	//	}


		if (input.Equals ("PLAYER")) {
			proximity = 3.0;
		} else if (input.Equals ("FOOD")) {
			proximity = 1.6;
		}

		if (input.Equals ("PLAYER")) {
			isEating = false;
		}

		if (Input.GetKeyDown (KeyCode.X)) {
			if (isWalking == true) {
				isWalking = false;
				isFollowing = false;
			} else if (isWalking == false) {
				isWalking = true;
			} 
		}

		if (input.Equals ("FOOD") && isEating == false) {
			isWalking = true;
		}

		//makes the dog stop once u stop and it walks to you
		if (Mathf.Abs (transform.position.x - target.position.x) < proximity && 
			Mathf.Abs (transform.position.z - target.position.z) < proximity 
			&& (input.Equals("FOOD") || input.Equals("PLAYER"))) {
				isWalking = false;
				if (input.Equals ("FOOD")) {
					isEating = true;
					isFollowing = false;
				} else {
					isEating = false;
					isFollowing = true;
				}
				anim.SetBool ("isEating", isEating);
			}

		if (isFollowing) {
			if (Input.GetKeyDown (KeyCode.A) || Input.GetKeyDown (KeyCode.W) ||
			   Input.GetKeyDown (KeyCode.S) || Input.GetKeyDown (KeyCode.D) ||
				input.Equals("BALL")) {
				isWalking = true;
				Walk ();
			}
		}
			


		if (Input.GetKeyDown (KeyCode.Z)) {
			isWalking = false;
			isFollowing = false;
			if (isSitting == false) {
				isSitting = true; //sits if its not walking nd u press z
			} else if (isSitting == true) {
				isSitting = false; //stands if its not walking nd press z
			}
		}

		if (isEating) {
			if (Input.GetKeyDown (KeyCode.X)) {
				isWalking = true;
			}

		}
			

		if (Input.GetKeyDown (KeyCode.V)) {

			isWalking = true;
			isSitting = false;
			isEating = false;

		}

		if (input.Equals ("BALL")) {
			if (Mathf.Abs (this.transform.position.x - ballCoords.x) < 2.2f &&
			    Mathf.Abs (this.transform.position.y - ballCoords.y) < 4.2f &&
			    Mathf.Abs (this.transform.position.z - ballCoords.z) < 2.2f) {
				isWalking = false;
				//Destroy (Player.getBall ());
				//input = "TEMP";
				//Player.setIsCaught (true);
			} //else {
				//isWalking = true;
			//	Walk ();
			//}
		}


			


		if (isSitting) {
			isWalking = false;
			isFollowing = false;
			isEating = false;
			setBooleans ();
		}
		if (Input.GetKeyDown (KeyCode.X))
			isWalking = true;

		//if walking, then its not sitting
		if (isWalking) {
			isSitting = false;
			isEating = false;
			setBooleans ();
			Walk ();

		}



		setBooleans ();


	
	}



	public void setBooleans(){
		anim.SetBool ("isWalking", isWalking); //is walking animation
		anim.SetBool ("isSitting", isSitting); //sitting animation
		anim.SetBool("isEating", isEating); //eating animation
	}

		


	public static void setTarget(Transform trns){
		target = trns;
	}

	public static void setInput(string str){
		input = str;
	}

	private void FaceTarget(){
		
		Vector3 relativePos = target.position - transform.position;
		Quaternion rotation = Quaternion.LookRotation(relativePos);
		transform.rotation = new Quaternion(0, rotation.y, 0, rotation.w);

	}
		

	private void Walk(){

		for (int speed = 0; speed < 2; speed++) {
			transform.position += new Vector3 (transform.forward.x / 7.5f, 0, transform.forward.z / 7.5f);
		}


	}
		
		

}
