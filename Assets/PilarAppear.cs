using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PilarAppear : MonoBehaviour 
{
	public ActivationRock activationRockScript;
	public Animator pilarAnim;

	void Update()
	{
		if(activationRockScript.isActive)
		{
			pilarAnim.Play ("PilarAppear");
		}
	}
}
