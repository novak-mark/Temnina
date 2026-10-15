using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public GameObject itemButton;
    private Inventory inv;
    void Start()
    {
          inv=GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }   
     void OnTriggerEnter2D(Collider2D othr){
        if(othr.CompareTag("Player")){
            for(int i=0;i<inv.items.Length;i++){
            if(inv.isFull[i]==false){
                inv.isFull[i]=true;
            Instantiate(itemButton,inv.items[i].transform,false);
            SoundManager.PlaySound("ItemPickup");
            Destroy(gameObject);
                break;
            }
            }
        }
    }
}
