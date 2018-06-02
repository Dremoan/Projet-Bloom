using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour {

	public string sceneName;

	void Update()
	{


		if(Input.GetKeyDown(KeyCode.Escape))
		{
			SceneManager.LoadScene ("Menu");
		}
		if(Input.GetKeyDown(KeyCode.P))
		{
			LoadSceneMenu ();
		}
	}

	public void LoadSceneMenu()
	{
		SceneManager.LoadScene(sceneName);
	}
}
