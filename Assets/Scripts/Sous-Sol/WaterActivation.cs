using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterActivation : MonoBehaviour {

	public GameObject rockSlot;
	public GameObject waterSource;
	public Animator animWater;
	public bool isActive = false;
	private bool activeAnim;

    private bool canPlayWaterSound = true;

	
	// Update is called once per frame
	void Update () 
	{
		animWater.SetBool ("ActiveAnim", activeAnim);
		if(rockSlot.GetComponent<ActivationRockSousSol>().isActive == true && canPlayWaterSound)
		{
            FMODUnity.RuntimeManager.PlayOneShot("event:/WATER_FILL");
            canPlayWaterSound = false;
			activeAnim = true;
			waterSource.GetComponent<PolygonCollider2D> ().enabled = true;
			waterSource.GetComponent<SpriteRenderer> ().enabled = true;
		}
	}
}