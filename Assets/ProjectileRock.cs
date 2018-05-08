using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileRock : Projectile 
{
	public CircleCollider2D explosionArea;
	public float waitTillLaunch = 0.5f;
	private bool canExplode = true;
	public Animator bossAnim;


	protected override void Shoot()
	{
		StartCoroutine (ShootDelay ());
	}

	IEnumerator removeDrop()
	{
		yield return new WaitForSeconds (0.25f);
		explosionArea.enabled = false;
		yield return new WaitForSeconds (5f);
		canExplode = true;
		projectileBody.mass = 1;
		DropManagerComponent.RemoveDrop (this);
	}

	IEnumerator ShootDelay()
	{
		yield return new WaitForSeconds (waitTillLaunch);
		if (needForce)
		{
			bossAnim.Play ("MiniBossLaunch");
			dirToTarget = targetPosition - launchPlace.transform.position;
			projectileBody.velocity = dirToTarget * shootSpeed * Time.fixedDeltaTime;
			needForce = false;
		}
		if(Vector3.Distance(transform.position, launchPlace.transform.position) > dirToTarget.magnitude && canExplode)
		{
			canExplode = false;
			projectileBody.velocity = Vector2.zero;
			projectileBody.mass = 100;
			GetComponent<PolygonCollider2D> ().enabled = true;
			explosionArea.enabled = true;
			StartCoroutine (removeDrop ());
		}
	}
}
