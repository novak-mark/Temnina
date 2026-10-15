using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class Item : MonoBehaviour
{    
    public enum InteractionType { NONE, PickUp}
    public enum ItemType { Key, Consumables, Use}
    public ItemType type;  
    public string descriptionText;
    public string ItemName;
    private Inventory inv;
   private void Start(){
        inv=GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
   }
}
