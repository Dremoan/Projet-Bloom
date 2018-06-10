using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockingRockScript : MonoBehaviour {

	public LaunchFlower flowerScript;
	public GameObject blockingRock;
	public PolygonCollider2D waterSource1;
	public PolygonCollider2D waterSource2;
	public PolygonCollider2D waterSource3;
	public Animator animWater;
	public Animator blockingRockAnim;
	private float backingCount = 0;


	void Update ()
	{

		if(flowerScript.onBlockingRock && Input.GetMouseButton(1))
		{
				backingCount += Time.deltaTime;
		}		
		if (backingCount > 1f) 
		{
			BackingAndDeleteRock ();
		}
	}

	private void BackingAndDeleteRock()
	{
		waterSource1.enabled = true;
		waterSource2.enabled = true;
		waterSource3.enabled = true;
		FindObjectOfType<CanvasGestion> ().activeSecondImage = false;
		flowerScript.isBacking = true;
		flowerScript.isHooked = false;
		backingCount = 0;
        FMODUnity.RuntimeManager.PlayOneShot("event:/Cascade");
		animWater.Play ("FillingFountain");
		blockingRockAnim.Play ("DestroyRock");
	}
}
