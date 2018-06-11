using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndBoss : MonoBehaviour {

	public string sceneName;
	public float timelineDuration;


	public void EndBossTimeline()
	{
		StartCoroutine(BossKilled());
	}

	IEnumerator BossKilled()
	{
		yield return new WaitForSeconds (timelineDuration);
		SceneManager.LoadScene (sceneName);
	}
}
