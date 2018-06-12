using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DalleSecrète : MonoBehaviour {

	public GameObject blockingDoorOther;
	public GameObject cadreDoor;
	public PlayerBehavior playerScript;
	public Animator animInterrupteur;
	public DetectionTimeline timelineScriptIncomplet;
	public DetectionTimeline timelineScriptComplet;
	public DalleSecrète otherInterrupteur;
	private bool canPlayTimeline = true;
	public bool active;
	private bool canInactiveDoor = true;


	void Update()
	{
		if(active)
		{
			animInterrupteur.SetBool ("Active", true);
			if(canInactiveDoor)
			{
				cadreDoor.SetActive (false);
				blockingDoorOther.SetActive (false);
				canInactiveDoor = false;
			}
		}
	}

	void OnTriggerStay2D(Collider2D coll)
	{
		if(coll.gameObject.tag == "Player" && canPlayTimeline && otherInterrupteur.active == false)
		{
			if (Input.GetKeyDown (KeyCode.A))
			{
				active = true;
				canPlayTimeline = false;
				timelineScriptIncomplet.DalleActive ();
			}
		}
		if(coll.gameObject.tag == "Player" && canPlayTimeline && otherInterrupteur.active == true)
		{
			if(Input.GetKeyDown(KeyCode.A))
			{
				canInactiveDoor = false;
				active = true;
				canPlayTimeline = false;
				timelineScriptComplet.DalleActive ();
			}
		}
	}
}
