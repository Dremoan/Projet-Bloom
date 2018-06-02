using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using Cinemachine;

public class DetectionTimeline : MonoBehaviour {


	public PlayableDirector timeline;
	public PlayerBehavior playerScript;
	public GameObject activationItem;
	private bool canPlayWaterSourceTimeline = true;
	private bool canPlayFlowerCinematic = true;
	private bool canPlayBlockingRockCinematic = true;
	public bool hasPlayedCinematic = false;
	public float timelineDuration;
	private float timeIncreasing = 0f;


	void Update () 
	{

		if(timeline.time > timelineDuration -0.05f && !hasPlayedCinematic)
		{
			hasPlayedCinematic = true;
			playerScript.cancelMoves = false;
			playerScript.EnableMovements ();
		}

	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if(col.gameObject.tag == "Player")
		{
			playerScript.cancelMoves = true;
			timeline.Play ();
		}

		if(col.gameObject.tag == "Player" && canPlayBlockingRockCinematic)
		{
			playerScript.cancelMoves = true;
			timeline.Play ();
		}
	}


//	public void RockSlotActive()
//	{
//		if(activationItem.GetComponent<ActivationRock>().isActive && canPlayWaterSourceTimeline)
//		{
//			canIncrease = true;
//			playerScript.cancelMoves = true;
//			timeline.Play ();
//			canPlayWaterSourceTimeline = false;
//		}
//	}

	public void DalleActive()
	{
		playerScript.cancelMoves = true;
		timeline.Play ();
	}



	public IEnumerator CancelMovements()
	{
		FindObjectOfType<PlayerBehavior> ().body.velocity = Vector2.zero;
		FindObjectOfType<PlayerBehavior> ().isMoving = false;
		FindObjectOfType<PlayerBehavior> ().canJump = false;
		FindObjectOfType<PlayerBehavior> ().canCharge = true;
		FindObjectOfType<PlayerBehavior> ().canMove = false;
		FindObjectOfType<PlayerBehavior> ().canLaunchAction = false;
		FindObjectOfType<LaunchFlower> ().canLaunch = false;
		yield return new WaitForSeconds (timelineDuration);
		FindObjectOfType<PlayerBehavior> ().canLaunchAction = true;
		FindObjectOfType<PlayerBehavior> ().canJump = true;
		FindObjectOfType<PlayerBehavior> ().canCharge = false;
		FindObjectOfType<PlayerBehavior> ().canMove = true;
		FindObjectOfType<LaunchFlower> ().canLaunch = true;
	}
	public IEnumerator CancelMovementsTuto()
	{
		Debug.Log ("coucou");
		FindObjectOfType<PlayerBehavior> ().body.velocity = Vector2.zero;
		FindObjectOfType<PlayerBehavior> ().isMoving = false;
		FindObjectOfType<PlayerBehavior> ().canJump = false;
		FindObjectOfType<PlayerBehavior> ().canCharge = true;
		FindObjectOfType<PlayerBehavior> ().canMove = false;
		FindObjectOfType<PlayerBehavior> ().canLaunchAction = false;
		//		FindObjectOfType<LaunchFlower> ().canLaunch = false;
		yield return new WaitForSeconds (timelineDuration);
		FindObjectOfType<PlayerBehavior> ().canLaunchAction = true;
		FindObjectOfType<PlayerBehavior> ().canJump = true;
		FindObjectOfType<PlayerBehavior> ().canCharge = false;
		FindObjectOfType<PlayerBehavior> ().canMove = true;
		//		FindObjectOfType<LaunchFlower> ().canLaunch = true;
	}
}
