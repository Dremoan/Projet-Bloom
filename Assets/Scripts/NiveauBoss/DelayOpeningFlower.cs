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
			edgeClose.enabled = false;
			animPlatform.Play ("Opening");
			canLaunchCount = true;
			edgeOpen.enabled = true;
		}
		if(coll.gameObject.tag =="Player")
		{
			canLaunchCount = false;
		}
	}

	void OnTriggerStay2D(Collider2D coll)
	{
		if(coll.gameObject.tag =="Player")
		{
			canLaunchCount = false;
		}
	}

	void OnTriggerExit2D(Collider2D coll)
	{
		if(coll.gameObject.tag =="Player")
		{
			canLaunchCount = true;
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
			edgeOpen.enabled = false;
			canLaunchCount = false;
			increaseFloat = 0f;
			edgeClose.enabled = true;
			animPlatform.Play ("Closing");
		}
	}
	 
}
