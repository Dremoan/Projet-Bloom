using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StairButtonScript : MonoBehaviour {

	public GameObject player;
	public GameObject buttonStair1;
	public GameObject buttonStair2;
	public GameObject gap;
	public GameObject grapplinPlant;
	public Animator animButtonStair;
	public Animator animStairs;
	public bool isActive;
	private bool buttonPressed;
	private bool hasPlayedAnimations;
	private bool timeCanRun;
	private float timeToInactive = 0;
	public float timeMaxToInactive = 3f;

	void Update ()
	{
		
		if(timeCanRun)
		{
			timeToInactive += Time.deltaTime;
		}
		if(timeToInactive > timeMaxToInactive)
		{
			timeToInactive = 0;
			buttonPressed = false;
			timeCanRun = false;
			isActive = false;
		}
		animButtonStair.SetBool ("ButtonPressed", buttonPressed);
		if(buttonStair1.GetComponent<StairButtonScript>().isActive && buttonStair2.GetComponent<StairButtonScript>().isActive && !hasPlayedAnimations)
		{
			animStairs.SetBool ("IsActive", true);
			FindObjectOfType<PlayerBehavior> ().CancelMovements ();
			StartCoroutine (DelayActivation ());
		}
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if(col.gameObject.tag == "Player" && !timeCanRun)
		{
			timeCanRun = true;
			isActive = true;
			buttonPressed = true;
		}
	}

	IEnumerator DelayActivation()
	{
		float grapplinPlantY = grapplinPlant.transform.position.y;
		hasPlayedAnimations = true;
		yield return new WaitForSeconds (0.85f);
		gap.SetActive (false);
		buttonStair1.GetComponent<SpriteRenderer> ().enabled = false;
		buttonStair2.GetComponent<SpriteRenderer> ().enabled = false;
		grapplinPlant.GetComponent<Rigidbody2D>().transform.Translate(0, -15f, 0);
		player.GetComponent<Rigidbody2D> ().transform.Translate (0, -15f, 0);
		player.GetComponent<Rigidbody2D> ().velocity = Vector2.zero;
		grapplinPlant.GetComponent<Rigidbody2D> ().velocity = Vector2.zero;
		FindObjectOfType<PlayerBehavior> ().EnableMovements ();
	}
}
