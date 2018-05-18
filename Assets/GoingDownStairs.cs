using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoingDownStairs : MonoBehaviour {

	public GameObject goingUpStairs;
	public SpriteRenderer grapplinPlant;



	void OnTriggerEnter2D(Collider2D col)
	{
		if(col.gameObject.tag == "Player")
		{
			goingUpStairs.SetActive (true);
			grapplinPlant.sortingOrder += 10;
			this.gameObject.SetActive (false);
		}
	}
}
