using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasGestionMenu : MonoBehaviour {

	public GameObject previousCanvas;
	public GameObject nextCanvas;


	public void SwitchCanvas()
	{
		previousCanvas.SetActive (false);
		nextCanvas.SetActive (true);
	}
}
