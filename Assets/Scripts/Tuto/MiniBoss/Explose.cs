using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explose : MonoBehaviour {

	private Vector2 dirToRepulse;
//	public GameObject targetSprite;
	public GameObject player;
	public float repulseForce;


	void Update () 
	{
		dirToRepulse = player.transform.position - transform.position;
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "Player")
		{
			StartCoroutine (Explosion());
		}
	}

	IEnumerator Explosion()
	{
		player.GetComponent<PlayerBehavior> ().CancelMovements ();
		player.GetComponent<Rigidbody2D> ().velocity = Vector2.zero;
		player.GetComponent<Rigidbody2D> ().AddForce (dirToRepulse.normalized * repulseForce * Time.fixedDeltaTime, ForceMode2D.Impulse);
		yield return new WaitForSeconds (0.25f);
		FindObjectOfType<ProjectileRock> ().explosionArea.enabled = false;
		player.GetComponent<PlayerBehavior> ().EnableMovements ();
	}
}
