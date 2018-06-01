using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AfricanusScript : MonoBehaviour {

	public Transform mouthPlace;
	public Transform initialPos;
	public Transform africanusReload;

	public GameObject player;
	public GameObject africanusAltPos;

	public PlayerBehavior playerScript;

	public SpriteRenderer flower;
	public SpriteRenderer shadow;

	public Image barFilling;

	public Animator animAfricanus;
	public Animator animBlackScreen;

	private Vector2 dirToFlower;

	private bool touchedPlayer;
	private bool hasGrab;
	private bool canSpam;
	private bool canDecrease;
	private bool attractFlower;

	private float numberForSpam = 3;
	private float countTillDecrease;

	[HideInInspector] public bool touchedFlower;
	[HideInInspector] public bool swallowing;
	[HideInInspector] public bool canSpit;

	public float maxCountDecrease = 2f;
	public float speedAttraction = 50f;


	void Update () 
	{
		Debug.Log (touchedFlower);
		dirToFlower = flower.transform.position - player.transform.position;
		barFilling.fillAmount = numberForSpam * 0.1f;
		animAfricanus.SetBool ("HasGrab", hasGrab);
		animAfricanus.SetBool ("Swallowing", swallowing);
		animAfricanus.SetBool ("Spit", canSpit);

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
			NotSpammedEnough ();
		}

		if(numberForSpam > 10f)
		{
			SpammedEnough ();
		}

		if(touchedFlower)
		{
			AttractFlowerTrue ();
		}
		if(attractFlower)
		{
			AttractFlower ();
		}
	}

	void OnTriggerEnter2D(Collider2D coll)
	{
		if(coll.gameObject.tag == "Player")
		{
			canDecrease = true;
			touchedPlayer = true;
			hasGrab = true;
		}
		if(coll.gameObject.tag == "Flower")
		{
			swallowing = true;
			flower.enabled = false;
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
		player.transform.position = mouthPlace.position;
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
		canSpit = false;
		swallowing = false;
		player.transform.position = transform.position;
		hasGrab = false;
		countTillDecrease = 0f;
		player.GetComponent<Rigidbody2D> ().transform.Translate (50f, 0, 0);
		player.GetComponent<SpriteRenderer> ().enabled = true;
		shadow.enabled = true;
		flower.enabled = true;
		playerScript.EnableMovements ();
		ChangeAnim ();
	}

	public IEnumerator SpawnOnOther()
	{
		if(touchedFlower)
		{
			attractFlower = false;
			player.transform.position = africanusAltPos.transform.position;
			this.gameObject.SetActive (false);
			swallowing = false;
			hasGrab = false;
			yield return new WaitForSeconds (1.5f);
			animBlackScreen.Play("EmptyingBlackScreen");
			africanusAltPos.SetActive (true);
			playerScript.CancelMovementsAfricanus ();
			africanusAltPos.GetComponent<Animator> ().Play ("AfricanusSpit");
			canSpit = false;
			FindObjectOfType<LaunchFlower> ().isHooked = false;
			FindObjectOfType<LaunchFlower> ().isBacking = true;
			touchedFlower = false;
		}
	}


	void AttractFlowerTrue()
	{
		attractFlower = true;
	}

	void AttractFlower()
	{
		playerScript.CancelMovementsAfricanus ();
		player.GetComponent<Rigidbody2D> ().velocity = dirToFlower.normalized * speedAttraction * Time.fixedDeltaTime;
		playerScript.isJumping = true;
			if(dirToFlower.magnitude < 5f)
				{
					player.GetComponent<Rigidbody2D> ().velocity = Vector3.zero;
					player.GetComponent<SpriteRenderer> ().enabled = false;
					shadow.enabled = false;
					playerScript.isJumping = false;
					canSpit = false;
					animBlackScreen.Play ("FillingBlackScreen");
				}
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

	void SetPos()
	{
		transform.position = initialPos.position;
	}


	void PlayBlackScreenFill()
	{
		if(!touchedFlower)
		{
			animBlackScreen.Play ("FillingBlackScreen");	
		}
	}

	public IEnumerator MovingAfricanus()
	{
		if(!touchedFlower)
		{
			transform.position = africanusReload.position;
			player.transform.position = transform.position;
			yield return new WaitForSeconds (1.5f);
			animBlackScreen.Play("EmptyingBlackScreen");
		}
	}

	void SpammedEnough()
	{
		barFilling.gameObject.SetActive (false);
		numberForSpam = 3f;
		canSpit = true;
		canDecrease = false;
	}

	void NotSpammedEnough()
	{
		barFilling.gameObject.SetActive (false);
		swallowing = true;
		numberForSpam = 3f;
		canDecrease = false;
	}
}
