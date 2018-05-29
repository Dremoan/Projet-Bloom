using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayOpeningFlower : MonoBehaviour {

	public GameObject waterDrop;
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
			animPlatform.Play ("Closing");
		}
	}
	 
}
