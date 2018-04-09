using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explose : MonoBehaviour {

	private Vector2 dirToRepulse;
	public GameObject player;
	public float repulseForce;

	void Start ()
	{
		
	}

	void Update () 
	{
		Debug.Log (player.GetComponent<PlayerBehavior> ().canMove);
		dirToRepulse = player.transform.position - transform.position;
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if(col.gameObject.tag =="Player")
		{
			player.GetComponent<Rigidbody2D> ().velocity = Vector2.zero;
			player.GetComponent<Rigidbody2D> ().AddForce (dirToRepulse.normalized * repulseForce * Time.fixedDeltaTime, ForceMode2D.Impulse);

		}
	}
}
