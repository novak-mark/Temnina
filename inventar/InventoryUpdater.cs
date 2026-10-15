using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUpdater : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D othr){
        if(othr.CompareTag("Player")){
        Debug.Log("Inventory saved");
        SaveSystem.SaveInventory(GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>());
        }
    }
}
