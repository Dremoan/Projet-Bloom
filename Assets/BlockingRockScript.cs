using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockingRockScript : MonoBehaviour {

	public LaunchFlower flowerScript;
	public GameObject blockingRock;
	public Animator animWater;
	private float backingCount = 0;


	void Update ()
	{

		if(flowerScript.onBlockingRock && Input.GetMouseButton(1))
		{
				backingCount += Time.deltaTime;
		}		
		if (backingCount > 2) 
		{
			BackingAndDeleteRock ();
		}
	}

	private void BackingAndDeleteRock()
	{
		blockingRock.SetActive (false);
		flowerScript.isBacking = true;
		flowerScript.isHooked = false;
		backingCount = 0;
		animWater.Play ("WaterFilling");
	}
}
