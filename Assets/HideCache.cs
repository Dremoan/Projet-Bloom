using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideCache : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D coll)
	{
		if(coll.gameObject.tag == "Player")
		{
			GetComponent<SpriteRenderer> ().enabled = false;
		}
	}

	void OnTriggerStay2D(Collider2D coll)
	{
		if(coll.gameObject.tag == "Player")
		{
			GetComponent<SpriteRenderer> ().enabled = false;
		}
	}

	void OnTriggerExit2D(Collider2D coll)
	{
		if(coll.gameObject.tag == "Player")
		{
			GetComponent<SpriteRenderer> ().enabled = true;
		}
	}
}
