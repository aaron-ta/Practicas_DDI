using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour 
{
	bool isInsideZone;
	public KeyCode interactionKey = KeyCode.I;
	/// <summary>
	/// Update is called every frame, if the MonoBehaviour is enabled.
	/// </summary>
	void Update()
	{
		if(isInsideZone)
		{
			if(Input.GetKeyDown(interactionKey))
			{
				Interact();
			}
		}
	}

	public virtual void Awake()
	{
		
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

	public virtual void Interact()
	{

	}
}
