﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassingBehind : MonoBehaviour {

	public SpriteRenderer ObjectToHide;
	public SpriteRenderer ObjectToHide2;
	public SpriteRenderer ObjectToHide3;
	public int layerNumber;
	private bool isBehind = false;
	// Use this for initialization

	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{

	}

	void OnTriggerEnter2D(Collider2D coll)
	{
		if (coll.gameObject.tag == "OrderLayer" && !isBehind)
		{
			ObjectToHide.sortingOrder = ObjectToHide.sortingOrder - layerNumber;
			ObjectToHide2.sortingOrder = ObjectToHide.sortingOrder +1;
			ObjectToHide3.sortingOrder = ObjectToHide.sortingOrder;
			isBehind = true;
		}
	}
	void OnTriggerExit2D(Collider2D coll)
	{
		if (coll.gameObject.tag == "OrderLayer" && isBehind)
		{
			ObjectToHide.sortingOrder = ObjectToHide.sortingOrder + layerNumber;
			ObjectToHide2.sortingOrder = ObjectToHide.sortingOrder + 1;
			ObjectToHide3.sortingOrder = ObjectToHide.sortingOrder +1;
			isBehind = false;
		}
	}
}
