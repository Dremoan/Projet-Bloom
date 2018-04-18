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
	[HideInInspector]public bool dispo = true;

	private Vector2 dirToTarget;


	void Update () 
	{
		dirToTarget = target.transform.position - launchPlace.transform.position;
		Shoot ();
	}

	void Shoot()
	{
		projectileBody.velocity = dirToTarget * shootSpeed * Time.fixedDeltaTime;
		if(Vector3.Distance(transform.position, launchPlace.transform.position) > dirToTarget.magnitude)
		{
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
