using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class BossCamera : MonoBehaviour {

	public CameraBehavior cameraScript;
	public GameObject canvasBossButtons;
	public Camera mainCamera;
	public CinemachineVirtualCamera lookingPlayer;
	public float dezoomSize = 180f;
	public float zoomSize = 150f;
	private bool inZone;
	private bool hasPlayedScript;
	private bool canDezoom;
	public bool canPrintHelpButtons = true;
	private float countToPrintHelpButtons;
	public float TimeMaxToPrintHelpButtons = 10f;

	void Update () 
	{

		if (FindObjectOfType<FrondeScript> ().isDead)
		{
			inZone = false;
			canDezoom = false;
			cameraScript.YMaxEnabled = false;
			cameraScript.YMinEnabled = false;
			mainCamera.orthographicSize = Mathf.Lerp (mainCamera.orthographicSize, zoomSize, Time.deltaTime * 1f);
		}
		if(inZone)
		{
			ClampCameraBossZone ();
			countToPrintHelpButtons += Time.deltaTime;
		}

		if(countToPrintHelpButtons > TimeMaxToPrintHelpButtons && canPrintHelpButtons)
		{
			Debug.Log ("coucou");
			countToPrintHelpButtons = 0;
			canPrintHelpButtons = false;
			canvasBossButtons.SetActive (true);

		}
		if(canDezoom)
		{
			cameraScript.XMinValue = Mathf.Lerp (cameraScript.XMinValue, 585f, Time.deltaTime * 1f);
			mainCamera.orthographicSize = Mathf.Lerp (mainCamera.orthographicSize, dezoomSize, Time.deltaTime * 1f);
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

	void ClampCameraBossZone()
	{
		cameraScript.XMaxEnabled = true;
		cameraScript.XMinEnabled = true;
		cameraScript.YMaxEnabled = true;
		cameraScript.YMinEnabled = true;
		cameraScript.XMaxValue = 625f;
		cameraScript.YMaxValue = -900f;
		cameraScript.YMinValue = -900f;
	}
		
}
