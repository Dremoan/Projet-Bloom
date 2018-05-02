using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingThru : MonoBehaviour {


	public GameObject player;
	private bool touchedPlayer;

	void Update () 
	{
		if(player.GetComponent<PlayerBehavior>().isJumping)
		{
			StartCoroutine (InactiveCollider ());
		}
		if(player.GetComponent<PlayerBehavior>().isJumping && touchedPlayer)
		{
			StartCoroutine (InactiveCollider ());
		}
	}

	IEnumerator InactiveCollider()
	{
		Physics2D.IgnoreCollision (player.GetComponent<Collider2D> (), this.GetComponent<Collider2D> (), ignore:true);
		yield return new WaitForSeconds (0.5f);
		Physics2D.IgnoreCollision (player.GetComponent<Collider2D> (), this.GetComponent<Collider2D> (), ignore:false);
	}

	void OnCollisionEnter2D(Collision2D coll)
	{
		touchedPlayer = true;
	}
	void OnCollisionExit2D(Collision2D coll)
	{
		touchedPlayer = false;
	}
}
