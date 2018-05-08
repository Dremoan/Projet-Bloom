using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class ModifyingZone : MonoBehaviour 
{

	public bool modify = false;
	private bool hasShake;
	public Animator anim;

    [FMODUnity.EventRef]
    public string inputsound;

	void Update () 
	{
		if (modify == true)
		{
			anim.SetBool ("Modify", modify);
		}
	}

	public void Modified()
	{
        FMODUnity.RuntimeManager.PlayOneShot(inputsound);
		modify = true;
	}
}
