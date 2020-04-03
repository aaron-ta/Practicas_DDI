using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereBall : Interactable 
{
	public float kickForce = 30f;
	public Vector3 kickDirection;
    public Transform player;
    AudioSource audioData;
	Rigidbody rb;

	/// <summary>
	/// Awake is called when the script instance is being loaded.
	/// </summary>
	public override void Awake()
	{
		base.Awake();
		rb = GetComponent<Rigidbody>();
        this.player = GameObject.FindWithTag("Player").transform;
        audioData = GetComponent<AudioSource>();
	}
	public override void Interact()
	{
        Vector3 direction = this.transform.position - player.position;
		Debug.Log("SphereBall");
        //audioData.Play();
        rb.AddForce(direction * kickForce, ForceMode.Force);
		//rb.AddForce(kickDirection * kickForce, ForceMode.Force);
        //rb.AddRelativeForce(0f,0f,thrust,ForceMode.Acceleration);
	}
}