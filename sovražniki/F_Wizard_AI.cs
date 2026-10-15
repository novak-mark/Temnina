using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class F_Wizard_AI : MonoBehaviour
{
    public GameObject fireball;
    public Transform bulletPos;
    public Transform AttackHitBox;
    public float attackRange;
    public LayerMask playerLayer;
    public float speed;
    private Animator anim;
    private float bulletSpeed;
    private GameObject player;
    private Rigidbody2D rb;
    private float timer;
    private float timer2;
    private  bool canShoot=false;
    private bool canAttack=false;
    private bool faceRight;
    private float distance;
    private float attackCooldown;
    private float shootCooldown;
    void Start()
    {
        anim=GetComponent<Animator>();
        rb=GetComponent<Rigidbody2D>();
        player=GameObject.FindGameObjectWithTag("Player");
        bulletSpeed=3.0f;
        attackCooldown=2.0f;
        shootCooldown=3.0f;
    }

    
    void Update()
    {
          if(player.transform.position.x<transform.position.x && faceRight){
            Flip();        
        }
        if(player.transform.position.x>transform.position.x && !faceRight){
            Flip();
        }
         distance=Vector2.Distance(transform.position,player.transform.position);
    if(distance<=5){
        canShoot=true;
        anim.SetBool("canWalk",false);
    }
    if(distance<=2){
        Chase();
        canShoot=false;
    }
    if(timer>shootCooldown && canShoot){
        anim.SetTrigger("Shoot");
        timer=0;
    }
    if(timer<attackCooldown+1){
        timer+=Time.deltaTime;  
    }
    
    if(this.gameObject.GetComponent<EnemyHealth>().isDead==true){
        this.enabled=false;
    }
    }
    public void Shoot(){
      GameObject fireballshoot= (GameObject) Instantiate(fireball,bulletPos.position,Quaternion.identity);
      fireballshoot.GetComponent<Rigidbody2D>().velocity=(player.transform.position-transform.position).normalized*bulletSpeed;
    }
    public void Chase(){
         anim.SetBool("canWalk",true);
        if(canAttack==false){
            transform.position=Vector2.MoveTowards(transform.position,player.transform.position,speed*Time.deltaTime);
            }
        if(distance<=1){
            canAttack=true;
            anim.SetBool("canWalk",false);
        }
        else {
            canAttack=false;
            anim.SetBool("canWalk",true);
        }
    if(timer2>attackCooldown && canAttack){
        anim.SetTrigger("Attack");
        timer2=0;
    }
    if(timer2<attackCooldown+1){
     timer2+=Time.deltaTime;
       
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

      private void OnDrawGizmos(){
         Gizmos.DrawWireSphere(AttackHitBox.position,attackRange);
    }
}
