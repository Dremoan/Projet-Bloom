using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockBoss : MonoBehaviour {

	private Vector3 dirToPlayer;
	private bool canLaunchRock = true;
	private float countToReload = 0;
	private bool timeCanRun = false;
	public bool canExplode;
	public GameObject player;
	public GameObject canon;
	public GameObject explosionArea;
	public GameObject targetSprite;
	public float waitTillLaunch = 0.25f;


	void Start ()
	{
		
	}


	void Update () 
	{


		if (timeCanRun) 
		{
			countToReload += Time.deltaTime;
		}

		if (countToReload >= 10) 
		{
			targetSprite.SetActive (false);
			explosionArea.SetActive (false);
			StopAllCoroutines ();
			StartCoroutine (Reload ());
		}


	}

	void OnTriggerStay2D(Collider2D col)
	{
		if (col.gameObject.tag=="Player" && canLaunchRock)
		{
			timeCanRun = true;
			StopAllCoroutines ();
			StartCoroutine (LaunchRock ());
		}
			
	}

	IEnumerator LaunchRock()
	{
		canExplode = false;
		canLaunchRock = false;
		dirToPlayer = player.transform.position - canon.transform.position;
		yield return new WaitForSeconds (waitTillLaunch);
		targetSprite.transform.position = player.transform.position;
		targetSprite.SetActive (true);
		DropManagerComponent.SpawnDrop (canon.transform.position, Mathf.Atan2 (dirToPlayer.y, dirToPlayer.x) * Mathf.Rad2Deg);
		yield return new WaitForSeconds (0.5f);
		explosionArea.GetComponent<CircleCollider2D> ().enabled = true;
		explosionArea.transform.position = targetSprite.transform.position;
		yield return new WaitForSeconds (0.2f);
		explosionArea.GetComponent<CircleCollider2D> ().enabled =false;
		targetSprite.SetActive (false);
		yield return new WaitForSeconds (0.5f);
		canLaunchRock = true;
	}



	IEnumerator Reload()
	{
		timeCanRun = false;
		canLaunchRock = false;
		countToReload = 0;
		yield return new WaitForSeconds (3f);
		canLaunchRock = true;
		timeCanRun = true;
	}
}
