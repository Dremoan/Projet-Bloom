using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasDyingPlayer : MonoBehaviour {

	public Animator animBlackScreen;
	public EjectingShockWave shockWaveScript;
	public GrenouilleBoss grenouilleScript;
	public PlayerBehavior playerScript;
	public SpriteRenderer flowerSprite;
	public Transform resetPos;


	void ReloadScene()
	{
		StartCoroutine (WaitBlackScreen ());
	}

	IEnumerator WaitBlackScreen()
	{
		yield return new WaitForSeconds (1f);
		playerScript.transform.position = resetPos.transform.position;
		animBlackScreen.Play ("ResetPlayerScreen");
		flowerSprite.enabled = true;
		playerScript.EnableMovements ();
		grenouilleScript.clampCamera = false;
	}
}
