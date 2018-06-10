using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodScriptBoss : MonoBehaviour {


	private FraxScript fraxinelleScript;
	private GameObject fraxinelle;
	public TriggerTransitionBoss transitionScript;
	public Animator animWood;
	public float woodCount;

	void OnCollisionEnter2D(Collision2D coll)
	{
		if(coll.gameObject.tag == "Fraxinelle")
		{
			fraxinelleScript = coll.gameObject.GetComponent<FraxScript> ();
			fraxinelle = coll.gameObject;
		}
	}

	void Update()
	{

		if(woodCount > 2)
		{
			StartCoroutine (DestroyWood ());
		}
	}

	void OnCollisionStay2D(Collision2D coll)
	{
		if(coll.gameObject.tag == "Fraxinelle")
		{
			fraxinelleScript.canMove = false;
			fraxinelleScript.enabled = false;
			fraxinelle.GetComponent<Rigidbody2D> ().velocity = Vector3.zero;
			fraxinelle.GetComponent<Collider2D> ().enabled = false;
			fraxinelle.GetComponent<Animator> ().Play ("DyingFrax");
			this.GetComponent<WoodScriptBoss>().woodCount += 1;
		}
	}
	void OnCollisionExit2D(Collision2D coll)
	{
		if(coll.gameObject.tag == "Fraxinelle")
		{
			fraxinelleScript.canMove = false;
			fraxinelleScript.enabled = false;
			fraxinelle.GetComponent<Rigidbody2D> ().velocity = Vector3.zero;
			fraxinelle.GetComponent<Collider2D> ().enabled = false;
			fraxinelle.GetComponent<Animator> ().Play ("DyingFrax");
			this.GetComponent<WoodScriptBoss>().woodCount += 1;
		}
	}

	IEnumerator DestroyWood()
	{
        FMODUnity.RuntimeManager.PlayOneShot("event:/LVL1/SFX/ronce_feu");
		this.GetComponent<Collider2D> ().enabled = false;
		animWood.SetBool ("Burnt", true);
		transitionScript.woodCount += 1;
		yield return new WaitForSeconds (1f);
		this.gameObject.SetActive (false);
	}
}
