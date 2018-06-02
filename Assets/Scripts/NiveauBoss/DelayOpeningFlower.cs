using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayOpeningFlower : MonoBehaviour {

	public GameObject waterDrop;
	public EdgeCollider2D edgeOpen;
	public EdgeCollider2D edgeClose;
	public Animator animPlatform;
	private float increaseFloat;
	public float maxTimeClose = 2f;
	private bool canLaunchCount;

	void OnTriggerEnter2D(Collider2D coll)
	{
		if(coll.gameObject.Equals(waterDrop))
		{
			animPlatform.Play ("Opening");
			canLaunchCount = true;
			FindObjectOfType<DrowningWater> ().Plateforme = edgeOpen;
			edgeClose.enabled = false;

		}
	}

	void Update ()
	{
		if(canLaunchCount)
		{
			increaseFloat += Time.deltaTime;
		}
		if(increaseFloat > maxTimeClose)
		{
			canLaunchCount = false;
			increaseFloat = 0f;
			FindObjectOfType<DrowningWater> ().Plateforme = edgeClose;
			edgeOpen.enabled = false;
			animPlatform.Play ("Closing");
		}
	}
	 
}
