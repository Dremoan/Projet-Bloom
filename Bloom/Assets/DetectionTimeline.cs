using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class DetectionTimeline : MonoBehaviour {


	public PlayableDirector timeline;
	private bool canPlayWaterSourceTimeline = true;
	public float timelineDuration;


	void Start () 
	{
		
	}

	void Update () 
	{
//		Debug.Log (canPlay);
		RockSlotActive ();
	}

//	void OnTriggerEnter2D(Collider2D col)
//	{
//		if(col.gameObject.tag == "Player" && canPlay)
//		{
//			timeline.Play ();
//			canPlay = false;
//		}
//	}
//

	void RockSlotActive()
	{
		if(FindObjectOfType<ActivationRock>().isActive && canPlayWaterSourceTimeline)
		{
			StartCoroutine (CancelMovements ());
			timeline.Play ();
			canPlayWaterSourceTimeline = false;
		}
	}



	IEnumerator CancelMovements()
	{
		FindObjectOfType<PlayerBehavior> ().body.velocity = Vector2.zero;
		FindObjectOfType<PlayerBehavior> ().isMoving = false;
		FindObjectOfType<PlayerBehavior> ().canJump = false;
		FindObjectOfType<PlayerBehavior> ().canMove = false;
		yield return new WaitForSeconds (timelineDuration);
		FindObjectOfType<PlayerBehavior> ().canJump = true;
		FindObjectOfType<PlayerBehavior> ().canMove = true;
	}
}
