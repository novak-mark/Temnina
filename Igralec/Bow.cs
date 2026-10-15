using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Bow : MonoBehaviour
{
    private Animator anim;
       void Start()
    {
        anim=GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
    }
    public void EquipBow(){
        anim.SetBool("BowEquiped",true);
        EquipItem.bowInInventory=true;
        Destroy(gameObject);
    }

}
