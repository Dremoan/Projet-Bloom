using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AfricanusCanvasGestion2 : MonoBehaviour {

	public AfricanusScript2 africaScript;

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
