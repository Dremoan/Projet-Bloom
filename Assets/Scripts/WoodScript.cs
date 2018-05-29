using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodScript : MonoBehaviour {

	private FraxScript fraxinelleScript;
	private GameObject fraxinelle;
	public Animator animWood;
	private bool canDie;

	void Update()
	{
		if(fraxinelleScript.onFire == true && canDie)
		{
			StartCoroutine (DestroyWood ());
		}
	}

	void OnTriggerEnter2D(Collider2D coll)
	{
		if(coll.gameObject.tag == "Fraxinelle")
		{
			fraxinelleScript = coll.gameObject.GetComponent<FraxScript> ();
			fraxinelle = coll.gameObject;
			canDie = true;
		}
	}
	void OnTriggerStay2D(Collider2D coll)
	{
		if(coll.gameObject.tag == "Fraxinelle")
		{
			canDie = true;
		}
	}
	void OnTriggerExit2D(Collider2D coll)
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
		fraxinelle.GetComponent<Animator> ().Play ("DyingFrax");
		animWood.SetBool ("Burnt", true);
		yield return new WaitForSeconds (2.5f);
		this.gameObject.SetActive (false);
	}
}
