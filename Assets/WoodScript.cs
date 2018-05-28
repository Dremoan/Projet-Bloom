using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodScript : MonoBehaviour {

	public FraxScript fraxinelleScript;
	public Animator animWood;


	void OnTriggerEnter2D(Collider2D coll)
	{
		if(coll.gameObject.tag == "Player")
		{
			fraxinelleScript.OnFire ();
		}
		if(coll.gameObject.tag == "Player" && fraxinelleScript.onFire == true)
		{
			animWood.SetBool ("Burnt", true);

		}
	}
}
