using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
   
    public Transform AttackHitBox;
    public float attackRange=0.5f;
    public LayerMask enemies;
    public bool canAttack;
     private Animator anim;
     private float timer;
     private float attackCooldown;
    static public bool isAttacking=false;

    void Start(){
        canAttack=true;
        anim=GetComponent<Animator>();
        timer=0.0f;
        attackCooldown=0.8f;
        
    }
    // Update is called once per frame
    void Update()
    {
     if(GameManager.EnableInput && canAttack){
        isAttacking=false;
        if(Input.GetKeyDown(KeyCode.Mouse0)){
        if(anim.GetBool("SwordEquiped")){
          if(timer>attackCooldown){
            anim.SetTrigger("SwordAttack");
            isAttacking=true;
            timer=0;
             }
        }
        else{
            anim.SetBool("HandAttack",true);
        } 
        }
        if(Input.GetKeyDown(KeyCode.Mouse1)){
           if(anim.GetBool("SwordEquiped")){
            if(timer>attackCooldown){
                anim.SetTrigger("MSwordAttack");
                isAttacking=true;
                  timer=0;
                }
           }
           else { 
            anim.SetTrigger("KickAttack");
           }
        }
        if(Input.GetKeyDown(KeyCode.Mouse2)){
        if(anim.GetBool("SwordEquiped")){
            if(timer>attackCooldown){
                anim.SetTrigger("HSwordAttack");
                isAttacking=true;
                timer=0;
                }
           }
        }
        if(Input.GetKeyDown(KeyCode.Alpha2)){
            if(anim.GetBool("BowEquiped") && EquipItem.arrowInInventory){
                    anim.SetTrigger("BowAttack");
                     if(timer>attackCooldown){
                anim.SetTrigger("MSwordAttack");
                isAttacking=true;
                  timer=0;
                }
            }
        }
        }
           if(timer<attackCooldown+1){
                    timer+=Time.deltaTime;
                }
    }
   public void Attack(int dmg){
         
    /*preverimo če smo katerega izmed sovraznikov zadeli*/
         Collider2D[] hitEnemies=Physics2D.OverlapCircleAll(AttackHitBox.position,attackRange,enemies);
    /*loopamo čez zadete sovraznike in jim dodelimo damage*/
         foreach(Collider2D enemy in hitEnemies){
                Debug.Log("We hit"+enemy.name);
            if(enemy.GetComponent<EnemyHealth>()!=null){
            
            enemy.GetComponent<EnemyHealth>().TakeDamage(dmg);
            }
            else if(enemy.GetComponent<FlyingEnemyHealth>()!=null){
                Debug.Log("DO THIS");
            enemy.GetComponent<FlyingEnemyHealth>().TakeDamage(dmg);
            }
         }
    }

    /*zvoki*/
    public void CombatSounds(string sound){
        SoundManager.PlaySound(sound);
    }
    void OnDrawGizmosSelected(){ 
        Gizmos.DrawWireSphere(AttackHitBox.position,attackRange);
    }
}
