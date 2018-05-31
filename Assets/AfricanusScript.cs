using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AfricanusScript : MonoBehaviour {

	public GameObject player;
	public GameObject africanusAltPos;
	public PlayerBehavior playerScript;
	public SpriteRenderer flower;
	public SpriteRenderer shadow;
	public Image barFilling;
	public Animator animAfricanus;
	private bool touchedPlayer;
	private bool canSpam;
	private bool hasGrab;
	private bool swallowing;
	private bool canDecrease;
	private float numberForSpam = 3;
	private float countTillDecrease;
	public float maxCountDecrease = 2f;


	void Update () 
	{
		barFilling.fillAmount = numberForSpam * 0.1f;
		animAfricanus.SetBool ("HasGrab", hasGrab);
		animAfricanus.SetBool ("Swallowing", swallowing);
		if(touchedPlayer)
		{
			GrabPlayer ();
		}

		if(playerScript.pressingA == false && canDecrease)
		{
			CounterIncreasing ();
		}
		if(canSpam)
		{
			Spam();
		}

		if(countTillDecrease > maxCountDecrease)
		{
			CounterDecreasing ();
		}

		if(numberForSpam < 0f)
		{
			
		}

		if(numberForSpam == 10f)
		{
			animAfricanus.SetBool ("Spit", true);
		}
	}

	void OnTriggerEnter2D(Collider2D coll)
	{
		if(coll.gameObject.tag =="Player")
		{
			canDecrease = true;
			touchedPlayer = true;
			hasGrab = true;
		}
	}
		
	void GrabPlayer()
	{
		barFilling.gameObject.SetActive (true);
		player.GetComponent<SpriteRenderer> ().enabled = false;
		shadow.enabled = false;
		flower.enabled = false;
		touchedPlayer = false;
		playerScript.CancelMovements ();
		player.GetComponent<Rigidbody2D> ().velocity = Vector3.zero;
		player.transform.position = transform.position;
		canSpam = true;
	}

	void Spam()
	{
		if(playerScript.pressingA)
		{
			canSpam = false;
			numberForSpam = numberForSpam + 1f;
			countTillDecrease = 0f;
		}
	}

	void CounterIncreasing()
	{
		canSpam = true;
		countTillDecrease += Time.deltaTime;
	}

	void CounterDecreasing()
	{
		countTillDecrease = 0f;
		numberForSpam = numberForSpam - 1f;
	}

	void ReleasingPlayer()
	{
		
		barFilling.gameObject.SetActive (false);
		canDecrease = false;
		hasGrab = false;
		countTillDecrease = 0f;
		canSpam = false;
		numberForSpam = 3f;
		player.GetComponent<Rigidbody2D> ().transform.Translate (50f, 0, 0);
		player.GetComponent<SpriteRenderer> ().enabled = true;
		shadow.enabled = true;
		flower.enabled = true;
		playerScript.EnableMovements ();
		ChangeAnim ();
	}

	void SpawnOtherAfricanus()
	{
		if(!hasGrab)
		{
			this.gameObject.SetActive (false);
			africanusAltPos.SetActive (true);
		}
	}

	void ChangeAnim()
	{
		animAfricanus.SetBool ("ReturnGround", true);
	}


}
