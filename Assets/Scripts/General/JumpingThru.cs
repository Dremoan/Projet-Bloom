using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingThru : MonoBehaviour {


	public GameObject player;
	public Collider2D obstacleCollider;
	private bool touchedPlayer;
	public float ignoreTime = 0.5f;

	void Update () 
	{
		if(player.GetComponent<PlayerBehavior>().isJumping)
		{
			obstacleCollider.enabled = false;
			StartCoroutine (InactiveCollider ());
		}
		if (player.GetComponent<PlayerBehavior> ().isJumping == false) 
		{
			obstacleCollider.enabled = true;
		}
		if(player.GetComponent<PlayerBehavior>().isJumping && touchedPlayer)
		{
			StartCoroutine (InactiveCollider ());
		}
	}

	IEnumerator InactiveCollider()
	{
		Physics2D.IgnoreCollision (player.GetComponent<Collider2D> (), this.GetComponent<Collider2D> (), ignore:true);
		yield return new WaitForSeconds (ignoreTime);
		Physics2D.IgnoreCollision (player.GetComponent<Collider2D> (), this.GetComponent<Collider2D> (), ignore:false);
	}

	void OnCollisionEnter2D(Collision2D coll)
	{
		touchedPlayer = true;
	}
	void OnCollisionStay2D(Collision2D coll)
	{
		touchedPlayer = true;
	}
	void OnCollisionExit2D(Collision2D coll)
	{
		touchedPlayer = false;
	}
}
