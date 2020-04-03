using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Interactable : MonoBehaviour 
{
	bool isInsideZone;
	bool isGazedAt;
	float gazedTimer = 0f;
	public float interactionTime = 2f;
	// public KeyCode interactionKey = KeyCode.I;
	/// <summary>
	/// Update is called every frame, if the MonoBehaviour is enabled.
	/// </summary>
	void Update()
	{
		if(isInsideZone)
		{
			// if(Input.GetKeyDown(interactionKey))
			if(CrossPlatformInputManager.GetButtonDown("Interact"))
			{
				Interact();
			}
		}

		if(isGazedAt){
			gazedTimer += Time.deltaTime;
			Debug.Log(gazedTimer);
			if(gazedTimer >= interactionTime){
				Interact();
				SetGazedAt(false);
			}
		}
	}

	/// <summary>
	/// OnTriggerEnter is called when the Collider other enters the trigger.
	/// </summary>
	/// <param name="other">The other Collider involved in this collision.</param>
	void OnTriggerEnter(Collider other)
	{
		if(!other.CompareTag("Player"))
			return;
		// Debug.Log("Entraste en la esfera!");
		// rend.material.color = newColor;
		isInsideZone = true;
	}

	/// <summary>
	/// OnTriggerExit is called when the Collider other has stopped touching the trigger.
	/// </summary>
	/// <param name="other">The other Collider involved in this collision.</param>
	void OnTriggerExit(Collider other)
	{
		isInsideZone = false;
	}

	public void SetGazedAt(bool gazedAt)
	{
		//añadir cambio de material
		//iniciar timer si gazedat es true, reset timer si es false
		isGazedAt = gazedAt;
		if(!gazedAt){
			//reset timer
			gazedTimer = 0f;
		}
	}

	public virtual void Interact()
	{

	}

	public virtual void Awake()
	{

	}
}
