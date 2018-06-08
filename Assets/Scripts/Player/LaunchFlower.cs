using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchFlower : MonoBehaviour {

	public GameObject player;
	public GameObject liane;
	public GoatInSand goatInSandScript;
	public Animator animFlower;
	public Transform flowerPlace;
	public Transform lianePlace;
	public Rigidbody2D bodyFlower;
	public Rigidbody2D bodyPlayer;
	public float flowerSpeed = 10f;
	public float flowerSpeedBack = 20f;
	public float maxDistanceToFlower = 125f;
	public float maxDistanceToFlowerOffset = 25f;
	public float hookTime = 2f;
	public bool canLaunch = false;
	public bool hitGoat = false;
	public bool holdsWater = false;
	[HideInInspector] public bool isLaunched = false;
	[HideInInspector] public bool isBacking = false;
	[HideInInspector] public bool isHooked = false;

	[HideInInspector] public bool onBlockingRock = false;
	[HideInInspector] public bool onGrapplinSpot = false;
	[HideInInspector] public bool onLaunchingRock = false;


	private Vector3 launchDir;
	private float angleLaunch;
	private Vector3 mousePos;
	private GameObject hookedThing;
	private bool lianeActive = false;
	private bool onWater = false;


	void Update () 
	{
		mousePos = Camera.main.ScreenToWorldPoint (Input.mousePosition) - transform.position;
		launchDir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - player.transform.position;
		angleLaunch = Mathf.Atan2 (launchDir.x, launchDir.y) * Mathf.Rad2Deg +180;
		OnWater ();
		FlowerLaunch ();
		Launch ();
		Animations ();
	}




	public void Launch()
	{
		if (lianeActive) 
		{
			StartCoroutine (lianeSprite ());
		}
			
		if(Input.GetMouseButtonDown(0) && !isLaunched && !isBacking && !isHooked && canLaunch)
		{
			animFlower.SetBool ("Launched", true);
			player.GetComponent<PlayerBehavior> ().canLaunchAction = false;
			canLaunch = false;
			this.GetComponent<CircleCollider2D> ().enabled = true;
			liane.SetActive (true);
			lianeActive = true;
			bodyFlower.velocity = mousePos.normalized * flowerSpeed * Time.fixedDeltaTime;
			isLaunched = true;
		}
		if (maxDistanceToFlower < Vector2.Distance (player.transform.position, transform.position))
			{
				isLaunched = false;
				isBacking = true;
			}
	}
		

	private void FlowerLaunch()
	{
		if(!isLaunched && !isBacking && !isHooked)
		{
			transform.position = flowerPlace.position;
		}

		if(isBacking)
		{
			Back ();
		}



		if(maxDistanceToFlower < Vector2.Distance(player.transform.position, transform.position))
		{
			isLaunched = false;
			isBacking = true;
		}


		if(hookedThing!= null && isHooked)
		{
			HookEnemy (hookedThing);
		}



		if(Vector2.Distance(player.transform.position, transform.position) > maxDistanceToFlower + maxDistanceToFlowerOffset && isHooked)
		{
			isLaunched = false;
			isHooked = false;
			isBacking = true;
		}
	}


	private void OnWater()
	{
		if(onWater && Input.GetMouseButtonDown(1))
		{
			FindObjectOfType<PlayerBehavior> ().canLaunchAction = true;
			onWater = false;
			holdsWater = true;
			isHooked = false;
			isBacking = true;
		}
	}


	IEnumerator hookDelay()
	{
		yield return new WaitForSeconds (hookTime);
		isHooked = false;
		isBacking = true;
	}


	IEnumerator lianeSprite()
	{
		liane.GetComponent<SpriteRenderer> ().size = Vector2.zero;
		yield return new WaitForSeconds (0.1f);
		Vector2 dirToFlower = lianePlace.transform.position - transform.position;
		float rot_Z = Mathf.Atan2 (dirToFlower.y, dirToFlower.x) * Mathf.Rad2Deg;
		liane.transform.rotation = Quaternion.Euler (0f, 0f, rot_Z - 90f);
		liane.GetComponent<SpriteRenderer> ().size = new Vector2 (3, Vector2.Distance (lianePlace.transform.position, transform.position));
	}
		

	public void Back()
	{
		animFlower.SetBool ("Launched", false);
		Vector2 dirToPlace = flowerPlace.transform.position - transform.position;
		bodyFlower.velocity = dirToPlace.normalized * flowerSpeedBack * Time.fixedDeltaTime;
		if(Vector2.Distance(player.transform.position, transform.position) < 20f)
		{
			canLaunch = true;
			this.GetComponent<CircleCollider2D> ().enabled = false;
			liane.SetActive (false);
			lianeActive = false;
			isBacking = false;
			isHooked = false;
			isLaunched = false;
			player.GetComponent<PlayerBehavior> ().canLaunchAction = true;
		}
	}


	public void HookEnemy(GameObject hookThing)
	{
		transform.position = hookThing.transform.position;
	}
		

	void Animations()
	{
		animFlower.SetFloat ("Horizontal", Input.GetAxisRaw ("Horizontal"));
		animFlower.SetFloat ("Vertical", Input.GetAxisRaw ("Vertical"));
		animFlower.SetFloat ("AngleLaunchX", angleLaunch);
		animFlower.SetFloat ("LastMoveX", player.GetComponent<PlayerBehavior> ().lastMove.x);
		animFlower.SetFloat ("LastMoveY", player.GetComponent<PlayerBehavior> ().lastMove.y);
		animFlower.SetBool ("IsMoving", player.GetComponent<PlayerBehavior>().isMoving);
	}


	void OnTriggerEnter2D(Collider2D coll)
	{
		if (coll.gameObject.tag == "WaterSource" && isLaunched && holdsWater == false)
		{
            FMODUnity.RuntimeManager.PlayOneShot("event:/FLEUR_TOMBE_EAU");
			isHooked = true;
			hookedThing = coll.gameObject;
			onWater = true;
			FindObjectOfType<PlayerBehavior> ().canLaunchAction = false;
			animFlower.SetBool ("Launched", false);
		}
		if(coll.gameObject.tag == "FlowerTarget")
		{
			goatInSandScript.isCharging = true;
			lianeActive = false;
			hitGoat = true;
			isBacking = false;
			isHooked = false;
			isLaunched = false;
			animFlower.SetBool ("Launched", false);
			FindObjectOfType<PlayerBehavior> ().canLaunchAction = false;
		}
		if(coll.gameObject.tag == "BlockingRock")
		{
			FindObjectOfType<CanvasGestion> ().activeFirstImage = false;
			FindObjectOfType<CanvasGestion> ().activeSecondImage = true;
			isHooked = true;
			hookedThing = coll.gameObject;
			onBlockingRock = true;
		}
		if(coll.gameObject.tag == "GrapplinSpot")
		{
			isHooked = true;
			hookedThing = coll.gameObject;
			onGrapplinSpot = true;
			animFlower.SetBool ("Launched", false);
		}
		if(coll.gameObject.tag == "RockToLaunch")
		{
			FindObjectOfType<FrondeScript> ().hookedRock = coll.gameObject;
			FindObjectOfType<FrondeScript> ().colliderRock = coll.GetComponent<PolygonCollider2D> ();
			isHooked = true;
			hookedThing = coll.gameObject;
			onLaunchingRock = true;
		}
		if(coll.gameObject.tag == "Africanus")
		{
			isHooked = true;
			hookedThing = coll.gameObject.GetComponent<AfricanusScript> ().mouthPlace.gameObject;
			player.GetComponent<Collider2D> ().enabled = false;
			FindObjectOfType<AfricanusScript> ().touchedFlower = true;
		}
		if(coll.gameObject.tag == "Africanus2")
		{
			isHooked = true;
			hookedThing = coll.gameObject.GetComponent<AfricanusScript2> ().mouthPlace.gameObject;
			player.GetComponent<Collider2D> ().enabled = false;
			FindObjectOfType<AfricanusScript2> ().touchedFlower = true;
		}
		if(coll.gameObject.tag == "AfricanusSecret")
		{
			isHooked = true;
			hookedThing = coll.gameObject.GetComponent<AfricanusScriptSecret> ().mouthPlace.gameObject;
			player.GetComponent<Collider2D> ().enabled = false;
			FindObjectOfType<AfricanusScriptSecret> ().touchedFlower = true;
		}
		if(coll.gameObject.tag == "Africanus3")
		{
			isHooked = true;
			hookedThing = coll.gameObject.GetComponent<AfricanusScript3> ().mouthPlace.gameObject;
			player.GetComponent<Collider2D> ().enabled = false;
			FindObjectOfType<AfricanusScript3> ().touchedFlower = true;
		}
	}
		

}
