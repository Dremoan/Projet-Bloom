using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StairButtonScript : MonoBehaviour {

	public GameObject player;
	public GameObject buttonStair1;
	public GameObject buttonStair2;
	public Animator animButtonStair;
	public bool isActive;
	private bool buttonPressed;

	void Update ()
	{
		if(buttonStair1.GetComponent<StairButtonScript>().isActive && buttonStair2.GetComponent<StairButtonScript>().isActive)
		{
			buttonPressed = true;
			float playerPosY = player.transform.position.y;
			playerPosY = playerPosY -15f;
		}
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if(col.gameObject.tag == "Player")
		{
			isActive = true;
			animButtonStair.SetBool ("ButtonPressed", buttonPressed);
		}
	}
}
