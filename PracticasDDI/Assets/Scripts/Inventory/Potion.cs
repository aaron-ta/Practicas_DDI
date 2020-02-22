using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Nuevo Item", menuName = "Inventario/Item/Potion")]
public class Potion : Item
{
    public int health = 5;
    public int magic = 10;
    public override void Use()
    {
        base.Use();
        Debug.Log("Subiendo vida: " + health + ", magia: " + magic);
    }
}
