using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillingGrenouille : MonoBehaviour {

	public float killingCount;
	public Animator animGrenouille;
	public GrenouilleBoss scriptGrenouille;
	private bool canHit;
    private bool canPlaySound = true;

	void Update () 
	{

		if(FindObjectOfType<LaunchFlower>().onFrog == true)
		{
			canHit = true;
		}
		if(canHit && Input.GetMouseButtonDown(1))
		{
			canHit = false;
			killingCount += 1;
			FindObjectOfType<LaunchFlower> ().isHooked = false;
			FindObjectOfType<LaunchFlower> ().isLaunched = false;
			FindObjectOfType<LaunchFlower> ().isBacking = true;
			animGrenouille.SetBool ("Tired", false);
		}
		if(killingCount > 2f && canPlaySound)
		{
            FMODUnity.RuntimeManager.PlayOneShot("event:/BOSS/SFX/BOSS_MORT");
            canPlaySound = false;
			animGrenouille.SetBool ("Die", true);
			scriptGrenouille.clampCamera = false;
		}
	}
		
}
