using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[ExecuteInEditMode]
public class Opacity : MonoBehaviour {


    [Range(0, 100)] public float opacity = 100;
    SpriteRenderer sprite;

	// Use this for initialization
	void Start () {
        sprite = gameObject.GetComponent<SpriteRenderer>();
        
    }
	
	// Update is called once per frame
	void Update () {


        sprite.color = new Color(1f, 1f, 1f, opacity / 100);



    }
}
