using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCamera : MonoBehaviour {

	public CameraBehavior cameraScript;
	private bool inZone;
	private bool hasPlayedScript;

	void Update () 
	{
		if(inZone && !hasPlayedScript)
		{
			hasPlayedScript = true;
			cameraScript.XMaxEnabled = true;
			cameraScript.XMinEnabled = true;
			cameraScript.YMaxEnabled = true;
			cameraScript.YMinEnabled = true;
			cameraScript.XMaxValue = 550f;
			cameraScript.XMinValue = 400f;
			cameraScript.YMaxValue = -700f;
			cameraScript.YMinValue = -900f;
		}
	}


	void OnTriggerEnter2D(Collider2D col)
	{
		if(col.gameObject.tag =="Player")
		{
			inZone = true;
		}
	}
}
