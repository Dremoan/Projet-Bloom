using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hiding : MonoBehaviour {

	public GameObject[] hidingZones;
	public CameraBehavior mainCamera;
	public GameObject receptionSand;
	public GameObject chuteSand;



	void OnTriggerStay2D(Collider2D coll)
	{
		if(coll.gameObject.tag == "Player")
		{
			mainCamera.XMaxValue = -260;
			mainCamera.XMinValue = -270;
			chuteSand.SetActive (false);
			receptionSand.SetActive (false);
			hidingZones [0].SetActive (true);
			hidingZones [1].SetActive (true);
			hidingZones [2].SetActive (false);
			hidingZones [3].SetActive (false);
		}
	}

	void OnTriggerEnter2D(Collider2D coll)
	{
		if (coll.gameObject.tag == "Player") 
		{
			mainCamera.XMaxValue = -260;
			mainCamera.XMinValue = -270;
			chuteSand.SetActive (false);
			receptionSand.SetActive (false);
		}
	}

	void OnTriggerExit2D(Collider2D coll)
	{
		if(coll.gameObject.tag == "Player")
		{
			mainCamera.XMaxValue = 160;
			mainCamera.XMinValue = 140;
			chuteSand.SetActive (true);
			receptionSand.SetActive (true);
			hidingZones [0].SetActive (false);
			hidingZones [1].SetActive (false);
			hidingZones [2].SetActive (true);
			hidingZones [3].SetActive (true);
		}
	}
}
