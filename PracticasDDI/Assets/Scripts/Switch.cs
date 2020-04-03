using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Switch : MonoBehaviour 
{
	SerialComm serialComm;

	private void Awake()
    {
        serialComm = FindObjectOfType<SerialComm>();
    }
	void OnTriggerEnter(Collider other)
	{
		if(!other.CompareTag("Player"))
			return;
		// Debug.Log("Entraste en la esfera!");
		// rend.material.color = newColor;
		serialComm.Write("i");
	}

	/// <summary>
	/// OnTriggerExit is called when the Collider other has stopped touching the trigger.
	/// </summary>
	/// <param name="other">The other Collider involved in this collision.</param>
	void OnTriggerExit(Collider other)
	{
		serialComm.Write("u");
	}

}
