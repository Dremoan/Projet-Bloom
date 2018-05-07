using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class DetectionTimeline : MonoBehaviour {


	public PlayableDirector timeline;
	private bool canPlay =true;


	void Start () 
	{
		
	}

	void Update () 
	{
		
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if(col.gameObject.tag == "Player" && canPlay)
		{
			timeline.Play ();
			canPlay = false;
		}
	}
}
