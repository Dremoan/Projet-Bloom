using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockToLaunchScript : MonoBehaviour {

	public float launchForce = 250;
	public float distToRemove = 200f;
	public Rigidbody2D rockToLaunch;
	public GameObject player;
	public GameObject targetSprite;
	public LaunchFlower flowerScript;
	private Vector2 dirToPlayer;
	private bool isLaunching;
	private float countBeforeLaunch = 0;

	void Start()
	{
		this.transform.position = targetSprite.transform.position;
	}
	void Update () 
	{
//		if(Vector3.Distance(player.transform.position, this.transform.position) < distToRemove)
//		{
//			this.gameObject.SetActive (false);
//		}

		if(flowerScript.onLaunchingRock && Input.GetMouseButton(1))
		{
			dirToPlayer = player.transform.position - transform.position;
			player.GetComponent<PlayerBehavior> ().CancelMovements ();
			countBeforeLaunch += Time.deltaTime;
		}
		if(flowerScript.onLaunchingRock && Input.GetMouseButtonUp(1) && !isLaunching)
		{
			countBeforeLaunch = 0f;
			player.GetComponent<PlayerBehavior> ().EnableMovements ();
			flowerScript.isBacking = true;
			flowerScript.isHooked = false;
			flowerScript.onLaunchingRock = false;
		}

		if(countBeforeLaunch > 1.5f)
		{
			StartCoroutine (LaunchingRock());
		}
			
	}

	IEnumerator LaunchingRock()
	{
		isLaunching = true;
		rockToLaunch.AddForce (dirToPlayer.normalized * launchForce * Time.fixedDeltaTime, ForceMode2D.Impulse);
		yield return new WaitForSeconds (0.5f);
		player.GetComponent<PlayerBehavior> ().EnableMovements ();

	}
}
