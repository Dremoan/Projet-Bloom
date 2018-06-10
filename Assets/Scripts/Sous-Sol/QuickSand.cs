﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuickSand : MonoBehaviour 
{
	public GameObject goat;
	public GameObject goatInSand;
	public Animator anim;
	private bool isInSand = false;

    private bool canPlaySound = true;

	void Start () 
	{
		
	}
	

	void Update () 
	{

		if(isInSand && canPlaySound)
		{
            FMODUnity.RuntimeManager.PlayOneShot("event:/BOUC_COULE");
            canPlaySound = false;
			goat.SetActive (false);
			goatInSand.SetActive (true);
			this.GetComponent<PolygonCollider2D> ().enabled = false;
		}
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if(col.gameObject.tag == "Goat")
		{
			isInSand = true;
		}
	}





}
