using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ExitCave : MonoBehaviour {

	public CinemachineVirtualCamera lookingPlayer;
	public Animator anim;
	public float dezoomAmount = 150f;
	public float increasingMultiplier = 2f;
	private bool canDezoom = false;

	void Update () 
	{
		if(canDezoom)
		{
			lookingPlayer.m_Lens.OrthographicSize += Time.deltaTime * increasingMultiplier;
		}

		if(lookingPlayer.m_Lens.OrthographicSize > dezoomAmount)
		{
			lookingPlayer.m_Lens.OrthographicSize = dezoomAmount;
		}
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "Player")
		{
			anim.Play ("ExitCave");
			canDezoom = true;
		}
	}

}
