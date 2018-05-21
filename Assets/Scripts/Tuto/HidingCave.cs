using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PostProcessing;

public class HidingCave : MonoBehaviour {

	public GameObject grotte;
	public GameObject skyBox;
	public PolygonCollider2D colliderLevel;
	public Animator anim;
	public Animator animFalaise;
	public PostProcessingBehaviour tutoPostProcess;
	public PostProcessingProfile canyonProcess;

	public CameraBehavior cameraScript;
	public Camera mainCamera;
	private bool canDezoom;

	void Update () 
	{
		if(canDezoom)
		{
			mainCamera.orthographicSize = Mathf.Lerp (mainCamera.orthographicSize, 150.01f , Time.deltaTime * 3f);
		}
	}

	void OnTriggerEnter2D(Collider2D coll)
	{
		if(coll.gameObject.tag == "Player")
		{
			grotte.SetActive (false);
			anim.Play ("LightCave");
			canDezoom = true;
			cameraScript.XMaxValue = -709f;
			cameraScript.XMinValue = -1100f;
			cameraScript.YMaxEnabled = false;
			cameraScript.YMinEnabled = false;
			StartCoroutine (ActiveColliderLevel ());
		}
	}

	IEnumerator ActiveColliderLevel()
	{
		tutoPostProcess.profile = canyonProcess;
		yield return new WaitForSeconds (0.75f);
		skyBox.SetActive (true);
		yield return new WaitForSeconds (0.75f);
		animFalaise.Play ("Falaise qui tombe");
		colliderLevel.enabled = true;
	}
}
