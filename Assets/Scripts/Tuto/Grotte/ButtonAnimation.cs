using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonAnimation : MonoBehaviour {


	public ParticleSystem light1;
	public ParticleSystem light2;
	public ParticleSystem gerbe;
	public GameObject interrupteur;
	public GameObject keyRock;
	public Animator buttonAnim;
	private bool buttonPressed = false;
	private bool canPlayParticles = true;
    private bool canPlaySound = true;


	void Update () 
	{
		var light1main = light1.main;
		var light2main = light2.main;
		var gerbemain = gerbe.main;

        if(interrupteur.GetComponent<ButtonScript>().isActive && canPlaySound)
        {
            canPlaySound = false;
            FMODUnity.RuntimeManager.PlayOneShot("event:/switches");
        }

		if(interrupteur.GetComponent<ButtonScript>().isActive && canPlayParticles)
		{
			buttonAnim.SetBool ("ButtonPressed", buttonPressed);
			buttonPressed = true;
			light1.Play ();
			light2.Play ();
			gerbe.Play ();
		}

		if(keyRock.activeInHierarchy)
		{
			canPlayParticles = false;
			light1main.loop = false;
			light2main.loop = false;
			gerbemain.loop = false;
		}
	}
}
