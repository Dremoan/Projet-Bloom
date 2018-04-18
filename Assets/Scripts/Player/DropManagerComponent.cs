using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropManagerComponent : MonoBehaviour {


	public static DropManagerComponent globalDropManager;
	public Projectile[] WaterProjectilePool;
	public Projectile[] RockProjectilePool;

	void Start () 
	{
		globalDropManager = this;
	}


	public static void SpawnDropWater(Vector3 position, float rot_Z)
	{
		for(int i = 0; i < globalDropManager.WaterProjectilePool.Length; i++)
		{
			if(globalDropManager.WaterProjectilePool[i].dispo)
			{
				globalDropManager.WaterProjectilePool[i].transform.position = position;
				globalDropManager.WaterProjectilePool [i].transform.rotation = Quaternion.Euler (0, 0, rot_Z);
				globalDropManager.WaterProjectilePool [i].gameObject.SetActive (true);
				globalDropManager.WaterProjectilePool [i].dispo = false;
				return;
			}
		}
	}

	public static void SpawnDropRock(Vector3 position, float rot_Z)
	{
		for(int i = 0; i < globalDropManager.RockProjectilePool.Length; i++)
		{
			if(globalDropManager.RockProjectilePool[i].dispo)
			{
				globalDropManager.RockProjectilePool[i].transform.position = position;
				globalDropManager.RockProjectilePool [i].transform.rotation = Quaternion.Euler (0, 0, rot_Z);
				globalDropManager.RockProjectilePool [i].gameObject.SetActive (true);
				globalDropManager.RockProjectilePool [i].dispo = false;
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
