using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManagerLvl1 : MonoBehaviour {

    public FMOD.Studio.EventInstance backgroundMusic;
    public FMOD.Studio.EventInstance secretMusic;

	// Use this for initialization
	void Start () {
        backgroundMusic = FMODUnity.RuntimeManager.CreateInstance("event:/LVL1/MUSIC/chill canyon -- revisited");
        secretMusic = FMODUnity.RuntimeManager.CreateInstance("event:/LVL1/MUSIC/montsetmerveilles");
        backgroundMusic.start();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
