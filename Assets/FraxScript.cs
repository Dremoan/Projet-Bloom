using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FraxScript : MonoBehaviour
{
	public GameObject player;
	public BoxCollider2D boxColl;
	public CircleCollider2D circleColl;
	public GameObject fireParticles;
	public Rigidbody2D bodyFrax;
	public float moveSpeed;
	public float speedOffset = 1000f;
	public float distToPlayer;
	[HideInInspector] public bool onFire;
	private Vector3 moveDirection;

	void Update ()
	{
		moveDirection = player.transform.position - transform.position;
		if(distToPlayer > moveDirection.magnitude)
		{
			Move ();
		}

		if(distToPlayer < moveDirection.magnitude)
		{
			StopMove ();
		}
	}

	void Move()
	{
		Vector3 invertMove = -moveDirection;
		bodyFrax.velocity = invertMove.normalized * moveSpeed * Time.fixedDeltaTime;
	}

	void StopMove()
	{
		bodyFrax.velocity = Vector3.zero;
	}

	public void OnFire()
	{
		fireParticles.SetActive (true);
		boxColl.enabled = false;
		circleColl.enabled = true;
		moveSpeed = moveSpeed + speedOffset;
		onFire = true;
	}
}
