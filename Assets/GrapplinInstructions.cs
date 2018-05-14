using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrapplinInstructions : MonoBehaviour {

	public GameObject downArrow;


	public void EnableDownArrow()
	{
		downArrow.SetActive (true);
	}

	public void DisableDownArrow()
	{
		downArrow.SetActive (false);
	}
}
