using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class ActivationRockSousSol: MonoBehaviour {

	public GameObject keyRock;
	public GameObject keyRockPlace;
	public GameObject cacheEau;
	public Animator anim;
	public bool isActive = false;

	void Update () 
	{
		anim.SetBool ("IsActive", isActive);

	}

	void OnTriggerEnter2D(Collider2D coll)
	{
		if(coll.gameObject.Equals(keyRock))
		{
			cacheEau.SetActive (false);
			isActive = true;
            FMODUnity.RuntimeManager.PlayOneShot("event:/IMPACT_DOOR");
			keyRock.transform.position = keyRockPlace.transform.position;
			keyRock.GetComponent<Rigidbody2D> ().velocity = Vector2.zero;
			keyRock.GetComponent<Rigidbody2D> ().isKinematic = true;
		}
	}

}