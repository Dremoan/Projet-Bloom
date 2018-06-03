using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoingDown : MonoBehaviour 
{
	public CameraBehavior mainCamera;
	public GameObject player;
	public GameObject goatInSand;
	public GameObject goingUp;
	public SpriteRenderer plateforme;
	public Collider2D highPlatform;
	public Collider2D ladderCollider;
	public Collider2D levelCollider;
	public float waitTime = 0.25f;
	public float YMinValueDown;
	public bool XMinEnable;
	public bool XMaxEnable;



	void OnTriggerEnter2D (Collider2D coll)
	{
		if (coll.gameObject.tag == "Player" && goingUp.GetComponent<GoingUp>().isHigh && goatInSand.GetComponent<GoatInSand>().inTheAir == false) 
		{
			StartCoroutine (ActiveCollider ());
		}
	}

	IEnumerator ActiveCollider()
	{
//		marcheSpit.sortingOrder -= 8;
//		shadow.GetComponent<SpriteRenderer> ().sortingOrder -= 8;
//		liane.GetComponent<SpriteRenderer> ().sortingOrder -= 8;
//		player.GetComponent<SpriteRenderer> ().sortingOrder -= 8;
//		flower.GetComponent<SpriteRenderer> ().sortingOrder -= 8;
		mainCamera.XMaxEnabled = XMaxEnable;
		mainCamera.XMinEnabled = XMinEnable;
		mainCamera.YMinValue = YMinValueDown;
		plateforme.sortingOrder += 8;
		yield return new WaitForSeconds (waitTime);
		goingUp.GetComponent<GoingUp>().isHigh = false;
		highPlatform.enabled = false;
		levelCollider.enabled = true;
		ladderCollider.enabled = false;
		this.GetComponent<Collider2D> ().enabled = false;
		goingUp.GetComponent<Collider2D> ().enabled = true;
	}
}
