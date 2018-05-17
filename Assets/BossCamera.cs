using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class BossCamera : MonoBehaviour {

	public CameraBehavior cameraScript;
	public Camera mainCamera;
	public CinemachineVirtualCamera lookingPlayer;
	public float DezoomSize = 200f;
	private bool inZone;
	private bool hasPlayedScript;
	private bool canDezoom;

	void Update () 
	{
		if(inZone)
		{
			cameraScript.XMaxEnabled = true;
			cameraScript.XMinEnabled = true;
			cameraScript.YMaxEnabled = true;
			cameraScript.YMinEnabled = true;
			cameraScript.XMaxValue = 550f;
			cameraScript.YMaxValue = -900f;
			cameraScript.YMinValue = -900f;
		}
		if(canDezoom)
		{
			cameraScript.XMinValue = Mathf.Lerp (cameraScript.XMinValue, 550f, Time.deltaTime * 1f);
			mainCamera.orthographicSize = Mathf.Lerp (mainCamera.orthographicSize, DezoomSize, Time.deltaTime * 1f);
		}
	}


	void OnTriggerEnter2D(Collider2D col)
	{
		if(col.gameObject.tag =="Player")
		{
			Destroy (lookingPlayer);
			inZone = true;
			canDezoom = true;
		}
	}
		
}
