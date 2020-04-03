using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBox : Interactable
{
    // Start is called before the first frame update
    public GameObject InventoryCanvas;
    private bool active = false;
    public override void Interact()
    {
        //teleport player
        if(InventoryCanvas != null)
        {
            active = !active;
            //InventoryCanvas.SetActive(active);
        }
    }
}
