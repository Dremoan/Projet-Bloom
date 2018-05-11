using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class ActivationRock : MonoBehaviour {

	public GameObject keyRock;
	public GameObject keyRockPlace;
	public Animator anim;
	public bool isActive = false;
	private bool hasShake;
	[HideInInspector] public bool hasPrintHelp;
	private float timeToPrintHelp = 0;



	void Update () 
	{
		anim.SetBool ("IsActive", isActive);

		if (!hasPrintHelp && !isActive) 
		{
			timeToPrintHelp += Time.deltaTime;
		}

		if(timeToPrintHelp> 12.5f && !hasPrintHelp)
		{
			hasPrintHelp = true;
			FindObjectOfType<CanvasGestion> ().PushRockHelp ();
			timeToPrintHelp = 0f;
		}
	}

	void OnTriggerEnter2D(Collider2D coll)
	{
		if(coll.gameObject.Equals(keyRock) && !hasShake)
		{
			isActive = true;
            FMODUnity.RuntimeManager.PlayOneShot("event:/IMPACT_DOOR");
			ShakeCamera ();
			keyRock.transform.position = keyRockPlace.transform.position;
			keyRock.GetComponent<Rigidbody2D> ().velocity = Vector2.zero;
			keyRock.GetComponent<Rigidbody2D> ().isKinematic = true;
			FindObjectOfType<CanvasGestion> ().PushRockHelpInactive ();
			FindObjectOfType<CanvasGestion> ().InstructionsPilarInactive ();
			FindObjectOfType<CanvasGestion> ().TalkAreaJumpActive ();
		}
	}


	void ShakeCamera()
	{
		CameraShaker.Instance.ShakeOnce (1f, 10f, 0.5f, 0.5f);
		hasShake = true;
	}
}