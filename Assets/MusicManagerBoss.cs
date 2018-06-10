using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManagerBoss : MonoBehaviour {

    public FMOD.Studio.EventInstance firstMusic;
    public FMOD.Studio.EventInstance bossMusic;

	// Use this for initialization
	void Start () {
        firstMusic = FMODUnity.RuntimeManager.CreateInstance("event:/LVL1/MUSIC/chill canyon -- revisited");
        bossMusic = FMODUnity.RuntimeManager.CreateInstance("event:/BOSS/MUSIC/FINAL_FIGHT");
        firstMusic.start();
    
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
