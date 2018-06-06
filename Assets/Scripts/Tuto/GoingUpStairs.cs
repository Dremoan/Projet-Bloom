using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoingUpStairs : MonoBehaviour {

	public GameObject goingDownStairs;
	public SpriteRenderer grapplinPlant;
	public BoxCollider2D colliderEscalier1;
	public BoxCollider2D colliderEscalier2;
	public GameObject colliderDown;
	public GameObject colliderUp;


	void OnTriggerEnter2D(Collider2D col)
	{
		if(col.gameObject.tag == "Player")
		{
			goingDownStairs.SetActive (true);
			this.gameObject.SetActive (false);
			colliderEscalier1.enabled = true;
			colliderEscalier2.enabled = true;
			colliderDown.SetActive (false);
			colliderUp.SetActive (true);
		}
	}
}
