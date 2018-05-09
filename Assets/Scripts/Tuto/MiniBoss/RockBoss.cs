using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockBoss : MonoBehaviour {

	private Vector3 dirToPlayer;
	public GameObject player;
	public GameObject canon;
	public GameObject explosionArea;
	public GameObject targetSprite;
	public Animator bossAnim;
	public float timeBeforeRelaunch = 0.5f;
	private bool inZone = false;
	private float timeElapsed = 0f;

	void Update () 
	{
		timeElapsed += Time.deltaTime;

		if (inZone && timeElapsed > timeBeforeRelaunch)
		{
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
		bossAnim.Play ("MiniBossLaunch");
		targetSprite.SetActive (true);
		DropManagerComponent.SpawnDropRock (canon.transform.position, 0f, player.transform.position);
		targetSprite.transform.position = player.transform.position;
		yield return new WaitForSeconds (1f);
		targetSprite.SetActive (false);
	}

}
