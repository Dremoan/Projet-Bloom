using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoingUp : MonoBehaviour {

	public CameraBehavior mainCamera;
	public GameObject goatInSand;
	public GameObject player;
	public GameObject goingDown;
	public SpriteRenderer plateforme;
	public Collider2D highPlatform;
	public Collider2D ladderCollider;
	public Collider2D levelCollider;
	public float waitTime = 0.25f;
	public float YMinValueUp;
	public float XMaxValueUp = 200f;
	public bool isHigh = false;
	public bool XMinEnable;
	public bool XMaxEnable;

	void OnTriggerEnter2D (Collider2D coll)
	{
		if(coll.gameObject.tag == "Player" && !isHigh && goatInSand.GetComponent<GoatInSand>().inTheAir)
		{
			
			StartCoroutine (ActiveCollider ());
		}
	}

	IEnumerator ActiveCollider()
	{
		mainCamera.XMaxEnabled = XMaxEnable;
		mainCamera.XMinEnabled = XMinEnable;
		mainCamera.YMinValue = YMinValueUp;
		mainCamera.XMaxValue = XMaxValueUp;
		plateforme.sortingOrder -= 8;
		yield return new WaitForSeconds (waitTime);
		isHigh = true;
		highPlatform.enabled = true;
		levelCollider.enabled = false;
		ladderCollider.enabled = true;
		this.GetComponent<Collider2D> ().enabled = false;
		goingDown.GetComponent<Collider2D> ().enabled = true;
	}
}
