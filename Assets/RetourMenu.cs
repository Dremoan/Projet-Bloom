using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class RetourMenu : MonoBehaviour {

	public PlayableDirector timeline;

	void Update () 
	{
		if(timeline.time > 59f)
		{
			SceneManager.LoadScene ("Menu");
		}
	}
}
