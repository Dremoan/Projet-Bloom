using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenouilleBoss : MonoBehaviour {

	public PlayerBehavior playerScript;
	public Animator animGrenouille;
	public Camera mainCamera;
	public CameraBehavior cameraScript;
	public float countAttack = 0;
	public float tiredCount = 0;
	private bool tired;
	public float Xmax;
	public float Xmin;
	public float Ymax;
	public float Ymin;
	public bool clampCamera = false;


	void Update ()
	{
		animGrenouille.SetFloat ("CountAttack", countAttack);
		animGrenouille.SetBool ("Tired", tired);
		if(tiredCount > 5f)
		{
			tired = true;
            FMODUnity.RuntimeManager.PlayOneShot("event:/BOSS/SFX/BOSS_fatigue");
			tiredCount = 0;
		}

		if(clampCamera)
		{
			cameraScript.XMaxValue = Xmax;
			cameraScript.YMaxValue = Ymax;
			cameraScript.XMinValue = Xmin;
			cameraScript.YMinValue = Ymin;
		}
	}

	void ResetCount()
	{
		countAttack = 0;
	}

	void RandomCount()
	{
		countAttack = Random.Range (1, 4);
		tiredCount += 1;
        FMODUnity.RuntimeManager.PlayOneShot("event:/BOSS/SFX/BOSS_ATTACK");
	}

	void TiredFalse()
	{
		tired = false;
	}

	void OnTriggerEnter2D(Collider2D coll)
	{
		if(coll.gameObject.tag =="Player")
		{
			clampCamera = true;
			animGrenouille.SetBool ("Angry", true);
		}
	}

	void OnTriggerStay2D(Collider2D coll)
	{
		if(coll.gameObject.tag =="Player")
		{
			clampCamera = true;
			animGrenouille.SetBool ("Angry", true);
		}
	}

	void OnTriggerExit2D(Collider2D coll)
	{
		if(coll.gameObject.tag =="Player")
		{
			animGrenouille.SetBool ("Angry", false);
		}
	}
}
