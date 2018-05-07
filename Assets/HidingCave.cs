using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HidingCave : MonoBehaviour {

	public GameObject grotte;
	public Animator anim;

	void Update () 
	{
		
	}

	void OnTriggerEnter2D(Collider2D coll)
	{
		if(coll.gameObject.tag == "Player")
		{
			grotte.SetActive (false);
			anim.Play ("LightCave");
		}
	}
}
