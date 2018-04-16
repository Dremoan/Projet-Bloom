using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropManagerComponent : MonoBehaviour {


	public static DropManagerComponent globalDropManager;
	public Projectile[] projectilePool;

	void Start () 
	{
		globalDropManager = this;
	}


	public static void SpawnDrop(Vector3 position, float rot_Z)
	{
		for(int i = 0; i < globalDropManager.projectilePool.Length; i++)
		{
			if(globalDropManager.projectilePool[i].dispo)
			{
				globalDropManager.projectilePool[i].transform.position = position;
				globalDropManager.projectilePool [i].transform.rotation = Quaternion.Euler (0, 0, rot_Z);
				globalDropManager.projectilePool [i].gameObject.SetActive (true);
				globalDropManager.projectilePool [i].dispo = false;
				return;
			}
		}
	}

	public static void RemoveDrop(Projectile removedDrop)
	{
		removedDrop.gameObject.SetActive (false);
		removedDrop.dispo = true;
	}
}
