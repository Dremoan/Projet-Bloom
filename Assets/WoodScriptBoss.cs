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
			BurnWood ();
		}
	}

	void Update()
	{

		if(woodCount > 2)
		{
			StartCoroutine (DestroyWood ());
		}
	}


	void BurnWood()
	{
		fraxinelle.GetComponent<SpriteRenderer> ().enabled = false;
		fraxinelle.GetComponent<Collider2D> ().enabled = false;
		fraxinelleScript.canMove = false;
		fraxinelleScript.enabled = false;
		fraxinelle.GetComponent<Rigidbody2D> ().velocity = Vector3.zero;
		fraxinelle.GetComponent<Animator> ().Play ("DyingFrax");
		this.GetComponent<WoodScriptBoss>().woodCount += 1;
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
