using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemyHealth: MonoBehaviour
{
    public Animator anim;
    public int maxHealth;
    public int currentHealth;
    public  bool isDead;
    public EnemyHealthBars HealthBar;

    private Rigidbody2D rb;
    void Start()
    {
        currentHealth=maxHealth;
         HealthBar.SetHealth(currentHealth,maxHealth);
      
    }
    public void TakeDamage(int dmg){
        currentHealth-=dmg;
        HealthBar.SetHealth(currentHealth,maxHealth);
        anim.SetTrigger("Hurt");
      
    if(currentHealth<=0){
       Die();  
    }
    }
    void Die(){
        Debug.Log("He dead");
        anim.SetBool("IsDead",true);
        this.GetComponent<BoxCollider2D>().enabled=false;
        this.GetComponent<Rigidbody2D>().gravityScale=0;
        rb=this.GetComponent<Rigidbody2D>();
        rb.constraints=RigidbodyConstraints2D.FreezePositionY;
         HealthBar.slider.gameObject.SetActive(false);
        this.enabled=false;
        isDead=true;
    }
}
