using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterActivation : MonoBehaviour {

	public GameObject rockSlot;
	public GameObject waterSource;
	public Animator rockSlotAnim;
	public bool isActive = false;
	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{

		rockSlotAnim.SetBool ("IsActive", rockSlot.GetComponent<ActivationRock>().isActive);

		if(rockSlot.GetComponent<ActivationRock>().isActive == true)
		{
			waterSource.GetComponent<PolygonCollider2D> ().enabled = true;
			waterSource.GetComponent<SpriteRenderer> ().enabled = true;
		}
	}
}