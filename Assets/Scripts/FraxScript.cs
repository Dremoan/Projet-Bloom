using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FraxScript : MonoBehaviour
{
	public GameObject player;
	public Animator animFrax;
	public BoxCollider2D boxColl;
	public CircleCollider2D circleColl;
	public GameObject fireParticles;
	public Rigidbody2D bodyFrax;
	public float moveSpeed;
	public float speedOffset = 1000f;
	public float distToPlayer;
	public float animTime = 1f;
	[HideInInspector] public bool onFire;
	[HideInInspector] public bool canMove = true;
	[HideInInspector] public bool canSetFire = true;
	private Vector3 moveDirection;

	void Update ()
	{
		animFrax.SetFloat ("VelocityX", bodyFrax.velocity.x);
		animFrax.SetFloat ("VelocityY", bodyFrax.velocity.y);
		moveDirection = player.transform.position - transform.position;
		if(distToPlayer > moveDirection.magnitude && canMove)
		{
			Move ();
		}

		if(distToPlayer < moveDirection.magnitude)
		{
			StopMove ();
		}

		if(bodyFrax.velocity.x > 0.1f || bodyFrax.velocity.y > 0.1f || bodyFrax.velocity.x < -0.1f || bodyFrax.velocity.y < -0.1f)
		{
			animFrax.SetBool ("IsMoving", true);
		}
		else
		{
			animFrax.SetBool ("IsMoving", false);
		}
	}

	void Move()
	{
		Vector3 invertMove = - moveDirection;
		bodyFrax.velocity = invertMove.normalized * moveSpeed * Time.fixedDeltaTime;
	}

	void StopMove()
	{
		bodyFrax.velocity = bodyFrax.velocity * 0.9f;
		if(bodyFrax.velocity.magnitude < 10f)
		{
			bodyFrax.velocity = Vector3.zero;
		}
	}

	public IEnumerator OnFire()
	{
		if(canSetFire)
		{
			yield return new WaitForSeconds (0.75f);
			canMove = false;
			bodyFrax.velocity = Vector3.zero;
			animFrax.SetBool ("CanBurn", true);
			boxColl.enabled = false;
			circleColl.enabled = true;
			moveSpeed = moveSpeed + speedOffset;
			onFire = true;
			yield return new WaitForSeconds (animTime);
			fireParticles.SetActive (true);
			canMove = true;
			animFrax.SetBool ("GoToFireIdle", true);
		}
	}


}
