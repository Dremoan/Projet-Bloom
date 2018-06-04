using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassingBehindFlower : MonoBehaviour {

	public SpriteRenderer ObjectToHide;
	public SpriteRenderer ObjectToHide2;
	public int layerNumber;
	private bool isBehind = false;


	void OnTriggerEnter2D(Collider2D coll)
	{
		if (coll.gameObject.tag == "OrderLayer" && !isBehind)
		{
			ObjectToHide.sortingOrder = ObjectToHide.sortingOrder - layerNumber;
			ObjectToHide2.sortingOrder = ObjectToHide.sortingOrder;
			isBehind = true;
		}
	}
	void OnTriggerExit2D(Collider2D coll)
	{
		if (coll.gameObject.tag == "OrderLayer" && isBehind)
		{
			ObjectToHide.sortingOrder = ObjectToHide.sortingOrder + layerNumber;
			ObjectToHide2.sortingOrder = ObjectToHide.sortingOrder;
			isBehind = false;
		}
	}
}
