﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodScript : MonoBehaviour {

	private FraxScript fraxinelleScript;
	private GameObject fraxinelle;
	public Animator animWood;
	private bool canDie;

	void OnCollisionEnter2D(Collision2D coll)
	{
		if(coll.gameObject.tag == "Fraxinelle")
		{
			fraxinelleScript = coll.gameObject.GetComponent<FraxScript> ();
			fraxinelle = coll.gameObject;
			canDie = true;
		}
	}

	void Update()
	{
		if(fraxinelleScript.onFire == true && canDie)
		{
			StartCoroutine (DestroyWood ());
		}
	}

	void OnCollisionStay2D(Collision2D coll)
	{
		if(coll.gameObject.tag == "Fraxinelle")
		{
			canDie = true;
		}
	}
	void OnCollisionExit2D(Collision2D coll)
	{
		if(coll.gameObject.tag == "Fraxinelle")
		{
			canDie = false;
		}
	}

	IEnumerator DestroyWood()
	{
		fraxinelleScript.canMove = false;
		fraxinelleScript.enabled = false;
		fraxinelle.GetComponent<Rigidbody2D> ().velocity = Vector3.zero;
		fraxinelle.GetComponent<Collider2D> ().enabled = false;
		fraxinelle.GetComponent<Animator> ().Play ("DyingFrax");
		animWood.SetBool ("Burnt", true);
		yield return new WaitForSeconds (2.5f);
		this.gameObject.SetActive (false);
	}
}
