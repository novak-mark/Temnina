using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealItem : MonoBehaviour
{
    private PHealth script;
    private void Start(){
        script=GameObject.FindGameObjectWithTag("Player").GetComponent<PHealth>();
    }
    public void Heal(int amount)
    {
        script.Heal(amount);
        Destroy(gameObject);
    }
}
