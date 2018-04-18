using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockBoss : MonoBehaviour {

	private Vector3 dirToPlayer;
	private bool canLaunchRock = true;
	private float countToReload = 0;
	private bool timeCanRun = false;
	private bool phase2 = true;
	public bool canExplode;
	public GameObject player;
	public GameObject canon;
	public GameObject explosionArea;
	public GameObject targetSprite;
	public GameObject rockToLaunch;
	public float waitTillLaunch = 0.25f;


	void Update () 
	{
		if (timeCanRun) 
		{
			countToReload += Time.deltaTime;
		}

		if (countToReload >= 10 && canLaunchRock && !phase2) 
		{
			explosionArea.GetComponent<CircleCollider2D> ().enabled = false;
			targetSprite.SetActive (false);
			StopAllCoroutines ();
			StartCoroutine (Reload ());
		}

		if (countToReload >= 10 && canLaunchRock && phase2) 
		{
			explosionArea.GetComponent<CircleCollider2D> ().enabled = false;
			targetSprite.SetActive (false);
			StopAllCoroutines ();
			StartCoroutine (ReloadLonger ());
		}


	}

	void OnTriggerStay2D(Collider2D col)
	{
		if (col.gameObject.tag=="Player" && canLaunchRock && !phase2)
		{
			timeCanRun = true;
			StopAllCoroutines ();
			StartCoroutine (LaunchRock ());
		}

		if (col.gameObject.tag=="Player" && canLaunchRock && phase2)
		{
			timeCanRun = true;
			StopAllCoroutines ();
			StartCoroutine (LaunchStayingRock ());
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
		DropManagerComponent.SpawnDropRock (canon.transform.position, Mathf.Atan2 (dirToPlayer.y, dirToPlayer.x) * Mathf.Rad2Deg);
		yield return new WaitForSeconds (0.5f);
		explosionArea.GetComponent<CircleCollider2D> ().enabled = true;
		explosionArea.transform.position = targetSprite.transform.position;
		targetSprite.SetActive (false);
		yield return new WaitForSeconds (0.2f);
		explosionArea.GetComponent<CircleCollider2D> ().enabled =false;
		yield return new WaitForSeconds (1f);
		canLaunchRock = true;

	}

	IEnumerator LaunchStayingRock()
	{
		canExplode = false;
		canLaunchRock = false;
		dirToPlayer = player.transform.position - canon.transform.position;
		yield return new WaitForSeconds (waitTillLaunch);
		targetSprite.transform.position = player.transform.position;
		targetSprite.SetActive (true);
		DropManagerComponent.SpawnDropRock (canon.transform.position, Mathf.Atan2 (dirToPlayer.y, dirToPlayer.x) * Mathf.Rad2Deg);
		yield return new WaitForSeconds (0.5f);
		explosionArea.GetComponent<CircleCollider2D> ().enabled = true;
		explosionArea.transform.position = targetSprite.transform.position;
		targetSprite.SetActive (false);
		rockToLaunch.SetActive (true);
		yield return new WaitForSeconds (0.2f);
		explosionArea.GetComponent<CircleCollider2D> ().enabled =false;
		yield return new WaitForSeconds (2f);
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

	IEnumerator ReloadLonger()
	{
		timeCanRun = false;
		canLaunchRock = false;
		countToReload = 0;
		yield return new WaitForSeconds (5f);
		canLaunchRock = true;
		timeCanRun = true;
	}
}
