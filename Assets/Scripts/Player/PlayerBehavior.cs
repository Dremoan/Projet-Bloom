﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour {

	public float speed = 100f;
	public float jumpSpeed = 10f;
	public float jumpTime = 0.5f;
	public float jumpCoolDown = 1f;
	public float actualSpeed;
	public float maxCibleDist = 20f;
	[HideInInspector] public bool canMove = true;
	 public bool canJump = true;
	[HideInInspector] public bool isJumping = false;
	[HideInInspector] public bool pressingA = false;
	[HideInInspector] public bool canCharge = false;
	[HideInInspector] public bool isAiming = false;
	[HideInInspector] public bool hasKey = false;
	[HideInInspector] public bool isMoving;
	[HideInInspector] public bool cancelMoves = false;
	public bool canLaunchAction = true;

	private bool holdsWater;

	public Transform player;
	public GameObject eau;
	public LaunchFlower Fleur;
	public Rigidbody2D body;
	public Vector2 move;
	public Vector3 eauPos;
	[HideInInspector] public Vector2 lastMove;

	private float idleCount = 0;
	private Animator anim;
	private Vector2 mousePos;

	void Start () 
	{
		anim = GetComponent<Animator> ();
	}

	void Update () 
	{
		if(cancelMoves)
		{
			CancelMovements ();
		}

		mousePos = Camera.main.ScreenToWorldPoint (Input.mousePosition) - transform.position;

		if (canJump && canMove) 
		{
			Move ();
		}


		if (Input.GetKeyDown (KeyCode.A)) 
		{
			pressingA = true;
		}
		if (Input.GetKeyUp (KeyCode.A)) 
		{
			pressingA = false;
		}

		if (Input.GetKeyDown (KeyCode.Space) && canJump == true && !isJumping && !canCharge) 
		{
			isJumping = true;
			canCharge = true;
			StartCoroutine (DashingDelay ());
		}
		if(FindObjectOfType<LaunchFlower>().gameObject.activeInHierarchy && canLaunchAction)
		{
			LaunchActionIdle ();
		}
		aimWater ();

		float horizontal = Input.GetAxisRaw ("Horizontal");
		float vertical = Input.GetAxisRaw ("Vertical");
		anim.SetBool ("isMoving", isMoving);
		anim.SetBool ("isJumping", isJumping);
		anim.SetFloat ("Horizontal", horizontal);
		anim.SetFloat ("Vertical", vertical);
		anim.SetFloat ("LastMoveX", lastMove.x);
		anim.SetFloat ("LastMoveY", lastMove.y);
	}
		
	IEnumerator DashingDelay()
	{
		FMODUnity.RuntimeManager.PlayOneShot("event:/CACTUS_DASH");
		canJump = false;
		body.velocity = Vector2.zero;
		body.velocity = lastMove.normalized * jumpSpeed * Time.fixedDeltaTime;
		yield return new WaitForSeconds (jumpTime);
		isJumping = false;
		canJump = true;
		canCharge = false;
	}
		

	void aimWater()
	{
		if (Input.GetKey (KeyCode.A) && Fleur.holdsWater)
		{
			body.velocity = move.normalized * actualSpeed * 20 * Time.deltaTime;
			eauPos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			eauPos.z = 0;
			if(Vector3.Distance(transform.position, eauPos) > maxCibleDist) 
			{
				eauPos = transform.position + ((eauPos - transform.position).normalized * maxCibleDist);
			}
			eau.transform.position = eauPos;
			eau.SetActive (true);
			if(Input.GetMouseButtonDown(1))
			{
                FMODUnity.RuntimeManager.PlayOneShot("event:/JET_BULLE");
				DropManagerComponent.SpawnDropWater (Fleur.transform.position, Mathf.Atan2 (mousePos.y, mousePos.x) * Mathf.Rad2Deg, eauPos);
				Fleur.holdsWater = false;
			}
		}
		if (Input.GetKeyUp (KeyCode.A)) 
		{
			eau.SetActive (false);
			isAiming = false;
		}
	}

	void Move()
	{
		isMoving = false;
		float horizontal = Input.GetAxisRaw ("Horizontal");
		float vertical = Input.GetAxisRaw ("Vertical");
		if(horizontal > 0.1f || horizontal < -0.1f)
		{
			isMoving = true;
			lastMove = new Vector2(horizontal, vertical);
		}
		if(vertical > 0.1f || vertical < -0.1f)
		{
			isMoving = true;
			lastMove = new Vector2(horizontal, vertical);
		}

		move = new Vector2(horizontal, vertical);
		actualSpeed = speed;
		body.velocity = move.normalized * actualSpeed;
	}

	public void CancelMovements()
	{
		Fleur.GetComponent<LaunchFlower> ().canLaunch = false;
		canLaunchAction = false;
		body.velocity = Vector2.zero;
		isMoving = false;
		canJump = false;
		canMove = false;
		canCharge = true;
	}

	public void CancelMovementsAfricanus()
	{
		canLaunchAction = false;
		isMoving = false;
		canJump = false;
		canMove = false;
		canCharge = true;
	}

	public void EnableMovements()
	{
		Fleur.GetComponent<LaunchFlower> ().canLaunch = true;
		canLaunchAction = true;
		canCharge = false;
		canJump = true;
		canMove = true;
	}
	public void EnableMovementsCave()
	{
		canJump = true;
		canMove = true;
		canCharge = false;
	}

	void LaunchActionIdle()
	{
		if(!isMoving)
		{
			idleCount += Time.deltaTime;
		}
		if(isMoving)
		{
			idleCount = 0;
		}
		if(idleCount > 2.75f)
		{
			anim.Play ("PlayerActionIdle");
			Fleur.GetComponent<Animator> ().Play ("FlowerActionIdle");
			idleCount = -2f;
		}
	}



}
