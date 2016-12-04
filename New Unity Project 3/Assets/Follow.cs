using UnityEngine;
using System.Collections;


public class Follow : MonoBehaviour
{
	private NavMeshAgent agent;
	Animator anim;


	void Start()
	{
		agent = GetComponent<NavMeshAgent>();
		anim = GetComponent<Animator>();
		anim.SetBool ("isWalking", false);
	}

	void GotoNextPoint()
	{
		Debug.Log ("GoToNextPoint()");
		Vector3 playerPos = GameObject.FindGameObjectWithTag("Player").transform.position;
		while (Mathf.Abs(transform.position.x - playerPos.x) < 1.0 && Mathf.Abs(transform.position.x - playerPos.x) < 1) {
			agent.destination = playerPos;

		}
		playerPos = GameObject.FindGameObjectWithTag("Player").transform.position;
		
	}

	void Update()
	{
		
		if (Input.GetKeyDown(KeyCode.X))
		{
			anim.SetBool ("isWalking", true);

			GotoNextPoint();

		}
		anim.SetBool ("isWalking", false);
	}
}