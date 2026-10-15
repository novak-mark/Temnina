using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public GameObject arrow;
    public Transform bulletPos;
    private Animator anim;
    private GameObject Player;
    private float timer;
    private float distance;
    private  bool canshoot=true;
    private bool faceRight;
    void Start()
    {
        anim=GetComponent<Animator>();
        Player=GameObject.FindGameObjectWithTag("Player");
    }
    void Update()
    {
        distance=Vector2.Distance(transform.position,Player.transform.position);
        /*racunamo razdaljo med igralcem in sovraznikom*/
       if(anim.GetCurrentAnimatorStateInfo(0).IsName("Skeleton_archer_hurt")){
        canshoot=false;
       }
       else {
         canshoot=true;
       }
        if(Player.transform.position.x<transform.position.x && faceRight){
            Flip();
            
        }
        if(Player.transform.position.x>transform.position.x && !faceRight){
            Flip();
        }

     if(canshoot){
        if(distance<5){
         timer+=Time.deltaTime;
            if(timer>=4.5){
            timer=0;
            anim.SetTrigger("Shoot");
            }
        }
        }
    }
   public void Shoot(){
        Instantiate(arrow,bulletPos.position,Quaternion.identity);
    }
    void Flip(){
        Vector3 scale=transform.localScale;
        scale.x*=-1;
        transform.localScale=scale;
        faceRight=!faceRight;
    }
    }
