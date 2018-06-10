using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestScript2 : MonoBehaviour {

	public GameObject keyOnScreen;
	public GameObject player;
	public GameObject interactingZone;
	public GameObject key;
	public PlayerBehavior playerScript;

	private bool isNearChest = false;
	private bool isOpened = false;


	void Update () 
	{
		if(interactingZone.GetComponent<InteractingScript>().canInteract)
		{
			isNearChest = true;
		}
		else if(interactingZone.GetComponent<InteractingScript>().canInteract == false)
		{
			isNearChest = false;
		}

		if(isNearChest && player.GetComponent<PlayerBehavior>().pressingA && !isOpened)
		{
            FMODUnity.RuntimeManager.PlayOneShot("event:/recup_clef");
			keyOnScreen.SetActive (true);
			player.GetComponent<PlayerBehavior> ().hasKey = true;
			isOpened = true;
		}
		if(isOpened)
		{
			key.SetActive (false);
		}
	}
}
