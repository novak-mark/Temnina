using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    private float Ypos;
    private float speed=4;    
    private bool Ladder;
    private bool isClimbing;
  
 
    void Update(){
        /*Dobimo Playerov y pozicijo*/
        Ypos=Input.GetAxis("Vertical");
        /*preverimo ce je vecja od 0, kar pomeni da pleza*/
        if(Ladder && Mathf.Abs(Ypos)>0){
            isClimbing=true;
        }
    }
    private void FixedUpdate(){
        if(isClimbing){
        rb.gravityScale=0;
        rb.velocity=new Vector2(rb.velocity.x,Ypos*speed);
        }
        else {
            rb.gravityScale=1;
        }
    }

    void OnTriggerEnter2D(Collider2D colls){
        if(colls.CompareTag("Ladder")){
            Ladder=true;
        }
    }
    void OnTriggerExit2D(Collider2D colls){
         if(colls.CompareTag("Ladder")){
            Ladder=false;
            isClimbing=false;
        }
    }
}
