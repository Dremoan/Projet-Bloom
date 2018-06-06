using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DrowningWater : MonoBehaviour {

	public EdgeCollider2D Plateforme;
	public GameObject rives;
	public GameObject eau1;
	public GameObject eau2;
	public PlayerBehavior playerScript;
	public string nameScene;

	void Update()
	{
		if(playerScript.isJumping == true)
		{
			eau1.SetActive (false);
			eau2.SetActive (false);
			Plateforme.enabled = false;
			rives.SetActive (false);
		}
		if(playerScript.isJumping == false)
		{
			eau1.SetActive (true);
			eau2.SetActive (true);
			Plateforme.enabled = true;
			rives.SetActive (true);
		}
	}
}
