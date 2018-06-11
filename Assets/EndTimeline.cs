using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTimeline : MonoBehaviour {

	public Animator animFond;
	public Animator animFrax;
	public GameObject fraxinelle;
	public GameObject boisDroit;
	public float timelineDuration = 34f;

	void Start()
	{
		StartCoroutine (DelayTimeline ());
	}

	IEnumerator DelayTimeline()
	{
		yield return new WaitForSeconds(timelineDuration);
		animFond.Play("EauCouleDroite");
		animFrax.SetBool ("CanBurn", false);
		animFrax.SetBool ("GoToFireIdle", false);
		fraxinelle.SetActive (false);
		boisDroit.SetActive (false);
	}
}
