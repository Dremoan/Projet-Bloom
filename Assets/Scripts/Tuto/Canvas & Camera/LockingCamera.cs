using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockingCamera : MonoBehaviour {

	public CameraBehavior cameraScript;
	public GameObject unlockingCamera;

	void OnTriggerEnter2D(Collider2D coll)
	{
		if(coll.gameObject.tag == "Player")
		{
			unlockingCamera.SetActive (true);
			cameraScript.XMinEnabled = true;
			cameraScript.XMaxEnabled = true;
			this.gameObject.SetActive (false);
		}
	}
}
