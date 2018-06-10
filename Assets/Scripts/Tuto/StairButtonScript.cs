using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StairButtonScript : MonoBehaviour {

	public GameObject player;
	public GameObject buttonStair1;
	public GameObject buttonStair2;
	public GameObject gap;
	public GameObject grapplinPlant;
	public GameObject grapplinAnchor;
	public Animator animButtonStair;
	public Animator animStairs;
	public Animator animBigStairs;
	public Animator animPilarDestroyed;
	public Animator animBoss;

	// Particles Game Objects

	public GameObject lightWayBas;
	public GameObject lightWayHaut;
	public GameObject lightWayMid;
	public GameObject lightWayFinal;
	public GameObject goingDown;
	public ParticleSystem EtincellesHaut;
	public ParticleSystem EtincellesBas;

	public bool isActive;
	[HideInInspector] public bool activeTrails;
	private bool buttonPressed;
	private bool hasPlayedAnimations;
	private bool timeCanRun;
	private float timeToInactive = 0;
	public float timeMaxToInactive = 3f;
	public float animDestroyPilarTime;
	public float timeParticlesPlaying = 2f;

	void Update ()
	{
		if(activeTrails)
		{
			EtincellesBas.Play ();
			EtincellesHaut.Play ();
			lightWayBas.SetActive (true);
			lightWayHaut.SetActive (true);
		}
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
		if(col.gameObject.tag == "Player")
		{
			timeCanRun = false;
			isActive = true;
			buttonPressed = true;
		}
	}

	void OnTriggerStay2D(Collider2D col)
	{
		if(col.gameObject.tag == "Player")
		{
			isActive = true;
			buttonPressed = true;
		}
	}
	void OnTriggerExit2D(Collider2D col)
	{
		if(col.gameObject.tag == "Player" && !timeCanRun)
		{
			timeCanRun = true;
		}
	}


	IEnumerator DelayActivation()
	{
		FindObjectOfType<BossCamera> ().canPrintHelpButtons = false;
		FindObjectOfType<BossCamera> ().canvasBossButtons.SetActive (false);
		hasPlayedAnimations = true;
		yield return new WaitForSeconds (0.85f);
		gap.SetActive (false);
		goingDown.SetActive (false);
		grapplinPlant.GetComponent<GrapplinScriptStairs> ().canSetActiveCollider = false;
		buttonStair1.GetComponent<SpriteRenderer> ().enabled = false;
		buttonStair2.GetComponent<SpriteRenderer> ().enabled = false;
		grapplinPlant.GetComponent<Rigidbody2D>().transform.Translate(0, -15f, 0);
		player.GetComponent<Rigidbody2D> ().transform.Translate (0, -15f, 0);
		player.GetComponent<Rigidbody2D> ().velocity = Vector2.zero;
		grapplinPlant.GetComponent<Rigidbody2D> ().velocity = Vector2.zero;
		grapplinAnchor.SetActive (false);
        FindObjectOfType<MusicManagerTuto>().backgroundMusic.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        FindObjectOfType<MusicManagerTuto>().bossMusic.start();
        FindObjectOfType<PlayerBehavior> ().EnableMovements ();
		activeTrails = true;
		yield return new WaitForSeconds (timeParticlesPlaying);
		lightWayMid.SetActive (true);
		yield return new WaitForSeconds (1f);
		lightWayFinal.SetActive (true);
		yield return new WaitForSeconds (1.75f);
		animBigStairs.SetBool ("IsActive", true);
		yield return new WaitForSeconds (0.5f);
		animPilarDestroyed.SetBool ("IsDestroying", true);
		yield return new WaitForSeconds (animDestroyPilarTime);
		animBoss.SetBool("LaunchIdle", true);
		yield return new WaitForSeconds (0.8f);
//		animBoss.SetBool ("IsHit", false);
		FindObjectOfType<RockBoss> ().enabled = true;
	}
}
