using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class ButtonScript : MonoBehaviour {

	public GameObject player;
	public GameObject interrupteur1;
	public GameObject interrupteur2;
	public GameObject keyRock;
	public float waitBeforeSpawn = 1f;

	[HideInInspector ]public bool isActive;


	void Update ()
	{
		if(interrupteur1.GetComponent<ButtonScript>().isActive && interrupteur2.GetComponent<ButtonScript>().isActive)
		{
			StartCoroutine (RockActive ());
		}
	}


	void OnTriggerEnter2D(Collider2D col)
	{
		if(col.gameObject.Equals(player))
		{
			isActive = true;
		}
	}


	IEnumerator RockActive()
	{
		yield return new WaitForSeconds (waitBeforeSpawn);
		keyRock.SetActive (true);
	}
}
