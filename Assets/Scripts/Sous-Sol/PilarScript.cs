using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class PilarScript : MonoBehaviour {

	public ModifyingZone colliderGauche;
	public ModifyingZone colliderDroit;
	public GameObject dialogPilar;

	void Update () 
	{
		if (colliderDroit.modify == true || colliderGauche.modify == true)
		{
			dialogPilar.SetActive (false);
		}
	}

}
