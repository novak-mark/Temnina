using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Sword : MonoBehaviour
{
     private Animator anim;
     private void Start(){
          anim=GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
     }
     public void EquipSword(){
        anim.SetBool("SwordEquiped",true);
        EquipItem.swordInInventory=true;
        Destroy(gameObject);
    }
}
