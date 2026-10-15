using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemyAI : MonoBehaviour
{
    private GameObject Player;
    public float moveSpeed;
    public float PlayerRange;

    public Animator anim;


    /*podatki za napadanje*/
    public Transform AttackHitBox;
    public float attackRange=0.10f;



    public LayerMask playerLayer;
    private bool PinRange;
    private bool isAttacking;
    private bool faceRight;
    private float timer;
    private float distance;
    void Start()
    {
        Player=GameObject.FindGameObjectWithTag("Player");
        isAttacking=false;
    }

   
    void Update()
    {
        PinRange=Physics2D.OverlapCircle(transform.position,PlayerRange,playerLayer);
        /*premaknemo se od neke točke do neke druge točke*/
    if(PinRange && GetComponent<FlyingEnemyHealth>().isDead==false){
        if(isAttacking==false){
            Debug.Log("Do this");
       transform.position=Vector3.MoveTowards(transform.position,Player.transform.position,moveSpeed*Time.deltaTime);
        }
        if(Player.transform.position.x<transform.position.x && faceRight){
            Flip();
            
        }
        if(Player.transform.position.x>transform.position.x && !faceRight){
            Flip();
        }
        }
        distance=Vector2.Distance(transform.position,Player.transform.position);
       
       if(this.GetComponent<FlyingEnemyHealth>().isDead==false){
        if(distance<0.5){
            timer+=Time.deltaTime;
            if(timer>2){
            timer=0;
            isAttacking=true;
            anim.SetTrigger("Attack");
            }
        }
        else {
            isAttacking=false;
        }
       }
      
    }
    void Flip(){
        Vector3 scale=transform.localScale;
        scale.x*=-1;
        transform.localScale=scale;
        faceRight=!faceRight;
    }
    public void  Attack(){
        
             
             Collider2D PlayerHit=Physics2D.OverlapCircle(AttackHitBox.position,attackRange,playerLayer);
    /*loopamo čez playarja in mu dodelimo damage*/
        if(PlayerHit){
                Debug.Log("We hit"+PlayerHit.name);
            PlayerHit.GetComponent<PHealth>().TakeDamageCombat(5);
           
                PlayerHit.GetComponent<Rigidbody2D>().AddForce(transform.up * 10 + (transform.right * 10)*-1);
            }
    }
    
    /* ustvarimo območje,ki bo aktiviral enemija ko player vstopi vanga*/
   void OnDrawGizmosSelected(){

        Gizmos.DrawSphere(transform.position,PlayerRange);

        Gizmos.DrawWireSphere(AttackHitBox.position,attackRange);
    }
   
}
