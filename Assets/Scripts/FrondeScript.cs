using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrondeScript : MonoBehaviour {

	public LaunchFlower flowerScript;
	public PlayerBehavior playerScript;
	public Animator animBoss;
	public PolygonCollider2D colliderRock;
	public GameObject hookedRock;
	private Vector2 dirToPlayer;
	private Vector2 dirRockToBoss;
	public float launchSpeed = 200f;
	public float colliderEnableTime;
	[HideInInspector] public bool isDead;



	void Update () 
	{
		Debug.Log (dirRockToBoss.magnitude);
		if(flowerScript.onLaunchingRock)
		{
			if(Input.GetMouseButton(1))
			{
				playerScript.CancelMovements ();
			}
			if(Input.GetMouseButtonUp(1))
			{
				playerScript.EnableMovements ();
				dirToPlayer = playerScript.transform.position - hookedRock.transform.position;
				hookedRock.GetComponent<Rigidbody2D> ().mass = 1;
				StartCoroutine (LaunchRock ());
			}
		}
	}


	IEnumerator LaunchRock()
	{
		dirRockToBoss = transform.position - hookedRock.transform.position;
		hookedRock.GetComponent<SpriteRenderer> ().sortingOrder += 8;
		flowerScript.isHooked = false;
		flowerScript.isBacking = true;
		colliderEnableTime = dirRockToBoss.magnitude/500;
		hookedRock.GetComponent<Rigidbody2D> ().AddForce (dirToPlayer.normalized * launchSpeed, ForceMode2D.Impulse);
		colliderRock.enabled = false;
		yield return new WaitForSeconds (colliderEnableTime);
		colliderRock.enabled = true;
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if(col.gameObject.tag == "RockToLaunch")
		{
			GetComponent<RockBoss> ().enabled = false;
			animBoss.SetBool ("LaunchingRock", false);
			animBoss.SetBool ("IsHit", true); 
			col.gameObject.SetActive (false);
			StartCoroutine (DelayAnimDeath ());
		}
	}

	IEnumerator DelayAnimDeath()
	{
		yield return new WaitForSeconds (0.8f);
		animBoss.Play ("MiniBossDeath");
		yield return new WaitForSeconds (2f);
		isDead = true;
		FindObjectOfType<RockBoss> ().instructionsDialogue.SetActive (false);

	}

}
