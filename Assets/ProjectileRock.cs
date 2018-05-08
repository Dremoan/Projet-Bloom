using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileRock : Projectile 
{
	public CircleCollider2D explosionArea;
	public float waitTillLaunch = 0.01f;
	
	protected override void Shoot()
	{
		StartCoroutine (ShootDelay ());
	}


	IEnumerator removeDrop()
	{
		yield return new WaitForSeconds (5f);
		DropManagerComponent.RemoveDrop (this);
	}

	IEnumerator ShootDelay()
	{
		yield return new WaitForSeconds (waitTillLaunch);
		if (needForce)
		{
			dirToTarget = targetPosition - launchPlace.transform.position;
			projectileBody.velocity = dirToTarget * shootSpeed * Time.fixedDeltaTime;
			needForce = false;
		}
		if(Vector3.Distance(transform.position, launchPlace.transform.position) > dirToTarget.magnitude)
		{
			projectileBody.velocity = Vector2.zero;
			StartCoroutine (removeDrop ());
		}
	}
}
