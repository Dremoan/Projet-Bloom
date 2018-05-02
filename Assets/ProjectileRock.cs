using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileRock : Projectile 
{
	public CircleCollider2D explosionArea;
	
	protected override void Shoot()
	{
		if (needForce)
		{
			projectileBody.velocity = dirToTarget * shootSpeed * Time.fixedDeltaTime;
			needForce = false;
		}
		if(Vector3.Distance(transform.position, launchPlace.transform.position) > dirToTarget.magnitude)
		{
			projectileBody.velocity = Vector2.zero;
			StartCoroutine (removeDrop ());
		}
	}


	IEnumerator removeDrop()
	{
		yield return new WaitForSeconds (5f);
		this.gameObject.SetActive (false);
		this.dispo = true;
		needForce = true;
	}
}
