using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerTransitionBoss : MonoBehaviour {

	public Animator animGrenouille;
	public Animator animBassin;
	public DetectionTimeline timelineScript;
	public float woodCount = 0;
	public float waitForTransitionBoss = 1.5f;
	public float waitForEmptyBassin = 2.5f;
	private bool canActiveTimeline = true;

	void Update()
	{
		if(woodCount > 8f && canActiveTimeline)
		{
			StartCoroutine (TimelineBassin ());
		}
	}


	IEnumerator TimelineBassin()
	{
		canActiveTimeline = false;
		timelineScript.EmptyBassinActive ();
		yield return new WaitForSeconds (waitForEmptyBassin);
		animBassin.Play ("EmptyGauche");
		yield return new WaitForSeconds (waitForTransitionBoss);
		animGrenouille.SetBool ("PlayCinematic", true);
        FindObjectOfType<MusicManagerBoss>().firstMusic.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        FindObjectOfType<MusicManagerBoss>().bossMusic.start();
	}
}
