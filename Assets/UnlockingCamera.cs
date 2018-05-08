using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockingCamera : MonoBehaviour {

	public CameraBehavior cameraScript;
	public GameObject lockingCamera;

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "Player")
		{
			lockingCamera.SetActive (true);
			cameraScript.XMinEnabled = false;
			cameraScript.XMaxEnabled = false;
			this.gameObject.SetActive (false);
		}
	}
}
