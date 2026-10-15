using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using TMPro;
 
[System.Serializable]
public class Inventory  : MonoBehaviour
{

    public GameObject[] items;
    public bool[] isFull;
    public GameObject InvWindow;
    public GameObject DescWindow;
    public Text Name;
    public Text Desc;
    
    private float descposX;
    private float descposY;
    public bool isOpen;
   private void Start(){
        if(MainMenu.isLoaded==true){          
          Debug.Log("Call this");
          LoadInventory();
        }
        if(NextLevel.isloaded==true){
          LoadInventory();
        }
   }
      private void Update(){
        if(GameManager.EnableInput){
        if(Input.GetKeyDown(KeyCode.I)){
             
            Open_Close_Inventory();
            SoundManager.PlaySound("OpenInventory");
        }
        }
   }
   void Open_Close_Inventory(){
    isOpen=!isOpen;
    InvWindow.SetActive(isOpen);
   }
  
   public void ShowDesc(int idItem){
    Debug.Log(idItem);
    Name.text=items[idItem].GetComponentInChildren<Item>().ItemName;
    Desc.text=items[idItem].GetComponentInChildren<Item>().descriptionText;
    DescWindow.SetActive(true);
    Name.enabled=true;
    Desc.enabled=true;
   }

   public void HideDesc(){
    DescWindow.SetActive(false);
     Name.enabled=false;
     Desc.enabled=false;
   }
  public void LoadInventory(){
    Inventory inv;
    inv=FindObjectOfType<Inventory>();
    InventoryData data=SaveSystem.LoadInventory();
      for(int i=0;i<inv.items.Length;i++){
        Debug.Log($"{data.name[i]}Button");
        Debug.Log($"index: {i}");
        Instantiate(Resources.Load($"ItemButtons/{data.name[i]}Button"),inv.items[i].transform,false);
        inv.isFull[i]=true;
        inv.items[i].GetComponentInChildren<Item>().ItemName=data.name[i];
        inv.items[i].GetComponentInChildren<Item>().descriptionText=data.desc[i];
      }
  }
}
