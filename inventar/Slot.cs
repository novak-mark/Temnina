using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
    private Inventory inv;
    public int itemID;
    void Start()
    {
        inv=GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }
    void Update(){
          if(transform.childCount<=0){
            inv.isFull[itemID]=false;
    }
    }
    public void DropItem(){
        foreach(Transform child in transform){
            GameObject.Destroy(child.gameObject);
        }
  
    }
}
