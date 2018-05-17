using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrondeScript : MonoBehaviour {

	public LaunchFlower flowerScript;
	public PlayerBehavior playerScript;
	public Animator animBoss;
	public PolygonCollider2D colliderRock;
	private GameObject hookedRock;
	private Vector2 dirToPlayer;
	public float launchSpeed = 200f;
	public float timeToLaunch;
	private float timeToIncrease;
	private bool canLaunch = true;



	void Update () 
	{
		if(flowerScript.onLaunchingRock)
		{
			if(Input.GetMouseButton(1))
			{
				playerScript.CancelMovements ();
			}
			if(Input.GetMouseButtonUp(1))
			{
				playerScript.EnableMovements ();
				dirToPlayer = playerScript.transform.position - this.transform.position;
				this.GetComponent<Rigidbody2D> ().mass = 1;
				StartCoroutine (LaunchRock ());
			}
		}
	}

	void OnTriggerEnter2D(Collider2D coll)
	{
		if (coll.gameObject.tag == "Flower")
		{
			Debug.Log ("yo");
			hookedRock = coll.gameObject;
		}
	}

	IEnumerator LaunchRock()
	{
		flowerScript.isHooked = false;
		flowerScript.isBacking = true;
		canLaunch = false;
		hookedRock.GetComponent<Rigidbody2D> ().AddForce (dirToPlayer.normalized * launchSpeed, ForceMode2D.Impulse);
		colliderRock.enabled = false;
		yield return new WaitForSeconds (0.5f);
		colliderRock.enabled = true;
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if(col.gameObject.tag == "Bigorpion")
		{
			this.gameObject.SetActive (false);
			animBoss.Play ("MiniBossHit");
		}
	}

	IEnumerator DelayAnimDeath()
	{
		yield return new WaitForSeconds (0.8f);
		animBoss.Play ("MiniBossDeath");
	}

}
