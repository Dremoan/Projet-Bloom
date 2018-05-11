using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class ButtonScript : MonoBehaviour {

	public GameObject player;
	public GameObject interrupteur1;
	public GameObject interrupteur2;
	public GameObject keyRock;
	public Animator animKeyRock;
	public float waitBeforeSpawn = 0.5f;

	[HideInInspector ]public bool isActive;


	void Update ()
	{
		if(interrupteur1.GetComponent<ButtonScript>().isActive && interrupteur2.GetComponent<ButtonScript>().isActive)
		{
			FindObjectOfType<CanvasGestion> ().InstructionsPilarInactive ();
			FindObjectOfType<ActivationRock> ().hasPrintHelp = false;
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
		yield return new WaitForSeconds (0.6f);
		animKeyRock.Play ("KeyRockAppear");
		yield return new WaitForSeconds (waitBeforeSpawn);
		keyRock.SetActive (true);
	}
}
