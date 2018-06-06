using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangingOrderDoor : MonoBehaviour {

	public SpriteRenderer shinyDoor;
	public int orderLayer;


	void ChangeOrder()
	{
		GetComponent<SpriteRenderer> ().enabled = false;
		shinyDoor.sortingLayerName = "Background";
		shinyDoor.sortingOrder = orderLayer;

	}
	
}
