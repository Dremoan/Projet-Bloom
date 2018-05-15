using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrapplinScript : MonoBehaviour {

	public ModifyingZone modifyScript;
	public GameObject gap;
	public LaunchFlower flowerScript;
	public Rigidbody2D playerBody;
	public float grapplinSpeed = 0;
	private Vector3 dirToFlower;
	void Update () 
	{
		if(flowerScript.onGrapplinSpot && Input.GetMouseButtonDown(1))
		{
			FindObjectOfType<GrapplinInstructions> ().DisableDownArrow ();
			gap.SetActive (false);
				StartCoroutine(Grapplin());
		}
	}

	IEnumerator Grapplin()
	{
		flowerScript.transform.position = this.transform.position;
		dirToFlower = flowerScript.transform.position - playerBody.transform.position;
		playerBody.velocity = Vector2.zero;
		FindObjectOfType<PlayerBehavior> ().CancelMovements ();
		playerBody.velocity = dirToFlower.normalized * grapplinSpeed * Time.fixedDeltaTime;
		yield return new WaitForSeconds (0.75f);
		playerBody.velocity = Vector2.zero;
		yield return new WaitForSeconds (0.25f);
		flowerScript.isHooked = false;
		flowerScript.isBacking = true;
		flowerScript.onGrapplinSpot = false;
		FindObjectOfType<PlayerBehavior> ().EnableMovements ();
		gap.SetActive (false);
		this.GetComponent<BoxCollider2D> ().enabled = false;
		yield return new WaitForSeconds (0.25f);
		this.GetComponent<BoxCollider2D> ().enabled = true;
		gap.SetActive (true);

	}
}
