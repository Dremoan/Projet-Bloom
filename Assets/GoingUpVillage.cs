using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoingUpVillage : MonoBehaviour {

	public GameObject passingBehindDown;
	public GameObject goingDown;
	public GameObject goingUp;
	public GameObject edgeCollidersHaut;
	public GameObject edgeCollidersBas;


	void OnTriggerEnter2D(Collider2D coll)
	{
		if(coll.gameObject.tag == "Player")
		{
			edgeCollidersBas.SetActive (false);
			edgeCollidersHaut.SetActive (true);
			goingDown.SetActive (true);
			goingUp.gameObject.SetActive (false);
			passingBehindDown.SetActive (false);
		}
	}
}
