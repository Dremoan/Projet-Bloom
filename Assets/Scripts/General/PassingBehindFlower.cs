using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassingBehindFlower : MonoBehaviour {

	public SpriteRenderer ObjectToHide;
	public SpriteRenderer ObjectToHide2;
	public int layerNumber;
	private bool isBehind = false;

	void Update()
	{
		ObjectToHide2.sortingOrder = ObjectToHide.sortingOrder;
	}
	void OnTriggerEnter2D(Collider2D coll)
	{
		if (coll.gameObject.tag == "OrderLayer" && !isBehind)
		{
			ObjectToHide.sortingOrder = ObjectToHide.sortingOrder - layerNumber;
			isBehind = true;
		}
	}
	void OnTriggerExit2D(Collider2D coll)
	{
		if (coll.gameObject.tag == "OrderLayer" && isBehind)
		{
			ObjectToHide.sortingOrder = ObjectToHide.sortingOrder + layerNumber;
			isBehind = false;
		}
	}
}
