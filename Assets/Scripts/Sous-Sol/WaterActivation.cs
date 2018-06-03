using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterActivation : MonoBehaviour {

	public GameObject rockSlot;
	public GameObject waterSource;
	public Animator animWater;
	public bool isActive = false;
	private bool activeAnim;

	
	// Update is called once per frame
	void Update () 
	{
		animWater.SetBool ("ActiveAnim", activeAnim);
		if(rockSlot.GetComponent<ActivationRockSousSol>().isActive == true)
		{
			activeAnim = true;
			waterSource.GetComponent<PolygonCollider2D> ().enabled = true;
			waterSource.GetComponent<SpriteRenderer> ().enabled = true;
		}
	}
}