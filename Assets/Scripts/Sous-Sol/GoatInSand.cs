using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoatInSand : MonoBehaviour {

	public Camera mainCamera;
	public GameObject player;
	public Animator animPlayer;
	public Animator animFlower;
	public Animator animGoatInSand;
	public Collider2D interactingZone;
	public GameObject flowerTarget;
	public GameObject interactZone;
	public GameObject[] lianeOnGoatPoints;

	[HideInInspector] public float launchAngle;
	[HideInInspector] public float goatDirAngle;
	[HideInInspector] public bool inTheAir;
	[HideInInspector] public bool isCharging;
	[HideInInspector] public bool isNearGoat = false;
	public float jumpMultiplier = 2000f;
	public float orthographicOffset = 200f;

	[HideInInspector] public Vector3 launchDir;
	private float jumpingForce = 0f;
	private bool isLaunching;
	private bool canZoom;

    private bool canPlayChargeSound = true;

	void Update () 
	{

		ChoosingAnchorPoint ();

		animFlower.SetFloat ("BoucAngleX", FindObjectOfType<GoatInSand> ().launchDir.x);
		animFlower.SetFloat ("BoucAngleY", FindObjectOfType<GoatInSand> ().launchDir.y);

		launchDir = transform.position - player.transform.position;
		goatDirAngle = Mathf.Atan2 (launchDir.x, launchDir.y) * Mathf.Rad2Deg + 180;




		animPlayer.SetBool ("IsCharging", isCharging);
		animPlayer.SetFloat ("LaunchingAngle", launchAngle);
		animPlayer.SetBool ("InTheAir", inTheAir);


		animFlower.SetBool ("IsCharging", isCharging);
		animFlower.SetFloat ("LaunchingAngle", launchAngle);
		animFlower.SetBool ("InTheAir", inTheAir);


		animGoatInSand.SetBool ("InTheAir", inTheAir);
		animGoatInSand.SetBool("IsNearGoat", isNearGoat);
		animGoatInSand.SetFloat("GoatDirAngle", goatDirAngle);

		if (interactZone.GetComponent<InteractingScript> ().canInteract) 
		{
			isNearGoat = true;
//			player.GetComponent<PlayerBehavior> ().canCharge= true;
		} 
		else if (interactZone.GetComponent<InteractingScript> ().canInteract == false) 
		{
			isNearGoat = false;
//			player.GetComponent<PlayerBehavior> ().canCharge = false;
		}

		if(inTheAir)
		{
			StartCoroutine(InactiveCollider ());
		}

		if(isNearGoat)
		{
			launchAngle = Mathf.Atan2 (launchDir.x, launchDir.y) * Mathf.Rad2Deg + 180;
		}

		if(canZoom)
		{
			mainCamera.orthographicSize = Mathf.Lerp (Camera.main.orthographicSize, 125f, Time.deltaTime * 2f);
		}
		if(isCharging && canPlayChargeSound)
		{
			FindObjectOfType<DialogueManagerSousSol> ().hasPlayDialog = true;
			canZoom = false;
			mainCamera.orthographicSize = Mathf.Lerp (Camera.main.orthographicSize, orthographicOffset, Time.deltaTime * 2f);
            FMODUnity.RuntimeManager.PlayOneShot("event:/Tension_lancepierre");
            canPlayChargeSound = false;
            StartCoroutine (Charging ());
		}
		if (jumpingForce >= 100) 
		{
			jumpingForce = 100f;
		}

		if(Input.GetMouseButtonDown(1) && isCharging)
		{
			FindObjectOfType<LaunchFlower> ().isHooked = false;
			FindObjectOfType<LaunchFlower> ().isLaunched = false;
			StartCoroutine (LaunchingCactus ());
		}

	}

	IEnumerator LaunchingCactus()
	{
		animFlower.SetFloat ("AngleFixeX", launchDir.x);
		animFlower.SetFloat ("AngleFixeY", launchDir.y);
		isNearGoat = false;
		isCharging = false;
		interactingZone.enabled = false;
        FMODUnity.RuntimeManager.PlayOneShot("event:/Lance_lancepierre");
		player.GetComponent<Rigidbody2D> ().AddForce (launchDir.normalized * jumpingForce* Time.deltaTime * jumpMultiplier, ForceMode2D.Impulse);
		animFlower.GetComponent<CircleCollider2D> ().enabled = false;
		jumpingForce = 0f;
		inTheAir = true;
		yield return new WaitForSeconds (0.25f);
		player.GetComponent<Collider2D> ().enabled = true;
		yield return new WaitForSeconds (0.25f);
		canZoom = true;
		player.GetComponent<PlayerBehavior> ().canJump = true;
		FindObjectOfType<LaunchFlower> ().canLaunch = true;
		player.GetComponent<PlayerBehavior> ().canLaunchAction = true;
		inTheAir = false;
		yield return new WaitForSeconds (0.5f);
		interactingZone.enabled = true;
        canPlayChargeSound = true;
	}


	IEnumerator InactiveCollider()
	{
		Physics2D.IgnoreCollision (flowerTarget.GetComponent<Collider2D> (), animFlower.GetComponent<Collider2D> (), ignore:true);
		yield return new WaitForSeconds (1f);
		Physics2D.IgnoreCollision (flowerTarget.GetComponent<Collider2D> (), animFlower.GetComponent<Collider2D> (), ignore:false);
	}

	IEnumerator Charging()
	{
		player.GetComponent<Rigidbody2D> ().velocity = Vector2.zero;
		player.GetComponent<PlayerBehavior> ().canJump = false;
		jumpingForce ++;
		player.GetComponent<Collider2D> ().enabled = false;
		interactingZone.enabled =false;
		yield return new WaitForSeconds (1f);
		interactingZone.enabled = true;
	}

	void ChoosingAnchorPoint()
	{
		if(launchAngle > 0 && launchAngle < 90)
		{
			lianeOnGoatPoints [0].SetActive (true);
			lianeOnGoatPoints [1].SetActive (true);
			lianeOnGoatPoints [2].SetActive (false);
			lianeOnGoatPoints [3].SetActive (false);
			lianeOnGoatPoints [4].SetActive (false);
			lianeOnGoatPoints [5].SetActive (false);
			lianeOnGoatPoints [6].SetActive (false);
			lianeOnGoatPoints [7].SetActive (false);
		}
		else if(launchAngle > 90 && launchAngle < 180)
		{
			lianeOnGoatPoints [0].SetActive (false);
			lianeOnGoatPoints [1].SetActive (false);
			lianeOnGoatPoints [2].SetActive (true);
			lianeOnGoatPoints [3].SetActive (true);
			lianeOnGoatPoints [4].SetActive (false);
			lianeOnGoatPoints [5].SetActive (false);
			lianeOnGoatPoints [6].SetActive (false);
			lianeOnGoatPoints [7].SetActive (false);
		}
		else if(launchAngle > 180 && launchAngle < 270)
		{
			lianeOnGoatPoints [0].SetActive (false);
			lianeOnGoatPoints [1].SetActive (false);
			lianeOnGoatPoints [2].SetActive (false);
			lianeOnGoatPoints [3].SetActive (false);
			lianeOnGoatPoints [4].SetActive (true);
			lianeOnGoatPoints [5].SetActive (true);
			lianeOnGoatPoints [6].SetActive (false);
			lianeOnGoatPoints [7].SetActive (false);
		}
		else if(launchAngle > 270 && launchAngle < 360)
		{
			lianeOnGoatPoints [0].SetActive (false);
			lianeOnGoatPoints [1].SetActive (false);
			lianeOnGoatPoints [2].SetActive (false);
			lianeOnGoatPoints [3].SetActive (false);
			lianeOnGoatPoints [4].SetActive (false);
			lianeOnGoatPoints [5].SetActive (false);
			lianeOnGoatPoints [6].SetActive (true);
			lianeOnGoatPoints [7].SetActive (true);
		}
	}
}

