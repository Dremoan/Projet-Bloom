using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EjectingShockWave : MonoBehaviour {

	public Animator animPlayer;
	public Animator animCanvas;
	private Vector2 dirFrogToPlayer;
	public Transform player;
	public Rigidbody2D playerBody;
	public Transform frog;
	public SpriteRenderer flowerSprite;
	public float ejectForce;

	void Update () 
	{
		dirFrogToPlayer = player.transform.position - frog.transform.position;


	}
	void OnTriggerEnter2D(Collider2D coll)
	{
		if(coll.gameObject.tag =="Player")
		{
			StartCoroutine (EjectingPlayer ());

		}
	}
//	void OnTriggerStay2D(Collider2D coll)
//	{
//		if(coll.gameObject.tag == "Player")
//		{
//			flowerSprite.enabled = false;
//			player.GetComponent<PlayerBehavior> ().cancelMoves = true;
//			playerBody.velocity = Vector2.zero;
//			playerBody.AddForce (dirFrogToPlayer.normalized * ejectForce * Time.fixedDeltaTime, ForceMode2D.Impulse);
//			animPlayer.Play ("EjectingCactus");
//		}
//	}


	IEnumerator EjectingPlayer()
	{
		flowerSprite.enabled = false;
		player.GetComponent<PlayerBehavior> ().CancelMovements ();
		playerBody.velocity = Vector2.zero;
		playerBody.AddForce (dirFrogToPlayer.normalized * ejectForce * Time.fixedDeltaTime, ForceMode2D.Impulse);
		animPlayer.Play ("CactusEjecting");
		yield return new WaitForSeconds (1f);
		animCanvas.Play ("EjectPlayerBlackScreen");
	}
}
