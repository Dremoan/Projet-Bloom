using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WaterKiller : MonoBehaviour {

	public Animator animPlayer;
	public PlayerBehavior playerScript;
	public SpriteRenderer flowerSprite;


	void OnTriggerEnter2D(Collider2D coll)
	{
		if(coll.gameObject.tag =="Player")
		{
			flowerSprite.enabled = false;
			playerScript.cancelMoves = true;
			animPlayer.Play ("CactusPlanche");
		}
	}

}
