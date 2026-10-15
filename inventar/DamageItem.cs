using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class DamageItem : MonoBehaviour
{
   private PHealth script;
    private void Start(){
        script=GameObject.FindGameObjectWithTag("Player").GetComponent<PHealth>();
    }
    public void Damage(int amount)
    {
        script.TakeDamageItem(amount);
        Destroy(gameObject);
    }
}
