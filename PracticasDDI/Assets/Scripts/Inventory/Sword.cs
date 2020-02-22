using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Nuevo Item", menuName = "Inventario/Item/Sword")]
public class Sword : Item
{
    //public GameObject swordMesh;
    
    public int strenght = 10;
    //public GameObject swordMesh;
    GameObject swordMesh;
    GameObject parent;
    public override void Use()
    {
        base.Use();
        Debug.Log("Equipando arma");
        swordMesh.SetActive(true);
    }

    public override void OnEnable(){
        if(GameObject.FindWithTag("Player") != null)
            Debug.Log("Encontrada");
        parent =  GameObject.FindWithTag("Player");

          foreach (Transform child in parent.transform)
          {
              if (child.tag == "Sword")
                swordMesh = (child.gameObject);
          }
        
    }
}
