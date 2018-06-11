using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassingBehindPlayer : MonoBehaviour {

	public SpriteRenderer ObjectToHide;
	public SpriteRenderer ObjectToHide2;
	public SpriteRenderer ObjectToHide3;
	public ParticleSystemRenderer marcheSpit;
	public int layerNumber;
	private bool isBehind = false;

	void OnTriggerEnter2D(Collider2D coll)
	{
		if (coll.gameObject.tag == "OrderLayer" && !isBehind)
		{
			marcheSpit.sortingOrder = ObjectToHide.sortingOrder - layerNumber;
			ObjectToHide.sortingOrder = ObjectToHide.sortingOrder - layerNumber;
			ObjectToHide2.sortingOrder = ObjectToHide.sortingOrder -1;
			ObjectToHide3.sortingOrder = ObjectToHide.sortingOrder + 1;
			isBehind = true;
		}
	}
	void OnTriggerExit2D(Collider2D coll)
	{
		if (coll.gameObject.tag == "OrderLayer" && isBehind)
		{
			marcheSpit.sortingOrder = ObjectToHide.sortingOrder + layerNumber;
			ObjectToHide.sortingOrder = ObjectToHide.sortingOrder + layerNumber;
			ObjectToHide2.sortingOrder = ObjectToHide.sortingOrder - 1;
			ObjectToHide3.sortingOrder = ObjectToHide.sortingOrder + 1;
			isBehind = false;
		}
	}
}
