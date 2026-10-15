using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System.IO;
using UnityEngine;

public class PHealth : MonoBehaviour
{
    private int maxHealth=100;
    public int currHealth;
     public Animator anim;
    public GameOver call;
    public PHealthBar healthbar;
    private GameObject player;
    void Start()
    {
        string path= Application.persistentDataPath + "/player.data";
        currHealth=maxHealth;
        healthbar.setMaxHealth(maxHealth);
        player=GameObject.FindGameObjectWithTag("Player");
        Debug.Log(currHealth);
    }
   void Update(){
      if(anim.GetCurrentAnimatorStateInfo(0).IsName("Player_hurt")){
            GetComponent<PlayerCombat>().canAttack=false;
      }
      else {
        GetComponent<PlayerCombat>().canAttack=true;
      }
   }
   public void Heal(int amount){
     Debug.Log($"Player health {currHealth}");
     Debug.Log($"Amount: {amount}");
         currHealth+=amount;
        Debug.Log($"Player healed for {amount}");
         Debug.Log(currHealth);
         healthbar.setHealth(currHealth);
          if(currHealth>maxHealth){
            Debug.Log("Maksimalen health reached ne mores vec jesti");
            currHealth=maxHealth;
            Debug.Log(currHealth);
        }
    }
    public void TakeDamageCombat(int dmg){
        Debug.Log($"Player hit for: {dmg}");
        currHealth-=dmg;
        anim.SetTrigger("PUnarmedHurt");
       healthbar.setHealth(currHealth);
        Debug.Log($"{currHealth}");
        if(currHealth<=0){
            Die();
        }
    }
    public void TakeDamageItem(int dmg){
        currHealth-=dmg;
        healthbar.setHealth(currHealth);
        if(currHealth<=0){
            Die();
        }
    }
    private void Die(){
        Debug.Log("Player has died");
        anim.SetBool("IsDead",true);
        call.EnableGameOver();
        this.enabled=false;
    }
}
