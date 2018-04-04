using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterActivation : MonoBehaviour {

	public GameObject rockSlot;
	public GameObject waterSource;
	public Animator anim;
	public bool isActive = false;
	private bool activeAnim;
	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		
		if(rockSlot.GetComponent<ActivationRock>().isActive == true)
		{
			anim.SetBool ("ActiveAnim", activeAnim);
			activeAnim = true;
			waterSource.GetComponent<PolygonCollider2D> ().enabled = true;
			waterSource.GetComponent<SpriteRenderer> ().enabled = true;
		}
	}
}