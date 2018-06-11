using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionTimeline : MonoBehaviour {

	public string sceneName;
	public float timelineDuration;

	void Update()
	{
		EndBossTimeline ();
	}
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