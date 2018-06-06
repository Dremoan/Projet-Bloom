using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasGestionSousSol : MonoBehaviour {

	public GameObject chest;
	public GameObject canvasChest;

	void Update () 
	{
		if(chest.GetComponent<InteractingScript>().canInteract == true)
		{
			canvasChest.SetActive (true);
		}
		else if(chest.GetComponent<InteractingScript>().canInteract == false)
		{
			canvasChest.SetActive (false);
		}
	}
}
