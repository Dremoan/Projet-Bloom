using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DrowningWater : MonoBehaviour {

	public GameObject Plateformes;
	public GameObject eau1;
	public GameObject eau2;
	public GameObject eauNiveau;
	public GameObject killingWater;
	public PlayerBehavior playerScript;

	void Update()
	{
		if(playerScript.isJumping == true)
		{
			eau1.SetActive (false);
			eau2.SetActive (false);
			eauNiveau.SetActive (false);
			killingWater.SetActive (false);
			Plateformes.SetActive (false);
		}
		if(playerScript.isJumping == false)
		{
			eau1.SetActive (true);
			eau2.SetActive (true);
			eauNiveau.SetActive (true);
			killingWater.SetActive (true);
			Plateformes.SetActive (true);
		}
	}
}
