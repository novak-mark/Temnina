using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton_W_behaviour : MonoBehaviour
{
    
    public float speed;
    public Transform AttackHitBox;
    public float attackRange;
    public LayerMask playerLayer;
    private Animator anim;
    private Rigidbody2D rb;

    private GameObject Player;
    private bool Chaseing;
    private bool faceRight;
    private bool canAttack;
    private AudioSource src;
   
    private float timer=0.0f;
    private float distance;
    private float attackCooldown;
    void Start()
    {
        anim=GetComponent<Animator>();
        rb=GetComponent<Rigidbody2D>();
        attackCooldown=2.0f;

    }
    void Update()
    {
        if(Chaseing){
          
            anim.SetBool("canWalk",true);
            if(canAttack==false){
            transform.position=Vector2.MoveTowards(transform.position,Player.transform.position,speed*Time.deltaTime);
            }
        if(Player.transform.position.x<transform.position.x && faceRight){
            Flip();        
        }
        if(Player.transform.position.x>transform.position.x && !faceRight){
            Flip();
        }
         distance=Vector2.Distance(transform.position,Player.transform.position);
    if(distance<=0.80){
    canAttack=true;
    anim.SetBool("canWalk",false);

    }
    else {
        canAttack=false;
         anim.SetBool("canWalk",true);
    }
        }
    if(timer>attackCooldown && canAttack){
        anim.SetTrigger("Attack");
        timer=0;
    }
    if(timer<attackCooldown+1){
        timer+=Time.deltaTime;
       
    }
    if(this.gameObject.GetComponent<EnemyHealth>().isDead==true){
        this.enabled=false;
    }
    }
    public void Attack(int dmg){

    Collider2D PlayerHit=Physics2D.OverlapCircle(AttackHitBox.position,attackRange,playerLayer);
    /*loopamo čez playarja in mu dodelimo damage*/
        if(PlayerHit){
                Debug.Log("We hit"+PlayerHit.name);
            PlayerHit.GetComponent<PHealth>().TakeDamageCombat(dmg);
           
            PlayerHit.GetComponent<Rigidbody2D>().AddForce(transform.up * 10 + (transform.right * 10)*-1);
            }
    }
    void Flip(){
        Vector3 scale=transform.localScale;
        scale.x*=-1;
        transform.localScale=scale;
        faceRight=!faceRight;
    }
    private void OnTriggerEnter2D(Collider2D trigg){
        if(trigg.gameObject.tag=="Player"){
            Chaseing=true;
            Player=trigg.gameObject;
            
        }
    }
      private void OnDrawGizmos(){
         Gizmos.DrawWireSphere(AttackHitBox.position,attackRange);
    }
}
