using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoingUpStairs : MonoBehaviour {

	public GameObject goingDownStairs;
	public SpriteRenderer grapplinPlant;


	void OnTriggerEnter2D(Collider2D col)
	{
		if(col.gameObject.tag == "Player")
		{
			goingDownStairs.SetActive (true);
			grapplinPlant.sortingOrder -= 10;
			this.gameObject.SetActive (false);
		}
	}
}
