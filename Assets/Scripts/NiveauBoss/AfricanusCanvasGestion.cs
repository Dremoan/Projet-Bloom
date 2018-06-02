using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AfricanusCanvasGestion : MonoBehaviour {

	public AfricanusScript africaScript;

	void PlayCoroutineAfricanus()
	{
		StartCoroutine (africaScript.MovingAfricanus ());
	}

	void PlayCoroutineAfricanusOther()
	{
		StartCoroutine (africaScript.SpawnOnOther ());
	}

	void SpitTrue()
	{
		africaScript.GetComponent<Animator> ().Play ("AfricanusSpit");
	} 

}
