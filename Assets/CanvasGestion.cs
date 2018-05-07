using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasGestion : MonoBehaviour {

	public bool activeFirstImage = false;
	public bool activeSecondImage = false;

	public GameObject pressLeftClick;
	public GameObject leftClick;

	public GameObject holdRightClick;
	public GameObject rightClick;

	void Update ()
	{
		if(activeFirstImage)
		{
			pressLeftClick.SetActive (true);
			leftClick.SetActive (true);
		}
		if(!activeFirstImage)
		{
			pressLeftClick.SetActive (false);
			leftClick.SetActive (false);
		}

		if(activeSecondImage)
		{
			holdRightClick.SetActive (true);
			rightClick.SetActive (true);
		}
		if(!activeSecondImage)
		{
			holdRightClick.SetActive (false);
			rightClick.SetActive (false);
		}
	}
		
}
