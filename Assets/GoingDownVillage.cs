using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoingDownVillage : MonoBehaviour {

	public GameObject passingBehindDown;
	public GameObject goingUp;
	public GameObject goingDown;
	public GameObject edgeCollidersHaut;
	public GameObject edgeCollidersBas;


	void OnTriggerEnter2D(Collider2D coll)
	{
		if(coll.gameObject.tag == "Player")
		{
			edgeCollidersHaut.SetActive (false);
			edgeCollidersBas.SetActive (true);
			goingUp.SetActive (true);
			goingDown.gameObject.SetActive (false);
			passingBehindDown.SetActive (true);
		}
	}
}
