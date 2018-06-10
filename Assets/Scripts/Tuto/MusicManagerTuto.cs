using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManagerTuto : MonoBehaviour {

	public FMOD.Studio.EventInstance backgroundMusic;
	public FMOD.Studio.EventInstance bossMusic;
	public FMOD.Studio.ParameterInstance toSection2;
	public FMOD.Studio.ParameterInstance toSection3;
	public FMOD.Studio.ParameterInstance outGrotte;

	// Use this for initialization
	void Start () 
	{
		backgroundMusic = FMODUnity.RuntimeManager.CreateInstance ("event:/TUTO/MUSIC/Music");
		bossMusic = FMODUnity.RuntimeManager.CreateInstance ("event:/TUTO/MUSIC/Miniboss");
		backgroundMusic.start ();
		backgroundMusic.getParameter ("toSection2", out toSection2);
		backgroundMusic.getParameter ("toSection3", out toSection3);
		backgroundMusic.getParameter ("outGrotte", out outGrotte);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
