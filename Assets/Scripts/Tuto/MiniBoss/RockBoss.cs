using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockBoss : MonoBehaviour {

	private Vector3 dirToPlayer;
	private bool canLaunchRock = true;
	public GameObject player;
	public GameObject canon;
	public GameObject explosionArea;
	public GameObject targetSprite;
	public float waitTillLaunch = 1f;
	private bool inZone = false;
	public float timeBeforeRelaunch = 0.5f;
	private float timeElapsed = 0f;

	void Update () 
	{
		timeElapsed += Time.deltaTime;

		if (inZone && timeElapsed > timeBeforeRelaunch)
		{
			//StopAllCoroutines ();
			StartCoroutine (LaunchRock ());
			timeElapsed = 0f;
		}

	}

	void OnTriggerStay2D(Collider2D col)
	{
		if (col.gameObject.tag=="Player")
			inZone = true;

			
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag=="Player")
			inZone = true;
	}

	void OnTriggerExit2D(Collider2D col)
	{
		if (col.gameObject.tag=="Player")
			inZone = false;
	}

	IEnumerator LaunchRock()
	{
		canLaunchRock = false;
//		dirToPlayer = player.transform.position - canon.transform.position;
		targetSprite.SetActive (true);
		DropManagerComponent.SpawnDropRock (canon.transform.position, 0f, player.transform.position);
		targetSprite.transform.position = player.transform.position;
		yield return new WaitForSeconds (1f);
		targetSprite.SetActive (false);
		canLaunchRock = true;

	}

}
