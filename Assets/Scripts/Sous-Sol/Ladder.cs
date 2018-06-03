using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ladder : MonoBehaviour 
{
	public GameObject player;
	public GameObject ladderPos2;
	public GameObject goingUp;
	public GameObject pressAToGoDown;

	private bool canInteract;

	void Update () 
	{

		if(this.GetComponent<InteractingScript>().canInteract && player.GetComponent<PlayerBehavior>().pressingA)
		{
			player.transform.position = ladderPos2.transform.position;
		}
	}

	void OnTriggerEnter2D(Collider2D coll)
	{
		if(coll.gameObject.tag =="Player")
		pressAToGoDown.SetActive (true);
	}

	void OnTriggerExit2D(Collider2D coll)
	{
		if(coll.gameObject.tag =="Player")
		pressAToGoDown.SetActive (false);
	}
	void OnTriggerStay2D(Collider2D coll)
	{
		if(coll.gameObject.tag =="Player")
		pressAToGoDown.SetActive (true);
	}

}
