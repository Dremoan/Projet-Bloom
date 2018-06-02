using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using Cinemachine;

public class DetectionTimelineTuto: MonoBehaviour {


	public PlayableDirector timeline;
	public PlayerBehavior playerScript;
	public GameObject activationItem;
	private bool canPlayWaterSourceTimeline = true;
	public bool hasPlayedCinematic = false;
	public float timelineDuration;
	private float timeIncreasing = 0f;


	void Update () 
	{

		if(timeline.time > timelineDuration -0.05f && !hasPlayedCinematic)
		{
			hasPlayedCinematic = true;
			playerScript.cancelMoves = false;
			playerScript.EnableMovementsCave ();
		}

	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if(col.gameObject.tag == "Player")
		{
			playerScript.cancelMoves = true;
			timeline.Play ();
		}

		if(col.gameObject.tag == "Player")
		{
			playerScript.cancelMoves = true;
			timeline.Play ();
		}
	}
}
