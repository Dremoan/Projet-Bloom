using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrapplinInstructions : MonoBehaviour {

	public GameObject downArrowGrapplin;
	public GameObject downArrowWater;
	public GameObject canvasLaunchWater;
	public ModifyingZone modifyScript;
	private float timeRunning;
	public float timeMax = 10f;
	private bool timeCanRun;

	void Update()
	{
		Debug.Log (timeRunning);
		if(timeCanRun)
		{
			timeRunning += Time.deltaTime;
		}

		if(timeRunning > timeMax)
		{
			timeRunning = 0;
			StartCoroutine(EnableDownArrowGrapplin ());
			timeCanRun = false;
		}
	}
	public void EnableDownArrowWater()
	{
		downArrowWater.SetActive (true);
	}


	IEnumerator EnableDownArrowGrapplin()
	{
		downArrowWater.SetActive (false);
		downArrowGrapplin.SetActive (true);
		canvasLaunchWater.SetActive (true);
		yield return new WaitForSeconds (3f);
		downArrowGrapplin.SetActive (false);
		canvasLaunchWater.SetActive (false);
	}

	void TimeCanRunTrue()
	{
		timeCanRun = true;
	}
}
