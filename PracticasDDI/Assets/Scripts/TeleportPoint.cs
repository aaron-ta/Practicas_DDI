using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportPoint : Interactable
{
    // Start is called before the first frame update
    public Transform playerObject;

    public override void Interact()
    {
        //teleport player
        if(playerObject != null)
        {
            playerObject.position = transform.position + new Vector3(0, 1.6f, 0);
        }
    }
}
