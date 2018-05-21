using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileRock : Projectile 
{
	public CircleCollider2D explosionArea;
	public float waitTillLaunch = 0.5f;
	private bool canExplode = true;

	protected override void Shoot()
	{
		StartCoroutine (ShootDelay ());
	}

	IEnumerator removeDrop()
	{
		yield return new WaitForSeconds (0.25f);
		GetComponent<PolygonCollider2D> ().enabled = true;
		explosionArea.enabled = false;
		yield return new WaitForSeconds (5f);
		GetComponent<PolygonCollider2D> ().enabled = false;
		canExplode = true;
		projectileBody.mass = 1;
		DropManagerComponent.RemoveDrop (this);
	}

	IEnumerator ShootDelay()
	{
		this.GetComponent<SpriteRenderer> ().sortingOrder = -4;
		yield return new WaitForSeconds (waitTillLaunch);
		if (needForce)
		{
			dirToTarget = targetPosition - launchPlace.transform.position;
			projectileBody.velocity = dirToTarget * shootSpeed * Time.fixedDeltaTime;
			needForce = false;
		}
		if(Vector3.Distance(transform.position, launchPlace.transform.position) > dirToTarget.magnitude && canExplode)
		{
			canExplode = false;
			projectileBody.velocity = Vector2.zero;
			projectileBody.mass = 100;
			explosionArea.enabled = true;
			StartCoroutine (removeDrop ());
		}
	}
}
