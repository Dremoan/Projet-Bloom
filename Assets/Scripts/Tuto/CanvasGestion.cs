using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasGestion : MonoBehaviour {

	public bool activeFirstImage = false;
	public bool activeSecondImage = false;
	private bool hasAlreadyPlayed;

	// Lancer la fleur
	public GameObject pressLeftClick;
	public GameObject leftClick;

	// Retirer le rocher
	public GameObject holdRightClick;
	public GameObject rightClick;

	// Appuyer sur les interrupteurs de la grotte
	public GameObject instructionsPilar;
	public GameObject interrupteurSprite;
	public GameObject colliderAreaTalk1;

	//Pousser le rocher sur le mécanisme
	public GameObject keyRockSprite;
	public GameObject instructionsPushRock;
	public GameObject rockSlotSprite;


	//Jump sur le pilier
	public GameObject dashInstruction;
	public GameObject SpaceSprite;
	public GameObject colliderAreaTalk2;

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

	void InstructionsPilarActive() // Instruction pour appuyer sur les boutons.
	{
		FindObjectOfType<PlayerBehavior> ().EnableMovements ();
		StartCoroutine (DelayAppear ());
	}

	public void InstructionsPilarInactive() // Désactiver le canvas qui explique qu'il faut appuyer sur les boutons, désactive le collider qui déclenchait le dialogue où le personnage dit qu'il ne peut pas traverser le trou.
	{
		instructionsPilar.SetActive (false);
		interrupteurSprite.SetActive (false);
		colliderAreaTalk1.SetActive (false);
	}

	public void TalkAreaJumpActive()
	{
		colliderAreaTalk2.SetActive (true);
	}
		

	public void InstructionJumpActive()
	{
		FindObjectOfType<PlayerBehavior> ().EnableMovements ();
		StartCoroutine (DelayRemove ());
	}


	public void PushRockHelp()
	{
		keyRockSprite.SetActive (true);
		instructionsPushRock.SetActive (true);
		rockSlotSprite.SetActive (true);
	}
	public void PushRockHelpInactive()
	{
		keyRockSprite.SetActive (false);
		instructionsPushRock.SetActive (false);
		rockSlotSprite.SetActive (false);
	}

	IEnumerator DelayAppear() // Faire apparaître le canvas avec un peu de retard
	{
		yield return new WaitForSeconds (1f);
		instructionsPilar.SetActive (true);
		interrupteurSprite.SetActive (true);
	}

	IEnumerator DelayRemove() // Faire disparaître l'instruction quelques secondes après
	{
		if (!hasAlreadyPlayed) 
		{
			hasAlreadyPlayed = true;
			colliderAreaTalk2.SetActive (false);
			dashInstruction.SetActive (true);
			SpaceSprite.SetActive (true);
			yield return new WaitForSeconds (3f);
			dashInstruction.SetActive (false);
			SpaceSprite.SetActive (false);
		}

	}
}
