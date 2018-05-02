using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PilarAppear : MonoBehaviour 
{
	public ActivationRock activationRockScript;
	public Animator pilarAnim;
	public BoxCollider2D holeCollider;

	void Update()
	{
		if(activationRockScript.isActive)
		{
			pilarAnim.Play ("PilarAppear");
			holeCollider.enabled = false;
		}
	}
}
