using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HidingCave : MonoBehaviour {

	public GameObject grotte;
	public Animator anim;
	public CameraBehavior cameraScript;

	void Update () 
	{
		
	}

	void OnTriggerEnter2D(Collider2D coll)
	{
		if(coll.gameObject.tag == "Player")
		{
			grotte.SetActive (false);
			anim.Play ("LightCave");
			cameraScript.XMaxValue = -709f;
			cameraScript.XMinValue = -1100f;
			cameraScript.YMaxEnabled = false;
			cameraScript.YMinEnabled = false;
		}
	}
}
