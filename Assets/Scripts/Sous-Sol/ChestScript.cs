using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestScript : MonoBehaviour {

	public GameObject keyOnScreen;
	public GameObject player;
	public GameObject interactingZone;
	public GameObject key;
	public PolygonCollider2D blockingWay;
	public Animator animPilar;
	public PlayerBehavior playerScript;

	private bool isNearChest = false;
	private bool isOpened = false;


	void Update () 
	{
		if (playerScript.isJumping == true && isOpened)
		{
			blockingWay.enabled = false;
		}

		if (playerScript.isJumping == false && isOpened)
		{
			blockingWay.enabled = true;
		}
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
			animPilar.Play ("Activation");
		}
	}
}
