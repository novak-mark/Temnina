using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;



[System.Serializable]
public class PlayerData {
   
   public int health;
   public int level;
   public float[] poss;

   public PlayerData (PHealth Phealth)
   {
        health=Phealth.currHealth;
        level=SceneManager.GetActiveScene().buildIndex;
        poss=new float[3];
   } 
}
[System.Serializable]
public class InventoryData {
   
   
   public string[] name;
   public string[] desc;
   public int numbofitems=0;
   

   public InventoryData (Inventory inv)
   {
         name=new string[12];
         desc=new string[12];
        for(int i=0;i<inv.items.Length;i++){
         Debug.Log(i);
           if(inv.isFull[i]==false){
               break;
         }
         name[i]=inv.items[i].GetComponentInChildren<Item>().ItemName;
         desc[i]=inv.items[i].GetComponentInChildren<Item>().descriptionText;
         numbofitems++;
        }
       
   } 
}
