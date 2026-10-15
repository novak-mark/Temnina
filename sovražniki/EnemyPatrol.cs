using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemyPatrol : MonoBehaviour
{
    
    public GameObject PointA;
    public GameObject PointB;
    public float speed;
    public Transform AttackHitBox;
    public float attackRange=0.10f;
    public LayerMask playerLayer;
    private Animator anim;
    private Rigidbody2D rb;
    private Transform currpoint;

    private GameObject Player;
    private bool Chaseing;
    private bool faceRight;
    private bool canAttack;
    private float timer;
    private float Attacktimer;
    private float distance;
   
 
    void Start()
    {
        rb=GetComponent<Rigidbody2D>();
        anim=GetComponent<Animator>();
        currpoint=PointB.transform;
        anim.SetBool("canWalk",true);
    }

   
    void Update()
    {
    if(Chaseing==false){
        if(currpoint==PointB.transform){
          
            transform.position=Vector2.MoveTowards(transform.position,currpoint.transform.position,speed*Time.deltaTime);
        }
        else {
          transform.position=Vector2.MoveTowards(transform.position,currpoint.transform.position,speed*Time.deltaTime);
          
        }
        if(Vector2.Distance(transform.position,currpoint.position)<0.5f && currpoint==PointB.transform){   
            
            timer+=Time.deltaTime;
            anim.SetBool("canWalk",false);
        if(timer>2){
            timer=0;
             Flip();
              anim.SetBool("canWalk",true);
            currpoint=PointA.transform;
            }
        }
         if(Vector2.Distance(transform.position,currpoint.position)<0.5f && currpoint==PointA.transform){
            timer+=Time.deltaTime;
            anim.SetBool("canWalk",false);
        if(timer>2){
            timer=0;
            Flip();
            anim.SetBool("canWalk",true);
            currpoint=PointB.transform;
        }
        }
      }
      if(Chaseing==true){
        Chase();
      }
      if(this.gameObject.GetComponent<EnemyHealth>().isDead==true){
        this.enabled=false;
      }
    }
     void Flip(){
        Vector3 scale=transform.localScale;
        scale.x*=-1;
        transform.localScale=scale;
        faceRight=!faceRight;
    }
    /*testiranje*/
     void OnTriggerEnter2D(Collider2D trigg){
        if(trigg.gameObject.tag=="Player"){
             Debug.Log("Chase");
            Player=trigg.gameObject;
             Chaseing=true;
        }
    }
    void Chase(){
    if(canAttack==false){
         transform.position=Vector2.MoveTowards(transform.position,Player.transform.position,speed*Time.deltaTime);
    }
    if(Player.transform.position.x<transform.position.x && !faceRight){
            Flip();        
        }
        if(Player.transform.position.x>transform.position.x && faceRight){
            Flip();
        }
        distance=Vector2.Distance(transform.position,Player.transform.position);
        if(distance<1.5){
            Attacktimer+=Time.deltaTime;
        if(Attacktimer>4){
            Attacktimer=0;
            canAttack=true;
            anim.SetBool("Attack",true);
            }
        }
        else {
            canAttack=false;
            anim.SetBool("Attack",false);
        }
        Debug.Log($"Attack IS {canAttack}");
    }
       public void  Attack(int dmg){
             Collider2D PlayerHit=Physics2D.OverlapCircle(AttackHitBox.position,attackRange,playerLayer);
    /*loopamo čez playarja in mu dodelimo damage*/
        if(PlayerHit){
                Debug.Log("We hit"+PlayerHit.name);
            PlayerHit.GetComponent<PHealth>().TakeDamageCombat(dmg);
           
                PlayerHit.GetComponent<Rigidbody2D>().AddForce(transform.up * 10 + (transform.right * 10)*-1);
            }
    }
    private void OnDrawGizmos(){
        Gizmos.DrawWireSphere(PointA.transform.position,0.5f);
         Gizmos.DrawWireSphere(PointB.transform.position,0.5f);
          Gizmos.DrawLine(PointA.transform.position,PointB.transform.position);
         Gizmos.DrawWireSphere(AttackHitBox.position,attackRange);
    }
}
