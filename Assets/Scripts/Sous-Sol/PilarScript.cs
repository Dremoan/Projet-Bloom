using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class PilarScript : MonoBehaviour {

	public ModifyingZone colliderGauche;
	public ModifyingZone colliderDroit;
	private bool hasShake = false;

	void Update () 
	{
		if (colliderDroit.modify == true && !hasShake)
		{
			StartCoroutine (ShakeCamera ());
		}
		if (colliderGauche.modify == true && !hasShake)
		{
			StartCoroutine (ShakeCamera ());
		}
	}

	IEnumerator ShakeCamera()
	{
		CameraShaker.Instance.ShakeOnce (2f, 5f, 0.05f, 0.05f);
		yield return new WaitForSeconds (0.25f);
		CameraShaker.Instance.ShakeOnce (4f, 5f, 0.05f, 0.15f);
		yield return new WaitForSeconds (0.1f);
		CameraShaker.Instance.ShakeOnce (2f, 1f, 0.1f, 0.1f);
		hasShake = true;
	}
}
