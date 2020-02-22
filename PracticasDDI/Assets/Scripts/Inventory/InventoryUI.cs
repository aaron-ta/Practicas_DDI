using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour 
{
	public GameObject inventoryPanel;
	private Inventory inventory;

	/// <summary>
	/// Start is called on the frame when a script is enabled just before
	/// any of the Update methods is called the first time.
	/// </summary>
	void Start()
	{
		Cursor.visible = true;
    	Cursor.lockState = CursorLockMode.None;
		inventory = FindObjectOfType<Inventory>();
		if (inventory == null)
		{
			Debug.LogWarning("No se encontró el Inventario");
			return;
		} 
		inventoryPanel.SetActive(false);
		inventory.onItemChange += UpdateUI;
	}

	void OnGUI()
	{
    		//Cursor.visible = true;
    		//Cursor.lockState = CursorLockMode.None;

	}

	/// <summary>
	/// Update is called every frame, if the MonoBehaviour is enabled.
	/// </summary>
	void Update()
	{
		if(Input.GetKeyDown(KeyCode.Q))
		{
			//Time.timeScale = 0f;
			inventoryPanel.SetActive(!inventoryPanel.activeSelf);
    		//if(Cursor.visible)
			Cursor.lockState = CursorLockMode.None;
			//else
			//	Cursor.lockState = CursorLockMode.Locked;
    		
			UpdateUI();
		}
	}

	void UpdateUI()
	{
		Slot[] slots = GetComponentsInChildren<Slot>();
		for (int i = 0; i < slots.Length; i++)
		{
			if(i < inventory.items.Count)
			{
				slots[i].AddItem(inventory.items[i]);
			}
			else
			{
				slots[i].ClearSlot();
			}
		}
	}
}
