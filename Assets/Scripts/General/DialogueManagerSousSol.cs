using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManagerSousSol : MonoBehaviour
{
	public float waitTime;
	public GameObject dialogZone;
	public bool delayAppear;
	public PlayerBehavior playerScript;
	public GoatInSand goatScript;
	public bool hasPlayDialog;

	void Update()
	{
		if(delayAppear)
		{
			StartCoroutine (WaitAppearDialogZone ());
		}

		if(hasPlayDialog)
		{
			delayAppear = false;
		}

		if(goatScript.isNearGoat)
		{
			delayAppear = true;
		}

	}
	IEnumerator WaitAppearDialogZone()
	{
		yield return new WaitForSeconds (waitTime);
		if (!hasPlayDialog)
		{
			dialogZone.SetActive (true);
			delayAppear = false;
		}
	}



}
