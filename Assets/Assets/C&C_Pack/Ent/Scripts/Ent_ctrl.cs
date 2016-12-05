using UnityEngine;
using System.Collections;

public class Ent_ctrl : MonoBehaviour {
	
	
	private Animator anim;
	private CharacterController controller;
	private bool battle_state;
	public float speed = 6.0f;
	public float runSpeed = 1.7f;
	public float turnSpeed = 60.0f;
	public float gravity = 20.0f;
	private Vector3 moveDirection = Vector3.zero;

	private DistanceSearch dist;
	
	
	// Use this for initialization
	void Start () {
		dist = GetComponent<DistanceSearch> ();
		anim = GetComponent<Animator>();
		controller = GetComponent<CharacterController> ();
		anim.SetInteger ("moving", 1);
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		
		if (dist.SearchedFlag) {
			anim.SetInteger ("moving", 0);
			anim.SetInteger ("battle", 1);
			battle_state = true;
		} else {
			anim.SetInteger ("battle", 0);
			anim.SetInteger ("moving", 1);
		}
//		if (Input.GetKey("2")) //idle
//		{
//			anim.SetInteger("battle", 1);
//			battle_state = true;
//			
//		}
		if (Input.GetKey("1")) 			//battle_state
		{
			anim.SetInteger("battle", 0);
			battle_state = false;
		}
		if (Input.GetKey ("up")) {		 //moving
			if (battle_state == false)
			{
				anim.SetInteger ("moving", 1);//walk
				runSpeed = 1.0f;
			} else 
			{
				anim.SetInteger ("moving", 2);//run
				runSpeed = 2.6f;
			}
			
			
		} 
//		else {
//			anim.SetInteger ("moving", 0);
//		}
		
		if (Input.GetKeyDown("o")) // die1
		{
			anim.SetInteger("moving", 13);
		}
		if (Input.GetKeyDown("i")) // die2
		{
			anim.SetInteger("moving", 14);
		}
		
		if (Input.GetKeyDown("u")) // hit
		{
			int n = Random.Range(0,2);
			if (n == 0) {
				anim.SetInteger("moving", 9);
			} else {anim.SetInteger("moving", 10);}
		}
		
		
		
		if (Input.GetKeyDown("p")) // defence_start
		{
			anim.SetInteger("moving", 11);
		}
		if (Input.GetKeyUp("p")) // defence_end
		{
			anim.SetInteger("moving", 12);
		} 

		if (Input.GetKeyDown("l")) // STOMP
		{
			anim.SetInteger("moving", 6);
		}

		if (Input.GetKeyDown("j")) // cast1
		{
			anim.SetInteger("moving", 7);
		}
		if (Input.GetKeyDown("k")) // cast2
		{
			anim.SetInteger("moving", 8);
		}


		
		
		

			if (Input.GetMouseButtonDown (0)) // attack1
			{
				anim.SetInteger("moving", 3);
			}
			if (Input.GetMouseButtonDown (1)) // attack2
			{
				anim.SetInteger("moving", 4);
			}
			if (Input.GetMouseButtonDown (2)) //power atack
			{
				anim.SetInteger("moving", 5);
			}
			


		
		
		if (anim.GetInteger ("moving") == 1) {
			if(controller.isGrounded)
			{
				moveDirection=transform.forward * speed * runSpeed;

			}
			float turn = Input.GetAxis("Horizontal");
			transform.Rotate(0, turn * turnSpeed * Time.deltaTime, 0);
			controller.Move(moveDirection * Time.deltaTime);
			moveDirection.y -= gravity * Time.deltaTime;
		}

		
		
		
	}
}

