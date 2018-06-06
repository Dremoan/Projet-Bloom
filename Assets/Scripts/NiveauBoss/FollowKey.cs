using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowKey : MonoBehaviour {

	private Vector3 moveDirection;
	public Rigidbody2D bodyKey;
	public GameObject player;
	public float distToPlayer;
	public int moveSpeed = 100;

	void Update () 
	{
		moveDirection = player.transform.position - transform.position;
		if(distToPlayer < moveDirection.magnitude)
		{
			Move ();
		}

		if(distToPlayer > moveDirection.magnitude)
		{
			StopMove ();
		}
	}

	void Move()
	{		
		bodyKey.velocity = moveDirection.normalized * moveSpeed * Time.fixedDeltaTime;
	}

	void StopMove()
	{
		bodyKey.velocity = bodyKey.velocity * 0.9f;
		if(bodyKey.velocity.magnitude < 10f)
		{
			bodyKey.velocity = Vector3.zero;
		}
	}

}
