﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using Cinemachine;

public class DetectionTimeline : MonoBehaviour {


	public PlayableDirector timeline;
	public GameObject activationItem;
	private bool canPlayWaterSourceTimeline = true;
	private bool canPlayFlowerCinematic = true;
	private bool canPlayBlockingRockCinematic = true;
	public float timelineDuration;


	void Update () 
	{
		RockSlotActive ();
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if(col.gameObject.tag == "Player" && canPlayFlowerCinematic)
		{
			StartCoroutine (CancelMovements ());
			timeline.Play ();
			canPlayFlowerCinematic = false;
		}

		if(col.gameObject.tag == "Player" && canPlayBlockingRockCinematic)
		{
			StartCoroutine (CancelMovements ());
			timeline.Play ();
			canPlayBlockingRockCinematic = false;
		}
	}


	public void RockSlotActive()
	{
		if(activationItem.GetComponent<ActivationRock>().isActive && canPlayWaterSourceTimeline)
		{
			StartCoroutine (CancelMovements ());
			timeline.Play ();
			canPlayWaterSourceTimeline = false;
		}
	}



	IEnumerator CancelMovements()
	{
		FindObjectOfType<PlayerBehavior> ().body.velocity = Vector2.zero;
		FindObjectOfType<PlayerBehavior> ().isMoving = false;
		FindObjectOfType<PlayerBehavior> ().canJump = false;
		FindObjectOfType<PlayerBehavior> ().canMove = false;
		FindObjectOfType<PlayerBehavior> ().canLaunchAction = false;
//		FindObjectOfType<LaunchFlower> ().canLaunch = false;
		yield return new WaitForSeconds (timelineDuration);
		FindObjectOfType<PlayerBehavior> ().canLaunchAction = true;
		FindObjectOfType<PlayerBehavior> ().canJump = true;
		FindObjectOfType<PlayerBehavior> ().canMove = true;
//		FindObjectOfType<LaunchFlower> ().canLaunch = true;
	}
}
