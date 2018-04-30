using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonAnimation : MonoBehaviour {


	public ParticleSystem light1;
	public ParticleSystem light2;
	public ParticleSystem gerbe;
	public GameObject interrupteur;
	public Animator buttonAnim;
	private bool buttonPressed = false;


	void Start () 
	{
		
	}


	void Update () 
	{
		if(interrupteur.GetComponent<ButtonScript>().isActive)
		{
			buttonAnim.SetBool ("ButtonPressed", buttonPressed);
			buttonPressed = true;
			light1.Play ();
			light2.Play ();
			gerbe.Play ();
		}
	}
}
