using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaisceauScript : MonoBehaviour {

	private bool canLaunchFunction = true;

	void OnTriggerEnter2D(Collider2D coll)
	{
		if(coll.gameObject.tag == "Fraxinelle" && coll.GetComponent<FraxScript>().canLaunchFunction == true)
		{
			StartCoroutine (coll.gameObject.GetComponent<FraxScript> ().OnFire ());
			coll.gameObject.GetComponent<FraxScript> ().canSetFire = true;
			coll.GetComponent<FraxScript> ().canLaunchFunction = false;
		}
	}
}
