using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasDyingPlayer : MonoBehaviour {

	public PlayerBehavior playerScript;


	void ReloadScene()
	{
		StartCoroutine (WaitBlackScreen ());
	}

	IEnumerator WaitBlackScreen()
	{
		yield return new WaitForSeconds (1.5f);
		playerScript.gameObject.transform.position = playerScript.jumpPos;
		GetComponent<Animator> ().Play ("EmptyingBlackPlayer");
	}
}
