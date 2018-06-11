using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using Cinemachine;

public class DetectionTimeline : MonoBehaviour {


	public PlayableDirector timeline;
	public PlayerBehavior playerScript;
	public bool hasPlayedCinematic = false;
	public bool onAwake;
	public float timelineDuration;
	private float timeIncreasing = 0f;


	void Update () 
	{
		if(onAwake)
		{
			playerScript.cancelMoves = true;
			timeline.Play ();
		}
		if(hasPlayedCinematic)
		{
			if(this.GetComponent<Collider2D>() != null)
			{
				this.GetComponent<Collider2D> ().enabled = false;		
			}
		}
		if(timeline.time > timelineDuration -0.05f && !hasPlayedCinematic)
		{
			hasPlayedCinematic = true;
			playerScript.cancelMoves = false;
			playerScript.EnableMovements ();
			onAwake = false;
		}

	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if(col.gameObject.tag == "Player")
		{
			playerScript.cancelMoves = true;
			timeline.Play ();
		}
	}


	public void DoorActive()
	{
		playerScript.cancelMoves = true;
		timeline.Play ();
	}
	public void DalleActive()
	{
		playerScript.cancelMoves = true;
		timeline.Play ();
	}

	public void RockSlotActive()
	{
		playerScript.cancelMoves = true;
		timeline.Play ();
	}

	public void EmptyBassinActive()
	{
		playerScript.cancelMoves = true;
		timeline.Play ();
	}

	public void KillBossActive()
	{
		playerScript.cancelMoves = true;
		timeline.Play ();
		FindObjectOfType<EndBoss> ().EndBossTimeline ();
	}

}
