using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoingDownStairs : MonoBehaviour {

	public GameObject goingUpStairs;
	public SpriteRenderer grapplinPlant;
	public BoxCollider2D colliderEscalier1;
	public BoxCollider2D colliderEscalier2;
	public GameObject colliderDown;
	public GameObject colliderUp;


	void OnTriggerEnter2D(Collider2D col)
	{
		if(col.gameObject.tag == "Player")
		{
			goingUpStairs.SetActive (true);
			this.gameObject.SetActive (false);
			colliderEscalier1.enabled = false;
			colliderEscalier2.enabled = false;
			colliderDown.SetActive (true);
			colliderUp.SetActive (false);
		}
	}
}
