using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour 
{

	public float shootSpeed;
	public Rigidbody2D projectileBody;
	public Rigidbody2D launcher;
	public GameObject launchPlace;
	public GameObject target;
	public Vector3 targetPosition;
	[HideInInspector] public bool needForce = true;
	[HideInInspector] public bool dispo = true;

	protected Vector2 dirToTarget;


	void Update () 
	{
		//dirToTarget = target.transform.position - launchPlace.transform.position;
		dirToTarget = targetPosition - launchPlace.transform.position;
		Shoot ();
	}

	protected virtual void Shoot()
	{
		if (needForce)
		{
			projectileBody.velocity = dirToTarget * shootSpeed * Time.fixedDeltaTime;
			needForce = false;
		}

		if(Vector3.Distance(transform.position, launchPlace.transform.position) > dirToTarget.magnitude)
		{
			DropManagerComponent.RemoveDrop (this);
		}
	}

}
