using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorInteract : MonoBehaviour
{
   public bool isOpen;
   public bool FindKey;
    public Animator Anim;
     public GameObject Player;
     private Inventory inv;
     public NextLevel nxlvl;
     private int timespressed;
    void Start(){
        timespressed=0;
        inv=Player.GetComponent<Inventory>();
    }
    private void Update(){
        if(Input.GetKeyDown(KeyCode.E) && isOpen && timespressed>1){
            Debug.Log("DO THIS");
            nxlvl.LoadGame(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
    public void OpenDoor(){
    if(!isOpen){
     for(int i=0;i<inv.items.Length;i++){
        if(inv.isFull[i]==true){
            if(inv.items[i].GetComponentInChildren<Item>().ItemName=="Key"){
                FindKey=true;
                 Debug.Log("Odpru si vrata");
                 Destroy(inv.items[i].gameObject);
                 isOpen=true;
                 Anim.SetBool("Open",isOpen);
                 break;
            }
           
       }
    if(FindKey==false){
        Debug.Log("Nimas kluca");
    }
    }
    }
     timespressed+=1;
    }
}

    
