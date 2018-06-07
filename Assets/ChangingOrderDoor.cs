using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangingOrderDoor : MonoBehaviour {

	public SpriteRenderer shinyDoor;
	public string layerName;
	public int orderLayer;

	void Update()
	{
		shinyDoor.sortingLayerName = layerName;
		shinyDoor.sortingOrder = orderLayer;
	}

	
}
