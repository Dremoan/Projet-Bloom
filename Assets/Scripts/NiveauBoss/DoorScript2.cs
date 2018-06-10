using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript2 : MonoBehaviour
{

	public GameObject interactingZone;
	public PlayerBehavior playerScript;
	public GameObject particles;
	public GameObject particles2;
	public ParticleSystem particleLightWay;
	public ParticleSystem particleLight;
	public ParticleSystem particleLightWay2;
	public ParticleSystem particleLight2;
	public GameObject key;
	public GameObject passingBehind;
	public GameObject keyMecanism;
	public Animator animMecanism;
	public Animator animDoor;
	public DetectionTimeline timelineScript;

	private bool isNearDoor;
	public float openingTime =2.5f;



	void Update () 
	{
		if(interactingZone.GetComponent<InteractingScript>().canInteract)
		{
			isNearDoor = true;
		}
		else if(interactingZone.GetComponent<InteractingScript>().canInteract == false)
		{
			isNearDoor = false;
		}

		if(isNearDoor && playerScript.pressingA && playerScript.hasKey)
		{
			StartCoroutine (ActiveDoor ());
		}
	}

	IEnumerator ActiveDoor()
	{
        FMODUnity.RuntimeManager.PlayOneShot("event:/switches");
		timelineScript.DoorActive ();
		playerScript.cancelMoves = true;
		yield return new WaitForSeconds (0.5f);
		key.SetActive (false);
		playerScript.hasKey = false;
		keyMecanism.SetActive (true);
		animMecanism.Play ("MécanismeActivé");
		yield return new WaitForSeconds (0.25f);
		particles.SetActive (true);
		yield return new WaitForSeconds (1.5f);
		particles2.SetActive (true);
		yield return new WaitForSeconds (openingTime);
        FMODUnity.RuntimeManager.PlayOneShot("event:/IMPACT_DOOR");
		animDoor.Play ("Porte_Exit");
	}

	public void EndLoop()
	{
		StartCoroutine (EndLooping ());
	}


	IEnumerator EndLooping()
	{
		animDoor.GetComponent<SpriteRenderer> ().sortingOrder = -1;
		playerScript.cancelMoves = false;
		playerScript.EnableMovements ();
		passingBehind.SetActive (false);
		particleLight.loop = false;
		particleLightWay.loop = false;
		yield return new WaitForSeconds (0.5f);
		particleLight2.loop = false;
		particleLightWay2.loop = false;
	}
}
