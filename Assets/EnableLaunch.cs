using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableLaunch : MonoBehaviour {


	public LaunchFlower flowerScript;
	private bool canvasActive;

	void Update()
	{
		ActiveCanvas ();
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if(col.gameObject.tag == "Player")
		{
			StartCoroutine (EnableLaunchFlower ());
		}
	}
	void ActiveCanvas()
	{
		if (flowerScript.canLaunch == true && !canvasActive)
		{
			FindObjectOfType<CanvasGestion> ().activeFirstImage = true;
			canvasActive = true;
		}
	}

	IEnumerator EnableLaunchFlower()
	{
		yield return new WaitForSeconds (6f);
		flowerScript.canLaunch = true;
	}

}
