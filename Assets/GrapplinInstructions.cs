using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrapplinInstructions : MonoBehaviour {

	public GameObject downArrowGrapplin;
	public GameObject downArrowWater;
	public GameObject canvasLaunchWater;
	public ModifyingZone modifyScript;
	private bool holdWater;
	void Update()
	{
		holdWater = FindObjectOfType<LaunchFlower> ().holdsWater;
		Enable ();
	}
	public void EnableDownArrowWater()
	{
		downArrowWater.SetActive (true);
	}

	void Enable()
	{
		if(Input.GetKeyDown(KeyCode.H))
		{
			StartCoroutine(EnableDownArrowGrapplin ());
		}
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
}
