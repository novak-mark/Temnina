using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestInteract : MonoBehaviour
{
    public bool isOpen;
    public Animator Anim;
    public GameObject Item;
    public void OpenChest(){
        if(!isOpen){
            isOpen=true;
            
            Item.SetActive(true);
            Item.transform.position=new Vector2(transform.position.x,transform.position.y+0.5f);

            Anim.SetBool("Open",isOpen);
        }
    }
}
