using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipItem : MonoBehaviour
{

    private Animator anim;
    private GameObject Player;
    public GameObject arrow;
    public Transform bulletPos;
    private bool equiped;
    private Inventory inv;
    public static bool swordInInventory;
    public static bool bowInInventory;
    public static bool arrowInInventory;
    void Start(){
        Player=GameObject.FindGameObjectWithTag("Player");
        inv=Player.GetComponent<Inventory>();
        anim=Player.GetComponent<Animator>();
     
    }
    void Update(){
        DrawSword();
        Bow();
    }
private void DrawSword(){
    if(swordInInventory){
        if(!equiped && Input.GetKeyDown(KeyCode.Alpha1) && PlayerCombat.isAttacking==false){
            SoundManager.PlaySound("DrawSword");
            anim.SetBool("DrawSword",true);
            anim.SetBool("SwordEquiped",true);
            equiped=true;
        }
        else if(equiped &&  Input.GetKeyDown(KeyCode.Alpha1) && PlayerCombat.isAttacking==false) {
            SoundManager.PlaySound("SheathSword");
            anim.SetBool("DrawSword",false);
             anim.SetBool("SwordEquiped",false);
            equiped=false;
        }
    }
    }
private void Bow(){
    if(bowInInventory){
            anim.SetBool("BowEquiped",true);
        for(int i=0;i<inv.items.Length;i++){
        if(inv.isFull[i]==true){
            if(inv.items[i].GetComponentInChildren<Item>().ItemName=="Arrow"){
                arrowInInventory=true;
            }
            else {
                arrowInInventory=false;
            }
        }
            }
    }
    }
    public void Shoot(){
    Instantiate(arrow,bulletPos.position,transform.rotation);   
     for(int i=0;i<inv.items.Length;i++){
        if(inv.isFull[i]==true){
            if(inv.items[i].GetComponentInChildren<Item>().ItemName=="Arrow"){
               Destroy(inv.items[i].transform.GetChild(0).gameObject);
               inv.isFull[i]=false;
                arrowInInventory=false;
                break;
               
        }
        }
    }
    }
}
