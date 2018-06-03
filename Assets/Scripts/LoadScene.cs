using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour {

	public string sceneName;
	public Animator animBlackScreen;

	void Update()
	{
		
		if(Input.GetKeyDown(KeyCode.Escape))
		{
			SceneManager.LoadScene ("Menu");
		}
	}

	public void LoadNextScene()
	{
		SceneManager.LoadScene(sceneName);
	}

	void OnTriggerEnter2D(Collider2D coll)
	{
		animBlackScreen.Play ("Transition");
	}
}
