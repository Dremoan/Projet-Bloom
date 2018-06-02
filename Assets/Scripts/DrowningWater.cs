﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DrowningWater : MonoBehaviour {

	public EdgeCollider2D Plateforme;
	public EdgeCollider2D rive;
	public PolygonCollider2D eauCollider;
	public PlayerBehavior playerScript;

	void Update()
	{
		if(playerScript.isJumping == true)
		{
			eauCollider.enabled = false;
			Plateforme.enabled = false;
			rive.enabled = false;
		}
		if(playerScript.isJumping == false)
		{
			eauCollider.enabled = true;
			Plateforme.enabled = true;
			rive.enabled = true;
		}
	}
	void OnTriggerEnter2D(Collider2D coll)
	{
		if(coll.gameObject.tag == "Player")
		{
			SceneManager.LoadScene("Niveau1");
		}
	}
	void OnTriggerStay2D(Collider2D coll)
	{
		if(coll.gameObject.tag == "Player")
		{
			SceneManager.LoadScene("Niveau1");
		}
	}
}
