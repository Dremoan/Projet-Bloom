using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveCinematic : MonoBehaviour {

	public ActivationRockSousSol activationRock;
	private bool canPlay = true;
	void Update () 
	{
		if(activationRock.isActive && canPlay)
		{
			canPlay = false;
			FindObjectOfType<DetectionTimeline> ().RockSlotActive ();
		}
	}
}
