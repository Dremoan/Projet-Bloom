using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaisceauScript : MonoBehaviour {

	public FraxScript fraxinelleScript;
	private bool canLaunchFunction = true;

	void OnTriggerEnter2D(Collider2D coll)
	{
		if(coll.gameObject.tag == "Fraxinelle")
		{
			StartCoroutine (coll.gameObject.GetComponent<FraxScript> ().OnFire ());
			coll.gameObject.GetComponent<FraxScript> ().canSetFire = false;
		}
	}
}
