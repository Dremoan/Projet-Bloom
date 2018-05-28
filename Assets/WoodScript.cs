using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodScript : MonoBehaviour {

	public FraxScript fraxinelleScript;
	public Animator animWood;


	void OnTriggerEnter2D(Collider2D coll)
	{
		if(coll.gameObject.tag == "Player" && fraxinelleScript.onFire == true)
		{
			StartCoroutine (DestroyWood ());
		}
	}

	IEnumerator DestroyWood()
	{
		animWood.SetBool ("Burnt", true);
		yield return new WaitForSeconds (2.5f);
		this.gameObject.SetActive (false);
	}
}
