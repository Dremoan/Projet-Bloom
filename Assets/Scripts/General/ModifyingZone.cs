using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class ModifyingZone : MonoBehaviour 
{

	public bool modify = false;
	private bool hasShake;
	public Animator anim;

	void Start () 
	{
		
	}

	void Update () 
	{
		if (modify == true)
		{
			anim.SetBool ("Modify", modify);
		}
	}

	public void Modified()
	{
		modify = true;
	}
}
