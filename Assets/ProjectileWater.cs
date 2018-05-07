using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileWater : Projectile
{
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
			DropManagerComponent.RemoveDrop (this);
		}
	}

	void OnTriggerEnter2D(Collider2D coll)
	{
		if(coll.gameObject.tag == "ModifyingZone")
		{
			coll.GetComponent<ModifyingZone> ().Modified ();
			DropManagerComponent.RemoveDrop (this);
		}
	}
}
